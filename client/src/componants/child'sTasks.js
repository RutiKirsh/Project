import React, { useState, useEffect } from 'react';
import { useSelector } from "react-redux";

const formatTime = (dateString) => {
    const date = new Date(dateString);
    const hours = date.getHours();
    const minutes = date.getMinutes().toString().padStart(2, '0');
    return `${hours}:${minutes}`;
};

export default function ChildTasks() {
    const [selectedItem, setSelectedItem] = useState(null);
    const [tasks, setTasks] = useState([]);
    const user = useSelector((state) => state.userReducer);

    const fetchData = async (url, options) => {
        try {
            const response = await fetch(url, options);
            if (!response.ok) throw new Error("Network response was not ok");
            return await response.json();
        } catch (error) {
            console.error(error);
        }
    };

    const Modal = ({ id, title, body, footer }) => (
        <div className="modal fade" id={id} tabIndex="-1" aria-labelledby={`${id}Label`} aria-hidden="true">
            <div className="modal-dialog">
                <div className="modal-content">
                    <div className="modal-header">
                        <h1 className="modal-title fs-5" id={`${id}Label`}>{title}</h1>
                        <button onClick={() => { setSelectedItem(null); }} type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div className="modal-body">{body}</div>
                    {footer && <div className="modal-footer">{footer}</div>}
                </div>
            </div>
        </div>
    );

    const loadTasks = async () => {
        if (user && Object.keys(user).length > 0) {
            const data = await fetchData(`https://localhost:7190/api/volunteeringtasks/${user.email}/${user.password}`);
            if (data) {
                setTasks([...data]);
                console.log(tasks);
            }
        }
    };  

    const deleteTask = async (id) => {
        try {
            const response = await fetch(`https://localhost:7190/api/volunteeringtasks/${id}/${user.email}/${user.password}`, { method: 'DELETE' });
            if(!response  || !response.ok){
                console.error(`Error deleting task ${id}`);
                return;
            }
            const data = response.json();
            if (data[id] != id){
                console.error(`Error deleting task ${id}: ${data[id]} is not the correct id.`);
                return;
            }
            var temp = tasks.filter((item) => item.id !== id);
            setTasks(temp);
            setSelectedItem(null);
        }
        catch (e) {
            console.error(e);
        }
    }

    useEffect(() => {
        const interval = setInterval(() => {
            if (user && Object.keys(user).length > 0) {
                loadTasks();
                clearInterval(interval);
            }
        }, 1000);
        return () => clearInterval(interval);
    }, [user]);

    return (
        <div>
            {tasks.map((item, index) => (
                <div key={index}>
                    {new Date(item.date).toLocaleDateString()} {new Date(item.date).getHours()}     {item.end} {item.place}
                    <br />
                    <button type="button" onClick={() => { setSelectedItem(item); console.log(tasks) }} className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" style={{ backgroundColor: "#FB4A45", border: "#FB4A45" }}>
                        לפרטים נוספים
                    </button>
                </div>
            ))}

            {selectedItem && (
                <Modal
                    id="exampleModal"
                    title=""
                    body={
                        <p>ביום {new Date(selectedItem.date).toLocaleDateString()} בשעה {formatTime(selectedItem.date)} יבואו לשמור עלי {selectedItem.end && (`עד השעה ${formatTime(selectedItem.end)}`)} {selectedItem.place}.
                            {selectedItem.volunteer && (
                                <p>למתנדבת שתבוא להיות איתי קוראים {selectedItem.volunteer.firstName} {selectedItem.volunteer.lastName} ומספר הטלפון שלה הוא {selectedItem.volunteer.phone}.</p>
                            )}
                            {!selectedItem.volunteer && (
                                <p>עדיין לא יודעים מי המתנדבת שתבוא להיות איתי.</p>
                            )}
                        </p>
                    }
                    footer={
                        !user.volunteer && (
                            <button onClick={() => {
                                deleteTask(selectedItem.id);
                            }} type="button" className="btn btn-secondary" data-bs-dismiss="modal">מתאים לי</button>
                        )
                    }
                />
            )}

            {!selectedItem && (
                <Modal id="exampleModal" title="" body="לא הצלחנו לטעון את הנתונים שלכם" />
            )}
        </div>
    );
}
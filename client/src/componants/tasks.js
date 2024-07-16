import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { addManyTasks } from '../redux/actions/addManyTask';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import { updateTask } from '../redux/actions/updateTask';
import {deleteTask } from '../redux/actions/deleteTask';

const formatTime = (dateString) => {
    const date = new Date(dateString);
    const hours = date.getHours();
    const minutes = date.getMinutes();
    return `${hours}:${minutes < 10 ? '0' + minutes : minutes}`;
};

export default function Tasks() {
    const [selectedItem, setSelectedItem] = useState(null);
    const tasks = useSelector((state) => state.taskReducer);
    const user = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();

    async function getMoreInfo(taskId) {
        try {
            const response = await fetch(`https://localhost:7190/api/volunteeringtasks/${taskId}/${user.email}/${user.password}`);
            if (response.ok) {
                const data = await response.json();
                dispatch(updateTask(data));
                console.log(tasks);
                setSelectedItem(data);
                console.log()
            } else {
                throw new Error("Network response was not ok");
            }
        } catch (error) {
            alert("הייתה בעיה בטעינת פרטי המשימה.");
        }
    }

    async function doTask(taskId) {
        try {
            const response = await fetch(`https://localhost:7190/api/volunteeringtasks/do/${taskId}/${user.email}/${user.password}`, {
                method: "Put"
            });
            if (response.ok) {
                const data = await response.json();
                console.log(data);
                dispatch(deleteTask(data));
                console.log(tasks);
                // show data
            } else {
                throw new Error("Network response was not ok");
            }
        } catch (error) {
            alert("לא הצלחנו לעדכן את ההתנדבות שלך");
        }
    }

    useEffect(() => {
        async function loadTasks() {
            try {
                const response = await fetch('https://localhost:7190/api/volunteeringtasks/');
                if (response.ok) {
                    const data = await response.json();
                    dispatch(addManyTasks(data));
                } else {
                    throw new Error("Network response was not ok");
                }
            } catch (error) {

            }
        }

        loadTasks();
    }, [dispatch]);

    return (
        <div>
            {tasks.map((item, index) => (
                <>
                    <div key={index}>
                        {new Date(item.date).toLocaleDateString()} {new Date(item.date).getHours()} {item.end} {item.place} {item.city}
                    </div>
                    <button onClick={() => getMoreInfo(item.id)} type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                        לפרטים נוספים
                    </button>
                </>
            ))}

            {selectedItem && (
                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h1 className="modal-title fs-5" id="exampleModalLabel"></h1>
                                <button onClick={() => setSelectedItem(null)} type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                <img alt="תמונת הילד" src={`${process.env.PUBLIC_URL}/Uploads/${selectedItem.image}`} width='100%w'></img>
                                <p>קוראים לי {selectedItem.childName} וההורים שלי מאד ישמחו אם תוכלי לבוא לקחת אותי ב{new Date(selectedItem.date).toLocaleDateString()} בשעה {formatTime(selectedItem.date)} ולשמור עלי {selectedItem.end && (`עד השעה ${formatTime(selectedItem.end)}`)} {selectedItem.place}.{'\n'} {selectedItem.comments && (`להורים שלי היה חשוב הפעם שתדעי: ${selectedItem.comments}`)}
                                    {'\n'} {selectedItem.childComments && (`ותמיד חשוב להורים לשלי שתדעי: ${selectedItem.childComments}`)}
                                </p>
                            </div>
                            <div className="modal-footer">
                                <button onClick={() => doTask(selectedItem.id)} type="button" className="btn btn-secondary" data-bs-dismiss="modal">מתאים לי</button>
                            </div>
                        </div>
                    </div>
                </div>
            )}

            {(!selectedItem) && (
                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h1 className="modal-title fs-5" id="exampleModalLabel"></h1>
                                <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body">
                                לא הצלחנו לטעון את הנתונים שלכם
                            </div>
                        </div>
                    </div>
                </div>
            )}
        </div>
    );
}

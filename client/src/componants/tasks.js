import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { addManyTasks } from '../redux/actions/addManyTask';
import { updateTask } from '../redux/actions/updateTask';
import { deleteTask } from '../redux/actions/deleteTask';
import { setMyTask } from '../redux/actions/setMyTask';
// import 'bootstrap/dist/css/bootstrap.min.css';
// import 'bootstrap/dist/js/bootstrap.bundle.min';

const formatTime = (dateString) => {
    const date = new Date(dateString);
    const hours = date.getHours();
    const minutes = date.getMinutes().toString().padStart(2, '0');
    return `${hours}:${minutes}`;
};

export default function Tasks() {
    const [selectedItem, setSelectedItem] = useState(null);
    const tasks = useSelector((state) => state.taskReducer);
    const user = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();

    const fetchData = async (url, options) => {
        try {
            const response = await fetch(url, options);
            if (!response.ok) throw new Error("Network response was not ok");
            return await response.json();
        } catch (error) {
            console.error(error);
        }
    };

    const loadTasks = async () => {
        const data = await fetchData('https://localhost:7190/api/volunteeringtasks/');
        if (data) dispatch(addManyTasks(data));
    };

    const getMoreInfo = async (taskId) => {
        const data = await fetchData(`https://localhost:7190/api/volunteeringtasks/${taskId}/${user.email}/${user.password}`);
        if (data) {
            dispatch(updateTask(data));
            setSelectedItem(data);
        }
    };

    const doTask = async (taskId) => {
        const response = await fetch(`https://localhost:7190/api/VolunteeringTasks/do/${taskId}/${user.email}/${user.password}`, { method: "PUT" });
        if (!response.ok) return;
        const data = await response.json();
        if (data) {
            dispatch(setMyTask(data));
            dispatch(deleteTask(data));
        }
    };

    useEffect(() => {
        loadTasks();
    }, [dispatch]);

    return (
        <div style={{marginTop: '11vh'}}>
            {tasks.map((item, index) => (
                <div key={index}>
                    {new Date(item.date).toLocaleDateString()} {new Date(item.date).getHours()} {item.end} {item.place} {item.city}
                    <br />
                    <button onClick={() => getMoreInfo(item.id)} type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal" style={{ backgroundColor: "#FB4A45", border: "#FB4A45" }}>
                        לפרטים נוספים
                    </button>
                </div>
            ))}

            {selectedItem && (
                <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby={`exampleModalLabel`} aria-hidden="true">
                    <div className="modal-dialog">
                        <div className="modal-content">
                            <div className="modal-header">
                                <h1 className="modal-title fs-5" id={`exampleModalLabel`}> </h1>
                                <button onClick={() => { setSelectedItem(null); setMyTask(null) }} type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div className="modal-body"><img alt="תמונת הילד" src={`${process.env.PUBLIC_URL}/Uploads/${user.volunteer ? selectedItem.image : (user.child ? selectedItem.child.imageURL : '')}`} width='100%' />
                                <p>קוראים לי {user.volunteer ? selectedItem.childName : (user.child ? selectedItem.child.firstName : '')} וההורים שלי מאד ישמחו אם תוכלי לבוא לקחת אותי ב{new Date(selectedItem.date).toLocaleDateString()} בשעה {formatTime(selectedItem.date)} ולשמור עלי {selectedItem.end && (`עד השעה ${formatTime(selectedItem.end)}`)} {selectedItem.place}.
                                    <br /> {selectedItem.comments && (`להורים שלי היה חשוב הפעם שתדעי: ${selectedItem.comments}`)}
                                    <br /> {selectedItem.childComments && (`תמיד חשוב להורים לשלי שתדעי: ${selectedItem.childComments}`)}
                                </p></div>
                            {
                                user.volunteer && (
                                    <div className="modal-footer">
                                        <button onClick={() => {
                                            doTask(selectedItem.id);
                                            setTimeout(() => {
                                                window.location.href = "/my-task";
                                            }, 3000);
                                        }
                                        } type="button" className="btn btn-secondary" data-bs-dismiss="modal">מתאים לי</button>
                                    </div>
                                )
                            }
                        </div>
                    </div>
                </div>
            )
            }

            {/* {
                !selectedItem && (
                    <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby={`exampleModalLabel`} aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id={`exampleModalLabel`}> </h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">לא הצלחנו לטעון את הנתונים שלכם</div>
                            </div>
                        </div>
                    </div>
                )
            }

            {
                Object.keys(myTask).length === 0 && (
                    // <Modal
                    //     id="allTaskInfo"
                    //     title=""
                    //     body={
                    //         <>
                    //             <img alt="תמונת הילד" src={`${process.env.PUBLIC_URL}/Uploads/${myTask.child.imageURL}`} width='100%' />
                    //             <p>שלום {myTask.volunteer.firstName}!<br />
                    //                 אני {myTask.child.firstName} {myTask.child.lastName} ואנחנו גרים ברחוב {myTask.child.street} {myTask.child.building} {myTask.child.city}.
                    //                 אנחנו שמחים מאד לשמוע שב{new Date(myTask.date).toLocaleDateString()} בשעה {formatTime(myTask.date)} את מגיעה לקחת אותי {myTask.end && (`עד השעה ${formatTime(selectedItem.end)}`)}.
                    //                 <br /> {myTask.comments && (`להורים שלי היה חשוב הפעם שתדעי: ${myTask.comments}`)}
                    //                 <br /> {myTask.child.comments && (`תמיד חשוב להורים לשלי שתדעי: ${myTask.child.comments}`)}
                    //                 <br /> לכל שאלה שיש לך, מספר הטלפון של ההורים שלי הוא {myTask.child.phone}.
                    //                 <br /> מחכים לך!
                    //             </p>
                    //         </>
                    //     }
                    // />
                    <div className="modal fade" id="allTaskInfo" tabIndex="-1" aria-labelledby={`allTaskInfoLabel`} aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id={`allTaskInfoLabel`}> </h1>
                                    <button onClick={() => { setSelectedItem(null); setMyTask(null) }} type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body"><img alt="תמונת הילד" src={`${process.env.PUBLIC_URL}/Uploads/${myTask.child.imageURL}`} width='100%' />
                                 <p>שלום {myTask.volunteer.firstName}!<br />
                                   אני {myTask.child.firstName} {myTask.child.lastName} ואנחנו גרים ברחוב {myTask.child.street} {myTask.child.building} {myTask.child.city}.
                                   אנחנו שמחים מאד לשמוע שב{new Date(myTask.date).toLocaleDateString()} בשעה {formatTime(myTask.date)} את מגיעה לקחת אותי {myTask.end && (`עד השעה ${formatTime(selectedItem.end)}`)}.
                                    <br /> {myTask.comments && (`להורים שלי היה חשוב הפעם שתדעי: ${myTask.comments}`)}
                                  <br /> {myTask.child.comments && (`תמיד חשוב להורים לשלי שתדעי: ${myTask.child.comments}`)}
                                     <br /> לכל שאלה שיש לך, מספר הטלפון של ההורים שלי הוא {myTask.child.phone}.
                                    <br /> מחכים לך!
                              </p></div>
                            </div>
                        </div>
                    </div>
                )
            }

            {
                !myTask && (
                    <div className="modal fade" id="allTaskInfo" tabIndex="-1" aria-labelledby={`allTaskInfoLabel`} aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id={`allTaskInfoLabel`}> </h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">לא הצלחנו לעדכן את ההתנדבות שלך</div>
                            </div>
                        </div>
                    </div>
                )
            } */}
        </div >
    );
}

import React, { useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { addManyTasks } from '../redux/actions/addManyTask';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import { updateTask } from '../redux/actions/updateTask';

export default function Tasks() {
    const publicUrl = process.env.REACT_APP_PROJECT_URL;
    const tasks = useSelector((state) => state.taskReducer);
    const user = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();

    async function getMoreInfo(taskId) {
        try {
            const response = await fetch(`https://localhost:7190/api/volunteeringtasks/${taskId}/${user.email}/${user.password}`);
            console.log(response)
            if (response.ok) {
                const data = await response.json();
                dispatch(updateTask(data));
                console.log(tasks);
            } else {
                throw new Error("Network response was not ok");
            }
        } catch (error) {
            alert("הייתה בעיה בטעינת פרטי המשימה.");
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
                alert("הייתה בעיה בטעינת המשימות. נסו שוב בעוד מספר דקות");
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
                        {/* <button onClick={() => getMoreInfo(item.id)} className="btn btn-info">More Info</button> */}
                    </div>
                    <button onClick={() => getMoreInfo(item.id)} type="button" className="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                        Launch demo modal
                    </button>
                    <div className="modal fade" id="exampleModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">
                                    <img alt="image" src={item.image}></img>
                                </div>
                                <div className="modal-footer">
                                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                                    <button type="button" className="btn btn-primary">Save changes</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </>
            ))}
        </div>
    );
}

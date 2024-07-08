import React from 'react';
import { useDispatch, useSelector } from "react-redux";

function loadTasks() {
    
}

export default function Tasks(){
    const tasks = useSelector((state) => state.taskReducer);
    const dispatch = useDispatch();
    return (
        <div>
            
            {tasks.map((item) => (
                <div>
                    {item.date} {item.hour} {item.type} {item.comments}
                </div>
            ))}
        </div>
    )
}
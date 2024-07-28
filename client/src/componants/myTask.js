import { useDispatch, useSelector } from "react-redux";
import {deleteMyTask} from '../redux/actions/deleteMyTask'

const formatTime = (dateString) => {
    const date = new Date(dateString);
    const hours = date.getHours();
    const minutes = date.getMinutes().toString().padStart(2, '0');
    return `${hours}:${minutes}`;
};

const handleNavigation = (path) => {
    window.location.href = path;
};

export default function MyTask() {
    const task = useSelector((state) => state.myTaskReducer);
    const dispatch = useDispatch();
    console.log(task);

    return (
        <div className="paragraph">
            {
                Object.keys(task).length > 0 && (
                    <p>שלום {task.volunteer.firstName}!<br />
                        אני {task.child.firstName} {task.child.lastName} ואנחנו גרים ברחוב {task.child.street} {task.child.building} {task.child.city}.
                        אנחנו שמחים מאד לשמוע שב{new Date(task.date).toLocaleDateString()} בשעה {formatTime(task.date)} את מגיעה לקחת אותי {task.end && (`עד השעה ${formatTime(task.end)}`)}.
                        <br /> {task.comments && (`להורים שלי היה חשוב הפעם שתדעי: ${task.comments}`)}
                        <br /> {task.child.comments && (`תמיד חשוב להורים לשלי שתדעי: ${task.child.comments}`)}
                        <br /> לכל שאלה שיש לך, מספר הטלפון של ההורים שלי הוא {task.child.phone}.
                        <br /> מחכים לך!
                    </p>

                )
            }

            {
                Object.keys(task).length === 0 && (

                    <> לא הצלחנו לעדכן את ההתנדבות שלך</>

                )
            }
            <button
                onClick={() => {
                    dispatch(deleteMyTask());
                    handleNavigation('/')}}
                className="btn btn-primary"
                style={{ backgroundColor: 'lightgray', border: 'lightgray' }}
            >
                לעמוד הבית
            </button>
        </div >
    )
}
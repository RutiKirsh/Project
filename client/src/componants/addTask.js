import { useState } from "react";
import { useSelector } from "react-redux";

import babushka from '../images/babushka.png';

const optionalPlaces = ['בבית שלנו', 'בבית שלך', 'בגינה', 'בבית חולים', 'במשחקיה'];

export default function AddTask() {
    const user = useSelector((state) => state.userReducer);
    const [task, setTask] = useState({
        Date: '',
        End: '',
        Place: '',
        Comments: '',
        ChildId: ''
    });

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setTask({ ...task, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        if (Object.keys(user).length === 0) {
            alert("לא ניתן להוסיף את הבקשה שלכם, אנא התחברו למערכת");
            return;
        }
        try {
            task.ChildId = user.child.id;
        } catch {
            alert("לא ניתן להוסיף את הבקשה שלכם");
            return;
        }

        try {
            const response = await fetch(`https://localhost:7190/api/volunteeringTasks/${user.email}/${user.password}`, {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(task)
            });

            if (response.ok) {
                alert("המשימה נוספה בהצלחה");
                window.location.href = "account"
            } else {
                alert("לצערנו לא ניתן להוסיף את הבקשה שלכם. נסו שוב מאוחר יותר");
            }
        } catch (error) {
            alert("לצערנו לא ניתן להוסיף את הבקשה שלכם. נסו שוב מאוחר יותר");
        }
    };

    return (
        <div className="paragraph" style={{ width: '98vw', marginTop: '11vh' }}>
            <img src={babushka} alt="babushka" style={{ height: '50px', width: '60px' }} />
            <h1 className="paragraph-title" style={{ fontSize: '50px', marginTop: '-3.2vh' }}>נשמח לעזור</h1>
            <form onSubmit={handleSubmit} style={{
                width: '60%',
                padding: '5%',
                boxShadow: '5px 5px 10px rgba(0, 0, 0, 0.1)',
                borderRadius: "50px",
                borderWidth: "1.5px",
                borderStyle: 'solid',
                borderColor: 'rgb(227, 200, 184)'
            }}>
                <div className="row g-3">
                    <div className="col">
                        <div className="row g-3">
                            <label htmlFor="date" className="form-label col">ממתי?</label>
                            <input id="date" type="datetime-local" className="form-control col" required name="Date" value={task.Date} onChange={handleInputChange} />
                        </div>
                    </div>
                    <div className="col">
                        <div className="row g-3">
                            <label htmlFor="endDate" className="form-label col">עד מתי?</label>
                            <input id="endDate" type="datetime-local" className="form-control col" required name="End" value={task.End} onChange={handleInputChange} />
                        </div>
                    </div>
                </div>
                <br />
                <div className="row g-3">
                    <label htmlFor='place' className="form-label col">איפה?</label>
                    <select id="place" className="form-select custom-select" name="Place" value={task.Place} onChange={handleInputChange}>
                        <option value="">בחר מקום</option>
                        {optionalPlaces.map((p, index) => (
                            <option key={index} value={p}>
                                {p}
                            </option>
                        ))}
                    </select>
                </div>
                <br />
                <div className="mb-3">
                    <textarea className="form-control" id="exampleFormControlTextarea1" rows="3" placeholder="כאן המקום לפרט אם יש הדגשים מיוחדים להפעם" name="Comments" value={task.Comments} onChange={handleInputChange} style={{ width: '100%' }}></textarea>
                </div>
                <br />
                <button type="submit" className="btn btn-primary" style={{ backgroundColor: "#FB4A45", border: "#FB4A45" }}>שליחה</button>
            </form>
        </div>
    );
}

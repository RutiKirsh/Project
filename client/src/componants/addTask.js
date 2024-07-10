import { useState } from "react";
import { useSelector } from "react-redux";

const optionalPlaces = ['בבית שלנו', 'בבית שלך', 'בגינה', 'בבית חולים', 'במשחקיה'];

export default function AddTask() {
    const user = useSelector((state) => state.userReducer);
    const [task, setTask] = useState({
        Date: null,
        End: null,
        Place: '',
        Comments: '',
        ChildId: ''
    })

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
            task.ChildId = user.Child.Id;
        }
        catch {
            alert("לא ניתן להוסיף את הבקשה שלכם");
            return;
        }

        try {
            const response = await fetch("https://localhost:7190/api/tasks", {
                method: "POST",
                body: task
            });

            if (response.ok) {
                console.log("task data submitted successfully!");
            } else {
                alert("לצערנו לא ניתן להוסיף את הבקשה שלכם. נסו שוב מאוחר יותר");
            }
        } catch (error) {
            alert("לצערנו לא ניתן להוסיף את הבקשה שלכם. נסו שוב מאוחר יותר");
        }
    };


    return (
        <form onSubmit={handleSubmit} style={{
            width: '45%',
            padding: '5%',
            boxShadow: '5 5 10 rgba(0, 0, 0, 0.1)',
            borderRadius: "50px",
            borderWidth: "1.5px",
            borderStyle: 'solid',
            borderColor: 'rgb(227, 200, 184)'
        }}>
            <div class="row g-3">
                <div class="col">
                    <div class="row g-3">
                        <label for="date" class="form-label col">ממתי?</label>
                        <input id="date" type="datetime-local" class="form-control col" required name="Date" value={task.Date} onChange={handleInputChange} />
                    </div>
                </div>
                <div class="col">
                    <div class="row g-3">
                        <label for="endDate" class="form-label col">עד מתי?</label>
                        <input id="endDate" type="datetime-local" class="form-control col" required name="End" value={task.End} onChange={handleInputChange} />
                    </div>
                </div>
            </div>
            <br></br>
            <div class="row g-3">
                <label for='place' class="form-label col">איפה?</label>
                <select id="place" class="form-select custom-select" name="Place" value={task.Place} onChange={handleInputChange}>
                    <option></option>
                    {optionalPlaces.map((p) => (
                        <option value={p}>
                            {p}
                        </option>
                    ))}
                </select>
            </div>
            <br></br>
            <div class="mb-3">
                <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" placeholder="כאן המקום לפרט אם יש הדגשים מיוחדים להפעם" name="Comments" value={task.Comments} onChange={handleInputChange} style={{width: '100%'}}></textarea>
            </div>
            <br></br>
            <button type="submit" class="btn btn-primary" style={{ backgroundColor: "#FB4A45", border: "#FB4A45" }}>שליחה</button>
        </form>
    );
}
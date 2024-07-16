import { useState, useEffect } from "react";

async function getChallenges() {
    try {
        const res = await fetch('https://localhost:7190/api/info/challenges');
        const data = await res.json();
        return data;
    } catch (err) {
        console.log(err);
        return [];
    }
}

export default function AddChild() {
    const [childData, setChildData] = useState({
        Id: "",
        FirstName: "",
        LastName: "",
        Phone: "",
        Challenge: "",
        BirthDate: "",
        Image: null,
        City: "",
        Street: "",
        Building: "",
        Comments: ""
    });

    const [challenges, setChallenges] = useState([]);

    useEffect(() => {
        async function fetchChallenges() {
            const data = await getChallenges();
            setChallenges(data);
        }

        fetchChallenges();
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setChildData({ ...childData, [name]: value });
    };

    const handleFileChange = (e) => {
        setChildData({ ...childData, Image: e.target.files[0] });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const formData = new FormData();
            formData.append("Id", childData.Id);
            formData.append("FirstName", childData.FirstName);
            formData.append("LastName", childData.LastName);
            formData.append("Phone", childData.Phone);
            formData.append("Challenge", childData.Challenge);
            formData.append("BirthDate", childData.BirthDate);
            formData.append("Image", childData.Image);
            formData.append("City", childData.City);
            formData.append("Street", childData.Street);
            formData.append("Building", childData.Building);
            formData.append("Comments", childData.Comments);

            const response = await fetch("https://localhost:7190/api/children", {
                method: "POST",
                body: formData
            });

            if (response.ok) {
                console.log("Child data submitted successfully!");
            } else {
                console.error("Failed to submit child data.");
            }
        } catch (error) {
            console.error("Error submitting child data:", error);
        }
    };

    return (
        <div style={{width: '50%'}}>
            {/* <form onSubmit={handleSubmit}>
                <input type="text" name="Id" value={childData.Id} onChange={handleInputChange} placeholder="מספר זהות" required />
                <input type="text" name="FirstName" value={childData.FirstName} onChange={handleInputChange} placeholder="שם פרטי" required />
                <input type="text" name="LastName" value={childData.LastName} onChange={handleInputChange} placeholder="שם משפחה" required />
                <input type="text" name="Phone" value={childData.Phone} onChange={handleInputChange} placeholder="מספר טלפון" required />
                <label htmlFor="challenges">אתגר</label>
                <select id="challenges" name="Challenge" value={childData.Challenge} onChange={handleInputChange} required>
                    {challenges.map((c, index) => (
                        <option key={index} value={c}>
                            {c}
                        </option>
                    ))}
                    <option value="אחר">אחר</option>
                </select>
                {childData.Challenge === "אחר" && (
                    <input
                        type="text"
                        name="Challenge"
                        value={childData.Challenge || ''}
                        onChange={handleInputChange}
                        placeholder="אנא ציין את האתגר"
                        required
                    />
                )}
                <input type="date" name="BirthDate" value={childData.BirthDate} onChange={handleInputChange} placeholder="תאריך לידה" required />
                <input type="file" name="Image" onChange={handleFileChange} placeholder="תמונה" />
                <label>כתובת</label>
                <input type="text" name="City" value={childData.City} onChange={handleInputChange} placeholder="עיר" required />
                <input type="text" name="Street" value={childData.Street} onChange={handleInputChange} placeholder="רחוב" required />
                <input type="text" name="Building" value={childData.Building} onChange={handleInputChange} placeholder="בניין" required />
                <textarea
                    maxLength={4000}
                    name="Comments"
                    value={childData.Comments}
                    onChange={handleInputChange}
                    placeholder="כאן המקום להוסיף כל מה שחשוב לדעת על הילד שלכם"
                />
                <input type="submit" value="שלח" />
            </form> */}
            <form
                onSubmit={handleSubmit}
                style={{
                    width: '100%',
                    padding: '5%',
                    boxShadow: '5px 5px 10px rgba(0, 0, 0, 0.1)',
                    borderRadius: '50px',
                    borderWidth: '1.5px',
                    borderStyle: 'solid',
                    borderColor: 'rgb(227, 200, 184)',
                }}
            >
                <div className="row g-3">
                    <label htmlFor="Id" className="form-label col">מספר זהות</label>
                    <input
                        id="Id"
                        type="text"
                        name="Id"
                        className="form-control col"
                        value={childData.Id}
                        onChange={handleInputChange}
                        placeholder="מספר זהות"
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="FirstName" className="form-label col">שם פרטי</label>
                    <input
                        id="FirstName"
                        type="text"
                        name="FirstName"
                        className="form-control col"
                        value={childData.FirstName}
                        onChange={handleInputChange}
                        placeholder="שם פרטי"
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="LastName" className="form-label col">שם משפחה</label>
                    <input
                        id="LastName"
                        type="text"
                        name="LastName"
                        className="form-control col"
                        value={childData.LastName}
                        onChange={handleInputChange}
                        placeholder="שם משפחה"
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="Phone" className="form-label col">מספר טלפון</label>
                    <input
                        id="Phone"
                        type="text"
                        name="Phone"
                        className="form-control col"
                        value={childData.Phone}
                        onChange={handleInputChange}
                        placeholder="מספר טלפון"
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="challenges" className="form-label col">אתגר</label>
                    <select
                        id="challenges"
                        name="Challenge"
                        className="form-select col"
                        value={childData.Challenge}
                        onChange={handleInputChange}
                        required
                    >
                        {challenges.map((c, index) => (
                            <option key={index} value={c}>
                                {c}
                            </option>
                        ))}
                        <option value="אחר">אחר</option>
                    </select>
                </div>

                {childData.Challenge === "אחר" && (
                    <div className="row g-3">
                        <label htmlFor="OtherChallenge" className="form-label col">אנא ציין את האתגר</label>
                        <input
                            id="OtherChallenge"
                            type="text"
                            name="Challenge"
                            className="form-control col"
                            value={childData.Challenge || ''}
                            onChange={handleInputChange}
                            placeholder="אנא ציין את האתגר"
                            required
                        />
                    </div>
                )}

                <div className="row g-3">
                    <label htmlFor="BirthDate" className="form-label col">תאריך לידה</label>
                    <input
                        id="BirthDate"
                        type="date"
                        name="BirthDate"
                        className="form-control col"
                        value={childData.BirthDate}
                        onChange={handleInputChange}
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="Image" className="form-label col">תמונה</label>
                    <input
                        id="Image"
                        type="file"
                        name="Image"
                        className="form-control col"
                        onChange={handleFileChange}
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="City" className="form-label col">עיר</label>
                    <input
                        id="City"
                        type="text"
                        name="City"
                        className="form-control col"
                        value={childData.City}
                        onChange={handleInputChange}
                        placeholder="עיר"
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="Street" className="form-label col">רחוב</label>
                    <input
                        id="Street"
                        type="text"
                        name="Street"
                        className="form-control col"
                        value={childData.Street}
                        onChange={handleInputChange}
                        placeholder="רחוב"
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="Building" className="form-label col">בניין</label>
                    <input
                        id="Building"
                        type="text"
                        name="Building"
                        className="form-control col"
                        value={childData.Building}
                        onChange={handleInputChange}
                        placeholder="בניין"
                        required
                    />
                </div>

                <div className="row g-3">
                    <label htmlFor="Comments" className="form-label col">הערות</label>
                    <textarea
                        id="Comments"
                        maxLength={4000}
                        name="Comments"
                        className="form-control col"
                        value={childData.Comments}
                        onChange={handleInputChange}
                        placeholder="כאן המקום להוסיף כל מה שחשוב לדעת על הילד שלכם"
                    />
                </div>

                <button
                    type="submit"
                    className="btn btn-primary"
                    style={{ backgroundColor: "#FB4A45", border: "#FB4A45", marginTop: '10px' }}
                >
                    שלח
                </button>
            </form>

        </div>
    );
}

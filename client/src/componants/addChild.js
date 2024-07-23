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
            Object.keys(childData).forEach(key => {
                formData.append(key, childData[key]);
            });

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
        <div style={{ width: '50%' }}>
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
                {[
                    { id: 'Id', label: 'מספר זהות', type: 'text', value: childData.Id },
                    { id: 'FirstName', label: 'שם פרטי', type: 'text', value: childData.FirstName },
                    { id: 'LastName', label: 'שם משפחה', type: 'text', value: childData.LastName },
                    { id: 'Phone', label: 'מספר טלפון', type: 'text', value: childData.Phone },
                    { id: 'BirthDate', label: 'תאריך לידה', type: 'date', value: childData.BirthDate },
                    { id: 'City', label: 'עיר', type: 'text', value: childData.City },
                    { id: 'Street', label: 'רחוב', type: 'text', value: childData.Street },
                    { id: 'Building', label: 'בניין', type: 'text', value: childData.Building }
                ].map(({ id, label, type, value }) => (
                    <div className="row g-3" key={id}>
                        <label htmlFor={id} className="form-label col">{label}</label>
                        <input
                            id={id}
                            type={type}
                            name={id}
                            className="form-control col"
                            value={value}
                            onChange={handleInputChange}
                            placeholder={label}
                            required
                        />
                    </div>
                ))}

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

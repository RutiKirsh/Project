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
            console.log(data);
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
            formData.append("challenge", childData.Challenge);
            formData.append("birthDate", childData.BirthDate);
            formData.append("image", childData.Image);
            formData.append("City", childData.City);
            formData.append("Street", childData.Street);
            formData.append("Building", childData.Building);
            formData.append("Comments", childData.Comments);
<<<<<<< HEAD
=======
           
>>>>>>> 2a7e127db99ebc7039089cb765be50512f3505a9

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
        <div>
            <form onSubmit={handleSubmit}>
                <input type="text" name="Id" value={childData.Id} onChange={handleInputChange} placeholder="מספר זהות"></input>
                <input type="text" name="FirstName" value={childData.FirstName} onChange={handleInputChange} placeholder="שם פרטי"></input>
                <input type="text" name="LastName" value={childData.LastName} onChange={handleInputChange} placeholder="שם משפחה"></input>
                <input type="text" name="Phone" value={childData.Phone} onChange={handleInputChange} placeholder="מספר טלפון"></input>
                <label htmlFor="challenges">אתגר</label>
                <select id="challenges" name="Challenge" value={childData.Challenge} onChange={handleInputChange}>
                    {challenges.map((c, index) => (
                        <option key={index} value={c}>
                            {c}
                        </option>
                    ))}
                    <option value="אחר">אחר</option>
                </select>
                <input type="date" name="BirthDate" value={childData.BirthDate} onChange={handleInputChange} placeholder="תאריך לידה"></input>
                <input type="file" name="Image" onChange={handleFileChange} placeholder="תמונה"></input>
                <label>כתובת</label>
                <input type="text" name="City" value={childData.City} onChange={handleInputChange} placeholder="עיר"></input>
                <input type="text" name="Street" value={childData.Street} onChange={handleInputChange} placeholder="רחוב"></input>
                <input type="text" name="Building" value={childData.Building} onChange={handleInputChange} placeholder="בניין"></input>
                <textarea maxLength={4000} name="Comments" value={childData.Comments} onChange={handleInputChange} placeholder="כאן המקום להוסיף כל מה שחשוב לדעת על הילד שלכם"></textarea>
                <input type="submit" value="שלח"></input>
            </form>
        </div>
    );
}

import { useState } from "react";
import babushka from '../images/babushka.png'
import { useDispatch, useSelector } from "react-redux";
import { logIn } from "../redux/actions/logIn";

export default function LogIn() {
    const globalUser = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();
    const [user, setUser] = useState({
        email: "",
        password: "",
    })

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await fetch(`https://localhost:7190/api/users/${user.email}/${user.password}`);
            if (response.ok) {
                const myUser = await response.json();
                sessionStorage.setItem("notnimYadUser", JSON.stringify(myUser));
                console.log("User logged in successfully:", myUser);
                dispatch(logIn(myUser));
            } else {
                throw new Error("Network response was not ok");
            }
        } catch (error) {
            alert("לא הצלחנו למצוא את החשבון שלכם. נסו שוב");
            console.error("Error:", error);
        }
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setUser({ ...user, [name]: value });
    };

    return (
        <div class="paragraph" style={{ width: '98vw' }}>
            <img src={babushka} style={{ height: '50px', width: '60px' }}></img>
            <h1 class="paragraph-title" style={{ fontSize: '50px', marginTop: '-3.2vh' }}>שמחים לפגוש אתכם שוב</h1>
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
                    <label for="email" class="form-label col">אימייל</label>
                    <input id="email" type="email" class="form-control col" required name="email" value={user.email} onChange={handleInputChange} />
                </div>
                <br />
                <div class="row g-3">
                    <label for="password" class="form-label col">סיסמא</label>
                    <input id="password" type="password" class="form-control col" required name="password" value={user.password} onChange={handleInputChange} />
                </div>
                <br />
                <button type="submit" class="btn btn-primary" style={{ backgroundColor: "#FB4A45", border: "#FB4A45" }}>כניסה</button>
            </form>
        </div>
    );
}
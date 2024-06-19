import React, { useEffect, useRef, useState } from 'react';

function checkExist() {
    const email = document.getElementById("emailInput").value;
    console.log("checking");
    console.log(email);
    fetch(`https://localhost:7190/api/users/${email}`)
        .then((res) => {
            return res.json()
                .then((data) => {
                    console.log(data);
                }
                );
        })
        .catch((err) => {console.log(err);});
}

export default function SignUp() {
    /*const [email, setEmail] = useState('');*/
    const emailInputRef = useRef(null);

    useEffect(() => {
        const input = emailInputRef.current;
        if (input) {
            input.addEventListener('blur', checkExist);
        }
        //אנחנו אמורות להוסיף פה ולידציה של אימייל
    }, []);

    return (
        <center>
            <h1>ברוכים הבאים</h1>
            <h2>כולנו נותנים יד בשביל כולם</h2>
            <form>
                <input
                    id="emailInput"
                    type="text"
                    placeholder="כתובת דואר אלקטרוני"
                    ref={emailInputRef}
                />
                <input type="text" placeholder="סיסמה" />
                <input type="text" placeholder="אימות סיסמה" />
                <input type="submit" value="הרשם"/>
            </form>
        </center>
    );
}

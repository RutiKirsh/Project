function checkExist(){

}
export default function SignUp() {
    return (
        <center>
            <h1>ברוכים הבאים</h1>
            <h2>כולנו נותנים יד בשביל כולם</h2>
            <form>
                <input type="text" placeholder="כתובת דואר אלקטרוני" onChange={checkExist}></input>
                <input type="text" placeholder="סיסמה"></input>
                <input type="text" placeholder="אימות סיסמה"></input>
                <input type="submit" value="הרשם"></input>
            </form>
        </center>
    );
}
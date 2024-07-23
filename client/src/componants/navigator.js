// 

import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import Tasks from "./tasks";
import HomePage from "./homePage";
// import Header from "./header";

export default function Navigator() {
    return (
        <BrowserRouter>
            <center>
                <div>
                    <div style={{ "display": "flex", "justify-content": "space-evenly" ,"margin": "2%"}}>
                        <button className="btn btn-secondary">
                            <Link style={{ "color": "white" }} to='/'>דף הבית</Link>
                        </button>
                        <button className="btn btn-secondary">
                            <Link style={{ "color": "white" }} to='/Tasks'>משימות</Link>
                        </button>
                    </div>
                    {/* <Header /> הוספת הרכיב שמכיל את הכפתור */}
                    <Routes>
                        <Route exact path="/" element={<HomePage />} />
                        <Route exact path="/Tasks" element={<Tasks />} />
                    </Routes>
                </div>
            </center>
        </BrowserRouter>
    )
} 
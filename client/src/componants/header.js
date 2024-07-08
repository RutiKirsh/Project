import logo from '../images/logo.png'
import React, { useState } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { logIn } from '../redux/actions/logIn';
import '../css/header.css';

export default function Header() {
    const userDetails = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();
    const [showPopover, setShowPopover] = useState(false);

    function uploadUser() {
        let user = sessionStorage.getItem('notnimYadUser');
        if (user) {
            dispatch(logIn(JSON.parse(user)));
        } else {
            dispatch(logIn());
        }
        // dispatch(logIn(sessionStorage.getItem('notnimYadUser').json()));
    }

    const togglePopover = () => {
        setShowPopover(!showPopover);
        console.log('togglePopover');
    };
    return (
        <header style={{ backgroundColor: 'rgb(227, 200, 184)', height: '11vh' }} onLoad={uploadUser}>
            <img src={logo} alt='logo' height='100vh' style={{ float: 'right' }} />
            <div style={{ display: 'flex', alignItems: 'flex-end', float: 'left', height: '100', marginLeft: '10px', marginTop: '2.5vh' }}>
                <div style={{ fontFamily: 'easy', fontSize: 'large', fontWeight: 'bold' }}>אנחנו כאן כדי לתת יד</div>
                <div class='user-details' style={{ textAlign: 'left', marginRight: '20px' }}>
                    <button onClick={togglePopover} style={{ backgroundColor: 'grey', borderRadius: '50%', padding: '10px', display: 'inline-block' }}>
                        <svg width="25" height="25" viewBox="0 0 24 24"
                            fill="none" xmlns="http://www.w3.org/2000/svg" >
                            <path d="M12 12C15.3137 12 18 9.31371 18 6C18 2.68629 15.3137 0 12 0C8.68629 0 6 2.68629 6 6C6 9.31371 8.68629 12 12 12ZM12 14C7.58172 14 0 16.2386 0 20.6667V24H24V20.6667C24 16.2386 16.4183 14 12 14Z"
                                fill="currentColor" />
                        </svg>
                    </button>
                    {showPopover && (

                        <div className="popover">
                            <h2>User Details</h2>
                            <p><strong>Name:</strong> {userDetails.name}</p>
                            <p><strong>Age:</strong> {userDetails.age}</p>
                            <p><strong>Email:</strong> {userDetails.email}</p>
                            {/* Add more details display as needed */}
                        </div>

                    )}
                </div>
            </div>
        </header>
    );
}


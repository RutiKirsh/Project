import logo from '../images/logo.png'
import React, { useState } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { logIn } from '../redux/actions/logIn';
import '../css/header.css';
import { calculateNewValue } from '@testing-library/user-event/dist/utils';

export default function Header() {
    const userDetails = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();
    const [showPopover, setShowPopover] = useState(false);
    const [myBackgroundColor, setMyBackgroundColor] = useState('rgb(227, 200, 184)');

    function setNavColor() {
        setMyBackgroundColor('rgb(255, 255, 255)'); 
    }

    window.addEventListener('scroll', setNavColor);

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
        <header class="navbar fixed-top navbar-expand-lg white" style={{ backgroundColor: myBackgroundColor, height: '11vh', width: '100vw', boxShadow: '5 5 10 rgba(0, 0, 0, 0.1)', borderRadius: "0 0 0 40px", borderWidth: "0 0 1.5px 1.5px", borderStyle:'solid', borderColor: 'rgb(227, 200, 184)'}} onLoad={uploadUser}>
            <div class="container-fluid"><img src={logo} alt='logo' height='100vh' style={{ float: 'right' }} /></div>
            <div class="d-flex" style={{ display: 'flex', alignItems: 'flex-end', float: 'left', height: '100', marginLeft: '10px', marginTop: '2.5vh' }}>
                <div style={{ fontFamily: 'easy', fontSize: 'large', fontWeight: 'bold', width: '100px'}}>כאן כדי לתת יד</div>
                <div class='user-details' style={{ textAlign: 'left', marginRight: '20px' }}>
                    <button onClick={togglePopover} style={{ backgroundColor: 'lightgray', borderRadius: '50%', padding: '10px', display: 'inline-block', borderColor:'grey', aspectRatio: '1:1' }}>
                        <svg width="15" height="15" viewBox="0 0 24 24"
                            fill="none" xmlns="http://www.w3.org/2000/svg" >
                            <path d="M12 12C15.3137 12 18 9.31371 18 6C18 2.68629 15.3137 0 12 0C8.68629 0 6 2.68629 6 6C6 9.31371 8.68629 12 12 12ZM12 14C7.58172 14 0 16.2386 0 20.6667V24H24V20.6667C24 16.2386 16.4183 14 12 14Z"
                                fill="darkgray" />
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


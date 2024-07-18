import logo from '../images/logo.png'
import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { logIn } from '../redux/actions/logIn';
import '../css/header.css';

export default function Header() {
    const userDetails = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();
    const [showPopover, setShowPopover] = useState(false);
    const [myBackgroundColor, setMyBackgroundColor] = useState('rgb(227, 200, 184)');

    useEffect(() => {
        function setNavColor() {
            setMyBackgroundColor('rgb(255, 255, 255)');
        }

        window.addEventListener('scroll', setNavColor);

        return () => {
            window.removeEventListener('scroll', setNavColor);
        };
    }, []);

    useEffect(() => {
        function uploadUser() {
            let user = sessionStorage.getItem('notnimYadUser');
            if (user) {
                dispatch(logIn(JSON.parse(user)));
            }
        }

        uploadUser();
    }, [dispatch]);

    const togglePopover = () => {
        setShowPopover(!showPopover);
    };

    return (
        <header className="navbar fixed-top navbar-expand-lg white" style={{ backgroundColor: myBackgroundColor, height: '11vh', width: '100vw', boxShadow: '5 5 10 rgba(0, 0, 0, 0.1)', borderRadius: "0 0 0 40px", borderWidth: "0 0 1.5px 1.5px", borderStyle: 'solid', borderColor: 'rgb(227, 200, 184)' }}>
            <div className="container-fluid"><img src={logo} alt='logo' height='100vh' style={{ float: 'right' }} /></div>
            <div className="d-flex" style={{ display: 'flex', alignItems: 'flex-end', float: 'left', height: '100', marginLeft: '10px', marginTop: '2.5vh' }}>
                <div style={{ fontFamily: 'easy', fontSize: 'large', fontWeight: 'bold', width: '100px' }}>כאן כדי לתת יד</div>
                <div className='user-details' style={{ textAlign: 'left', marginRight: '20px' }}>
                    <button onClick={togglePopover} style={{ backgroundColor: 'lightgray', borderRadius: '50%', padding: '5px', display: 'inline-block', borderColor: 'grey', height: 37, width: 37, marginLeft: '15px' }}>
                        <svg width="15" height="15" viewBox="0 0 24 24"
                            fill="none" xmlns="http://www.w3.org/2000/svg" >
                            <path d="M12 12C15.3137 12 18 9.31371 18 6C18 2.68629 15.3137 0 12 0C8.68629 0 6 2.68629 6 6C6 9.31371 8.68629 12 12 12ZM12 14C7.58172 14 0 16.2386 0 20.6667V24H24V20.6667C24 16.2386 16.4183 14 12 14Z"
                                fill="darkgray" />
                        </svg>
                    </button>
                    {showPopover && (
                        <div className="popover">
                            {userDetails.child && (
                                <p>{userDetails.child.firstName} {userDetails.child.lastName}</p>
                            )}
                            {userDetails.volunteer && (
                                <p>{userDetails.volunteer.firstName} {userDetails.volunteer.lastName}</p>
                            )}
                        </div>
                    )}
                </div>
            </div>
        </header>
    );
}


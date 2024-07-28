import { useDispatch, useSelector } from 'react-redux';
import ChildTasks from './child\'sTasks';
import { logOut } from '../redux/actions/logOut';

export default function Account() {
    const userDetails = useSelector((state) => state.userReducer);
    const dispatch = useDispatch();

    const handleLogout = () => {
        dispatch(logOut());
    };

    const handleNavigation = (path) => {
        window.location.href = path;
    };

    return (
        <div className="paragraph" style={{ width: '98vw' }}>
            {!Object.keys(userDetails).length ? (
                <h1 className="paragraph-title">
                    לא מצאנו את המשתמש שלכם. נסו להכנס שוב.
                </h1>
            ) : (
                <>
                    {userDetails.child && (
                        <div>
                            <h1 className="paragraph-title">
                                {userDetails.child.firstName} {userDetails.child.lastName}
                            </h1>
                            <br />
                            המשימות שלי:
                            <ChildTasks />
                            <br />
                            <button
                                onClick={() => handleNavigation('/add-task')}
                                className="btn btn-primary"
                                style={{ backgroundColor: '#FB4A45', border: '#FB4A45' }}
                            >
                                להוספת משימה
                            </button>
                        </div>
                    )}
                    {userDetails.volunteer && (
                        <h1 className="paragraph-title">
                            {userDetails.volunteer.firstName} {userDetails.volunteer.lastName}
                        </h1>
                    )}
                    <br />
                    <br />
                    <button
                        onClick={handleLogout}
                        className="btn btn-primary"
                        style={{ backgroundColor: '#FB4A45', border: '#FB4A45' }}
                    >
                        יציאה
                    </button>
                </>
            )}
            {!Object.keys(userDetails).length && (
                <button
                    onClick={() => handleNavigation('/log-in')}
                    className="btn btn-primary"
                    style={{ backgroundColor: '#FB4A45', border: '#FB4A45' }}
                >
                    כניסה
                </button>
            )}
            <br />
            <br />
            <button
                    onClick={() => handleNavigation('/')}
                    className="btn btn-primary"
                    style={{ backgroundColor: 'lightgray', border: 'lightgray' }}
                >
                    לעמוד הבית
                </button>
        </div>
    );
}

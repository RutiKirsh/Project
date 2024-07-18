import './App.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import 'bootstrap/dist/css/bootstrap.min.css';
// import { Scrollbars } from 'react-custom-scrollbars-2';
import { Provider } from 'react-redux';
import store from './redux/store';
import HomePage from './componants/homePage';
import Header from './componants/header';
import Tasks from './componants/tasks';
import LogIn from './componants/logIn';
import AddChild from './componants/addChild';
import ChildTasks from './componants/child\'sTasks';

function App() {
  return (
    <div className="App">


      <Provider store={store}>
        <Header></Header>
        <body style={{display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center'}}>
        <HomePage></HomePage>
        <LogIn></LogIn>
        {/* <Tasks></Tasks> */}
        {/* <AddChild></AddChild> */}
        <ChildTasks></ChildTasks>
        </body>
      </Provider>
    </div>
  );
}

export default App;

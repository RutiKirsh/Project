import './App.css';
import { Scrollbars } from 'react-custom-scrollbars-2';
import { Provider } from 'react-redux';
import store from './redux/store';
import HomePage from './componants/homePage';
import Header from './componants/header';
import LogIn from './componants/logIn';

function App() {
  return (
    <div className="App">


      <Provider store={store}>
        <Header></Header>
        <body style={{display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center'}}>
        <HomePage></HomePage>
        <LogIn></LogIn>
        {/* <Tasks></Tasks>
        <AddChild></AddChild> */}
        </body>
      </Provider>
    </div>
  );
}

export default App;

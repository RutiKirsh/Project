import logo from './logo.svg';
import './App.css';
import Tasks from './componants/tasks';
import { Provider } from 'react-redux';
import store from './redux/store';
import SignUp from './componants/signUp';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
      <SignUp></SignUp>
      <Provider store={store}>
        <Tasks></Tasks>
        
      </Provider>
    </div>
  );
}

export default App;

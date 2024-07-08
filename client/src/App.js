import logo from './logo.svg';
import './App.css';
import Tasks from './componants/tasks';
import { Provider } from 'react-redux';
import store from './redux/store';
import AddChild from './componants/addChild';

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
      <Provider store={store}>
        <Tasks></Tasks>
        <AddChild></AddChild>
      </Provider>
    </div>
  );
}

export default App;

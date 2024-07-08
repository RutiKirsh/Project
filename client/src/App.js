import './App.css';
import Tasks from './componants/tasks';
import { Provider } from 'react-redux';
import store from './redux/store';
import AddChild from './componants/addChild';
import HomePage from './componants/homePage';
import Header from './componants/header';

function App() {
  return (
    <div className="App">


      <Provider store={store}>
        <Header></Header>
        <HomePage></HomePage>
        {/* <Tasks></Tasks>
        <AddChild></AddChild> */}
      </Provider>
    </div>
  );
}

export default App;

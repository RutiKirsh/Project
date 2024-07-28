import './App.css';
// import 'bootstrap/dist/css/bootstrap.min.css';
// import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import { Provider } from 'react-redux';
import store from './redux/store';
import HomePage from './componants/homePage';
import Header from './componants/header';
import Tasks from './componants/tasks';
import LogIn from './componants/logIn';
import Account from './componants/account';
import AddTask from './componants/addTask';
import ChildTasks from './componants/child\'sTasks';
import MyTask from './componants/myTask';
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {

  return (
    <div className="App">
      <Provider store={store}>
        <BrowserRouter>
          <Header />
          <main style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center' }}>
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/tasks" element={<Tasks />} />
              <Route path="/child-tasks" element={<ChildTasks />} />
              <Route path="/log-in" element={<LogIn />} />
              <Route path='/account' element={<Account />} />
              <Route path='/add-task' element={<AddTask />} />
              <Route path='/my-task/' element={<MyTask />} />
            </Routes>
          </main>
        </BrowserRouter>
      </Provider>
    </div>
  );
}

export default App;

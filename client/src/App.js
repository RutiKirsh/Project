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
import Account from './componants/account';
import AddTask from './componants/addTask';
import AddChild from './componants/addChild';
import ChildTasks from './componants/child\'sTasks';
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
// import Navigator from './componants/navigator';

// function App() {
//   return (
//     <div className="App">


//       <Provider store={store}>
//         <Header></Header>
//         <body style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center' }}>
//           <BrowserRouter>
//             <Routes>
//               <Route exact path="/" element={<HomePage />} />
//               <Route exact path="/tasks" element={<Tasks />} />
//               <Route exact path='/child-tasks' element={<ChildTasks/>}/>
//               <Route exact path="/log-in" element={<LogIn />} />
//             </Routes>
//           </BrowserRouter>
//           {/* <HomePage></HomePage>
//           <LogIn></LogIn>
//           <Navigator></Navigator>
//           <Tasks></Tasks>
//           <AddChild></AddChild>
//           <ChildTasks></ChildTasks> */}
//         </body>
//       </Provider>
//     </div>
//   );
// }

// export default App;

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
            </Routes>
          </main>
        </BrowserRouter>
      </Provider>
    </div>
  );
}

export default App;

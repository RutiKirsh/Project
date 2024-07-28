import { combineReducers } from "redux";
import { taskReducer } from "./taskReducer";
import { userReducer } from "./userReducer";
import { myTaskReducer } from "./myTaskReducer";

export const allReducers = combineReducers({
    taskReducer: taskReducer,
    userReducer: userReducer,
    myTaskReducer: myTaskReducer
});


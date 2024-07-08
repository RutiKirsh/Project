import { combineReducers } from "redux";
import { taskReducer } from "./taskReducer";
import { userReducer } from "./userReducer";

export const allReducers = combineReducers({
    taskReducer: taskReducer,
    userReducer: userReducer
});


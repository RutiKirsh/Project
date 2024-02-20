import {combineReducers} from "redux";
import { taskReducer } from "./TaskReducer";

export const allReducers = combineReducers({
    taskReducer : taskReducer
})


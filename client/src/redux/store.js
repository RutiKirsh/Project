import { createStore } from "redux";
import { allReducers } from "./reducers";

const store = createStore(
    allReducers
);
store.getState();
export default store;
import { createStore } from "../../node_modules/redux/dist/redux";
import { allReducers } from "./reducers";

const store = createStore(
    allReducers
);
store.getState();
export default store;
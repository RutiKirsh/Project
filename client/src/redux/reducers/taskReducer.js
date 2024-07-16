const tasks = [];
export const taskReducer = (state = tasks, action) => {
    switch(action.type){
        case "ADDONETASK": {
            return [...state, action.task];
        }
        case "ADDMANYTASKS": {
            return [...state, ...action.tasks];
        }
        case "DELETETASK": {
            return state.filter((item) => item.Id !== action.task.Id);
        }
        case "UPDATETASK": {
            console.log(action.task);
            return state.map((item) => item.Id === action.task.Id? {...item,...action.task} : item);
        }
        default: return state;
    }
}
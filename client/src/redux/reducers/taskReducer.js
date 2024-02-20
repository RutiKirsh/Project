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
            return state.filter((item) => item.Id != action.task.Id);
        }
        default: return state;
    }
}
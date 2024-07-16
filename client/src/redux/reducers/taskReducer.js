const tasks = [];
export const taskReducer = (state = tasks, action) => {
    switch (action.type) {
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
            if (action.task != null) {
                console.log(action.task.id);
                return state.map((task) => action.task.id == task.id ? { ...task, ...action.task }  : task);
            }
            return state;
        }
        default: return state;
    }
}
const myTask = {};

export const myTaskReducer = (state = myTask, action) => {
    switch(action.type){
        case "SET": {
            console.log(action.task)
            return {...state, ...action.task};
        }
        case "DELETE": {
            return {};
        }
        default: return state;
    }
}
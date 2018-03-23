import React from 'react';
import TaskCard from './taskCard';
import TaskModal from './taskModal';
/*
***** PROPS *****
tasks - array - array of tasks
task - object - modal's current task
createTask - function - create new task
editTask - function - edit selected task
handleInputChange - function
submitTask - function - handles modal submit
deleteTask - function - delete selected task
onClick={props.createTask}
 */
const TaskIndex = props => {

    let rows = props.tasks.map(task => 
        <TaskCard  
            colSize={"col-md-4"}  
            task={task}
            {...task}
            key={task.id}
            editTask={props.editTask}
            deleteTask={props.deleteTask}
        />
    );

    return (
        <div className="container mt-3">
            <div className="row mb-2">
                <h3 className="mx-auto font-weight-bold">Your Tasks</h3>
            </div>
            <div className="row mb-3">
                <button className="btn btn-outline-primary btn-lg btn-block" data-toggle="modal" data-target="#taskModal" >Create New Task</button>
            </div>
            <div>
                <div className="card-deck mb-3 text-center">
                    {rows}
                </div>
            </div>
            <TaskModal task={props.task} handleInputChange={props.handleInputChange} submitTask={props.submitTask} />
        </div>
    );
}

export default TaskIndex;
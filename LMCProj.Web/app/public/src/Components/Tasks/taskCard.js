import React from 'react';

/*
***** PROPS *****
task - object with properties
    title - string - task title
    description - string task description
    date - datetime - task date
    id - int - task id
editTask - function - function to edit task, receives id as parameter
deleteTask - function - function to delete task, receives id as parameter
 */
const TaskCard = props => {
    let task = props.task;
    return (
        <div className="col-md-4">
            <div className="card mb-4 box-shadow">
                <div className="card-header">
                    <h5 >
                        {task.title}
                    </h5>
                </div>
                <div className="card-body">
                    <h5 className="card-title">{task.date}</h5>
                    <p className="card-text">{task.description}</p>
                </div>
                <div className="card-footer text-muted">
                    <div className="w-33 text-left">
                        2 days ago
                    </div>
                    <div className="w-66 text-right">
                        <button className="btn btn-outline-info btn-sm" onClick={() => props.editTask(task.id)}>Edit Task</button>
                        <button className="btn btn-outline-danger btn-sm" onClick={() => props.deleteTask(task.id)}>Delete Task</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default TaskCard;
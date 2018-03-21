import React from 'react';
/* 
***** PROPS *****
handleInputChange - function - binds event to function and passes it in as param
task - object - task object with properties
    title - string
    description - string
    date - datetime
submitTask - function - submits task for creation or editing
*/
const TaskModal = props => {
    let task = props.task;

    return (
        <div className="modal fade" id="taskModal" role="dialog" aria-labelledby="taskModalLabel" aria-hidden="true">
            <div className="modal-dialog" role="document">
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title" id="taskModalLabel">Task Form</h5>
                        <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div className="modal-body">
                        <div className="form-row">
                            <div className="form-group col-md-12">
                                <label htmlFor="title" className="col-form-label"><strong>Task Title: </strong></label>
                                <input type="text" onChange={(e) => props.handleInputChange(e)} name="title" value={task.title} className="form-control" />
                            </div>
                        </div>
                        <div className="form-row">
                            <div className="form-group col-md-12">
                                <label htmlFor="description" className="col-form-label"><strong>Task Description: </strong></label>
                                <textarea type="textarea" onChange={(e) => props.handleInputChange(e)} name="description" value={task.description} className="form-control" />
                            </div>
                        </div>
                        <div className="form-row">
                            <div className="form-group col-md-6">
                                <label htmlFor="date" className="col-form-label">Task Date: </label>
                                <input type="datetime-local" onChange={(e) => props.handleInputChange(e)} value={task.date} name="date" className="form-control" />
                            </div>
                        </div>
                    </div>
                    <div className="modal-footer">
                        <button type="button" className="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" onClick={props.submitTask} className="btn btn-primary">Submit Task</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default TaskModal;
import React from 'react';
import {FormattedDate, FormattedTime} from 'react-intl';

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
    let date = props.date.substring(0, 10);
    let time = props.date.substring(11, 22);

    let currentDate = Date.now();
    let UTCDiff = new Date().getTimezoneOffset();
    //converting UTCDiff to milliseconds
    UTCDiff = UTCDiff*60000;
    console.log(UTCDiff);
    let currentUTCDate = currentDate + UTCDiff;

    let taskDate = Date.parse(props.date);
    let timeToTask = taskDate - currentDate;
    let weeksToTask = Math.floor(timeToTask/(1000*60*60*24*7));
    let daysToTask = Math.floor(timeToTask/(1000*60*60*24));
    let hoursToTask = Math.floor(timeToTask/(1000*60*60));
    let displayDate = 0;
    if (weeksToTask >= 1) {
        displayDate = "In " + weeksToTask + " weeks"
    } else if (daysToTask <= 6 && daysToTask >= 1) {
        if (daysToTask === 1) {
            displayDate = "In " + daysToTask + " day"
        } else{
            displayDate = "In " + daysToTask + " days"
        }
    } else if (hoursToTask <= 23) {
        displayDate = "In " + hoursToTask + " hours"
    }
    console.log(displayDate);
    // console.log(hoursToTask);
    // console.log(daysToTask);
    // console.log(weeksToTask);
    // console.log(timeToTask);
    // console.log("Task Date: " + taskDate);
    // console.log("Current Date: " + currentDate);
    // console.log(taskDate - currentUTCDate);


    return (
        <div >
            <div className="card mb-4 box-shadow">
                <div className="card-header">
                    <h5 >
                        {task.title}
                    </h5>
                </div>
                <div className="card-body">
                    <h5 className="card-title"> 
                        <FormattedDate 
                            value={date}
                            year='numeric'
                            month='long'
                            day='2-digit'
                        />
                    </h5>
                    <p className="card-text">{task.description}</p>
                    <div className="text-right text-muted">
                        {displayDate}
                    </div>
                </div>
                <div className="card-footer text-muted">
                    <div className="w-66 text-right">
                        <button className="btn btn-outline-info btn-sm mr-5 text-left" data-toggle="modal" data-target="#taskModal" onClick={() => props.editTask(task.id)}>Edit Task</button>
                        <button className="btn btn-outline-danger btn-sm" onClick={() => props.deleteTask(task.id)}>Delete Task</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default TaskCard;
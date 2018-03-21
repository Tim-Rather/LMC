import React, { Component } from 'react';
import TaskIndex from '../Components/Tasks/taskIndex';
import axios from 'axios';

class TaskManager extends Component {
    constructor(props) {
        super(props)
        this.state = {
            taskList: [],
            task: {
                title: '',
                description: '',
                date: '',
                id: 0
            }
        }
    }

    /***Event Handlers***/
    handleInputChange = e => {
        const target = e.target;
        const name = target.name;
        const value = target.value;

        let newTask = this.state.task;
        newTask[name] = value;
        this.setState({
            task: newTask
        });
    }

    handleSubmit = () => {
        let newTaskList = this.state.taskList;
        let task = this.state.task;
        newTaskList.push(task);
        this.setState({
            taskList: newTaskList,
            task: {
                title: '',
                description: '',
                date: '',
                id: 0
            }
        })
    }

    handleEdit = id => {

    }

    handleDelete = id => {
        
    }

    render() {
        return (
            <div>
                <TaskIndex 
                    tasks={this.state.taskList} 
                    task={this.state.task} 
                    submitTask={this.handleSubmit} 
                    handleInputChange={this.handleInputChange} 
                    editTask={this.handleEdit} 
                    deleteTask={this.handleDelete}/>
            </div>
        );
    }

}
/**
tasks - array - array of tasks
task - object - modal's current task
createTask - function - create new task
editTask - function - edit selected task
handleInputChange - function
submitTask - function - handles modal submit
deleteTask - function - delete selected task 
 */

export default TaskManager;
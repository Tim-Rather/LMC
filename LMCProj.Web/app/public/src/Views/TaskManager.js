import React, { Component } from 'react';
import TaskIndex from '../Components/Tasks/taskIndex';
import axios from 'axios';
import { DotLoader } from 'react-spinners';

class TaskManager extends Component {
    constructor(props) {
        super(props)
        this.state = {
            loading: true,
            taskList: [],
            task: {
                title: '',
                description: '',
                date: ''
            }
        }
    }

    componentDidMount(){
        this.getTasks();
    }

    getTasks = () => {
        axios.get('/api/tasks/getbyid/2')
        .then(resp => {
            console.log(resp);
            console.log(resp.data.items);
            this.setState({
                taskList: resp.data.items,
                loading: false
            })
        }, err => console.error(err))
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
        let task = this.state.task;
        let date = new Date(task.date).toISOString();
        task.date = date;
        // console.log(task.date);
        task.accountId = 2;
        if (task.id == undefined) {
            return axios.post('/api/tasks', task)
            .then(resp => {
                console.log(resp)
                this.getTasks();
            }, err => console.log(err))
        }
        axios.put('/api/tasks', task)
        .then(resp => {
            console.log(resp)
            this.getTasks() }, 
            err => console.log(err)
        )
        this.setState({
            task: {
                title: '',
                description: '',
                date: ''
            }
        })
    }

    handleEdit = id => {
        let tasks = this.state.taskList;
        let index = tasks.findIndex(task => task.id == id);
        let editTask = tasks[index];
        let dateMil = Date.parse(editTask.date);
        let UTCDiff = new Date().getTimezoneOffset();
        //converting UTCDiff to milliseconds
        UTCDiff = UTCDiff*60000;

        let convertedDateMil = dateMil - (UTCDiff*2);
        console.log(convertedDateMil);

        let convertedDate = new Date(convertedDateMil).toISOString();
        console.log(convertedDate);
        editTask.date = convertedDate.substring(0, convertedDate.length-2)

        this.setState({
            task: editTask
        })
    }

    handleDelete = id => {
        axios.delete('/api/tasks/' + id)
        .then(resp => {
            console.log(resp)
            this.getTasks();
            }, 
            err => console.log(err)
        )
    }

    render() {
        return (
            <div>
                {this.state.loading ?
                <div className="sweet-loading container h-100 mt-5 pt-5">
                    <div className="row h-100 mt-5 pt-5 justify-content-center align-items-center">
                        <DotLoader
                            className="mt-5 pt-5"
                            size={100}
                            color={'#17a2b8'} 
                            loading={this.state.loading} 
                        />
                    </div>
                </div>
                :
                <TaskIndex 
                    tasks={this.state.taskList} 
                    task={this.state.task} 
                    submitTask={this.handleSubmit} 
                    handleInputChange={this.handleInputChange} 
                    editTask={this.handleEdit} 
                    deleteTask={this.handleDelete}/>
                }
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
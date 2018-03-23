import React, { Component } from 'react';
import axios from 'axios';
import { DotLoader } from 'react-spinners';
import TaskCard from '../Components/Tasks/taskCard';
import { LinkCard } from './Links';
import { FormattedDate } from 'react-intl';
import ProfileModal from '../Components/Profile/profileModal';

class Profile extends Component {
    constructor(props){
        super(props)
        this.state = {
            loading: true,
            taskList: [],
            linkList: [],
            user: {}
        }
    }

    componentDidMount(){
        this.getUser();
        this.getTasksAndLinks();
    }
    //realized here I probably should have used redux
    getTasksAndLinks = () => {
        let tasks = []
        let newLinks = [];
        axios.get('/api/tasks/getbyid/2')
        .then(resp => {
            console.log(resp.data.items);
            tasks = resp.data.items
        }).then(
            axios.get('/api/links')
            .then(resp => {
                console.log(resp)
                newLinks = resp.data.items;
                this.setState({
                    taskList: tasks,
                    linkList: newLinks,
                    loading: false
                })
            }
            , err => console.log(err), err => console.log(err))
        )
    }
    
    getUser = () => {
        let newUser = {};
        axios.get('/api/people/getbyid/2')
        .then(resp => {
            console.log(resp);
            newUser = resp.data.item;
            console.log(newUser);
            console.log(newUser.firstName);
            this.setState({user: newUser})
            console.log(this.state.user);
        }, err => console.log(err))

    }

    /***Event Handlers***/
    handleInputChange = e => {
        const target = e.target;
        const name = target.name;
        const value = target.value;

        let newuser = this.state.user;
        newuser[name] = value;
        this.setState({
            user: newuser
        });
    }

    editProfile = e => {
    }
    
    updateProfile = () => {
        let user = this.state.user;
        axios.put('/api/people', user)
        .then(resp => console.log(resp), err => console.log(err))
    }

    

    render(){
        let tasks = this.state.taskList.map(task => 
            <TaskCard
                colSize={"mt-4"}  
                task={task}
                {...task}
                key={task.id}
            />
        );

        let links = this.state.linkList.map((link, index) => 
            <LinkCard
                formatting={"mb-3 mt-4"}
                {...link}
                link={link}
                key={index}
            />
        );

        let user = this.state.user;
        console.log(user);

        return (
            <div className="row">
                <ProfileModal handleInputChange={this.handleInputChange} submitProfile={this.updateProfile} profile={user} />
                <div className="col-3">
                    <div className="card shadow-box mt-4 ml-5">
                        <img className="card-img img-fluid rounded mx-auto" src={user.image} alt="" />
                        <div className="card-body">
                            <h5 className="card-title text-center">{user.firstName} {user.lastName}'s Profile</h5>
                        </div>
                        <ul className="list-group list-group-flush">
                            <li className="list-group-item"><p className="card-text mx-auto">{user.description}</p></li>
                            <li className="list-group-item">Birthday: 
                                <FormattedDate 
                                    value={user.dob}
                                    year='numeric'
                                    month='long'
                                    day='2-digit'
                                />
                            </li>
                            <li className="list-group-item"><button className="btn btn-outline-info btn-lg btn-block" data-toggle="modal" data-target="#profileModal" onClick={() => this.editProfile(user.id)}>Edit Profile</button></li>
                        </ul>
                    </div>
                </div>
                {this.state.loading ?
                <div className="sweet-loading row h-100 ml-5 pl-5 mt-5 pt-5">
                    <div className="h-100 mt-5 ml-5 pl-5 pt-5 justify-content-center align-items-center">
                        <DotLoader
                            className="mt-5 ml-5 pl-5 pt-5"
                            size={100}
                            color={'#17a2b8'} 
                            loading={this.state.loading} 
                        />
                    </div>
                </div>
                :
                <div className="col-5 container-fluid">
                    {links}    
                </div>
                
                }
                <div className="col-3 mr-5">
                    {tasks}
                </div>
            </div>
        );
    }
}

export default Profile
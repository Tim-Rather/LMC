import React, { Component } from 'react';
import { $ } from 'jquery';
// import { $ } from 'jquery/dist/jquery.slim';

class Home extends Component {

    componentDidMount() {
        $("#navigationBar").hide();
    }

    render(){
        return(
           <div className="cover-container d-flex h-100 p-3 mx-auto flex-column">
               you did it
           </div>
        );
    }
}

export default Home;
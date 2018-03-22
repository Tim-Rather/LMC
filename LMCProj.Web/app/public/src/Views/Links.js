import React from 'react';
import axios from 'axios';

class Links extends React.Component {
    constructor(props){
        super(props)
        this.state = {
            links: []
        }
    }

     componentDidMount(){
        this.getLinks();
    }

    getLinks = () => {
        let newLinks = [];
        axios.get('/api/links')
        .then(resp => {
            console.log(resp)
            newLinks = resp.data.items;
            this.setState({
                links: newLinks
            })
        }
        , err => console.log(err))
    }

    render(){
        let links = this.state.links.map((link, index) => 
            <LinkCard 
            {...link}
            link={link}
            key={index}
             />
        )
        
        return (
            <div className="card-deck">
                {links}
            </div>
        );
    }
}

const LinkCard = props => {

    let link = props.link

    return(
        <div className="card">
        <img className="card-img-top" src={link.image} alt="" />
        <div className="card-body">
            <h5 className="card-title"><a href={link.url}>{link.title}</a></h5>
            <p className="card-text">{link.description}</p>
        </div>
    </div>

    );
}



export default Links;
import React from 'react';
import axios from 'axios';
import '.././index.css';
import { DotLoader } from 'react-spinners';


class Links extends React.Component {
    constructor(props){
        super(props)
        this.state = {
            loading: true,
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
                links: newLinks,
                loading: false
            })
        }
        , err => console.log(err))
    }

    render(){
        let links = this.state.links.map((link, index) => 
            <LinkCard 
                formatting={"col-md-4 mb-3 h-100"}
                {...link}
                link={link}
                key={index}
             />
        )
        
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
                <div className="container card-column">
                    <div className="card-deck row">
                        {links}
                    </div>
                </div>
                }
            </div>
        );
    }
}

export const LinkCard = props => {

    let link = props.link

    return(
        <div className={props.formatting}>
            <div className="card shadow-box h-100">
                <a href={link.url}><img className="card-img img-fluid rounded mx-auto" src={link.image} alt="" /></a>
                <div className="card-header h-100">
                    <h5 className="card-title"><a href={link.url}><strong>{link.title}</strong></a></h5>
                </div>
                <div className="card-body h-100">
                    <p className="card-text h-100">{link.description}</p>
                </div>
            </div>
        </div>
    );
}



export default Links;
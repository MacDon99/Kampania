import React from 'react'
import axios from "axios"
import List from "./campaignList"


class main extends React.Component {

    componentDidMount(){
        axios.get("https://localhost:5001/api/campaign/all")
            .then(result => {
                this.setState({
                    campaigns: result.data.campaigns
                })
            })
            .catch()
    }
    edit = (id) =>{
        console.log(id)
        this.props.enableEditMode()
    }
    state = {
        campaigns: []
    }

    render(){
        if(this.props.Mode == "Home"){
            return(
                <div>
                    <List campaignItems={this.state.campaigns} edit = {this.edit}/>
                </div>
            )
        } else if (this.props.Mode == "Add"){
            return(
                <div>
                    <form>
                        <label>Name</label><br/>
                        <input type="text"/><br/>
                        <label>Description</label><br/>
                        <input type="text"/><br/>
                        <label>Cost</label><br/>
                        <input type="text"/><br/>
                        <input type="submit" value="Submit"></input>
                    </form>
                </div>
            )
        } else if (this.props.Mode == "Edit"){
            return (
                <div>
                    Edit
                </div>
            )
        } else {
            return(
                <div>
                    <p>{console.log(this.props.raport)}</p>
                </div>
            )
        }
}
}
export default main
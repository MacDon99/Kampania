import React, { Component } from 'react'

export class Item extends Component {
    edit = event => () => {
        this.props.edit(this.props.item.id)
    }
    render() {
        return (
            <div>
                <hr/>
                {this.props.item.name}<br/>
                {this.props.item.description}<br/>
                {this.props.item.cost}<br/>
                <button>Edit</button>
                <hr/>
            </div>
        )
    }
}

export default Item

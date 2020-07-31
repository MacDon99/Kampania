import React, { Component } from 'react'
import Item from './campaignItem'

export default class Items extends Component {
    render() {
            return this.props.campaignItems.map((item) => <h3 key={item.id}><Item item = {item} edit = {this.props.edit}/></h3>)
    }
}

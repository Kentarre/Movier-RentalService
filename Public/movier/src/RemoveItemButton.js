import React, { Component } from 'react';

class RemoveItemButton extends Component {
    constructor(props){
        super(props)
    }

    render() {
        return (
        <button type="button" class="close" data-dismiss="modal" aria-label="Close" onClick={this.props.handleClick}>
            <span aria-hidden="true">&times;</span>
        </button>);
    }
}

export default RemoveItemButton
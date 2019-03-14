import React, { Component } from 'react';
import { AppContext } from './AppContext.js';

class AddButton extends Component {
    constructor(props) {
        super(props)

        this.state = {
            disabled: false
        }
    }

    handleClick = () => {
        this.setState({
            disabled: true
        })
    }

    render() {
        return (
            <AppContext.Consumer>
                {(context) => (<button type="button" className="btn btn-sm btn-outline-success" onClick={() => { context.setFilms(this.props.film); this.handleClick() }} disabled={this.state.disabled}>Add to cart</button>)}
            </AppContext.Consumer>)
    }
}

export default AddButton
import React, { Component } from 'react';
import { AppContext } from './AppContext.js';
import { throws } from 'assert';
import { th } from 'date-fns/esm/locale';

class AddButton extends Component {
    constructor(props) {
        super(props)

        this.state = {
            disabled: false
        }
    }

    handleClick = (context) => {
        context.selectedFilms.push(this.props.film);
        context.setFilms(context.selectedFilms);  
        
        this.setState({
            disabled: true
        })
    }

    render() {
        return (
            <AppContext.Consumer>
                {(context) => (<button type="button" className="btn btn-sm btn-outline-success" onClick={() => {  
                        this.handleClick(context); 
                    }} disabled={this.state.disabled}>Add to cart</button>)}
            </AppContext.Consumer>)
    }
} 

export default AddButton
import React, { Component } from 'react';
import { AppContext } from './AppContext.js';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";

class Cart extends Component{
    render(){
        return (
            <div className="form-inline mt-2 mt-md-0">
                <AppContext.Consumer>
                    {(context) => (<Link className="btn btn-outline-success my-2 my-sm-0" to="/checkout">Checkout <span className="badge badge-success">{context.selectedFilms.length}</span> </Link>)}    
                </AppContext.Consumer>
            </div>);
    }
}

export default Cart;
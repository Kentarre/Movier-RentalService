import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import Home from './Home.js';
import List from './List.js';
import Checkout from './Checkout.js';

class Main extends Component {
    render() {
        return (
            <Switch>
                <Route exact path="/" component={Home} />
                <Route path="/films" component={List} />
                <Route path="/checkout" component={Checkout} />
            </Switch>
        );
    }
}

export default Main;
import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link, Switch } from "react-router-dom";
import Checkout from './Checkout.js';

class Nav extends Component {
  constructor(){
    super()

    this.state = {
      homeActive: false,
      filmsActive: false,
      ordersActive: false
    }
  }

  toggleClass(navItem){
    Object.keys(this.state).map(i => {
      if (i != navItem + 'Active'){
        this.setState({ [i]: false});
      }else{
        this.setState({ [i]: true});
      }
    });   
  }

  render() {
    return (
      <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
        <a className="navbar-brand" href="#">Movier: Film rent</a>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse"
          aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarCollapse">
          <ul className="navbar-nav mr-auto">
            <li className={this.state.homeActive ? 'nav-item active' : 'nav-item'} onClick={this.toggleClass.bind(this, 'home')}>
              <Link className="nav-link" to="/">Home</Link>
            </li>
            <li className={this.state.filmsActive ? 'nav-item active' : 'nav-item'} onClick={this.toggleClass.bind(this, 'films')}>
              <Link className="nav-link" to="/films">Films</Link>
            </li>
            <li className={this.state.ordersActive ? 'nav-item active' : 'nav-item'} onClick={this.toggleClass.bind(this, 'orders')}>
              <Link className="nav-link" to="/orders">Orders</Link>
            </li>
          </ul>
          <Checkout></Checkout>
        </div>
      </nav>);
  }
}

export default Nav;
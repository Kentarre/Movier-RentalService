import React, { Component } from 'react';
import Nav from './Nav.js';
import Main from './Main.js';

class App extends Component {
  render(){
    return(
      <div>
        <Nav />
        <Main />
      </div>
    );
  }
}

export default App;

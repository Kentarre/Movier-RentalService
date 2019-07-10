import React, { Component } from 'react';
import { AppContext } from './AppContext.js'
import Nav from './Nav.js';
import Main from './Main.js';

class App extends Component {
  constructor(props) {
    super(props)

    this.state = {
      selectedFilms: [],
      setFilms: (a) => {
        this.setState({
          selectedFilms: a
        })
      }
    }
  }

  render() {
    return (
      <AppContext.Provider value={this.state}>
        <div>
          <Nav />
          <Main />
        </div>
      </AppContext.Provider>
    );
  }
}

export default App;

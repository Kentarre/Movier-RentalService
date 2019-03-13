import React, { Component } from 'react';
import { AppContext } from './AppContext.js'
import Nav from './Nav.js';
import Main from './Main.js';

class App extends Component {
  constructor(props) {
    super(props)


    this.state = {
      selectedFilms: [],
      length: 0,
      getLength: () => {
        this.setState({
          length: this.state.selectedFilms.length
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

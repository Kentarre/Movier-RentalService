import React, { Component } from 'react';
import Nav from './Nav.js';
import Film from './Film.js';

class App extends Component {
  constructor(props) {
    super(props);

    this.state = {
      error: null,
      isLoaded: false,
      films: []
    }

    this.getFilms = this.getFilms.bind(this);
  }

  componentDidMount(){
      this.getFilms();
  }

  async getFilms() {
    fetch("https://localhost:44358/api/home/getfilms")
      .then(res => res.json())
      .then((result) => {
        this.setState({
          isLoaded: true,
          films: result
        });
      },
    (error) => {
      this.setState({
        isLoaded: true,
        error
      })
    });
  }

  render() {
    const {error, isLoaded, result} = this.state;

    if (error){
      return <div>{error.message}</div>
    }else if (!isLoaded){
      return <div>Loading</div>
    }
    
    return (
      <div>
        <Nav></Nav>
        <main role="main" className="container">
          <div className="jumbotron">
            <h1>Films list:</h1>
            <div className="row">
              <Film films={this.state.films}/>
            </div>
          </div>
        </main>
      </div>
    );
  }
}

export default App;

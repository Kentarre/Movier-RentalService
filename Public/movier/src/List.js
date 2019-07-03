import React, { Component } from 'react';
import Nav from './Nav.js';
import Film from './Film.js';

class List extends Component {
    constructor(props) {
        super(props);

        this.state = {
            error: null,
            isLoaded: false,
            films: [],
            selectedFilms: []
        }

        this.getFilms = this.getFilms.bind(this);
        this.handleClick = this.handleClick.bind(this);
    }

    componentDidMount() {
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

    handleClick(f){
        this.state.selectedFilms.push(f);
        console.log(this.state.selectedFilms);
    }

    render() {
        const { error, isLoaded, result } = this.state;

        if (error) {
            return ( 
            <div>
                <main role="main" className="container">
                    <div className="jumbotron">
                        <h1>Films list:</h1>
                        <div className="row">
                            {error.message}
                        </div>
                    </div>
                </main>
            </div>)
        } else if (!isLoaded) {
            return (
            <div>
                <main role="main" className="container">
                    <div className="jumbotron">
                        <h1>Films list:</h1>
                        <div className="row">
                            <div class="spinner-border" role="status">
                                <span class="sr-only">Loading...</span>
                            </div>
                        </div>
                    </div>
                </main>
            </div>)
        }

        return (
            <div>
                <main role="main" className="container">
                    <div className="jumbotron">
                        <h1>Films list:</h1>
                        <div className="row">
                            <Film films={this.state.films} onClick={this.handleClick}/>
                        </div>
                    </div>
                </main>
            </div>
        );
    }
}

export default List;
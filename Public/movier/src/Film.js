import React, { Component } from 'react';

class Film extends Component {
    render() {
        return (
            <>
                {this.props.films.map(f => {
                    return (
                        <div className="col-md-4">
                            <div className="card mb-4 shadow-sm">
                                <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" preserveAspectRatio="xMidYMid slice" focusable="false" role="img" aria-label="Placeholder: Thumbnail"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"></rect><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>
                                <div className="card-body">
                                    <h5 className="card-title">{f.title}</h5>
                                    <p className="card-text">{f.description}</p>
                                    <div className="d-flex justify-content-between align-items-center">
                                        <button type="button" className="btn btn-sm btn-outline-success">Add to cart</button>
                                        <small className="text-muted">{new Date(f.releaseDate).toLocaleDateString()}</small>
                                    </div>
                                </div>
                            </div>
                        </div>
                    );
                })}
            </>
        )
    }
}

export default Film;
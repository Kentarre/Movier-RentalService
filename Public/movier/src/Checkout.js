import React, { Component } from 'react';

class Checkout extends Component{
    render(){
        return (
            <div className="form-inline mt-2 mt-md-0">
                <button className="btn btn-outline-success my-2 my-sm-0" type="submit">Checkout <span className="badge badge-success">4</span> </button>
            </div>);
    }
}

export default Checkout;
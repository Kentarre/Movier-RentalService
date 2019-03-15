import React, {Component} from 'react'

class CheckoutButton extends Component{
    constructor(props){
        super(props)

        this.state = {
            checkOutModel: this.props.checkOutModel
        }
    }

    handleClick = () => {
        console.log(this.state.checkOutModel)
        this.postData();
    }

    postData = () => {
        var array = this.state.checkOutModel;
        var arrayForSending = []

        Object.keys(array).map(x => {
            var obj = array[x];

            arrayForSending.push(obj);
        });

        fetch('https://localhost:44358/api/rental/start', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(arrayForSending)
        })
    }

    render(){ 
        return(<button class="btn btn-primary btn-lg btn-block" onClick={this.handleClick}>Checkout</button>)
    }
}

export default CheckoutButton
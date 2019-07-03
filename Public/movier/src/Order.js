import React, { Component } from 'react';
import StopRentalButton from './StopRentalButton.js';
import DownloadButton from './DonwloadButton';

class Order extends Component {
    constructor(props) {
        super(props);

        this.state = {
            rental: this.props.rentalObj,
            invoiceReady: false,
            stopRentalButtonStyle: { 
                display: '',
                marginTop: '5px'
            }
        }

        this.dateToYMD = this.dateToYMD.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.requestRentalStop = this.requestRentalStop.bind(this);
        this.checkIfReady = this.checkIfReady.bind(this);
    }

    handleClick(id) {
        this.requestRentalStop(id);

        this.setState({
            stopRentalButtonStyle: { display: 'none' }
        })
    }

    dateToYMD(date) {
        var d = date.getDate();
        var m = date.getMonth() + 1;
        var y = date.getFullYear();

        return '' + (d <= 9 ? '0' + d : d) + '.' + (m <= 9 ? '0' + m : m) + '.' + y;
    }

    requestRentalStop(rentId) {
        fetch('https://localhost:44358/api/rental/stop/' + rentId, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            }
        })
    }

    checkIfReady(orderId) {
        fetch("https://localhost:44358/api/file/isready/" + orderId)
            .then(res => res.json())
            .then((result) => {
                if (result.status === "success") {
                    window.open("https://localhost:44358" + result.url);

                    return;
                }

                this.checkIfReady(orderId);
            })
    }

    requestDownload(orderId) {
        fetch("https://localhost:44358/api/file/create/" + orderId, { method: 'POST' })
            .then(res => res.json())
            .then((result) => {
                if (result.status == 'success') {
                    this.checkIfReady(orderId)
                }
            })
    }

    render() {
        const style = {
            color: 'red'
        }

        const itemStyle = {
            marginBottom: '5px'
        }

        return (
            <>
                <ul className="list-group-item" style={itemStyle}>
                    <li class="media">
                        <img src="https://s3.amazonaws.com/infinite.dev/images/events/3e81f8c6ba3fed35_thumb.jpg" class="mr-3" alt="..." />
                        <div class="media-body">
                            <small>Order nr: {this.state.rental.orderId}</small>
                            <h5 class="mt-0 mb-1">{this.state.rental.title}</h5>
                            {this.state.rental.description}
                        </div>
                        <ul className="list-group">
                            <li className="list-group-item">Price: {this.state.rental.price}€ </li>
                            <li className="list-group-item">Active from: {this.dateToYMD(new Date(this.state.rental.activeFrom))} </li>
                            <li className="list-group-item"> {this.state.rental.isDue ? <a style={style}>Is due from {this.dateToYMD(new Date(this.state.rental.activeTo))}</a>
                                : this.state.rental.returned !== null ? "Returned: " + this.dateToYMD(new Date(this.state.rental.returned))
                                    : this.state.rental.validUntil === 1 ? this.state.rental.validUntil + " day left"
                                        : this.state.rental.validUntil + " days left"} </li>
                            <DownloadButton handleDownload={() => this.requestDownload(this.props.rentalObj.orderId)} />
                            {this.state.rental.isRented ? <StopRentalButton handleClick={() => this.handleClick(this.state.rental.id)} stopButtonStyle={this.state.stopRentalButtonStyle}/> : ""}
                        </ul>
                    </li>
                </ul>
            </>);
    };
}

export default Order;


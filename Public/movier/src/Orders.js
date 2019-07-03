import React, { Component } from 'react';
import Order from './Order';
import DownloadButton from './DonwloadButton';

class Orders extends Component {
    constructor(props) {
        super(props);

        this.state = {
            rentals: [],
            isLoaded: false
        }

        this.getRentals = this.getRentals.bind(this);
        this.getDaysDiff = this.getDaysDiff.bind(this);
    }

    getDaysDiff(end) {
        var st = new Date();
        var en = new Date(end);
        var timeDiff = en.getTime() - st.getTime();
        var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
    
        return diffDays;
    }

    componentDidMount() {
        this.getRentals('abfefc7a-66aa-4b9e-91a4-9e968b912229');
    }

    async getRentals(id) {
        fetch("https://localhost:44358/api/home/getrentals/" + id)
            .then(res => res.json())
            .then((result) => {
                this.setState({
                    rentals: result,
                    isLoaded: true
                });
            })
    }

    render() {
        if (this.state.isLoaded) {
            return (
                <div>
                    <main role="main" className="container">
                        <div className="jumbotron">
                            <div class="list-group">
                                {
                                    this.state.rentals.map(f => {
                                        var rentalObj = {
                                            id: f.id,
                                            activeFrom: f.activeFrom,
                                            activeTo: f.activeTo,
                                            isDue: f.isDue,
                                            price: f.price,
                                            title: f.title,
                                            isRented: f.isRented,
                                            description: f.description,
                                            returned: f.returnedDate,
                                            validUntil: this.getDaysDiff(f.activeTo),
                                            orderId: f.orderId
                                        };

                                        return(<Order rentalObj={rentalObj} />);
                                    })
                                }
                            </div>
                        </div>
                    </main>
                </div>);
        };

        return (
            <div>
                <main role="main" className="container">
                    <div className="jumbotron">
                        <div class="spinner-border" role="status">
                            <span class="sr-only">Loading...</span>
                        </div>
                    </div>
                </main>
            </div>);
    }
}

export default Orders;

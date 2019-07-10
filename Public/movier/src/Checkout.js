import React, { Component } from 'react';
import { AppContext } from './AppContext.js'
import Datepicker from './Datepicker.js'
import CheckoutButton from './CheckoutButton.js'
import RemoveItemButton from './RemoveItemButton.js'

function calculatePrice(type, durationDays, availableBonus, useBonuses) {
    var tempDays;

    durationDays = useBonuses ? durationDays - getDaysDiscounted(availableBonus) : durationDays;

    if (durationDays < 1)
        return parseFloat(0).toFixed(2);

    switch (type) {
        case 0:
            return parseFloat(40 * durationDays).toFixed(2);
        case 1:
            if (durationDays <= 3)
                return parseFloat(30).toFixed(2);

            tempDays = durationDays - 3;
            return parseFloat((tempDays * 30) + 30).toFixed(2);
        default:
            if (durationDays <= 5)
                return parseFloat(30).toFixed(2);

            tempDays = durationDays - 5;
            return parseFloat((tempDays * 30) + 30).toFixed(2);
    }
}

function getDaysDiscounted(availableBonus) {
    return Math.floor(availableBonus / 25);
}

function getDaysDiff(today, tommorow) {
    var timeDiff = tommorow.getTime() - today.getTime();
    var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));

    return diffDays;
}

class Checkout extends Component {
    constructor(props) {
        super(props)

        this.state = {
            checkOutModel: [],
            user: null,
            total: 0,
            dateTo: null
        }

        this.setPeriod = this.setPeriod.bind(this);
        this.getUser = this.getUser.bind(this);
        this.getTotal = this.getTotal.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.removeItem = this.removeItem.bind(this);
    }

    componentDidMount() {
        this.getUser('abfefc7a-66aa-4b9e-91a4-9e968b912229');
    }

    getUser(id) {
        fetch("https://localhost:44358/api/home/getuser/" + id)
            .then(res => res.json())
            .then((result) => {
                this.setState({
                    user: result
                });
            })
    }

    setPeriod(id, type, rentTo) {
        let user = this.state.user;
        var rentFrom = new Date();
        var daysDiff = getDaysDiff(rentFrom, rentTo);
    
        if (daysDiff < 0)
            return;

        var price = calculatePrice(type, daysDiff, user[0].availableBonus, true);

        this.state.checkOutModel[id] = {
            filmId: id,
            price: price,
            useBonuses: true,
            rentFrom: rentFrom,
            rentTo: rentTo,
            userId: user[0].id
        }

        this.getTotal();
    }

    getTotal() {
        var total = Number(0);
        var array = this.state.checkOutModel;

        Object.keys(array).map(x => {
            var obj = array[x];

            total += Number(obj.price);
        });

        this.setState({ total: total });
    }

    handleChange(id, type, dateTo) {
        this.setPeriod(id, type, dateTo); 
    }

    removeItem(context, id){
        var filmsArray = context.selectedFilms;
        var i = filmsArray.findIndex(f => f.id === id)

        filmsArray.splice(i, 1);

        var checkout = this.state.checkOutModel;
        delete checkout[id];

        this.setState({checkOutModel: checkout});
        this.getTotal();
                
        context.setFilms(filmsArray);
    }

    render() {
        return (
            <div>
                <main role="main" className="container">
                    <div className="jumbotron">
                        <div className="row">
                            <div class="col-md-4 order-md-2 mb-4">
                                <h4 class="d-flex justify-content-between align-items-center mb-3">
                                    <span class="text-muted">Your cart</span>
                                </h4>
                                <ul class="list-group mb-3">
                                    <AppContext.Consumer>
                                        {(context) => (context.selectedFilms.map(f => {
                                            return (
                                                <li class="list-group-item d-flex justify-content-between lh-condensed" data-id={f.id}>
                                                    <div>
                                                        <h6 class="my-0">{f.title}</h6>
                                                        <Datepicker onChange={(dateTo) => {this.handleChange(f.id, f.type, dateTo); }}/>
                                                        <small className="text-muted">{typeof this.state.checkOutModel[f.id] === 'undefined' ? '' : ' - ' + this.state.checkOutModel[f.id].price + '€'}</small>
                                                    </div>
                                                    <RemoveItemButton handleClick={() => this.removeItem(context, f.id)}/>
                                                </li>
                                            )
                                        }))}
                                    </AppContext.Consumer>
                                    <li class="list-group-item d-flex justify-content-between">
                                        <span>Total: </span>
                                        <strong>{parseFloat(this.state.total).toFixed(2)}€</strong>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-8 order-md-1">
                                <h4 class="mb-3">Billing address</h4>
                                <form class="needs-validation" novalidate="">
                                    <div class="row">
                                        <div class="col-md-6 mb-3">
                                            <label for="cc-name">Name on card</label>
                                            <input type="text" class="form-control" id="cc-name" placeholder="" required="" />
                                            <small class="text-muted">Full name as displayed on card</small>
                                            <div class="invalid-feedback">
                                                Name on card is required
                                            </div>
                                        </div>
                                        <div class="col-md-6 mb-3">
                                            <label for="cc-number">Credit card number</label>
                                            <input type="text" class="form-control" id="cc-number" placeholder="" required="" />
                                            <div class="invalid-feedback">
                                                Credit card number is required
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 mb-3">
                                            <label for="cc-expiration">Expiration</label>
                                            <input type="text" class="form-control" id="cc-expiration" placeholder="" required="" />
                                            <div class="invalid-feedback">
                                                Expiration date required
                                            </div>
                                        </div>
                                        <div class="col-md-3 mb-3">
                                            <label for="cc-cvv">CVV</label>
                                            <input type="text" class="form-control" id="cc-cvv" placeholder="" required="" />
                                            <div class="invalid-feedback">
                                                Security code required
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <CheckoutButton checkOutModel={this.state.checkOutModel}/>
                                </form>
                            </div>
                        </div>
                    </div>
                </main>
            </div>
        )
    }
}

export default Checkout
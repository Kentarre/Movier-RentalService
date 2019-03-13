import React, { Component } from 'react';
import { AppContext } from './AppContext.js'

class Checkout extends Component {
    constructor(props){
        super(props)

        this.state = {
            checkOutModel: []
        }

        this.setPeriod = this.setPeriod.bind(this);
    }

    setPeriod(id, type){
        this.state.checkOutModel[id] = {
            id: id,
            price: 23,
            useBonuses: true
        }
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
                                                        <a href="#" onClick={() => this.setPeriod(f.id, f.type)}><small class="text-muted">Choose period</small></a>
                                                    </div>
                                                    <span class="text-muted">{typeof this.state.checkOutModel[f.id] === 'undefined' ? '' : this.state.checkOutModel[f.id].price + '€'}</span>
                                                </li>
                                            )
                                        }))}
                                    </AppContext.Consumer>
                                    <li class="list-group-item d-flex justify-content-between">
                                        <span>Total (USD)</span>
                                        <strong>20€</strong>
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-8 order-md-1">
                                <h4 class="mb-3">Billing address</h4>
                                <form class="needs-validation" novalidate="">
                                    <div class="row">
                                        <div class="col-md-6 mb-3">
                                            <label for="firstName">First name</label>
                                            <input type="text" class="form-control" id="firstName" placeholder="" value="" required="" />
                                            <div class="invalid-feedback">
                                                Valid first name is required.
                                            </div>
                                        </div>
                                        <div class="col-md-6 mb-3">
                                            <label for="lastName">Last name</label>
                                            <input type="text" class="form-control" id="lastName" placeholder="" value="" required="" />
                                            <div class="invalid-feedback">
                                                Valid last name is required.
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
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
                                    <hr/>
                                    <button class="btn btn-primary btn-lg btn-block" type="submit">Checkout</button>
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
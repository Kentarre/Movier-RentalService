import React, { Component } from 'react'
import DatePicker, { registerLocale, setDefaultLocale } from 'react-datepicker'
import ee from 'date-fns/locale/et'

import "react-datepicker/dist/react-datepicker.css";

class Datepicker extends Component {
    constructor(props) {
        super(props)

        this.state = {
            isOpen: false,
            endDate: null
        }

        this.handleChange = this.handleChange.bind(this);
        this.toggleCalendar = this.toggleCalendar.bind(this);
        
        registerLocale('et', ee);
        setDefaultLocale('et');
    }

    handleChange(date) {
        this.setState({ endDate: date });
        this.toggleCalendar();
        this.props.onChange(date);
    }

    toggleCalendar(e) {
        e && e.preventDefault()
        this.setState({ isOpen: !this.state.isOpen })
    }

    render() {
        return (
            <>
                <a href="#" onClick={this.toggleCalendar}><small class="text-muted">{this.state.endDate != null ? "End date: " + this.state.endDate.toLocaleDateString() : "Choose end date"}</small></a>
                {
                    this.state.isOpen && (
                        <DatePicker
                            selected={this.state.endDate}
                            onChange={this.handleChange}
                            withPortal
                            inline 
                            />
                    )
                }
            </>)
    }
}

export default Datepicker
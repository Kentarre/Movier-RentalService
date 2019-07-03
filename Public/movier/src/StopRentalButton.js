import React, {Component} from 'react'

class StopRentalButton extends Component {
    constructor(props){
        super(props)
    }

    render() {
        return (<button className="btn btn-outline-danger" style={this.props.stopButtonStyle} onClick={this.props.handleClick}>Stop rental</button>);
    }
}

export default StopRentalButton
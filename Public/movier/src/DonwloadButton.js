import React, {Component} from 'react'

class DownloadButton extends Component{
    constructor(props){
        super(props)
    }

    render(){
        const itemStyle = {
            marginTop: '5px'
        }

        return(<button className="btn btn-info" style={itemStyle} onClick={this.props.handleDownload}>Download receipt</button>);
    }
}

export default DownloadButton
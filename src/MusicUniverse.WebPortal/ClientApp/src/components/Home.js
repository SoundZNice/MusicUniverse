import React, { Component } from 'react';
import { home } from './fetch.js'

export default class Home extends Component {
    static displayName = Home.name;
    
    constructor(props){
        super(props);

        this.state = {
            loaded: false
        }
    }

    async componentDidMount ()  {
        var res = await home();
        this.setState({
            loaded: true,
            data: res,
            failed: res.failed
        })
    }

    render () {
        let content;
        if (!this.state.loaded)
            content = <label>loading...</label>
        else if (!this.state.failed && this.state.data)
            content = <label>Currently we have {this.state.data.artistsCount} artists!</label>
        else
            this.props.history.push('/500')
        return (
            <div>
                <h1>Home Page</h1>
                {content}
            </div>
        )
    }
}
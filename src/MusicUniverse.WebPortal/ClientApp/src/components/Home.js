import React, { Component } from 'react';
import { home } from './fetch.js'
import Load from './Load.js'

export default class Home extends Component {
    static displayName = Home.name;
    
    constructor(props){
        super(props);

        this.state = {
            loaded: false
        }
        this.mounted = false;
    }

    async componentDidMount ()  {
        this.mounted = true;
        var res = await home();

        if (this.mounted)
            this.setState({
                loaded: true,
                data: res,
                failed: res.failed
            })
    }

    componentWillUnmount(){
        this.mounted = false;
    }

    render () {
        let content;
        if (!this.state.loaded)
            content = <Load/>;
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
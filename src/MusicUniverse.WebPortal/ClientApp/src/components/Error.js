import React, { Component } from 'react';
import sorry from '../img/sorry.jpg'

export default class Error extends Component{
    render(){
        return(
            <div>
                <h1>Ups... :(</h1>
                <img src={sorry} alt="sowwie"></img>
            </div>
        )
    }
}

import React, { Component } from 'react';
import { artists } from './fetch.js'
import Load from './Load.js'
import { Table } from 'reactstrap';

export default class Artists extends Component {
    static displayName = Artists.name;

    constructor(props){
        super(props);

        this.state = {
            loaded: false
        }

        this.mounted = false;
    }

    async componentDidMount() {
        this.mounted = true;

        var res = await artists();

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
        else if (!this.state.failed && this.state.data.list)
            content = <Table>
                    <tbody>
                        {this.state.data.list.map(a => 
                            (<Artist key={a.id} obj={a} />))}
                    </tbody>
                </Table>
        else 
            this.props.history.push('/500')
        return (
            <div>
                <h1>Artists page</h1>
                {content}
            </div>
        )
    }
}

export const Artist = props => (
    <tr>
        <td><img src={props.obj.image}></img></td>
        <td>{props.obj.name}</td>
        <td>{props.obj.countryName}</td>
        <td>{props.obj.genres.join(', ')}</td>
        <td>{props.obj.description}</td>
    </tr>
) 


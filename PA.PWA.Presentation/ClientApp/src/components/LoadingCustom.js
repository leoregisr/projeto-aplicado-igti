import React, { Component } from 'react';
import { SpinnerRoundOutlined } from 'spinners-react';
import bootstrap from './assets/css/bootstrap.module.css';
import './Loading.css';

export default class LoadingCustom extends Component {

    constructor(props) {
        super(props);

        this.state = {
            show: false
        };
    }

    componentDidMount() {
        if (this.props.show)
            this.setState({ show: this.props.show });
    }

    componentDidUpdate(oldProps) {
        const newProps = this.props;
        if (JSON.stringify(newProps) !== JSON.stringify(oldProps)) {
            this.setState({
                show: newProps.show
            });
        }
    }

    render() {
        return (
            <>
                <div className={[bootstrap['modal-backdrop'], (this.state.show ? bootstrap['show'] : bootstrap['fade'])].join(' ')}
                    style={{
                        display: `${this.state.show ? 'block' : 'none'}`,
                        opacity: 0.2
                    }}
                />
                <div style={{
                    position: "fixed",
                    top: "50%",
                    left: "50%",
                    transform: "translate(-50%, -50%)",
                    zIndex: 9999
                }}>
                    <SpinnerRoundOutlined color="#2A5C78" size={100} enabled={this.state.show} />
                </div>
            </>

        )
    };
}
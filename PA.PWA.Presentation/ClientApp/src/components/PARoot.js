import './public-path';
import React, { Suspense } from 'react';
import ReactDOM from 'react-dom';
import bootstrap from './assets/css/bootstrap.module.css';
import AuthService from './Auth/AuthService';
import * as ComponentList from './ComponentList';
import { ToastContainer } from "react-toastify";
import './assets/css/ReactToastify.min.css';
import Loading from '../components/LoadingCustom'

export default class PARoot extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            isAuthenticated: AuthService.IsAuthenticated(),
            authError: true,
            loggedUser: {},
            showLoading: false
        };
    }

    componentDidMount() {
        this.setState({ showLoading: true })      

        if (!this.state.isAuthenticated) {
            this.RedirectToLogin();
        } else {
            this.setState({
                loggedUser: JSON.parse(sessionStorage.getItem("AuthUser")),
                authError: false,
                showLoading: false
            });
        }
    }

    RedirectToLogin() {
        this.setState({ redirect: "/" });
    }

    render() {
        if (this.state.showLoading) return <Loading show={this.state.showLoading} />

        const ComponentToRender = ComponentList[this.props.component];        
        const rootProps = { ...this.props, ...this.state };

        

        return <>
            <ToastContainer />
            <Suspense fallback={<Loading />}>
                <ComponentToRender  {...rootProps} />
            </Suspense>
        </>
    }
}

window.PARoot = {
    mount: (elementId, props) => {
        const el = document.getElementById(elementId);
        ReactDOM.render(<PARoot {...props} />, el);
    },
    unmount: (elementId) => {
        const el = document.getElementById(elementId);
        ReactDOM.unmountComponentAtNode(el);
    }
}
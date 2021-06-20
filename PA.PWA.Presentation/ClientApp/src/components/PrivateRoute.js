import React from 'react';
import { Route, Redirect } from 'react-router-dom';

function PrivateRoute({ component: Component, roles, ...rest }) {
    return (
        <Route {...rest} render={props => {
            if (!sessionStorage.getItem('AuthUser')) {                
                return <Redirect to={{ pathname: '/', state: { from: props.location } }} />
            }            
            return <Component {...props} />
        }} />
    );
}

export { PrivateRoute };
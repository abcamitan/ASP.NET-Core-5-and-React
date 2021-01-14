import React, { Component } from "react";
import { Router, Switch, Route } from "react-router-dom";

import Dashboard from "./Page/Dashboard";
import Login from "./Page/Login";
import history from './Component/History';

export default class App extends Component {
    render() : JSX.Element {
        return (
            <Router history={history}>
                <Switch>
                    <Route path="/" exact component={Login} />
                    <Route path="/Login" exact component={Login} />
                    <Route path="/Dashboard" component={Dashboard} />
                </Switch>
            </Router>
        )
    }
}
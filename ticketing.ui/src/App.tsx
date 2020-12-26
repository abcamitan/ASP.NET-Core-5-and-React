import React from "react";
import { Router, Switch, Route } from "react-router-dom";

import Dashboard from "./Dashboard";
import Login from "./Login";
import history from './History';

export default class App extends React.Component {
    render() {
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
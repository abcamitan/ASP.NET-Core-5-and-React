import React from "react";
import { Router, Switch, Route } from "react-router-dom";

import Dashboard from "./Dashboard";
import App from "./App";
import history from './History';

export default class Routes extends React.Component {
    render() {
        return (
            <Router history={history}>
                <Switch>
                    <Route path="/" exact component={App} />
                    <Route path="/Dashboard" component={Dashboard} />
                </Switch>
            </Router>
        )
    }
}
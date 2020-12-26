import React from 'react'; 

import Header from './Header' ;
import LoginForm from './LoginForm';

export default class App extends React.Component {
  render() {
    return (
      <> 
        <Header />
        <LoginForm />
      </>
    );
  }
}

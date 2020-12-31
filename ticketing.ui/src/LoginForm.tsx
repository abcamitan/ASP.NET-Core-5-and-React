import React from 'react'; 
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';

import history from './History';

const useStyles = makeStyles((theme) => ({
  root: {
    '& > *': {
      margin: theme.spacing(1),
      width: '25ch',
    },
    display: "grid",
    justifyItems: "center",
    margin: "10%",
  },
}));

export default function LoginForm() : JSX.Element {
    const classes = useStyles();
  
    return (
      <>
          <form className={classes.root} noValidate autoComplete="off">
              <TextField id="text-username" label="Username" />
              <TextField id="text-password" label="Password" type="password" />
              <Button onClick={() => history.push('/Dashboard')}>Login</Button>
          </form>
      </>
    );
  }
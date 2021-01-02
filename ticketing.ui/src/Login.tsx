import React, { Component } from 'react'; 
import { withStyles, WithStyles, createStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';

import history from './History';

const styles = (theme: { spacing: (arg0: number) => unknown; }) => createStyles({
  root: {
    '& > *': {
      margin: theme.spacing(1),
      width: '25ch',
    },
    display: "grid",
    justifyItems: "center",
    margin: "10%",
  },
});

type Styles = WithStyles<typeof styles>
class Login extends Component<Styles> {
  render() : JSX.Element {
    const { classes } = this.props;
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
}

export default withStyles(styles, { withTheme: true })(Login);
  
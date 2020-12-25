import React from 'react'; 
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';

import Header from './Header' ;

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
  
  export default function Status() : JSX.Element {
      const classes = useStyles();
    
      return (
        <>
          <Header /> 
            <form className={classes.root} noValidate autoComplete="off">
                <TextField id="text-status" label="Status" />
            </form>
        </>
      );
    }
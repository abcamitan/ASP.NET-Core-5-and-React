import React from 'react';
import logo from './logo.svg';
import { makeStyles } from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles(() => ({
  root: {
    flexGrow: 1,
  },
  toolBar:{
    backgroundColor: "white",
  },
  title: {
    flexGrow: 1,
    color: "black",
  },
  headerLogo: {
    pointerEvents: "none",
    animation: "headerLogoSpin infinite 20s linear",
  },
  "@global":{
    "@keyframes headerLogoSpin": {
        "from": {
          transform: "rotate(0deg)"
        },
        "to": {
          transform: "rotate(360deg)"
        }
      }
  },
}));

export default function Header() : JSX.Element {
    const classes = useStyles();
  
    return (
    <>
        <AppBar position="static">
        <Toolbar className={classes.toolBar}>
            <img
                alt=""
                src={ logo }
                width="100"
                height="100"
                className={classes.headerLogo}
            />
            <Typography variant="h6" className={classes.title}>
                Ticketing System
            </Typography>
        </Toolbar>
        </AppBar>
    </>
  );
}

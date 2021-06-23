import React, { useState, useEffect, useMemo } from 'react';
import Loading from '../../components/LoadingCustom';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import { blue } from '@material-ui/core/colors';
import Container from '@material-ui/core/Container';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import ListItemText from '@material-ui/core/ListItemText';
import PendenciesService from './PendenciesService';
import { Warning, Check  } from '@material-ui/icons';

const useStyles = makeStyles((theme) => ({
  root: {
    width: '100%',
    '& > *': {
      margin: theme.spacing(1),
      width: '25ch',
    },
  },
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    flex: 1
  },  
  title: {
    color: blue[500],    
  },
  list: {
    flexGrow: 1,
    flex: 1,
    width: '100%',
    overflow: 'auto',
    bottom: '1em',
    top: '1em',
  } ,
  MuiList: {
    root: {
      width: '100%',
    },
  },
}));

export default function TimeCard() {
  const classes = useStyles();

  const [ isAuthenticated, setIsAuthenticated ] = useState(false);
  const [ showLoading, setShowLoading ] = useState(false);
  const dates = (s, e) => { 
    for(var a=[], d= new Date(s); d<=e; d.setDate(d.getDate()+1)) { 
      a.push(new Date(d).toLocaleDateString());
    }
    return a;
  };

  const dateList = dates(new Date(2021, 5, 1), new Date(2021, 5, 30))
  
  const RedirectToHome = () => {
    this.setState({ redirect: "/Home" }); 
  }  
  
  
  return (
        <>
            <Loading show={showLoading} />
            <br/>
            <br/>
            <br/>
            <br/>
            <Container component="main">
                <h1 className={classes.title}>
                    Pendências
                </h1>
                <div className={classes.paper}>                
                  <List dense className={classes.list}>
                      {dateList.map((value) => {
                        const labelId = `checkbox-list-secondary-label-${value}`;
                        return (
                          <ListItem key={value} button>                          
                            <ListItemText id={labelId} primary={`${value + 1}`} />
                            <ListItemSecondaryAction>
                              <Warning style={{color : blue[500]}} />
                            </ListItemSecondaryAction>
                          </ListItem>
                        );
                      })}
                    </List>
                </div>
            </Container>
        </>
  );
}
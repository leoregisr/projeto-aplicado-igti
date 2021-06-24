import React, { useState } from 'react';
import Loading from '../../components/LoadingCustom';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import { blue } from '@material-ui/core/colors';
import Container from '@material-ui/core/Container';
import ReportsService from './ReportsService';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';
import { Link } from 'react-router-dom';

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

export default function Reports() {
  const classes = useStyles();

  const [ isAuthenticated, setIsAuthenticated ] = useState(false);
  const [ showLoading, setShowLoading ] = useState(false);  

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
                Relatórios
            </h1>
            <div className={classes.paper}>                
              <List dense className={classes.list}>                  
                <ListItem button key="Relatório-1" component={Link} to="/Reports/ReportByDate">            
                  <ListItemText primary="Relatório Horas/Data"
                    secondary={"Descrição"} />
                </ListItem>
                <ListItem button key="Relatório-2" component={Link} to="/Reports/ReportByYearMonth">            
                  <ListItemText primary="Relatório Horas/Mês"
                    secondary={"Descrição"}/>
                </ListItem>
              </List>
            </div>
        </Container>
    </>
  );
};
import React, { useState, useEffect } from 'react';
import Loading from '../../components/LoadingCustom';
import logoImage from '../assets/img/logo.png';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { grey } from '@material-ui/core/colors';
import CssBaseline from '@material-ui/core/CssBaseline';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import Container from '@material-ui/core/Container';

const useStyles = makeStyles((theme) => ({
  root: {
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
  },
  avatar: {
    margin: theme.spacing(5),    
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(1),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

const ColorButton = withStyles((theme) => ({
  root: {
    //color: theme.palette.getContrastText(white[500]),
    backgroundColor: grey[800],
    '&:hover': {
      backgroundColor: grey[500],
    },
  },
}))(Button);

export default function Login() {
  const classes = useStyles();

  const [ isAuthenticated, setIsAuthenticated ] = useState(false);  
  const [ showLoading, setShowLoading ] = useState(true)

  useEffect(() => {
    if (isAuthenticated) {
      RedirectToHome();
    } else {
      setShowLoading(false);      
    }
  });  

  const RedirectToHome = () => {
    this.setState({ redirect: "/Home" }); 
  }  
  
  return (
        <>
            <Loading show={showLoading} />
            <Container component="main" maxWidth="xs">              
              {/* <CssBaseline /> */}
              <div className={classes.paper}>
                <form 
                    className={classes.form} 
                    noValidate 
                    autoComplete="off">
                  <div className={classes.avatar}>
                    <img src={logoImage}/>
                  </div>
                  <TextField 
                      id="standard-basic" 
                      label="E-mail" 
                      fullWidth
                      margin="normal"
                      required />
                  <TextField 
                    id="standard-basic" 
                    label="Senha" 
                    fullWidth                  
                    margin="normal"
                    required  />
                  <ColorButton 
                    variant="contained" 
                    color="primary" 
                    disableElevation
                    fullWidth
                    className={classes.submit}
                    >
                      ENTRAR
                    </ColorButton>      
                    <Grid container>
                      <Grid item xs>
                        <Link href="#" variant="body2">
                          Esqueceu a senha?
                        </Link>
                      </Grid>
                      <Grid item>
                        <Link href="#" variant="body2">
                          {"Não tem uma conta? Contate o DP"}
                        </Link>
                      </Grid>
                    </Grid>
                </form>
              </div>
            </Container>
        </>
  );
}
import React, { useState, useEffect, useCallback } from 'react';
import Loading from '../../components/LoadingCustom';
import logoImage from '../assets/img/logo.png';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import { grey } from '@material-ui/core/colors';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Container from '@material-ui/core/Container';
import AuthenticationService from './AuthService';
import { useHistory   } from 'react-router'; 

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
  const [ showLoading, setShowLoading ] = useState(true);  
  const [ state , setState ] = useState({
    email : "",
    password : ""
  });  

  const history = useHistory();    

  useEffect(() => {   

    if (AuthenticationService.IsAuthenticated()) {
      RedirectToHome();
    } else {
      setShowLoading(false);      
    }
  });  

  const RedirectToHome = () => {
    history.push("/Home")    
  }    

  const LoginService =  () => {      
      AuthenticationService.Login(state.email, state.password)
      .then((data) => {
        setIsAuthenticated(true);        
      })
      .catch((error) => {

      });
  }  

  const handleChange = (e) => {
    const {id , value} = e.target;    
    setState(prevState => ({
        ...prevState,
        [id] : value
    }));    
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
                      id="email" 
                      label="E-mail" 
                      fullWidth
                      margin="normal"                                            
                      onChange={handleChange}
                      value={state.email}
                      required />
                  <TextField 
                    id="password" 
                    label="Senha" 
                    fullWidth                  
                    margin="normal"
                    type="password"         
                    value={state.password}
                    onChange={handleChange}
                    required  />
                  <ColorButton 
                    variant="contained" 
                    color="primary" 
                    disableElevation
                    fullWidth
                    className={classes.submit}
                    onClick={LoginService}
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
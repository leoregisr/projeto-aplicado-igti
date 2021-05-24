import React, { useState, useEffect } from 'react';
import Loading from '../../components/LoadingCustom';
import logoImage from '../assets/img/logo.png';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import { blue } from '@material-ui/core/colors';
import MenuItem from '@material-ui/core/MenuItem';
import Select from '@material-ui/core/Select';
import Container from '@material-ui/core/Container';
import InputLabel from '@material-ui/core/InputLabel';
import Icon from '@material-ui/core/Icon';
import FormControl from '@material-ui/core/FormControl';

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
  title: {
    color: blue[500],
  },
  bigIcon: {
    fontSize: '8.75rem'
  },  
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
  formControl: {
    margin: theme.spacing(1),
    minWidth: 120,
  }
}));

const ColorButton = withStyles((theme) => ({
  root: {
    //color: theme.palette.getContrastText(white[500]),
    backgroundColor: blue[800],
    '&:hover': {
      backgroundColor: blue[500],
    },
  },
}))(Button);

export default function TimeCard() {
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
                <h1 className={classes.title}>
                    Alocação
                </h1>
                <div className={classes.paper}>                
                    <Icon
                        className={classes.bigIcon}
                        style={{ color: blue[500] }}>
                        schedule
                    </Icon>
                    <form 
                        className={classes.form} 
                        noValidate 
                        autoComplete="off">                  
                        <FormControl 
                            className={classes.formControl}
                            fullWidth>
                            <InputLabel 
                                id="labelCliente"
                                shrink>
                                Cliente
                            </InputLabel>
                            <Select 
                                labelId="labelCliente" 
                                id="selectCliente"
                                fullWidth
                                displayEmpty
                                className={classes.selectEmpty}
                                value="">
                                <MenuItem value="">
                                    <em>Nome Cliente</em>
                                </MenuItem>
                            </Select>
                        </FormControl>              
                        <FormControl 
                            className={classes.formControl}
                            fullWidth>
                            <InputLabel 
                                id="labelCliente"
                                shrink>
                                Projeto
                            </InputLabel>
                            <Select 
                                labelId="labelCliente" 
                                id="selectProjeto"
                                fullWidth
                                displayEmpty
                                className={classes.selectEmpty}
                                value="">
                                <MenuItem value="">
                                    <em>Nome Projeto</em>
                                </MenuItem>                            
                            </Select>                        
                        </FormControl>    
                        <FormControl 
                            className={classes.formControl}
                            fullWidth>
                            <ColorButton 
                                variant="contained" 
                                color="primary" 
                                disableElevation
                                fullWidth
                                className={classes.submit}
                                endIcon={<Icon>play_arrow</Icon>}>
                                INICIAR
                            </ColorButton>
                        </FormControl>      
                    </form>
                </div>
            </Container>
        </>
  );
}
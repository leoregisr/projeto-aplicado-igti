import React, { useState, useEffect, useMemo } from 'react';
import Loading from '../../components/LoadingCustom';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import { blue } from '@material-ui/core/colors';
import MenuItem from '@material-ui/core/MenuItem';
import Select from '@material-ui/core/Select';
import Container from '@material-ui/core/Container';
import InputLabel from '@material-ui/core/InputLabel';
import Icon from '@material-ui/core/Icon';
import FormControl from '@material-ui/core/FormControl';
import ReportsService from './ReportsService';

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

export default function ReportByYearMonth() {
  const classes = useStyles();

  const [ isAuthenticated, setIsAuthenticated ] = useState(false);
  const [ showLoading, setShowLoading ] = useState(true);
  const [ clientsData, setClientsData] = useState([])
  const [ projectsData, setProjectsData] = useState([])
  const [ clientId, setClientId ] = useState("")
  const [ projectId, setProjectId ] = useState("")


  const clients = useMemo(() => {
    const clientsValues = [];
    clientsData.forEach((d) => {
      clientsValues.push(d);
    });  
    return clientsValues;
  });

  const projects = useMemo(() => {
    const projectValues = [];
    projectsData.forEach((d) => {
      projectValues.push(d)
    });
  
    return projectValues;
  });
  

  useEffect(() => {
    loadClients();

    if (isAuthenticated) {
      RedirectToHome();
    } else {
      setShowLoading(false);      
    }
  }, []);  

  useEffect(() => {    
    loadProjects(clientId);
  }, [clientId]);

  const RedirectToHome = () => {
    this.setState({ redirect: "/Home" }); 
  }  

  const loadClients = () => {
    ReportsService.ListClients()
    .then((data) => {
      if (data)
        setClientsData(data);
    });
  }

  const loadProjects = () => {
    if (clientId) {
      ReportsService.ListClientProjects(clientId)
      .then((data) => {
        if (data)
          setProjectsData(data);
      });
    }    
  }

  const handleClientIdChange = (e) => {
    setClientId(e.target.value);
  }

  const handleProjectIdChange = (e) => {
    setProjectId(e.target.value);
  }

  const handleClockIn = () => {
    if (projectId) {
      ReportsService.ClockIn(projectId)
      .then(() => {

      });
    }
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
                                value={clientId}
                                onChange={handleClientIdChange}>
                                <MenuItem value="">
                                    <em>Nome Cliente</em>
                                </MenuItem>
                                {clients.map((option) => (
                                  <MenuItem key={option.id} value={option.id}>
                                    {option.name}
                                  </MenuItem>
                                ))}
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
                                value={projectId}
                                onChange={handleProjectIdChange}>
                                <MenuItem value="">
                                    <em>Nome Projeto</em>
                                </MenuItem> 
                                {projects.map((option) => (
                                  <MenuItem key={option.id} value={option.id}>
                                    {option.name}
                                  </MenuItem>
                                ))}                           
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
                                endIcon={<Icon>play_arrow</Icon>}
                                onClick={handleClockIn}
                            >
                                INICIAR
                            </ColorButton>
                        </FormControl>      
                    </form>
                </div>
            </Container>
        </>
  );
}
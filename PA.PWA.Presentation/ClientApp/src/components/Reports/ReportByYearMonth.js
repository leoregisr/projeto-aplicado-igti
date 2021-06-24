import React, { useState } from 'react';
import Loading from '../../components/LoadingCustom';
import { makeStyles, withStyles } from '@material-ui/core/styles';
import { blue } from '@material-ui/core/colors';
import Container from '@material-ui/core/Container';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { DatePicker } from "@material-ui/pickers";
import Icon from '@material-ui/core/Icon';
import FormControl from '@material-ui/core/FormControl';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';

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
  form: {
    width: "100%"
  }
}));

function createData(date, start, end) {
  return { date, start, end};
}

const dates = (s, e) => { 
  for(var a=[], d= new Date(s); d<=e; d.setDate(d.getDate()+1)) { 
    a.push(new Date(d).toLocaleDateString());
  }
  return a;
};

const dateList = dates(new Date(2021, 5, 1), new Date(2021, 5, 30))

const rows = dateList.map(d => createData(d, "08:00", "17:00"));

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
              Relatório Horas/Mês
            </h1>
            <div className={classes.paper}>            
            <form 
                  className={classes.form} 
                  noValidate 
                  autoComplete="off">                  
                  <Grid
                      container
                      direction="row"
                      justify="space-between"
                      alignItems="center"
                      item xs={12}>
                    <FormControl 
                        className={classes.formControl}>                            
                        <DatePicker
                            variant="inline"
                            openTo="year"
                            views={["year", "month"]}
                            label="Mês/Ano"
                            helperText="Selecione o mês"                            
                          />
                    </FormControl>
                    <FormControl 
                        className={classes.formControl}>
                        <ColorButton 
                            variant="contained" 
                            color="primary" 
                            disableElevation
                            fullWidth
                            className={classes.submit}
                            endIcon={<Icon>search</Icon>}>
                            Pesquisar
                        </ColorButton>
                    </FormControl>      
                  </Grid>
              </form>          
              <br/>              
              <br/>    
              <TableContainer component={Paper}>
                <Table className={classes.table} size="small" aria-label="a dense table">
                  <TableHead>
                    <TableRow>
                      <TableCell>Data</TableCell>
                      <TableCell align="right">Entrada (HH:mm)</TableCell>
                      <TableCell align="right">Saída (HH:mm)</TableCell>                      
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    { rows.map((row, idx) => {                      
                      return(
                      <TableRow key={idx}>
                        <TableCell component="th" scope="row">
                          {row.date}
                        </TableCell>
                        <TableCell align="right">{row.start}</TableCell>
                        <TableCell align="right">{row.end}</TableCell>                        
                      </TableRow>
                    )
                   })}
                  </TableBody>
                </Table>
              </TableContainer>
            </div>
            <br/>
            <br/>
            <br/>
            <br/>
        </Container>
    </>
  );
};
import React from 'react';
import { Theme, createStyles, makeStyles } from '@material-ui/core/styles';
import Accordion from '@material-ui/core/Accordion';
import AccordionSummary from '@material-ui/core/AccordionSummary';
import AccordionDetails from '@material-ui/core/AccordionDetails';
import Checkbox from '@material-ui/core/Checkbox';
import AddIcon from '@material-ui/icons/Add';
import Typography from '@material-ui/core/Typography';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    root: {
        height: "125px",
        width: "250px"
    },
    heading: {
      fontSize: "13px",

    },
  }),
);

export default function SimpleAccordion() {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Accordion>
        <AccordionSummary
          expandIcon={<AddIcon />}
          aria-controls="panel1a-content"
          id="panel1a-header"
        >
          <Typography className={classes.heading}>Localidade da Vaga</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Typography className={classes.heading}>
              <Checkbox/>
            cidade
          </Typography>
        </AccordionDetails>
      </Accordion>
      <br/>
      <Accordion>
        <AccordionSummary
          expandIcon={<AddIcon />}
          aria-controls="panel2a-content"
          id="panel2a-header"
        >
          <Typography className={classes.heading}>Tipo de Vaga </Typography>
        </AccordionSummary>
        <AccordionDetails>
        <Typography className={classes.heading}>
              <Checkbox/> Clt
          </Typography>
          <Typography className={classes.heading}>
              <Checkbox/> Estagio
          </Typography>
          <Typography className={classes.heading}>
              <Checkbox/> Pj
          </Typography>
        </AccordionDetails>
      </Accordion>
      <br/>
      <Accordion>
        <AccordionSummary
          expandIcon={<AddIcon />}
          aria-controls="panel2a-content"
          id="panel2a-header"
        >
          <Typography className={classes.heading}>Nivel de Vaga </Typography>
        </AccordionSummary>
        <AccordionDetails>
        <Typography className={classes.heading}>
              <Checkbox/> Junior
          </Typography>
          <Typography className={classes.heading}>
              <Checkbox/> Pleno
          </Typography>
          <Typography className={classes.heading}>
              <Checkbox/> Senior
          </Typography>
        </AccordionDetails>
      </Accordion>
      <br/>
      <Accordion>
        <AccordionSummary
          expandIcon={<AddIcon />}
          aria-controls="panel2a-content"
          id="panel2a-header"
        >
          <Typography className={classes.heading}>Tamanho da empresa </Typography>
        </AccordionSummary>
        <AccordionDetails>
        <Typography className={classes.heading}>
              <Checkbox/> Pequena
          </Typography>
          <Typography className={classes.heading}>
              <Checkbox/> Grande
          </Typography>
          <Typography className={classes.heading}>
              <Checkbox/> Media
          </Typography>
        </AccordionDetails>
      </Accordion>
    </div>
  );
}
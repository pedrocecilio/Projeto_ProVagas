import React, { useEffect, useState } from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableFooter from '@material-ui/core/TableFooter';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';

import TablePaginationActions, { useStyles2 } from '../TablePaginationActions';
import './style.css';
import { TableHead } from '@material-ui/core';

export default function CustomPaginationActionsTable() {
  const classes = useStyles2();
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  


  const [contratos, setContratos] = useState<any[]>([]);

   

  const listar = () => {
    fetch('http://localhost:5000/api/contratos', {
      method: 'GET',
      headers: {
         authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
      }
    })
    .then(response => response.json())
    .then(dados =>{
      setContratos(dados);
    })
    .catch(err => console.error(err));
  }

  useEffect(() => {
    listar();
  }, [])

  const emptyRows = rowsPerPage - Math.min(rowsPerPage, contratos.length - page * rowsPerPage);

  const handleChangePage = (event: React.MouseEvent<HTMLButtonElement> | null, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  return (
    <div className="tdlista">

      <TableContainer component={Paper}>
        <Table className={classes.table} aria-label="custom pagination table">
          <TableHead>
            <TableRow>
              <TableCell>Nome</TableCell>
              <TableCell>Data Inicio</TableCell>
              <TableCell>Data Alerta</TableCell>
              <TableCell></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            
            {(rowsPerPage > 0
              ? contratos.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              : contratos
            )
            
            .map((row) => (
              
              <TableRow key={row.idContrato}>
                <TableCell component="th" scope="row">
                  {row.candidato}
                </TableCell>
                <TableCell>
                  {row.dataInicio}
                </TableCell>
                <TableCell>
                  {row.dataAlertar}
                </TableCell>
              
              </TableRow>
            ))}
            {emptyRows > 0 && (
              <TableRow style={{ height: 53 * emptyRows }}>
                <TableCell colSpan={6} />
              </TableRow>
            )}
          </TableBody>
          <TableFooter>
            <TableRow>
              <TablePagination
                rowsPerPageOptions={[5, 10, 25, { label: 'Todos', value: -1 }]}
                colSpan={2}
                count={contratos.length}
                rowsPerPage={rowsPerPage}
                page={page}
                SelectProps={{
                  inputProps: { 'aria-label': 'notificações' },
                  native: true,
                }}
                onChangePage={handleChangePage}
                onChangeRowsPerPage={handleChangeRowsPerPage}
                ActionsComponent={TablePaginationActions}
              />
            </TableRow>
          </TableFooter>
        </Table>
      </TableContainer>


    </div>
  );
}

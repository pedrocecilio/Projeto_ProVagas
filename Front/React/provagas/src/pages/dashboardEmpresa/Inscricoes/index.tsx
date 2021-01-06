import React from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableFooter from '@material-ui/core/TableFooter';
import TablePagination from '@material-ui/core/TablePagination';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import './style.css';
import { useState } from 'react';
import { useEffect } from 'react';
import Button from '../../../components/Button';
import TablePaginationActions, {useStyles2} from '../../../components/TablePaginationActions';
import { TableHead } from '@material-ui/core';
import { match } from 'react-router-dom';
import Navleft from '../../../components/Navbar/navbar';




interface inscricaoprops {
    match: match<{id:string}>
  }


export default function CustomPaginationActionsTable({match} : inscricaoprops) {
  const classes = useStyles2();
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const [inscricoescandidatos, setinscricoescandidatos] = React.useState<any[]>([]);

  const emptyRows = rowsPerPage - Math.min(rowsPerPage, inscricoescandidatos.length - page * rowsPerPage);

  const handleChangePage = (event: React.MouseEvent<HTMLButtonElement> | null, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  useEffect(() => {

    fetch('http://localhost:5000/api/empresas/list/' + match.params.id, {
      method: 'GET',
      headers: {
        // authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
      }
    })
      .then(response => response.json())
      .then(dados => {
        setinscricoescandidatos(dados);
      })
      .catch(err => console.error(err));
  }, [])

  return (
      <div className="cabeçalho">

      <aside>

         <Navleft />
      </aside>
      <div className="ba">

    <div className="tdlista">

      <TableContainer component={Paper}>
        <Table className={classes.table} aria-label="custom pagination table">
          <TableHead>
            <TableRow>
              <TableCell>Nome Completo</TableCell>
              <TableCell>E-mail</TableCell>
              <TableCell>Curso</TableCell>
              <TableCell>Data de Inscricao</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {(rowsPerPage > 0
              ? inscricoescandidatos.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              : inscricoescandidatos
              ).map((row) => (
                  <TableRow key={row.idAdministrador}>
                <TableCell component="th" scope="row">
                  {row.nomecandidato}
                </TableCell>
                <TableCell>
                  {row.email}
                </TableCell>
                <TableCell>
                  {row.curso}
                </TableCell>
                <TableCell>
                  {row.dataInscricao}
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
                count={inscricoescandidatos.length}
                rowsPerPage={rowsPerPage}
                page={page}
                labelRowsPerPage={'Candidados por pagina'}
                // SelectProps={{
                    //   inputProps: { 'aria-label': 'notificações' },
                    //   native: true,
                    // }}
                onChangePage={handleChangePage}
                onChangeRowsPerPage={handleChangeRowsPerPage}
                ActionsComponent={TablePaginationActions}
                />
            </TableRow>
          </TableFooter>
        </Table>
      </TableContainer>


    </div>
                </div>
  </div>
  );
}


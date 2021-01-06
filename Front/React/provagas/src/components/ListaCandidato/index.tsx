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
import Button from '../Button';
import TablePaginationActions, {useStyles2} from '../TablePaginationActions';
import { TableHead } from '@material-ui/core';



export default function CustomPaginationActionsTable() {
  const classes = useStyles2();
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const [candidato, setCandidato] = useState<any[]>([])

  const deletar = (id:any) =>{
    fetch('http://localhost:5000/api/administradores/candidato/'+id,{
    method: 'DELETE',
    headers:{
       authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
    }
  })
  .then(response => listar())
  .catch(err => console.error(err));
}

const listar =() =>{
  fetch('http://localhost:5000/api/administradores/candidato',{
    method: 'GET',
    headers:{
       authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
    }
  })
  .then(response => response.json())
  .then(dados =>{
    setCandidato(dados);
  })
  .catch(err => console.error(err));
}

useEffect(() =>{
  listar();
},[])
  

  const emptyRows = rowsPerPage - Math.min(rowsPerPage, candidato.length - page * rowsPerPage);

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
            <TableCell>Nome Completo</TableCell>
            <TableCell>Cpf</TableCell>
            <TableCell>Curso</TableCell>
            <TableCell></TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {(rowsPerPage > 0
            ? candidato.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
            : candidato
            ).map((row) => (
              <TableRow key={row.idCandidato}>
              <TableCell component="th" scope="row">
                {row.nomeCompletoCandidato}
              </TableCell>
              <TableCell>
                {row.cpf}
              </TableCell>
              <TableCell>
                <Button value="deletar" onClick={()=>deletar(row.idCandidato)}/>
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
              colSpan={3}
              count={candidato.length}
              rowsPerPage={rowsPerPage}
              labelRowsPerPage={'Candidados por pagina'}
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

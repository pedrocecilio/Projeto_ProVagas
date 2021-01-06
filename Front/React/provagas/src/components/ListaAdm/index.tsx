import React, { useEffect } from 'react';
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
import Button from '../Button';



export default function CustomPaginationActionsTable() {
  const classes = useStyles2();
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(5);
  const [administradores, setAdministradores] = React.useState<any[]>([]);
  const [botao, setBotao] = React.useState(true);

  const emptyRows = rowsPerPage - Math.min(rowsPerPage, administradores.length - page * rowsPerPage);

  const handleChangePage = (event: React.MouseEvent<HTMLButtonElement> | null, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>,
  ) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const deletar = (id: any) => {
    fetch('http://localhost:5000/api/administradores/' + id, {
      method: 'DELETE',
      headers: {
        authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
      }
    })
      .then(() => alert('Administrador recusado.'))
      .then(response => listar())
      .catch(err => console.error(err));
  }

  const listar = () => {
    fetch('http://localhost:5000/api/administradores', {
      method: 'GET',
      headers: {
        authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
      }
    })
      .then(response => response.json())
      .then(dados => {
        setAdministradores(dados);
      })
      .catch(err => console.error(err));
  }

  useEffect(() => {
    listar();
  }, [])

  return (
    <div className="tdlista">

      <TableContainer component={Paper}>
        <Table className={classes.table} aria-label="custom pagination table">
          <TableHead>
            <TableRow>
              <TableCell>Nome</TableCell>
              <TableCell>Departamento</TableCell>
              <TableCell>Unidade</TableCell>
              <TableCell></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {(rowsPerPage > 0
              ? administradores.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              : administradores
            ).map((row, index) => (
              <TableRow key={row.idAdministrador}>
                <TableCell component="th" scope="row">
                  {row.nomeCompletoAdmin}
                </TableCell>
                <TableCell>
                  {row.departamento}
                </TableCell>
                <TableCell>
                  {row.unidadeSenai}
                </TableCell>

                {
                  botao && localStorage.getItem("id") === "1" && index === 1 ?
                    <>
                      <TableCell><Button style={{ backgroundColor: 'green' }} value="Aceitar" onClick={() => setBotao(false)}>Aceitar</Button></TableCell>
                      <TableCell><Button value="Recusar" onClick={() => deletar(row.idAdministrador)}>Recusar</Button></TableCell>
                    </> :
                    <>
                      <TableCell></TableCell>
                      <TableCell></TableCell>
                    </>
                }
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
                count={administradores.length}
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

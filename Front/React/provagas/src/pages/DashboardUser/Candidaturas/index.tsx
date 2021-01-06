import React, { useEffect, useState } from 'react';
import Navleft from '../../../components/Navbar/navbar'
import './style.css'
import Grafico from '../../../components/grafico'
import IconButton from '@material-ui/core/IconButton/IconButton';
import { parseJWT } from '../../../services/auth';
import * as Gricons from 'react-icons/gr'
import * as Faicons from 'react-icons/fa'
import * as Vsicons from 'react-icons/vsc'

export default function Candidaturas () {

  const [salario, setsalario] = useState('');
  const [idInscricao, setidinscricao] = useState(0);
  const [localidade, setlcoalidade] = useState('');
  const [ titulo, settitulo] = useState('');
  const [remoto, setremoto] = useState('');
  const [status, setstatus] = useState(''); 
  const [inscricao , setinscricao] = useState([])



useEffect (() => {
  listarInscricao();
}, [])

const listarInscricao = () => {
  fetch(`http://localhost:5000/api/Candidatos/Inscricao/${parseJWT().Id}`, {
      method: 'GET',
      headers: {
          authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
      }
  })
  .then(response => response.json())
  .then(dados => {
    setinscricao(dados);
  })
  .catch(erro => console.error(erro))
}

  return (
    <>
    <aside>
    <Navleft/> 
    </aside>
    <div className='candidaturacenter'>
      <h1 className="candidaturash1">Candidaturas</h1>
      <br/>
      <br/>
     
      <table>
        <tbody>
          {
            inscricao.map((item:any) =>{
              return (      
                <div className="espacamento">
                      <div className='box-shadows'>
                           <div className='rowa'>
                               <tr >
                                 <div className="coluna">
                                   <td><h4>{item.nomeVaga}</h4></td>
                                   <hr/>
                                   <div className="rowasde">
                                   <td style={{padding: "2rem"}}><Faicons.FaRegMoneyBillAlt/>     Salario: {item.salario} </td>
                                   <td style={{padding: "2rem"}}><Gricons.GrMapLocation/>       Localidade: {item.localizacao}</td>
                                   <td style={{padding: "2rem"}}><Vsicons.VscRemoteExplorer/>    Porte da Empresa: {item.nomePorte}</td>
 
                                   </div>
                                 </div>
                               </tr>
 
                             </div>
                        </div>
                  </div>
                )
            })
          }
        </tbody>       
      </table>
     
      </div>

    </>
  )
}
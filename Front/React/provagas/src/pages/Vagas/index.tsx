import React, { useState } from 'react';
import Input from '../../components/InputVagas';
import Button from '../../components/Button';
import Header from '../../components/Header';
import {Link} from 'react-router-dom';
import './style.css';
import imgvaga from '../../assets/images/imgvaga.png';
import Footer from '../../components/Footer';
import { useEffect } from 'react';
import * as Gricons from 'react-icons/gr'
import * as Faicons from 'react-icons/fa'
import * as Vsicons from 'react-icons/vsc'
import Filter from '../../components/filter'

function Vagas() {

  const [vagas, setvagas] = useState([]);

  useEffect (() => {
    listarInscricao();
  }, [])
  
  const listarInscricao = () => {
    fetch("http://localhost:5000/api/vagas", {
        method: 'GET',
        headers: {
            authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
        }
    })
    .then(response => response.json())
    .then(dados => {
      setvagas(dados);
    })
    .catch(erro => console.error(erro))
  }
  

  return (
      <div>
        <Header/>
          <div className="telavagas">
            <img src={imgvaga} alt="Imagem da página de vagas"/>
              <div className="buscarvaga">
                <Input  />
              </div>
                <br/>
                <br/>
                <br/>
              {/* <div className="filter">
                <div className="quadrado">
                    <Filter/>
                </div> */}
              <table>
             <tbody>
          {
            vagas.map((item:any) =>{
            return (      
               <div className="espacamento">
                     <div className='box-vagas'>
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
                                  <Link to={`/detalhevaga/${item.idVaga}`} className="mudabotao"><Button value="Saiba mais"/></Link>
                                  
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
        {/* </div> */}
        <Footer/>
      </div>
  );
}

export default Vagas;
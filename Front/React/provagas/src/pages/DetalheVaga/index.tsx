import React, { useEffect, useState } from 'react';
import Button from '../../components/Button';
import './style.css';
import '../../assets/global.css';
import Header from '../../components/Header';
import imgdetalhevaga from '../../assets/images/imgdetalhevaga.png';
import iconelocal from '../../assets/images/local.png';
import iconeporte from '../../assets/images/porte.png';
import iconecontrato from '../../assets/images/tipo-contrato.png';
import logo_brq from '../../assets/images/logo_brq.png';
import Footer from '../../components/Footer';
import * as GrIcons from 'react-icons/gr'
import { parseJWT, usuarioLogado } from '../../services/auth';
import { match, useHistory } from 'react-router-dom';
import deagr from 'moment';
import * as Gricons from 'react-icons/gr'
import * as Faicons from 'react-icons/fa'
import * as Vsicons from 'react-icons/vsc'


  interface vagasprops {
    match: match<{id:string}>
  }
  
function DetalheVaga({match} : vagasprops) {

  const [vagas,setvagas] = useState([])
  const [idvagas, setidvagas] = useState(0)
  const [inscrito,setInscrito] = useState(Boolean)

  let history = useHistory();

  
  useEffect (() => {
    let url =  match.params.id

    
    
    fetch('http://localhost:5000/api/beneficiosxvagas/vagou/' + match.params.id, {
      method: 'GET',
      headers: {
        authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
      }
    })
    .then(response => response.json())
    .then(dados => {
      setvagas(dados);
      setidvagas(parseInt(url));
    })
    .catch(erro => console.error(erro))
    
    
    
  }, [])
  
  
  
 
  
  
  let id = parseJWT().Id
  const logadouser = () => {
  const form = {
    dataInscricao: deagr (new Date()),
    idVaga: idvagas,
    IdStatusInscricao: 1,
    idCandidato: id
  }
  
      
  console.log(form)
      const urlinscricao = "http://localhost:5000/api/Inscricoes"
      fetch(urlinscricao, {
        method: "POST",
        body: JSON.stringify(form),
        headers: {
            'content-type': 'application/json',
            authorization: 'bearer' + localStorage.getItem('provagas-chave-autenticacao')
        }
      })
      .then(response => response.json())
      .catch(erro => console.error(erro))
    }
  
  
  const verificarInscricao = async () => {
    try {
      const request = await fetch("http://localhost:5000/api/Inscricao/varinscricao"+  match.params.id, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
            authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
        },
    })
    
    const response = await request.json();
    setInscrito(response);
    } catch (error) 
        {
            console.log("ERROR")
            console.log(error)
        }
    }


    const vagaselecionada = () => {
      if (!usuarioLogado()) { 
        return (
            <div>
              <Header/>
              <div className="detalhe">
              <img src={imgdetalhevaga} alt="Detalhes da vaga"/>

              {vagas.map((item:any) => {
                verificarInscricao()
                return (
                  <div>
                    <div className="detalhesvaga">
                
                <h1>Descrição da empresa</h1>
              
                <p>{item.descricaoEmpresa}</p>

              <h1>Atividades e responsabilidades</h1>
              
                <p>{item.descricaoAtividade}</p>


              <h1>Benefícios oferecidos</h1>
                <ul>
                  <li>{item.nomeBeneficio} </li>
                </ul>
                </div> 
                    
                  </div>
                )
              })}
                <Button value="Quero me candidatar" onClick={logadouser}/>
              </div>
              
              <Footer/>
                            
            </div>
 
          )}
          else {
            if (parseJWT().Role == "Candidato") {
              return (
               <div>
               <Header/>
               <div className="detalhe">
               <img src={imgdetalhevaga} alt="Detalhes da vaga"/>
 
               {vagas.map((item:any) => {
                 verificarInscricao()
                 return (
                   <div>
                     <div className="detalhesvaga">
                 
                 <h1>Descrição da empresa</h1>
               
                 <p>{item.descricaoEmpresa}</p>
 
               <h1>Atividades e responsabilidades</h1>
               
                 <p>{item.descricaoAtividade}</p>
 
 
               <h1>Benefícios oferecidos</h1>
                 <ul>
                   <li>{item.nomeBeneficio} </li>
                 </ul>
                 </div> 
                     
                   </div>
                 )
               })}
                
               {inscrito === true ? <Button value="Inscrito" onClick={() => {alert('Você já se inscreveu nessa vaga')}}/> 
               : <Button value="Quero me candidatar" onClick={logadouser}/>}
               </div>
               <Footer/>
                             
             </div>
              )} else if(parseJWT().Role == "Empresa") {
                  return (
                   <div>
                   <Header/>
                   <div className="detalhe">
                   <img src={imgdetalhevaga} alt="Detalhes da vaga"/>
     
                   {vagas.map((item:any) => {
                     verificarInscricao()
                     return (
                       <div>
                         <div className="detalhesvaga">
                     
                     <h1>Descrição da empresa</h1>
                   
                     <p>{item.descricaoEmpresa}</p>
     
                   <h1>Atividades e responsabilidades</h1>
                   
                     <p>{item.descricaoAtividade}</p>
     
     
                   <h1>Benefícios oferecidos</h1>
                     <ul>
                       <li>{item.nomeBeneficio} </li>
                     </ul>
                     </div> 
                         
                       </div>
                     )
                   })}
                    
                  <Button value="Quero me candidatar" onClick={() => {alert('Apenas alunos podem se candidatar há uma vaga')}}/> 
                  
                   </div>
                   <Footer/>
                                 
                 </div>
                  )}
                  else if(parseJWT().Role == "Administrador") {
                    return (
                     <div>
                     <Header/>
                     <div className="detalhe">
                     <img src={imgdetalhevaga} alt="Detalhes da vaga"/>
       
                     {vagas.map((item:any) => {
                       verificarInscricao()
                       return (
                         <div>
                           <div className="detalhesvaga">
                       
                       <h1>Descrição da empresa</h1>
                     
                       <p>{item.descricaoEmpresa}</p>
       
                     <h1>Atividades e responsabilidades</h1>
                     
                       <p>{item.descricaoAtividade}</p>
       
       
                     <h1>Benefícios oferecidos</h1>
                       <ul>
                         <li>{item.nomeBeneficio} </li>
                       </ul>
                       </div> 
                           
                         </div>
                       )
                     })}
                      
                    <Button value="Quero me candidatar" onClick={() => {alert('Apenas alunos podem se candidatar há uma vaga')}}/> 
                    
                     </div>
                     <Footer/>
                                   
                   </div>
                    )}

          } 
    }




 
  return (
      <div>
       
       {vagaselecionada()};
      </div>
  );
}

export default DetalheVaga;
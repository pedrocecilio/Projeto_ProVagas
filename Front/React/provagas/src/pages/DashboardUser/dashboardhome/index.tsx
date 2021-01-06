import React, { useEffect, useState } from 'react';
import Navleft from '../../../components/Navbar/navbar';
import './style.css'
import imgsetup from '../../../assets/images/undraw_setup_obqo.png';
import imgdisc from '../../../assets/images/unnamed.png'
import Button from '../../../components/Button/index';
import imgflor from '../../../assets/images/semtitulo.png'
import {Link} from 'react-router-dom'
import { parseJWT } from '../../../services/auth';
import { CollectionsOutlined } from '@material-ui/icons';



function Dashboard() {

    const [inscricao , setinscricao] = useState([])
    const [msg , setmsg] = useState(false)
    const [ count , setCount] = useState(0)

    useEffect (() =>{
        listarInscricao();
    }, [])


    const listarInscricao = () => {
        fetch(`http://localhost:5000/api/candidatos/inscricao/${parseJWT().Id}`, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
            }
        })
            .then(response => response.json())
            .then(dados => {
                console.log(dados)
                    setinscricao(dados);
                    setCount(dados.length);
                    setmsg(false);

                    
                })
                .catch(erro => console.error(erro))
            }
            console.log(setCount)


    return (
        <div>
              <Navleft/>  
                <div className='row'>              
               <br/>
               <div className='conteudo'>
            <div className='box-shadow'>
                <p>{count}</p>   
                <hr/>
                <h3>Candidaturas</h3>
             </div>
               <div className='divhf'>
                <img className="setup" src={imgsetup} alt="imagem ilustrativa"/>
               </div>
            </div>
                <div className="centeral">
                 <h4>Descubra já o que é predominante na sua personalidade</h4>
                 <p>Faça o teste comportamental agora !!</p><br/>
                 <img className="disc" src={imgdisc} alt="imagem ilustrativa"/><br/>
                 <Button value='Faça já o seu'/>
                 </div>
                 <div className='divhf'>
                <img className="flor" src={imgflor} alt="imagem ilustrativa"/>
               </div>
               </div>
        </div>
    )
}
export default  Dashboard
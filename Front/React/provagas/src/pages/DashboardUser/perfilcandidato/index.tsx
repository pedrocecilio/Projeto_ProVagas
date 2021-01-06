import React, { useState, useEffect } from 'react';
import Button from '../../../components/Button';
import Navleft from '../../../components/Navbar/navbar';
import './style.css'
import Input from '../../../components/inputPerfil/inputperfil';
import * as AiIcons from 'react-icons/ai';
import {IconContext} from 'react-icons';
import {parseJWT} from '../../../services/auth';
import history from '../../../History'
import { parse } from 'path';

export default function Perfil (){

    const [nome, setNome] = useState('');
    const [cpf, setcpf] = useState('');
    const [github, setgithub] = useState('');
    const [nomeidioma, setnomeidioma] = useState("");
    const [nomenivel, setnomenivel] = useState('');
    const [cursosenai, setcursosenai] = useState('');
    const [nomegenero , setnomegenero] = useState('');

    const [mudado, setMudado] = useState(false);

    useEffect (() => {
        listar();
    })


    const listar = () => { 
         fetch(`http://localhost:5000/api/candidatos/${parseJWT().Id}`, {
                method: 'GET',
                headers: {
                    authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
                }
            })
                .then(response => response.json())
                .then(dados => {
                    // setUsuario(dados);
                    setNome(dados.nomeCompletoCandidato);
                    setgithub(dados.linkedin);
                    setcpf(dados.cpf);
                    setnomeidioma(dados.nomeIdioma);
                    setnomenivel(dados.nomeNivel);
                    setcursosenai( dados.curso);
                    setnomegenero(dados.nomeGenero);
                })
                .catch(erro => console.error(erro))
     }

     const atualizaR = () => {
        let form = {
            nomeCompletoCandidato: nome,
            cpf: cpf,
            nomeGenero: nomegenero,
            linkedin: github,
            curso: cursosenai,
            nomeIdioma: nomeidioma,
            nomeNivel: nomenivel
        }

        fetch(`http://localhost:5000/api/candidatos/${parseJWT().Id}`, {
            method: 'PUT',
            body: JSON.stringify(form),
            headers: {
                'content-type': 'application/json',
                authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
            }
        })
            .then(response => response.json())
            .then(() => {
                setNome('');
                    setgithub('');
                    setcpf('');
                    setnomeidioma('');
                    setnomenivel('');
                    setcursosenai( '');
                    setnomegenero('');

                    setMudado(false);
                    listar();
            })
            .catch(erro => {
                console.error(erro);
            })
     }


    return (
        <>
        <aside>

            <Navleft/>
        </aside>
            <h2 className='h234' >Perfil do candidato</h2>
                <br/>
    
            <div className='rowlin'>

                <div className='left'>

                        <div className='hb'>

                            <Input name='Nome'
                            mask=""
                            label='Nome Completo' 
                            placeholder={nome}
                            onChange={e => {
                                setNome(e.target.value);
                                setMudado(true);
                            }}
                            />

                        </div><br/>

                        <div className='hb'>
                            <Input name='CPF' 
                            mask="999.999.999-99"
                            label='CPF'
                            value={cpf}
                           
                             />
                        </div><br/>

                        <div className='hb'>
                            <Input name='E-mail'
                            mask=""
                             label='E-mail'
                             value={parseJWT().email}
                             />
                        </div>

                        <div className='hb'>
                            <Input name='github'
                            mask=""
                             label='Gênero'
                             value={nomegenero}
                             placeholder={nomegenero}
                             onChange={e => {
                                setnomegenero(e.target.value);
                                setMudado(true);
                            }}
                             />
                        </div>
                </div>

                <div className='right'>

                    <div className='bh'>

                    <Input name='Idioma'
                    mask=''
                     label='Idioma' 
                     placeholder={nomeidioma}
                     value={nomeidioma}
                     onChange={e => {
                        setnomeidioma(e.target.value);
                        setMudado(true);
                    }}
                     />
                    </div><br/>

                    <div className='bh'>

                    <Input name='nivel'
                    mask=""
                    label='Nivel Idioma'
                    placeholder={nomenivel}
                    onChange={e => {
                        setnomenivel(e.target.value);
                        setMudado(true);
                    }}

                    />
                    </div><br/>

                    <div className='bh'>

                    <Input name='Github'
                    mask=""
                     label='Github'
                     placeholder={github}
                     onChange={e => {
                        setgithub(e.target.value);
                        setMudado(true);
                    }}
                     />

                    </div>
                    

                     <div className='bh'>

                    <Input name='curso'
                    mask=""
                     label='Curso do Senai'
                     placeholder={cursosenai}
                     onChange={e => {
                        setcursosenai(e.target.value);
                        setMudado(true);
                    }}
                     />

                    </div>

                </div>

            </div>
                <div className='btnao'> 
                <br/>
                {mudado === true ? <Button value="Salvar" onClick={() => atualizaR()} ></Button> : <Button value="Voltar" onClick={() => history.goBack()} ></Button>}
                </div>               
            
        </>
    )
}
import React, { useEffect, useState } from 'react';
import Button from '../../../components/Button';
import Navleft from '../../../components/Navbar/navbar';
import './style.css'
import Input from '../../../components/Input';
import * as AiIcons from 'react-icons/ai';
import { IconContext } from 'react-icons'
import { parseJWT } from '../../../services/auth';
import history from '../../../History';
import ImageUploading, { ImageType } from "react-images-uploading";


export default function Perfil() {

    const [nomefantasia, setnomefantasia] = useState('');
    const [razaoSocial, setrazaosocial] = useState('');
    const [foto, setfoto] = useState('');;
    const [cnpj, setcnpj] = useState('');
    const [cnae, setcnae] = useState('');
    const [linkedin, setlinkedin] = useState('');
    const [Website, setWebsite] = useState('');
    const [descricao, setdescricao] = useState('');
    const [port, setport] = useState('');

    const [fotos, setfotos] = useState([]);


    const [att, setatt] = useState(false);

    useEffect(() => {
        listar(parseJWT().Id);
    })


    const listar = (id: Number) => {
        fetch('http://localhost:5000/api/empresas/' + id, {
            method: 'GET',
            headers: {
                authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setnomefantasia(dados.nomeFantasia);
                setrazaosocial(dados.razaoSocial);
                setcnpj(dados.cnpj);
                setcnae(dados.cnae);
                setlinkedin(dados.linkedin);
                setWebsite(dados.website);
                setport(dados.nomePorte);
                setdescricao(dados.descricaoEmpresa)

            })
            .catch(erro => console.error(erro))
    }

    const atualizaR = () => {
        let formemrpresa = {
            nomeFantasia: nomefantasia,
            cnpj: cnpj,
            razaoSocial: razaoSocial,
            cnae: cnae,
            linkedin: linkedin,
            Website: Website,
            descricaoEmpresa: descricao,
            nomePorte: port
        }

        fetch('http://localhost:5000/api/empresas', {
            method: 'PUT',
            body: JSON.stringify(formemrpresa),
            headers: {
                'content-type': 'application/json',
                authorization: 'Bearer ' + localStorage.getItem('provagas-chave-autenticacao')
            }
        })
            .then(response => response.json())
            .then(() => {
                setnomefantasia('');
                setrazaosocial('');
                setcnpj('');
                setcnae('');
                setlinkedin('');
                setWebsite('');
                setport('');
                setdescricao('')

                setatt(false);
                listar(parseJWT().Id);
            })
            .catch(erro => {
                console.error(erro);
            })
    }


    return (
        <>
            <aside>

                <Navleft />
            </aside>
            <h2 className='h234'>Perfil da Empresa</h2>


            <br />
            <div className='hebert'>
                <div className='left'>
                    <div className='hb'>
                        <Input name='Razão Social'
                            label='Razão Social'
                            placeholder={razaoSocial}
                            value={razaoSocial}
                            onChange={e => {
                                setrazaosocial(e.target.value);
                                setatt(true);
                            }}
                        />
                    </div>
                    <div className='hb'>
                        <Input name='Nome Fantasia'
                            label='Nome Fantasia'
                            placeholder={nomefantasia}
                            value={nomefantasia}
                            onChange={e => {
                                setnomefantasia(e.target.value);
                                setatt(true);
                            }}
                        />
                    </div>
                    <div className='hb'>
                        <Input name='E-mail'
                            label='E-mail'
                            placeholder={parseJWT().email}
                        />
                    </div>
                    <div className='hb'>
                        <Input name='website'
                            label='WebSite'
                            placeholder={Website}
                            value={Website}
                            onChange={e => {
                                setWebsite(e.target.value);
                                setatt(true);
                            }}
                        />
                    </div>
                </div>
                <div className='right'>
                    <div className='bh'>
                        <Input name='CNPJ'
                            label='CNPJ'
                            placeholder={cnpj}
                            value={cnpj}
                            onChange={e => {
                                setcnpj(e.target.value);
                                setatt(true);
                            }}
                        />
                    </div>
                    <div className='bh'>
                        <Input name='CNAE'
                            label='CNAE'
                            placeholder={cnae}
                            value={cnae}
                            onChange={e => {
                                setcnae(e.target.value);
                                setatt(true);
                            }}
                        />

                    </div>

                    <div className='bh'>
                        <Input name='Linkedin'
                            label='Linkedin'
                            placeholder={linkedin}
                            value={linkedin}
                            onChange={e => {
                                setlinkedin(e.target.value);
                                setatt(true);
                            }}
                        />
                    </div>


                    <div className='bh'>
                        <Input name='port'
                            label='Porte da Empresa'
                            placeholder={parseJWT().nomePorte}
                            value={port}
                            onChange={e => {
                                setport(e.target.value);
                                setatt(true);
                            }}
                        />
                    </div>
                </div>

            </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div className='btnao'>
                {att === true ? <Button value="Salvar" onClick={() => atualizaR()} ></Button> : <Button value="Voltar" onClick={() => history.goBack()} ></Button>}
            </div>

            <br /><br />

        </>
    )
}
import React, { useState } from 'react';
import Header from '../../components/Header';
import imgcolaborador from '../../assets/images/imgcadastroadm.png';
import Input from '../../components/Input';
import InputSmaller from '../../components/InputSmaller';
import Button from '../../components/Button';
import './style.css';
import { parse } from 'path';
import { Link, useHistory } from 'react-router-dom';

function CadastroAdm() {

    let history = useHistory();

    const [nomeAdm, setnomeAdm] = useState('');
    const [nif, setnif] = useState(0);
    const [unisenai, setunisenai] = useState('');
    const [departamento, setdepartamento] = useState('');
    const [email, setemail] = useState('');
    const [senha, setsenha] = useState('');
    const [telefone, settelefone] = useState('');



    const cadastrarAdm = () => {
        const cadadm = {
            NomeCompletoAdmin: nomeAdm,
            Nif: nif,
            UnidadeSenai: unisenai,
            Departamento: departamento,
            idUsuarioNavigation: {
                Email: email,
                Telefone: telefone,
                Senha: senha,
                IdTipoUsuario: 3
            }
        }

        fetch('http://localhost:5000/api/Administradores', {
            method: 'POST',
            body: JSON.stringify(cadadm),
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            }
        },

        )
            .then(() => {
                alert("Cadastro concluido com sucesso");
                history.push('/login')
            })
            .catch(error => {
                console.error(error);
                alert("Erro ao cadastrar usuario.");
            });

    }


    return (
        <div className="prcp">
            <Header />
            <form onSubmit={event => {
                event.preventDefault();
                cadastrarAdm();
            }}>
                <div className="cadastroAdmin">
                    <div className="box-banner-colaborador">
                        <img src={imgcolaborador} alt='desenho de duas pessoas frente a frente e cada uma mexendo em um computador' />
                    </div>

                    <h1>Cadastro de Colaboradores</h1>
                    <h4>Dados de acesso</h4>
                    <Input type="email" label="E-mail" name="email" value={email} onChange={e => setemail(e.target.value)} />
                    <Input type="password" label="Senha" name="senha" value={senha} onChange={e => setsenha(e.target.value)} />
                    <h4>Informações do Colaborador</h4>
                    <Input type="text" label="Nome Completo" name="nome" value={nomeAdm} onChange={e => setnomeAdm(e.target.value)} />
                    <Input type="text" label="Unidade Senai" name="senai" value={unisenai} onChange={e => setunisenai(e.target.value)} />

                    <Input type="text" label="Departamento" name="departamento" value={departamento} onChange={e => setdepartamento(e.target.value)} />
                    <div className="input-duplo">
                        <InputSmaller type="text" label="Numero do NIF" name="nif" onChange={e => setnif(parseInt(e.target.value))} />
                        <InputSmaller type="tel" label="Tel/Cel" name="Contato" value={telefone} onChange={e => settelefone(e.target.value)} />
                    </div>
                    <br />
                    <Link className="link" to="/login"></Link><Button
                        value="Finalizar cadastro"
                    />
                    <br />
                    <br />

                </div>
            </form>
        </div>


    )
}



export default CadastroAdm;
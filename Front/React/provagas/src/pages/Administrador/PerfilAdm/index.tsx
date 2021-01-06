import React, { useEffect, useState } from 'react';
import { match } from 'react-router-dom';
import Input from '../../../components/Input';
import InputSmaller from '../../../components/InputSmaller';
import Button from '../../../components/Button';
import './style.css';
import Navbar from '../../../components/Navbar/navbar';

interface PerfilAdmProps {
    match: match<{ id: string }>;
}

const PerfilAdm = ({ match }: PerfilAdmProps) => {

    const [nome, setNome] = useState('');
    const [unidade, setUnidade] = useState('');
    const [departamento, setDepartamento] = useState('');
    const [senha, setSenha] = useState('');
    const [telefone, setTelefone] = useState('');
    const [email, setEmail] = useState('');
    const [admin, setAdmin] = useState<any | undefined>(undefined);

    useEffect(() => {
        fetch('http://localhost:5000/api/administradores/' + match.params.id, {
            method: 'GET',
            headers: {
                // authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                setNome(dados.nomeCompletoAdmin);
                setUnidade(dados.unidadeSenai);
                setDepartamento(dados.departamento);
                setAdmin(dados);
                // fetch('http://localhost:5000/api/administradores/usuarios/' + dados.idUsuario, {
                //     method: 'GET',
                //     headers: {
                //         // authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
                //     }
                // })
                //     .then(response => response.json())
                //     .then(dados => {
                //         setTelefone(dados.telefone);
                //         setSenha(dados.senha);
                //         setEmail(dados.email);

                //     })
                //     .catch(err => console.error(err))

            })
            .catch(err => console.error(err))
    }, []);

    const salvar = () => {
        const admAtualizado = {
            ...admin,
            NomeCompletoAdmin: nome,
            UnidadeSenai: unidade,
            Departamento: departamento,
        };

        fetch('http://localhost:5000/api/administradores/' + match.params.id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                // authorization: 'Bearer' + localStorage.getItem('token')
            },
            body: JSON.stringify(admAtualizado)
        })

            .then((response) => {
                return response.json();
            })
            .then(() => {
                alert("Cadastro concluido com sucesso");
            })
            .catch(error => {
                console.error(error);
                alert("Erro ao cadastrar usuario.");
            });
    }

    return (
        <div className="prcp">
            <Navbar />
            <div className="cadastro">
                {/* <h2>Meus dados de acesso</h2>
                <Input type="email" label="E-mail" name="email" value={email} />
                <Input type="password" label="Senha" name="senha" value={senha} onChange={event => setSenha(event.target.value)} /> */}
                <h4>Informações do Colaborador</h4>
                <Input type="text" label="Nome Completo" name="nome" value={nome} onChange={event => setNome(event.target.value)} />
                <Input type="text" label="Unidade Senai" name="senai" value={unidade} onChange={event => setUnidade(event.target.value)} />
                <div className="input-duplo">
                    <InputSmaller type="text" label="Departamento" name="departamento" value={departamento} onChange={event => setDepartamento(event.target.value)} />
                    <InputSmaller type="text" label="Numero do NIF" name="nif" value={admin?.nif} />
                </div>
                {/* <Input type="tel" label="Tel/Cel" name="Contato" value={telefone} onChange={event => setTelefone(event.target.value)} /> */}

                <Button value="Atualizar cadastro" onClick={salvar} />

            </div>
        </div>
    )
}

export default PerfilAdm;
import { DashboardSharp } from '@material-ui/icons';
import React, { useEffect, useState } from 'react';
import Button from '../../../components/Button';
import InputSmaller from '../../../components/InputSmaller';
import Lista from '../../../components/Lista';
import Navbar from '../../../components/Navbar/navbar';
import './style.css';


function AlertaContrato() {

    const [dataInicio, setDataInicio] = useState('');
    const [dataAlerta, setDataAlerta] = useState('');
    const [candidato, setCandidato] = useState('');
    const [empresa, setEmpresa] = useState('');

    const cadastrarContrato = () => {
        const novoContrato = {
            dataInicio,
            dataAlertar: dataAlerta,
            candidato,
            empresa,
        };

        fetch('http://localhost:5000/api/contratos', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                // authorization: 'Bearer' + localStorage.getItem('token')
            },
            body: JSON.stringify(novoContrato)
        })
            .then(() => {
                alert("Cadastro concluido com sucesso");
                window.location.reload();
            })
            .catch(error => {
                console.error(error);
                alert("Erro ao cadastrar usuario.");
            });
    };

    useEffect(() => {
        fetch('http://localhost:5000/api/contratos', {
            method: 'GET',
            headers: {
                // authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao, token')
            }
        })
            .then(response => response.json())
            .then(dados => {
                const dadosFiltrado = dados.filter((row: any) => {
                    const d1 = new Date(row.dataAlertar);
                    const d2 = new Date();
                    return d1.getFullYear() === d2.getFullYear() &&
                        d1.getMonth() === d2.getMonth() &&
                        d1.getDate() === d2.getDate();
                });
                alert(dadosFiltrado.map((row:any)=>"O Contrato do candidato "  + row.candidato + ' vence hoje\n'));
            })
            .catch(err => console.error(err));
    }, [])



    return (
        <>

            <Navbar />
            <div className='b'>

                <div className="input-duplo">
                    <InputSmaller type="text" label="Nome" name="nome" value={candidato} onChange={event => setCandidato(event.target.value)} />
                    <InputSmaller type="date" label="Data Inicio" name="Data Inicio" value={dataInicio} onChange={event => setDataInicio(event.target.value)} />
                </div>
                <div className="input-duplo">
                    <InputSmaller type="date" label="Data Alerta" name="dataAlerta" value={dataAlerta} onChange={event => setDataAlerta(event.target.value)} />
                    <InputSmaller type="text" label="Empresa" name="Empresa" value={empresa} onChange={event => setEmpresa(event.target.value)} />
                </div>
                <Button value="Cadastrar" onClick={cadastrarContrato} />
            </div>
            <Lista />
        </>

    )
}

export default AlertaContrato;
import React, { useState } from 'react';
import Button from '../../components/Button';
import Header from '../../components/Header';
import Input from '../../components/Input';
import InputSmaller from '../../components/InputSmaller';
import imgcolaborador from '../../assets/images/imgEmpresa.png';
import './style.css';
import { Link, useHistory } from 'react-router-dom';
import InputMask from '../../components/InputMask';
import InputSmallerMask from '../../components/MaskTel'


export default function Business() {

    let history = useHistory();

    const [nomefantasia, setnomefantasia] = useState('');
    const [razaoSocial, setrazaosocial] = useState('');
    const [nomeContato, setnomecontato] = useState('');
    const [Linkedin, setlinkedin] = useState('');
    const [Website, setWebsite] = useState('');
    const [Cnpj, setcnpj] = useState('');
    const [cnae, setcnae] = useState('');
    const [email, setemail] = useState('');
    const [telefone, settelefone] = useState('');
    const [descricao, setdescricao] = useState('');
    const [porte, setport] = useState('');
    const [senha, setsenha] = useState('');
    const [cep, setCep] = useState('');
    const [rua, setRua] = useState('');
    const [complemento, setComplemento] = useState('');
    const [bairro, setBairro] = useState('');
    const [localidade, setLocalidade] = useState('');
    const [uf, setUf] = useState('');
    const [numero, setNumero] = useState('');

    const save = () => {
        const newbusi = {
            nomeFantasia: nomefantasia,
            razaoSocial: razaoSocial,
            nomeParaContato: nomeContato,
            linkedin: Linkedin,
            website: Website,
            cnpj: Cnpj,
            cnae: cnae,
            descricaoEmpresa: descricao,
            nomePorte: porte,
            idEnderecoNavigation: {
                rua: rua,
                numero: numero,
                bairro: bairro,
                complemento: complemento,
                cep: cep,
                nomeCidade: localidade,
                nomeEstado: uf,
                idUsuarioNavigation: {
                    email: email,
                    senha: senha,
                    telefone: telefone,
                    idTipoUsuario: 2
                }
            }
        }

        const urlRequest = "http://localhost:5000/api/empresas";

        console.log(newbusi)

        fetch(urlRequest, {
            method: "POST",
            body: JSON.stringify(newbusi),
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
                authorization: 'Bearer' + localStorage.getItem('provagas-chave-autenticacao')
            }
        })
            .then((response) => {
                return response.json()
            })
            .then(data => {
                if (data !== undefined) {
                    alert('Cadastrado')
                }
                else {
                    alert('Cadastro inválido');
                }
            })
            .catch(err => console.error(err));
    }




    const listcep = (valor: string) => {
        fetch(`https://viacep.com.br/ws/${valor}/json/`, {
            method: 'GET',
            headers: {
                'content-type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(dados => {
                setCep(dados.cep);
                setRua(dados.logradouro);
                setBairro(dados.bairro);
                setLocalidade(dados.localidade)
                setUf(dados.uf)

            })
            .catch(erro => console.error(erro))
    }

    return (
        <div className="prcp">
            <Header />
            <form onSubmit={event => {
                event.preventDefault();
                save();
            }}>
                <div className="cadastroEmpresa">
                    <div className="box-banner-candidato">
                        <img src={imgcolaborador} alt='desenho de duas pessoas frente a frente e cada uma mexendo em um computador' />
                    </div>

                    <h1>Cadastro da empresa</h1>
                    <h3>Dados de acesso</h3>
                    <br />
                    <div className="input-duplo">

                        <Input type="email"
                            label="E-mail *"
                            name="email"
                            placeholder={"Ex: gugugacasco@gmail.com"}
                            onChange={e => setemail(e.target.value)} />
                    </div>

                    <div className="input-duplo">

                        <Input type="password"
                            label="Senha *"
                            name="senha"
                            minLength={8}
                            maxLength={32}
                            onChange={e => setsenha(e.target.value)} />
                    </div>

                    <h4>Informações da Empresa</h4>

                    <div className="input-duplo">

                        <Input type="text"
                            label="Razão Social *"
                            name="senai"
                            placeholder={"Ex: BRQ Digital Soluções "}
                            onChange={e => setrazaosocial(e.target.value)} />

                    </div>

                    <div className="input-duplo">
                        <Input type="text"
                            label="Nome Fantasia *"
                            name="nome"
                            placeholder={"Ex: BRQ"}
                            onChange={e => setnomefantasia(e.target.value)} />
                    </div>

                    <div className="input-duplo">
                        <Input type="text"
                            label="CNPJ *"
                            name="cnpj"
                            maxLength={14}
                            minLength={14}
                            placeholder={"Ex: 01.222.333/0001-20"}
                            onChange={e => setcnpj(e.target.value)} />


                    </div>

                    <div className="input-duplo">

                        <Input type="text"
                            label="Linkedin ou GitHub"
                            name="linkedin"
                            placeholder={"Ex: https://www.linkedin.com/in/martinlutherc ou https://github.com/filipedeschamps"}
                            onChange={e => setlinkedin(e.target.value)} />
                    </div>

                    <div className="input-duplo">
                        <Input type="text"
                            label="Nome Para Contato"
                            name="nc"
                            placeholder={"Ex: Gabriel Espirito Santo"}
                            onChange={e => setnomecontato(e.target.value)} />


                    </div>

                    <div className="box-experiencias-text">
                        <label htmlFor="atividades">Descrição da empresa</label><br />
                        <textarea className="text-experiencias-atividades" name="atividades"
                            onChange={e => setdescricao(e.target.value)}
                            placeholder={"Ex: Somos uma rede de franquias sendo a primeira empresa brasileira dedicada exclusivamente ao desenvolvimento das capacidades do cérebro e a saúde mental"} />
                    </div>

                    <div className="input-duplo">

                        <InputSmaller type="text"
                            label="Website"
                            name="web"
                            placeholder={"Ex: http://www.brq.com/"}
                            onChange={e => setWebsite(e.target.value)} />

                        <InputSmaller type="text"
                            label="Porte da Empresa"
                            name="porte"
                            placeholder={"Ex: Grande"}
                            onChange={e => setport(e.target.value)} />

                    </div>

                    <div className="input-duplo">

                        <InputSmaller type="text"
                            label="CNAE"
                            name="cnae"
                            placeholder={"Ex: 9999-9/99"}
                            onChange={e => setcnae(e.target.value)} />

                        <InputSmallerMask type="tel"
                            mask="(99) 99999-9999"
                            label="Tel/Cel"
                            name="Contato"
                            placeholder={"Ex: (11) 97070-7070"}
                            onChange={e => settelefone(e.target.value)} />

                    </div>

                    <h4>Endereço da Empresa</h4>

                    <div className="input-duplo">
                        <InputMask type="text"
                            mask="99999-999"
                            label="CEP"
                            name="cep"
                            placeholder={"Ex: 03531-010"}
                            onChange={e => listcep(e.target.value)}
                        />

                    </div>

                    <div className="input-duplo">
                        <Input type="text"
                            label="Rua"
                            name="Rua"
                            placeholder={"Avenida Amador Bueno"}
                            value={rua}
                        />

                    </div>


                    <div className="input-duplo">
                        <InputSmaller type="text"
                            label="Estado"
                            name="esta"
                            placeholder={"Ex: São Paulo"}
                            value={uf}
                        />

                        <InputSmaller type="text"
                            label="Cidade"
                            name="Cidade"
                            placeholder={"Ex: São Paulo"}
                            value={localidade}
                        />
                    </div>

                    <div className="input-duplo">
                        <Input type="text"
                            label="Complemento"
                            name="compl"
                            placeholder={"Ex: Ao lado da padaria"}
                            onChange={e => setComplemento(e.target.value)} />

                    </div>

                    <div className="input-duplo">

                        <InputSmaller type="text"
                            label="Numero"
                            name="num"
                            placeholder={"Ex: 347"}
                            onChange={e => setNumero(e.target.value)} />

                        <InputSmaller type="text"
                            label="Bairro"
                            name="bairro"
                            placeholder={"Ex: Vila Campos de Jordão"}
                            value={bairro}
                        />

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
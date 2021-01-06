import React, { useEffect, useState } from 'react';
import Input from '../../components/Input';
import SelectInput from '../../components/SelectInput';
import InputSmaller from '../../components/InputSmaller'
import Button from '../../components/Button';
import ImageCandidato from '../../assets/images/imgCandidato.png';
import './style.css';
import Header from '../../components/Header';
import { Link, useHistory } from 'react-router-dom';
import { CropFreeTwoTone, LinkedIn } from '@material-ui/icons';
import InputSmallerMask from '../../components/MaskTel'

function Cadastro() {

  let history = useHistory();
  //POST - Candidato
  const [nomecompleto, setnome] = useState('');
  const [cpf, setcpf] = useState('');
  const [datanasc, setdatanasc] = useState('');
  const [linkedin, setlinkedin] = useState('');
  const [nomegenero, setnomegenero] = useState('');
  const [deficiencia, setdeficiencia] = useState(Boolean);
  const [cursosenai, setcursosenai] = useState(Boolean);
  const [nomedeficiencia, setnomedeficiencia] = useState('');
  const [nomeidioma, setnomeidioma] = useState('');
  const [nomecurso, setnomecurso] = useState('');
  const [nivelidioma, setnivelidioma] = useState('');
  const [nomeescolaridade, setEscolaridade] = useState( '')
  //POST - Usuario
  const [email, setemail] = useState('');
  const [telefone, settel] = useState('');
  const [senha, setsenha] = useState('');
  //POST - Endereço
  const [cep, setCep] = useState('');
  const [logradouro, setRua] = useState('');
  const [complemento, setComplemento] = useState('');
  const [bairro, setBairro] = useState('');
  const [localidade, setLocalidade] = useState('');
  const [uf, setUf] = useState('');
  const [numero, setNumero] = useState('');
  // POST - Experiencia 
  // const [experiencia,setexperiencia] = useState('')
  // const [empresa, setempresa] = useState('')
  // const [cargo, setcargo] = useState('')
  // const [dataInicio, setdatainicio] = useState('')
  // const [datafim, setdatafim] = useState('')
  // const [empregoAtual, setempregoatual] = useState(Boolean)
  // const [descricao, setdescricao] = useState('')

  // const [ idcandidato, setcandidato] = useState(0)

  // useEffect(() => {
  //   fetch('http://localhost:5000/api/NiveisEscolaridades')
  //     .then(data => data.json())
  //     .then(json => {
  //       json.map((item: any) => setEscolaridade((itens: any) => {
  //         return [...itens, {
    //           nomePropriedade: item.escolaridade,
    //           idPropriedade: item.idNivelEscolaridade
    //         }]
    //       }))
    //     })
    // }, []);
    
  
  
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

  const cadform = () => {
    const formadm = {
      nomeCompletoCandidato: nomecompleto,
      cpf: cpf,
      dataNascimento: datanasc,
      linkedin: linkedin,
      nomeGenero: nomegenero,
      possuiDeficiencia: deficiencia,
      nomeDeficiencia: nomedeficiencia,
      nomeIdioma: nomeidioma,
      nomeNivel: nivelidioma,
      cursandoSenai: cursosenai,
      curso: nomecurso,
      idEnderecoNavigation: {
        rua: logradouro,
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
                    idTipoUsuario : 1
               }
    },
    idNivelEscolaridadeNavigation: {
      escolaridade: nomeescolaridade,
    }
    
  }
   
     const urlRequest = "http://localhost:5000/api/candidatos";

        console.log(formadm)
        fetch(urlRequest, {
            method: "POST",
            body: JSON.stringify(formadm),
            headers: {
                'Content-Type': 'application/json;charset=utf-8',
            }
        })
            .then((response) => {
                return response.json()         
            })
            .then (data => {
                if (data !== undefined) {
                   alert('Cadastrado')
                  }
                  else{
                    alert('Cadastro inválido');
                  }
            })
            .catch(err => console.error(err));

  }


  // const caexperiencia = () => {
  //   const formexperiencia = {
  //     nomeExperiencia: experiencia,
  //   	nomeEmpresa: empresa ,
	//     cargo: cargo  ,
	//     dataInicio: dataInicio,
	//     dataFim: datafim,
  //   	empregoAtual: empregoAtual,
  //     descricaoAtividade: descricao,
  //     idCandidato: idcandidato
  //   }
  //   const urlRequest = "http://localhost:5000/api/experienciasprofissionais";

  //   console.log(formexperiencia)
  //   fetch(urlRequest, {
  //       method: "POST",
  //       body: JSON.stringify(formexperiencia),
  //       headers: {
  //           'Content-Type': 'application/json;charset=utf-8',
  //       }
  //   })
  //       .then((response) => {
  //           return response.json()         
  //       })
  //       .catch(err => console.error(err));
  // }

  return (
    <div className='ol'>
      <Header/>
      <form onSubmit= {event=>{ event.preventDefault();
            cadform();
            }}>
        <div className="cadastroCandidato">
          <div className="box-banner-candidato">
            <img className="imagem-candidato" src={ImageCandidato} alt="desenho de duas pessoas escrevendo" />
          </div>
          <h1>Cadastro de candidato</h1>
          <h4>Dados de acesso</h4>
          <Input 
            type="email" 
            label="E-mail *" 
            name="email" 
            onChange={e => setemail(e.target.value)}/>
          
          <Input 
            type="password" 
            label="Senha *" 
            name="senha" 
            placeholder="A senha deve conter no mínimo 8 caracteres" 
            onChange={e => setsenha(e.target.value)}/>
          
          <h4>Informações pessoais</h4>
          <Input 
            type="text" 
            label="Nome completo *" 
            name="nome" 
            onChange={e => setnome(e.target.value)}/>
          
          <div className="input-duplo">
            <Input 
              type="text" 
              label="CPF *" 
              name="cpf" 
              onChange={e => setcpf(e.target.value)}/>
         
          </div>
          <div className="input-duplo">
            <InputSmaller 
              type="date" 
              label="Data de nascimento *" 
              name="nascimento" 
              onChange={e => setdatanasc(e.target.value)}/>
            
            <InputSmallerMask type="tel" 
                            mask="(99) 99999-9999"
                            label="Tel/Cel"
                            name="Contato" 
                            placeholder={"Ex: (11) 97070-7070"} 
                            onChange={e => settel(e.target.value)}/>
            
          </div>
          <div className="input-duplo">
            <InputSmaller
              label="Gênero *"
              name="genero "
              placeholder={"Digite o seu genero"}
              onChange={e => setnomegenero(e.target.value)}/>
            
            <InputSmaller
              label="Nivel de escolaridade"
              name="escolaridade"
              placeholder={"Digite o seu nivel de escolaridade aqui"}
              onChange={e => setEscolaridade(e.target.value)}/>
            
          </div>
          <div className="input-duplo">
            <InputSmaller
              label="Idioma"
              name="idioma"
              onChange={e => setnomeidioma(e.target.value)}/>
            
            <InputSmaller
              label="Nivel idioma"
              name="nivelIdioma"
              onChange={e => setnivelidioma(e.target.value)}/> 
            
          </div>
          <Input 
            type="tex" 
            label="LinkedIn" 
            name="linkedin" 
            placeholder="Adicione aqui o link do seu LindekIn" 
            onChange={e => setlinkedin(e.target.value)}/>
          
       
        
        
            <div className="input-duplo">
            <div className="box-radio-label"> 
              <label>Possui alguma deficiência?</label>

              <div className="group-radio-label">
                <div className="group-radio">
                  <input id="sem" type="radio" name="radio1" value={"Sim"} onChange={e => { setdeficiencia(true)}} />
                  <label htmlFor="sem">Sim</label>
                </div>
                                                                                              
                <div className="group-radio">
                  <input id="com" type="radio" name="radio1" value={"Não"} onChange={e => { setdeficiencia(false) }} />
                  <label htmlFor="com">Não</label>
                </div>
              </div>
              </div>


            <InputSmaller
              label="Se sim, qual?"
              name="pcd"
              onChange={e => setnomedeficiencia(e.target.value)}/> 
        
            </div>
        <div className="input-duplo">
          <div className="box-radio-label">

            <label>Atualmente está cursando SENAI?</label>

            <div className="group-radio-label">
              <div className="group-radio">
            <input id="sim" type="radio" name="radio" value={"Sim"} onChange={e => { setcursosenai(true) }}  />
                <label htmlFor="sim">Sim</label>
              </div>

              <div className="group-radio">
                <input id="nao" type="radio" name="radio"value={"Não"} onChange={e => { setcursosenai(false) }}/>
                <label htmlFor="nao">Não</label>
              </div>
            </div>
          </div>
        <InputSmaller
              label="Qual?"
              name="pcd"
              onChange={event => setnomecurso( event.target.value)} 
            />
        </div>
        <h4>Endereço do usuario</h4>
          <div className="input-duplo">
            <InputSmaller 
              type="text" 
              label="CEP *" 
              name="cep" 
              onChange={event => listcep(event.target.value)}   
            />
            <InputSmaller 
              type="text" 
              label="Bairro" 
              name="bairro" 
              value={bairro} disabled
            />
          </div>
          <Input
            type="text" 
            label="Logradouro" 
            name="logradouro" 
            value={logradouro} 
            disabled 
          />
          <Input 
            type="text" 
            label="Complemento" 
            name="complemento"
            onChange={e => setComplemento(e.target.value)}/>
          
          <Input 
            type="text" 
            label="Número *" 
            name="numero" 
            onChange={e => setNumero(e.target.value)}/>
          
          <div className="input-duplo">
            <Input
              label="Cidade"
              name="cityInput"
              value={localidade} 
              disabled 
            />
         </div>
   
        {/* <h4>Experiências profissionais</h4>
          <div className="box-experiencias">
            <div className="input-duplo">
              <InputSmaller type="text" label="Nome da Empresa" name="empresa" onChange={e => setempresa(e.target.value)}/> 
              <InputSmaller type="text" label="Cargo" name="cargo" onChange={e => setcargo(e.target.value)} />
            </div>
            <div className="input-duplo">
              <InputSmaller type="date" label="Data de início" name="dataInicio"  onChange={e => setdatainicio(e.target.value)}/>
              <InputSmaller type="date" label="Data término" name="dataTermino"  onChange={e => setdatafim(e.target.value)}/>
            </div>
            <div className="box-experiencias-text">
              <label htmlFor="atividades">Descreva suas atividades</label>
              <textarea className="text-experiencias-atividades" name="atividades"  onChange={e => setdescricao(e.target.value)}/>
            </div>
            <input type="submit" className="btn-add-experiencia" value="Adicionar experiência" />

          </div> */}

          <br/>
          <br/>
          <br/>
        <Link className="link" to="/login"></Link><Button 
          value="Finalizar cadastro" 
        />
        <br/>
          <br/>
          <br/>
        </div>
      </form>
    </div>
  );
}

export default Cadastro;

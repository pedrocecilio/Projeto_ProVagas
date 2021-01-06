import React, { useEffect, useState } from 'react';
import Input from '../../../components/Input';
import InputSmaller from '../../../components/InputSmaller'
import Button from '../../../components/Button';
import ImageCandidato from '../../../assets/images/undraw_Documents_re_isxv.png';
import './style.css';
import Navleft from '../../../components/Navbar/navbar';
import moment from 'moment';
import TextField from '@material-ui/core/TextField/TextField';
import Check from '../../../components/Checkbox';
import InputSmallerMask from '../../../components/MaskTel'
import { parseJWT } from '../../../services/auth';


function CadastroVAGA() {

  const [nomevaga, setnomevaga] = useState('');
  const [localizacao, setlocalizacao] = useState('');
  const [limite, setlimite] = useState('');
  const [tipovaga, settipovaga] = useState('');
  const [nivelvaga, setnivelvaga] = useState('');
  const [datalimite, setdata] = useState('');
  const [descricaorequi, setdescricaorequi] = useState('')
  const [beneficiosFormat, setbeneficiosFormat] = useState<any[]>([])
  const [datainitial, setdateinitial] = useState('')
  const [descricao, setdescricao] = useState('');
  const [salario, setsalario] = useState('');



  const cadvaga = () => {

    let id = parseJWT().Id;


    const novavaga = {
      idVagaNavigation: {
        nomeVaga: nomevaga,
        descricaoAtividade: descricao,
        descricaoRequisito: descricaorequi,
        limiteDeInscricao: limite,
        dataInicio: datainitial,
        dataFinal: datalimite,
        localizacao: localizacao,
        salario: salario,
        idEmpresa: id,
        idTipoVagaNavigation: {
          nomeTipoVaga: tipovaga
        },
        idNivelVagaNavigation: {
          nomeNivelVaga: nivelvaga
        },
      },
      idBeneficioNavigation: {
        nomeBeneficio: String(beneficiosFormat)
      },
    }


    const urlRequest = "http://localhost:5000/api/beneficiosxvagas";
    console.log(novavaga)
    console.log(beneficiosFormat)
    fetch(urlRequest, {
      method: "POST",
      body: JSON.stringify(novavaga),
      headers: {
        'Content-Type': 'application/json',
      }
    })
      .then((response) => {
        return response.json()
      })
      .then(data => console.log(data))
      .catch(err => console.error(err));


  }

  return (
    <div className='ol'>
      <Navleft />
      <form onSubmit={event => {

        event.preventDefault();
        cadvaga();
      }
      }>
        <div className="cadas">
          <div className="box-banner-vaga">
            <img className="imagem-vaga" src={ImageCandidato} alt="desenho de duas pessoas escrevendo" />
          </div>
          <h1>Cadastro de vagas</h1>
          <h4>Dados da vaga</h4>
          <Input type="text" label="Nome Vaga" name="vaga"
            onChange={e => setnomevaga(e.target.value)}
          />

          <Input type="text" label="Cidade" name="cidade"
            onChange={e => setlocalizacao(e.target.value)}
          />

          <div className="box-experiencias">
            <div className="box-experiencias-text">

              <label htmlFor="atividades">Descreva as atividades dessa vaga</label><br />
              <textarea className="text-experiencias-atividades"
                name="atividades"
                onChange={e => setdescricao(e.target.value)}
              />
            </div>


          </div>


          <div className="input-duplo">
            <InputSmaller
              label="Salário"
              type="text"
              name="salario"
              placeholder={'Ex: R$ 700,00'}
              onChange={e => setsalario(e.target.value)}
            />

            <InputSmaller type="text"
              label="Limite de inscrição"
              name="limite"
              maxLength={3}
              placeholder={"Ex: 40"}
              onChange={e => setlimite(e.target.value)}
            />
          </div>

          <div className="input-duplo">
            <InputSmaller type="date"
              label="Data Inicial"
              name="date"
              onChange={e => setdateinitial(e.target.value)}
            />

            <InputSmaller
              type="date"
              label="Data Final"
              name="limite"
              onChange={e => setdata(e.target.value)}
            />
          </div>

          <div className="input-duplo">
            <InputSmaller type="text"
              label="Tipo da vaga"
              name="vaga"
              placeholder={"Ex: CLT"}
              onChange={e => settipovaga(e.target.value)}
            />

            <InputSmaller type="text"
              label="Nível da Vaga"
              name="vaga"
              placeholder={"Ex: Júnior"}
              onChange={e => setnivelvaga(e.target.value)}
            />
          </div>
          <h4>
            Selecione os beneficios da vaga
          </h4>
          <div className="rowlk">

            <div className="checkbox-left">
              <Check
                label={"Vale-Alimentação"}
                values={"Vale-Alimentação"}
                title={"Vale-Alimentação"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
            <br/>


              <Check
                label={"Vale-Refeição"}
                values={"Vale-Refeição"}
                title={"Vale-Refeição"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
            <br/>

              <Check
                label={"Vale-Transporte"}
                values={"Vale-Transporte"}
                title={"Vale-Transporte"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
            <br/>
              

              <Check
                label={"Auxílio-Creche"}
                values={"Auxílio-Creche"}
                title={"Auxílio-Creche"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
            <br/>

            </div>

            <div className="checkbox-right">
              <Check
                label={"Assistência-Odontologico"}
                values={"Assistência-Odontologico"}
                title={"Assistência-Odontologico"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
              <br/>

              <Check
                label={"Assistência-Médica"}
                values={"Assistência-Médica"}
                title={"Assistência-Médica"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
              <br/>

              <Check
                label={"Horario Flexivel"}
                values={"Horario Flexivel"}
                title={"Horario Flexivel"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
              <br/>


              <Check
                label={"Home-Office"}
                values={"Home-Office"}
                title={"Home-Office"}
                callbackvalue={(value: any) => setbeneficiosFormat((a: any) => [...a, value.value])}
              />
              <br/>
            </div>
          </div>
          <br/>
          <br/>
          <br/>
          <br/>
          <br/>
          <br/>

          <br />
          <br />
          <br />
          <Button value="Finalizar cadastro" />
        </div>
        <br/>
        <br/>
        

        <br />
      </form>
    </div>
  );
}
export default CadastroVAGA;
import React, {useState} from 'react';
import {useHistory} from 'react-router-dom';
import Button from '../../components/Button';
import imglogin from '../../assets/images/img_login.png'
import './style.css';
import Header from '../../components/Header';
import Footer from '../../components/Footer';
import InputSmaller from '../../components/InputSmaller';
import {parseJWT} from '../../services/auth';

function Login() {

  let history = useHistory();

  const [email, setEmail] = useState('');
  const [senha, setSenha] = useState('');

  const login = () => {
    const login ={
      email: email,
      senha: senha
    }
  
      fetch('http://localhost:5000/api/login', {
        method: 'POST',
        body: JSON.stringify(login),
        headers: {
            'content-type':'application/json'
        }
    })
        .then(resp => resp.json())
        .then(data =>{ localStorage.setItem("id", data.value.id)
            if (data.value.token != undefined) 
            {
                localStorage.setItem('provagas-chave-autenticacao', data.value.token)
                
                if (parseJWT().Role === 'Administrador')
                {
                    history.push('/dashboardadm/administrador');
                }
                if (parseJWT().Role === 'Empresa') 
                {
                    history.push('/dashboardempresa');
                }  
                if (parseJWT().Role === 'Candidato') 
                {
                    history.push('/');
                }
            }
            else {
                alert('Email ou senha incorretos');
            }
        })
        .catch(e => console.error(e));
  }

  return (
      <div>
        <Header />
        <div className="login">
          <img src={imglogin} alt="Imagem principal da tela de login"/>
            <hr/>
            <div className="login-dados">
                <h1>Bem vindo!</h1>
                <form onSubmit={ event => {
                  event.preventDefault();
                  login();
                }}>
                  <InputSmaller type="email" label="" name="email" placeholder="Digite seu e-mail" onChange={e => setEmail(e.target.value)}/>
                  <br/>
                  <InputSmaller type="password" label="" name="senha" placeholder="Digite sua senha" onChange={e => setSenha(e.target.value)}/>
                  <Button value="Entrar"/>
                </form>
            </div>
        </div>
        <Footer/>
      </div>
  );
}

export default Login;
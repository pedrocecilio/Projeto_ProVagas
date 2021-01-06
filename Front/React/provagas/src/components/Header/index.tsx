import React, {useState, useEffect} from 'react';
import './style.css';
import '../../assets/global.css';
import logoSenai from '../../assets/images/logoSenai.png';
import logoProVagas from '../../assets/images/logoProVagas.png';
import { Link, useHistory } from 'react-router-dom';
import { parseJWT } from '../../services/auth'


interface HeaderProps{
 
}




const Header:React.FC<HeaderProps> = (props) => {

    //Variavel que define a rota
    let history = useHistory();

    //Função que remove o token, efetuando o logout do usuario
    const logout =() => {
        //deve ser passsado no parametro da função "removeitem" o mesmo token que é passado no services
        localStorage.removeItem('provagas-chave-autenticacao');
        //definindo a rota, parametro passado deve ser a pagina que deseja que o usuario vá após o logout
        history.push('/');
    }

    const menu = () => {
        const token = localStorage.getItem('provagas-chave-autenticacao');

        if(token === undefined || token === null)
        {
            return (

                <div className="container-principal center">
                <div className="container-principal-header">
                <div className="container-central">
                    <nav className="navigation-header">
                    <div className="box-logos">
                            <Link to="/" className='menu-link'><img className="LOGO" src={logoSenai} alt="Logo do Senai" /></Link>
                            <Link to="/" className='menu-link'><img className="logoProVagas" src={logoProVagas} alt="Logo ProVagas"/></Link>
                        </div>
                        <ul className="menu">
                            <li><Link to="/vagas" className="menu-link linkheader"> Vagas</Link></li>
                            <li><Link to="/tipoCadastro" className="menu-link linkheader">Cadastro</Link></li>
                            <li><Link to="/login" className="menu-link link-login">Login</Link></li>
                        </ul>
                    </nav>
                </div>
            </div>
            </div>
            )
        }

        else 
        {
            if(parseJWT().Role === "Candidato"){
                return (
                    <div className="container-principal center">
                    <div className="container-principal-header" style={{   width: "100%", height: "10vh",  display: "flex", justifyContent: "center", backgroundColor: "#ED1F24" }}>
                    <div className="container-central">
                        <nav className="navigation-header">
                        <div className="box-logos">
                                <Link to="/"><img className="LOGO" src={logoSenai} alt="Logo do Senai" /></Link>
                                <Link to="/"><img className="logoProVagas" src={logoProVagas} alt="Logo ProVagas"/></Link>
                            </div>
                            <ul className="menu">
                                <li><Link to="/vagas" className="menu-link">Vagas</Link></li>
                                <li><Link to="/dashboarduser" className="menu-link">Dashboard</Link></li>
                                <li onClick={(event) => {
                                     event.preventDefault();
                                     logout();  }}>
                                <Link to="/" className="menu-link link-login">Logout</Link></li>
                            </ul>
                        </nav>
                    </div>
                </div>
                </div>
            );
            
        }
        else {
            
            if(parseJWT().Role === "Empresa")
            {
            return (
                <div className="container-principal center">
                <div className=".container-principal-header" style={{   width: "100%", height: "10vh",  display: "flex", justifyContent: "center", backgroundColor: "#ED1F24" }}>
                <div className="container-central">
                    <nav className="navigation-header">
                    <div className="box-logos">
                            <Link to="/"><img className="LOGO" src={logoSenai} alt="Logo do Senai" /></Link>
                            <Link to="/"><img className="logoProVagas" src={logoProVagas} alt="Logo ProVagas"/></Link>
                        </div>
                        <ul className="menu">
                            <li><Link to="/dashboardempresa" className="menu-link">Dashboard</Link></li>
                            <li><Link to="/vagas" className="menu-link">Vagas</Link></li>
                            <li onClick={(event) => {
                                 event.preventDefault();
                                 logout();  }}>
                            <Link to="/" className="menu-link link-login">Logout</Link></li>
                        </ul>
                    </nav>
                </div>
            </div>
            </div>
        );
        } else {
            if(parseJWT().Role === "Administrador"){
                return (
                    <div className="container-principal center">
                    <div className="container-principal-header"  style={{   width: "100%", height: "10vh",  display: "flex", justifyContent: "center", backgroundColor: "#ED1F24" }}>
                    <div className="container-central">
                        <nav className="navigation-header">
                        <div className="box-logos">
                                <Link to="/"><img className="LOGO" src={logoSenai} alt="Logo do Senai" /></Link>
                                <Link to="/"><img className="logoProVagas" src={logoProVagas} alt="Logo ProVagas"/></Link>
                            </div>
                            <ul className="menu">
                                <li><Link to="/vagas" className="menu-link">Vagas</Link></li>
                                <li><Link to="/dashboardadm/administrador" className="menu-link">Dashboard</Link></li>
                                <li onClick={(event) => {
                                     event.preventDefault();
                                     logout();  }}>
                                <Link to="/" className="menu-link link-login">Logout</Link></li>
                            </ul>
                        </nav>
                    </div>
                </div>
                </div>
             );
         }
      }
    }
  }
}
    return(
    <>
          {menu()}
      
        </>
    );
} 
export default Header;


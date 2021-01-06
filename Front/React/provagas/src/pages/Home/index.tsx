import React from 'react';
import Footer from '../../components/Footer';
import Header from '../../components/Header/index';
import Button from '../../components/Button';
import {Link} from 'react-router-dom';
import imgprincipal from '../../assets/images/imgprincipal_home.png';
import imgcandidato from '../../assets/images/imgcandidato_home.png';
import imgempresa from '../../assets/images/undraw_business_deal_cpi9.png';
import iconelocal from '../../assets/images/local.png';
import iconeporte from '../../assets/images/porte.png';
import iconecontrato from '../../assets/images/tipo-contrato.png';
import './style.css';
import { GrTextAlignCenter } from 'react-icons/gr';

function Home(){
    return(
            <div>
                <Header/>
                <div className="home">
                    <div className="slogan">
                        <div className="texto-slogan">
                            <h1>Pensado para empresas, pensado para candidatos!</h1>
                                <p>Uma plataforma de emprego dedicada ao Senai, onde os alunos encontram vagas selecionadas
                                    de empresas conceituadas e parceiras, capazes de proporcionar um ambiente adequado aos 
                                    que estão ingressando na área. Disponibilizando todo o apoio e conteúdo necessário para 
                                    que o aluno coloque em prática tudo o que foi aprendido no curso e consiga ter um 
                                    crescimento profissional.
                                </p>
                            <div className="botao-slogan">
                                <div className="btn1home">
                                <Link to="/vagas" className="mudabotao"><Button value="Encontrar uma vaga"/></Link>
                                </div>
                                <div className="btn2home">
                                <Link to="/login" className="mudabotao"><Button value="Publicar uma vaga" id="bt2"/></Link>
                                </div>
                            </div>
                        </div>
                        <img id="imgprincipal" src={imgprincipal} alt="Imagem principal ProVagas"/>
                    </div>
                    <div className="vantagens">
                        <ul className="candidato">
                            <img src={imgcandidato} alt="Imagem candidato"/>
                            <h2>Candidato</h2>
                            <li>Candidatura simplificada</li>
                            <li>Plataforma segura</li>
                            <li>Vagas direcionadas ao seu perfil</li>
                        </ul>
                        <ul className="empresa">
                            <img src={imgempresa} alt="Imagem empresa"/>
                            <h2>Empresa</h2>
                            <li>Candidatos qualificados</li>
                            <li>Plataforma gratuita</li>
                            <li>Acompanhamento do processo</li>
                        </ul>
                    </div>
                    <div className="ultimasvagas">
                        <h2>Nossas últimas vagas</h2>
                        <div className="algumasvagas">
                            <ul className="vaga">
                                <h3>Estágio em Desenvolvimento de Sistemas</h3>
                                <hr/>
                                <h4>BRQ</h4>
                                <li><img src={iconelocal} alt="Ícone de local"/>São Paulo</li>
                                <li><img src={iconeporte} alt="Ícone de porte da empresa"/>Grande</li>
                                <li><img src={iconecontrato} alt="Ícone de contrato"/>Estagiário</li>
                                <Link to="/detalhevaga" className="mudabotao"><Button value="Saiba mais" id="btnvaga1"/></Link>
                            </ul>
                            <ul className="vaga">
                                <h3>Desenvolvedor Full Stack</h3>
                                <hr/>
                                <h4>BRQ</h4>
                                <li><img src={iconelocal} alt="Ícone de local"/>São Paulo</li>
                                <li><img src={iconeporte} alt="Ícone de porte da empresa"/>Grande</li>
                                <li><img src={iconecontrato} alt="Ícone de contrato"/>Junior</li>
                                <Link to="/detalhevaga" className="mudabotao"><Button value="Saiba mais" id="btnvaga1"/></Link>
                            </ul>
                            <ul className="vaga">
                                <h3>Desenvolvedor Back-end</h3>
                                <hr/>
                                <h4>BRQ</h4>
                                <li><img src={iconelocal} alt="Ícone de local"/>São Paulo</li>
                                <li><img src={iconeporte} alt="Ícone de porte da empresa"/>Grande</li>
                                <li><img src={iconecontrato} alt="Ícone de contrato"/>Junior</li>
                                <Link to="/detalhevaga" className="mudabotao"><Button value="Saiba mais" id="btnvaga1"/></Link>
                            </ul>
                        </div>
                        <Link to="/vagas" className="mudabotao"><Button value="Ver mais"/></Link>
                    </div>
                </div>
                <Footer/>
            </div>
    );
}

export default Home;
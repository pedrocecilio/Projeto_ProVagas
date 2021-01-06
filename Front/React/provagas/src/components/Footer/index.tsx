import React from 'react';
import logosenai from './../../assets/images/logo-senai.png';
import facebook from './../../assets/images/face-icon.png';
import instagram from './../../assets/images/insta-icon.png';
import twitter from './../../assets/images/twit-icon.png';
import linkedin from './../../assets/images/link-icon.png';

import './style.css';




function Footer() {
  return (
    <div className="footer">
      <div className="logoFooter">
        <img src={logosenai} alt="Logotipo do Senai, vermelho e branco." />
        <hr/>
          <div>
            <p>Escola SENAI de informatica</p>
            <p>Avenida Alameda Barâo de Limeira</p>
            <p>CEP: 01202-001</p>
            <p>Telefone: (11)3273-5000</p>
          </div>
      </div>
      <div className="iconsFooter">
        <img src={facebook} alt="Logotipo facebook, com link direto para o facebook." />
        <img src={instagram} alt="Logotipo instagram, com link direto para o instagram." />
        <img src={twitter} alt="Logotipo twitter, com link direto para o twitter." />
        <img src={linkedin} alt="Logotipo linkedin, com link direto para o linkedin." />
      </div>
    </div>
  );
}

export default Footer;

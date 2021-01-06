import React from 'react';
import './style.css';


function Menu(){
    return(
            <div className='menuAdm'>
                <ul>
                    <li>Perfil</li>
                    <hr/>
                    <li>Empresas</li>
                    <hr/>
                    <li>Alunos</li>
                    <hr/>
                    <li>Administradores</li>
                    <hr/>
                    <li>Alerta</li>
                    <hr/>
                </ul>
            </div>
    )
}

export default Menu;
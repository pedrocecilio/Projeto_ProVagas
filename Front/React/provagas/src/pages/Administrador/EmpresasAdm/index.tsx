import React from 'react';
import InputSearch from '../../../components/InputSearch';
import ListaEmpresa from '../../../components/ListaEmpresa';
import Navbar from '../../../components/Navbar/navbar';
import './style.css';



function EmpresaAdm(){
    return(
        <div className="cabeçalho">
            <aside>
                <Navbar/>
            </aside>
            <div className='bo'>
            <ListaEmpresa/>                
            </div>
        </div>
                
    );
}

export default EmpresaAdm;
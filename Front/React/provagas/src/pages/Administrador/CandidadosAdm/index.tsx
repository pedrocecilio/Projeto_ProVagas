import React from 'react';
import InputSearch from '../../../components/InputSearch';
import ListaCandidato from '../../../components/ListaCandidato';
import Navbar from '../../../components/Navbar/navbar';
import './style.css';



function CandidatosAdm(){
    return(
        <div className="cabeçalho">
            <aside>
                <Navbar/>
            </aside>
            <div className="be">

            <ListaCandidato/>                
            </div>
        </div>
                
    );
}

export default CandidatosAdm;
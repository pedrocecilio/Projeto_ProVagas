import React from 'react';
import InputSearch from '../../../components/InputSearch';
import ListaAdm from '../../../components/ListaAdm';
import Navbar from '../../../components/Navbar/navbar';
import './style.css';



function Admin(){
    return(
        <div className="cabeçalho">
            <aside>
                <Navbar/>
            </aside>
            <div className='ba'>

            <ListaAdm/>
                
            </div>
        </div>
                
    );
}

export default Admin;
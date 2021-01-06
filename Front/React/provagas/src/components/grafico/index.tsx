import React from 'react';
import './style.css'

export default function grafico() {
    return (
    <div className="body">
        <div className='circular'>
            <div className="inner"></div>
            <div className="numb">50%</div>
                <div className="circle">
                   <div className="bar left">
                        <div className="progress">
                        </div>
                    </div>
                    <div className="bar right">
                        <div className="progress">
                        </div>
                    </div>
                </div>
        </div>
    </div>
    )
}
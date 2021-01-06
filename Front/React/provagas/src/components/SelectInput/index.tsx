import './style.css'
import React from 'react';
import { InputHTMLAttributes } from 'react';


interface SelectProps extends InputHTMLAttributes<HTMLInputElement>{
    name: string;
    options: Array<any>, 
    labelText: string,
    callbackChangedValue:(value: any) => void
}


export default function Select(props: SelectProps){

    const {name, options, labelText, callbackChangedValue} = props;

    return (
        <div className="">
            <div className="box-select-label">
            <label htmlFor={name}>{labelText}</label>
            <select className="select-input" id={name} onChange={(event) => {
                callbackChangedValue(event.target.value)
            }}>
                <option defaultValue="selected">Selecione</option>
                {options.map((o, i) => {
                    if(o.nomePropriedade) {
                        return <option key={i} value={o.idPropriedade}>{o.nomePropriedade}</option>
                    }
                })
                }
            </select>
            </div>
        </div>
    )
}
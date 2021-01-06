import React from 'react';
import { InputHTMLAttributes } from 'react';
import InputMask from 'react-input-mask';
import './style.css'

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
    label: string;
    name: string;
    mask:any;
  }
  
  const Inputperfil: React.FunctionComponent<InputProps> = ({mask, label, name, ...rest}) => {
    return (
      <div>
          <label htmlFor={name}>{label}</label>
          <br/>
          <InputMask mask={mask}  className='entrada' type="text" id={name} {...rest}/>
      </div>
    );
  }
  
  export default Inputperfil;
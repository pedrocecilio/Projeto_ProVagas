import React, {InputHTMLAttributes} from 'react';
import '../../assets/global.css';
import './style.css';

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
  label: string;
  name: string;
}

const Input: React.FunctionComponent<InputProps> = ({label, name, ...rest}) => {
  return (
    <div>
        <label htmlFor={name}>{label}</label>
        <br/>
      <input className="entrada" type="text" id={name} {...rest}/>
    </div>
  );
}

export default Input;
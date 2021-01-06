import React, {InputHTMLAttributes} from 'react';
import '../../assets/global.css';
import './style.css';
import Iinput from 'react-input-mask'

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
  label: string;
  name: string;
  mask:any;
}

const Inputperfil: React.FunctionComponent<InputProps> = ({ mask, label, name, ...rest}) => {
  return (
    <div>
        <label htmlFor={name}>{label}</label>
        <br/>
        <Iinput mask={mask} maskPlaceholder={null} className='per' type="text" id={name} {...rest}/>
    </div>
  );
}

export default Inputperfil;
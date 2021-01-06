import React, {InputHTMLAttributes} from 'react';
import '../../assets/global.css';
import './style.css';
import InputTel from 'react-input-mask'

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
  label: string;
  name: string;
  mask: any;
}

const Inputmasktel: React.FunctionComponent<InputProps> = ({mask, label, name, ...rest}) => {
  return (
    <div>
      <div className="box-input-smaller">
        <label htmlFor={name}>{label}</label>
        <InputTel maskPlaceholder={null} mask={mask} className="smaller-input" type="text" id={name} {...rest}/>
      </div>
    </div>
  );
}

export default Inputmasktel;
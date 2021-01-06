import React, {InputHTMLAttributes} from 'react';
import '../../assets/global.css';
import './style.css';

interface InputProps extends InputHTMLAttributes<HTMLInputElement>{
  label: string;
  name: string;
}

const InputSmaller: React.FunctionComponent<InputProps> = ({label, name, ...rest}) => {
  return (
    <div>
      <div className="box-input-smaller">
        <label htmlFor={name}>{label}</label>
        <input className="smaller-input" type="text" id={name} {...rest}/>
      </div>
    </div>
  );
}

export default InputSmaller;
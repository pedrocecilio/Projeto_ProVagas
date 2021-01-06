import React from 'react';
import '../../assets/global.css';
import './style.css';

interface ButtonProps {
  value: string;
  id?:string;
  onClick ?: any;
  style ?: any;
}

const Button: React.FunctionComponent<ButtonProps> = ({style, onClick, value, id}) => {
  return (
    <div className="btn">
      <input  style={style} className="button" type="submit" value={value} id={id} onClick={onClick} />
    </div>
  );
}

export default Button;
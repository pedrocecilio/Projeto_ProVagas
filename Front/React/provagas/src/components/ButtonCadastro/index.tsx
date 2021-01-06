import React from 'react';
import '../../assets/global.css';
import './style.css';

interface ButtonProps {
  value: string;
  id?:string;
  onClick?:any;
}

const Button: React.FunctionComponent<ButtonProps> = ({value, id, onClick}) => {
  return (
    <div className="btn">
      <input className="button" type="submit" value={value} id={id} onClick={(event: any) => onClick(event)}/>
    </div>
  );
}

export default Button;
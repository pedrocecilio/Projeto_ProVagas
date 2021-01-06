import React from 'react'
import './style.css'

interface checkboxprops {
    values: any;
    label:string;
    callbackvalue: any;
    title:any;
}

const checkBox: React.FunctionComponent<checkboxprops>= ({title, values, callbackvalue, label}) => {
  return (
      <div>
            <input 
            className="box"
            type="checkbox"
            value={values}
            title={title}
            onChange={event => {
                callbackvalue({
                    value: title,
                    checked: event.target.checked
                })
            }}
            
            />
            <label htmlFor="label">{label}</label>
      </div>
  )
}

export default checkBox;
import React from "react";
import Th from "./th.jpg";
import "./logo.css";

class Logo extends  React.Component{

    render(){
        return(
            <div className="Row" >
            <a href="https://fr.reactjs.org/"><img src={Th} alt="logo"/></a>
          </div>
        )
    }
}


export default Logo;
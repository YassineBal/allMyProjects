import React from "react";
import axios from "axios";

class AjouterDep extends React.Component{
    constructor(props){
        super(props);
        this.state={
            departement:'',
            Superviseur:'',
            code:''
        }

        this.onchangeCode=this.onchangeCode.bind(this);
        this.onchangeDep=this.onchangeDep.bind(this);
        this.onchangeSuperviseur=this.onchangeSuperviseur.bind(this);
        this.onsubmit=this.onsubmit.bind(this);
    }

    onsubmit(e){
        e.preventDefault(e);
        const Dep={
            departement:this.state.departement,
            superviseur:this.state.superviseur,
            code:this.state.code
         }
         console.log(Dep);
         axios.post("http://10.30.40.121:3044/departement/newdepartement",Dep)
         .then(res=>console.log(res.data))
         
         this.setState({
            departement:'',
            superviseur:'',
            code:''
         })
    }

    onchangeDep(e){
        this.setState({
            departement:e.target.value
        })
    }

    onchangeSuperviseur(e){
        this.setState({
            superviseur:e.target.value
        })
    }
    
    onchangeCode(e){
        this.setState({
            code:e.target.value
        })
    }
    
    render(){
        return(
            <div className="container">
                <h3>Ajouter un departement</h3>
               <form onSubmit={this.onsubmit}>
                    <div className="form-group">
                        <label>
                            Departement:
                        </label>
                        <input type="text" name="departement" value={this.state.departement} required className="form-control" onChange={this.onchangeDep} >
                        </input>
                        <label>
                            Superviseur:
                        </label>
                        <input type="text" name="superviseur"  value={this.state.superviseur} required className="form-control" onChange={this.onchangeSuperviseur} >
                        </input>
                        <label>
                            Code:
                        </label>
                        <input type="text" name="code"  value={this.state.code} required className="form-control" onChange={this.onchangeCode}  ></input>
                    </div>
                    <br/>
                    <div className="form-group">
                        <input type="submit" value="Ajout" className="btn btn-primary" id="monbtn">
                        </input>
                    </div>
               </form>
            </div>
        )
    }
}

export default AjouterDep;
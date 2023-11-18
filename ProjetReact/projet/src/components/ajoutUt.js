import React from "react";
import axios from 'axios';

class ajoutUt extends React.Component{



    
handleChange(e){
    this.setState({[e.target.name]:e.target.value});
    console.log(e.target.name);

}


onSubmit(e){
    e.preventDefault();
    const util={
        code:this.state.code,
        nom:this.state.nom,
        prenom:this.state.prenom,
        departement:this.state.dep
    }


    console.log(util);

    axios.post('http://10.30.40.121:3044/user/newuser',util)
    .then(resultat=>{
        console.log(resultat.data)
    });

    //on fait cela pour qu'il vide les champs du formulaire

    this.setState(
        this.setState({
            code:'',
            nom:'',
            prenom:''
        })
    );
}



constructor(props){
    super(props);
   
    this.state={
        code:'',
        nom:'',
        prenom:'',
        dep:'',
        departs:[]
    }

    this.onSubmit=this.onSubmit.bind(this);
    this.handleChange=this.handleChange.bind(this);
   

}


componentDidMount(){
    axios.get('http://10.30.40.121:3044/departement/departements')
    .then(response=>{
        console.log(response.data);
       const deps = response.data; //
        if(response.data.length > 0){
            this.setState({
                departs:deps.map(dep=>dep.departement), //
                dep:deps[0].departement //
            })
        }
       }).catch((error)=>{
        console.log(error);
       })}

    render(){



        return(
<div className='container'>
                <h3>Ajouter un utiliateur </h3>
                <form onSubmit={this.onSubmit}>
                    <div className="form-groupe">
                       <label>
                         Departement
                       </label>
                       <select className="form-control" onChange={this.handleChange} name="dep" value={this.state.dep}>
  {this.state.departs.map(function(dep){
    return <option key={dep} value={dep}>{dep}</option>
  })}
</select>


                    </div>
                    <div className='form-group'>
                        <label>Nom : </label>
                        <input type="text"
                         required 
                         name='nom'
                         className='form-control'
                         value={this.state.nom}
                         
                         onChange={this.handleChange}/>    

                    </div>

                    <div className='form-groupe'>
                        <label>Prenom : </label>
                        <input type="text"
                         
                        name='prenom' 
                        className='form-control'
                        value={this.state.prenom}
                       
                        onChange={this.handleChange}
                        />
                     </div>
                    
                    <div className='form-groupe'>
                    <label>Code : </label>
                         <input 
                         name='code' type="text" required className='form-control'
                         value={this.state.code}
                        
                         onChange={this.handleChange}
                         />
                    </div>
                    <div className='form-group'>

                        <input type="submit" value="Ajout" className='btn btn-primary'/>
                    </div>
                </form>
            </div>


        )
    }
}

export default ajoutUt;
import React from "react";
import {useNavigate, useParams} from "react-router-dom";
import {  useState, useEffect} from 'react';
import axios from "axios";


const edit =() => {
    const navigate = useNavigate();
    const {id}=useParams();
    console.log(id);
 const[code,setCode]=useState('');
 const[nom, setNom]=useState('');
 const[prenom, setPrenom]=useState('');
useEffect(()=>{
const url = `http://10.30.40.121:3044/user/lireUnUser/${id}`;
axios.get(url)
.then((tata)=>{
    const{code,nom,prenom}=tata.data
    setCode(code);
    setNom(nom);
    setPrenom(prenom);
})
.catch((err)=>{
    console.log(err);
});
},[]);

function handleNomChange(event) {
    setNom(event.target.value);
  }

  function handlePrenomChange(event) {
    setPrenom(event.target.value);
  }

  function handleCodeChange(event) {
    setCode(event.target.value);
  }

const onSubmit=(e)=>{
    e.preventDefault();
    setCode('')
    setNom('')
    setPrenom('')
    console.log("la fonction est appelee")
    const util={
        code:code,
        nom:nom,
        prenom:prenom
    }
    console.log(util);

    axios.put('http://10.30.40.121:3044/user/updateuser/'+id, util)
    .then(res=>{
        console.log(res.data);
        navigate("/liste")
        
    });
    
  
}
    return(
        <div className='container'>
                <h3>Modifier un utilisateur </h3>
                <form onSubmit={onSubmit}>

                    <div className='form-group'>
                        <label>Nom : </label>
                        <input type="text"
                         required 
                         name='nom'
                         className='form-control'
                         value={nom}
                         
                         onChange={handleNomChange}/>    

                    </div>

                    <div className='form-groupe'>
                        <label>Prenom : </label>
                        <input type="text"
                         required
                        name='prenom' 
                        className='form-control'
                        value={prenom}
                       
                        onChange={handlePrenomChange}
                        />
                     </div>
                    
                    <div className='form-groupe'>
                    <label>Code : </label>
                         <input 
                         name='code' type="text" required className='form-control'
                         value={code}
                        
                         onChange={handleCodeChange}
                         />
                    </div>
                    <div className='form-group'>

                        <input type="submit" value="Modifier" className='btn btn-primary'/>
                    </div>
                </form>
            </div>
        
    )
}


export default edit;
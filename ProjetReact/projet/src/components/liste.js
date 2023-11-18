import React from "react";
import GenListe from './GenListe';
import axios from "axios";




class Utilisateurs extends React.Component{



componentDidMount(){
   axios.get('http://10.30.40.121:3044/user/users')
   .then(response=>{
    console.log(response.data);
    if(response.data.length > 0){
        this.setState({
            utilis: response.data
        })
    }
   }).catch((error)=>{
    console.log(error);
   })
}
deleteUtil(id){
    axios.delete('http://10.30.40.121:3044/user/deluser/'+id)
    .then(res =>console.log(res.data));
    this.setState({
        utilis:this.state.utilis.filter(toto =>toto._id !==id)
    })
}
userList(){
    return this.state.utilis.map(utilCourant => {
 
     return <GenListe utilisateur={utilCourant}deleteUtil={this.deleteUtil} key={utilCourant.code}/>;
 
 })}

 constructor(props){
    super(props);
    this.state={
        utilis:[]
    }

    this.deleteUtil=this.deleteUtil.bind(this);
}
 render(){
    return(
       <div className="container">
       <h3>Liste des utilisateurs</h3>
       <table className='table'>
        <thead className='thead-light'>
            
            <tr>
                <th>Code</th>
                <th>Nom</th>
                <th>Prenom</th>
                <th>Departement</th>
            </tr>
        </thead>
        <tbody>
            {this.userList()}
            
        </tbody>
       </table>
       </div>
    );
}
}



    

export default Utilisateurs;
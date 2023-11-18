import React from 'react'
import { Link } from 'react-router-dom';

class GenListe extends React.Component{
    render(){
        return(
        <tr>
            <td>{this.props.utilisateur.code}</td>
            <td>{this.props.utilisateur.nom}</td>
            <td>{this.props.utilisateur.prenom}</td>
            <td>{this.props.utilisateur.departement}</td>
            <td>
            <Link to={"/edit/"+this.props.utilisateur._id}>Edition</Link> <a href="#" onClick={()=>{this.props.deleteUtil(this.props.utilisateur._id)}}>Suppression</a>
            </td>
            <td>{this.props.deps}</td>
        </tr>
        )
    }
}



export default GenListe;
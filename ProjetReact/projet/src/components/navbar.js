import React from 'react';
import {Link} from 'react-router-dom'



class Navbar extends React.Component { 
       render()  {
        return (
<nav className="navbar navbar-expand-lg navbar-dark bg-dark">
  <div className="container-fluid">
  <a className="navbar-brand" href="/">Bienvenue</a>
    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span className="navbar-toggler-icon"></span>
    </button>
    <div className="collapse navbar-collapse" id="navbarNav">
     <div className='navbar-nav'>
        <Link to="/liste" className='nav-link'>Utilisateurs</Link>
        <Link to="/ajoutUt"  className='nav-link'>Ajout Utilisateurs</Link>
        <Link to="/ajoutDep" className='nav-link'>Ajout Departement</Link>
        

        </div>
    </div>
  </div>
</nav>
        );
    }
}


export default Navbar;
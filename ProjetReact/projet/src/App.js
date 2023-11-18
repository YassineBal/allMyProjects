import React from 'react';
import { BrowserRouter,Routes,Route, Navigate } from 'react-router-dom';
import "bootstrap/dist/js/bootstrap.bundle.min.js";
import "bootstrap/dist/css/bootstrap.min.css";
import Edit from './components/edit';
import Navbar from './components/navbar';
import Logo from './components/Logo';
import AjoutUt from './components/ajoutUt';
import Liste from './components/liste';
import AjouterDep from './components/ajoutDep';

class App extends React.Component{
  render(){

    return(
      <div className='container'>
<BrowserRouter>
<Navbar/>

<Routes>
<Route path='/' element={<Navigate to="/Logo"/>}/>

<Route path='/Logo' element={<Logo/>} />
  <Route path='/edit/:id' element={<Edit/>}/>
  <Route path='liste' element={<Liste/>}/>
  <Route path="ajoutUt" element={<AjoutUt/>}/>
  <Route path="/ajoutDep" element={<AjouterDep/>}/>
  
</Routes>

</BrowserRouter>
     

      </div>
    )
  }
}



export default App;

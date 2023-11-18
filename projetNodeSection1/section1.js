const express = require('express');
const prj = express();

prj.set("views","./views");
prj.set("view engine","ejs");

prj.use('/public',express.static('public'));

routeAnimaux=require('./routes/RoutesAnimaux');
prj.use('/anim',routeAnimaux);


prj.get('/',function(req,res){
    res.render('index',{pageTitle:"Votre_Nom"});
})

prj.get('/:nom',(req,res)=>{
    const nom=req.params.nom;
    res.render('index',{pageTitle:nom});
})






prj.listen(3045,()=>{
    console.log("Server On :)");
})

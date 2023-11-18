const { name } = require('ejs');
const express = require('express');
const router =express.Router();
const mysql=require('mysql');


router.use('/public',express.static('public'));

var con =mysql.createConnection({
    host:'localhost',
    user:'root',
    password:'',
    database:'fcsprojet'
})

con.connect(function(erreur){
    if(erreur){
        throw erreur;
    }
    console.log("Connection reussi");
})

router.get('/animaux',(req,res)=>{
    con.query('SELECT*FROM animal',(erreur,result)=>{
        if(erreur){
            throw erreur;
        }
        else{
            console.log({print:result});
            res.render('animaux',{print:result,pageTitle:"Votre_Nom"});
        }   
})
})


router.get('/animaux/:nom',(req,res)=>{
    const nom=req.params.nom;
    con.query('SELECT*FROM animal',(erreur,result)=>{
        if(erreur){
            throw erreur;
        }
        else{
            console.log({print:result});
            res.render('animaux',{print:result,pageTitle:nom});
        }   
    })
})

module.exports=router;
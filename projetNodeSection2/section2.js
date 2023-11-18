const express = require("express");
const app = express();
const cors = require('cors');
app.use(cors());
const mongoose = require('mongoose');
const connection=mongoose.connection;


app.use(express.json());
const routesCours=require('./routes/routesCours');

app.use('/proj',routesCours);

//creation de connection 

mongoose.connect('mongodb://BalAM2:12345@10.30.40.121:27017/BalAM2',{ useNewUrlParser:true });

/*mongoose.connect('mongodb://BalA:12345@10.30.40.121:27017/BalA',{ useUnifiedTopology: true, useNewUrlParser: true }  ); */

/*mongoose.connect('mongodb://localhost:27017/bdSection2',{useNewUrlParser:true});*/

//tester la connexion 

connection.once('open',()=>{
    console.log('Connected to MongoDB');
})


app.listen(3044,()=>{
    console.log("j'ecoute le port 3044!");
});


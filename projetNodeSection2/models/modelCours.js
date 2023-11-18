const mongoose=require('mongoose');

const shemaCours=new mongoose.Schema({
   module: String,
   professeur: String,
   duree: String,
   prix: String 
})

module.exports = mongoose.model('cours',shemaCours);


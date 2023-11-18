const mongoose=require('mongoose');
const express=require('express');
const router=express();

const cours=require('../models/modelCours');

router.post('/newCour/',(req,res)=>{
    console.log('req.body',req.body);

    const nvcour = new cours(req.body);

    nvcour.save((erreur,nvcour)=>{
        if(erreur){
            return res.status(500).json(erreur);
        }
        res.status(201).json(nvcour);
    })
})


router.get('/cours/',(req,res)=>{
    cours.find().exec().then(data=>res.status(200).json(data));

})

router.delete('/delCour/:id',(req,res)=>{
    const id = req.params.id;
    cours.findByIdAndDelete(id,(erreur,cours)=>{
        if(erreur){
            return res.status(500).json(erreur);
        }
        res.status(202).json({msg: `cour avec id  ${cours._id} supprimee`});
    })
})

router.put('/upCour/:id',(req,res)=>{
    const id=req.params.id
    cours.findById(id).then(cours =>{
        cours.module=req.body.module;
        cours.professeur=req.body.professeur;
        cours.duree=req.body.duree;
        cours.prix=req.body.prix;

        cours.save().then(()=>res.json('Edition reussie!')).catch(erreur=>res.status(400).json('Error on saving: '+erreur));
    }).catch(erreur=>res.status(400).json('Error with id: '+erreur));
    
});

router.get('/findCour/:id',(req,res)=>{
    const id=req.params.id
    cours.findById(id,(erreur,cours)=>{
        if(erreur){
            res.status(202).json(msg=>`cette id  ${cours._id} est non trouvee`);
        }
        res.json(cours);
    })
})
module.exports=router;
<?php
include 'connexion.php';
class boutique{
    public function DisplayCat()
    {
        $connexion=new Connexion();
        $con= $connexion->getConnexion();
        $req= "SELECT DISTINCT categorie FROM fleurs";
        $res=$con->query($req);
        if ($res->num_rows>0){
            $data=array();
        while($cat = $res->fetch_assoc()){
            $data[]=$cat;
        }
        return $data;
        

    }}

    public function DisplayData()
    {
        $connexion=new Connexion();
        $con= $connexion->getConnexion();
        $req= "SELECT * FROM fleurs";
        $res=$con->query($req);
        if ($res->num_rows>0){
            $data=array();
        while($cat = $res->fetch_assoc()){
            $data[]=$cat;
        }
        return $data;
        

    }}


    // Fetch single product data
    public function displayRecordBycat($cat){
        $connexion=new Connexion();
        $con=$connexion->getConnexion();
        $new_query = "SELECT * FROM fleurs WHERE categorie = '$cat'";
        $result = $con->query($new_query);
        if($result->num_rows > 0){            
           $row = $result->fetch_assoc();
            return $row;
        }
        else{
            echo 'Record not found!';
        }
    }
    
    // Fetch single product data
    public function displayRecordById($id){
        $connexion=new Connexion();
        $con=$connexion->getConnexion();
        $new_query = "SELECT * FROM fleurs WHERE id_produit = '$id'";
        $result = $con->query($new_query);
        if($result->num_rows > 0){            
           $row = $result->fetch_assoc();
            return $row;
        }
        else{
            echo 'Record not found!';
        }
    }
    




    
}
?>
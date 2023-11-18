<?php
include 'boutique_Model.php';
$boutique=new boutique();
$bout=$boutique->DisplayCat();
if(isset($_GET['categorie'])){
   $categorie=  $_GET['categorie'];
  $bot=$boutique->displayRecordBycat($categorie);
 }

 if(isset($_GET['id_produit'])) 
	{  
        $id_produit=  $_GET['id_produit'];
		$bout=$boutique->displayRecordById($id_produit);
   }
?>
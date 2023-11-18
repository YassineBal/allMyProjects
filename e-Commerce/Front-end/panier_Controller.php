<?php
include 'panier_Model.php';
$panier=new panier();
if(isset($_POST['ajout_panier']))
{
    $produit=$panier->ajout_panier($_POST['ajout_panier']);
    if (!isset($_SESSION['panier']))
	{$panier->creation_Panier();}
    $panier->ajouterProduitDansPanier($produit['categorie'],$_POST['id_produit'],$_POST['quantite'],$produit['prix']);

}

//retirer un produit du panier
if(isset($_GET['action']) && $_GET['action'] == "retirer")
{
	$panier->retirerproduitDuPanier($_GET['id_produit']);
}

//vider le panier
if((isset($_GET['action']) && $_GET['action'] == "vider"))
{
	$panier->viderpanier();
}
//MAJ de stock dans la base de données
if(isset($_POST['payer']))
{
    $produit=$panier->valider_paiement();
    $panier->viderpanier();
}
?>
<?php
include 'boutique_Controller.php';

//--------------------------------- TRAITEMENTS PHP ---------------------------------//
/*if(isset($_GET['id_produit'])) 
	{  
        $id_produit=  $_GET['id_produit'];
		$bout=$boutique->displayRecordById($id_produit);
*/
$output='';	
$output .= "<p>Categorie: $bout[categorie]</p>";
$output .= "<h3>Description : $bout[description]</h3><hr /><br />";
$output .= "<p>Couleur: $bout[couleur]</p>";
$output .= "<img src='../Back-end/$bout[photo]' width='150' height='150' />";
$output .= "<p>Prix : $bout[prix] $</p><br />";

if($bout['stock'] > 0)
{
	$output .= "<i>Quantité disponible : $bout[stock] </i><br /><br />";
	$output .= '<form method="post" action="panier_View.php">';
	$output .= "<input type='hidden' name='id_produit' value='$bout[id_produit]' />";
	$output .= '<label for="quantite">Quantité : </label>';
	$output .= '<select id="quantite" name="quantite">';
			for($i = 1; $i <= $bout['stock'] && $i <= 5; $i++)
			{
				$output .= "<option>$i</option>";
			}
			$output .= '</select>';
			$output .= '<input type="submit" name="ajout_panier" value="ajout au panier" />';
			$output .= '</form>';
}
else
{
	$output .= 'Rupture de stock !';
} 
$output .= "<br /><a href='displayboutique.php?categorie=" . $bout['categorie'] . "'>Retour vers la sélection de " 
. $bout['categorie'] . "</a>";
//--------------------------------- AFFICHAGE HTML ---------------------------------//
//require_once('entete.php');
echo $output;

<!Doctype html>
<html>
    <head>
        <title>Mon Site</title>
        <link rel="stylesheet" href="css/style.css">
    </head>
    <?php
include 'boutique_Controller.php';
$output='';


$output .= '<div class="boutique-gauche">';
$output .='<b>Veuillez choisir une catégorie</b>';
$output .= "<ul>";

    foreach($bout as $bou){
       
    $output .= "<li><a href='?categorie=" . $bou['categorie'] . "'>" . $bou['categorie'] . "</a></li>";
    
}
$output .= "</ul>";
$output .= "</div>";

$output .= '<div class="boutique-droite">';

if(isset($_GET['categorie'])){
  $categorie=  $_GET['categorie'];
  
$bot=$boutique->displayRecordBycat($categorie);


    $output .= '<div class="boutique-produit">';
        $output .= "<h2>$bot[categorie]</h2>";
        $output .= "<a href=\"productcard.php?id_produit=$bot[id_produit]\"><img src=\"../Back-end/$bot[photo]\" =\"130\" height=\"100\"></a>";
        $output .= "<p>$bot[prix] $</p>";
        $output .= '<a href="productcard.php?id_produit=' . $bot['id_produit'] . '">Voir la fiche</a>';
        $output .= '</div>';

    }
    echo $output;

?>
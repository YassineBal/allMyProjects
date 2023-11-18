<?php
include 'connexion.php';
session_start();
class panier{
    public function ajout_panier($id_produit)
    {
        $connexion=new Connexion();
        $con=$connexion->getConnexion();
        $new_query = "SELECT * FROM fleurs WHERE id_produit = '$_POST[id_produit]'";
        $result = $con->query($new_query);
        $row = $result->fetch_assoc();
        return $row;
    }

    public function creation_Panier()
    {
       
          $_SESSION['panier']=array();
          $_SESSION['panier']['titre'] = array();
          $_SESSION['panier']['id_produit'] = array();
          $_SESSION['panier']['quantite'] = array();
          $_SESSION['panier']['prix'] = array();
       
    }

 
     public function ajouterProduitDansPanier($titre,$id_produit,$quantite,$prix)
    {
	    $position_produit = array_search($id_produit,  $_SESSION['panier']['id_produit']); 
        if ($position_produit !== false)
        {
            $_SESSION['panier']['quantite'][$position_produit] += $quantite ;
        }
        else 
        {
            $_SESSION['panier']['titre'][] = $titre;
            $_SESSION['panier']['id_produit'][] = $id_produit;
            $_SESSION['panier']['quantite'][] = $quantite;
            $_SESSION['panier']['prix'][] = $prix;
        }
    }



    public function retirerproduitDuPanier($id_produit_a_supprimer)
    {
        $position_produit = array_search($id_produit_a_supprimer,  $_SESSION['panier']['id_produit']);
        if ($position_produit !== false)
        {
            array_splice($_SESSION['panier']['titre'], $position_produit, 1);
            array_splice($_SESSION['panier']['id_produit'], $position_produit, 1);
            array_splice($_SESSION['panier']['quantite'], $position_produit, 1);
            array_splice($_SESSION['panier']['prix'], $position_produit, 1);
        }
    }

    public function viderpanier()
    {
        unset($_SESSION['panier']);

    }

    public function montantTotal()
    {
        $total=0;
        for($i = 0; $i < count($_SESSION['panier']['id_produit']); $i++) 
        {
            $total += $_SESSION['panier']['quantite'][$i] * $_SESSION['panier']['prix'][$i];
        }
        return round($total,2);
    }

    public function valider_paiement()
    {
        $connexion=new Connexion();
        $con=$connexion->getConnexion();
        for($i=0 ;$i < count($_SESSION['panier']['id_produit']) ; $i++) 
	    {
            $x=$_SESSION['panier']['quantite'][$i];
            $req = "SELECT * FROM fleurs WHERE id_produit=" . $_SESSION['panier']['id_produit'][$i];
            $resultat=$con->query($req);
            $row = $resultat->fetch_assoc();
            $y=$row['stock'];
            $req="UPDATE fleurs set   stock=$y-$x WHERE id_produit=" . $_SESSION['panier']['id_produit'][$i];
            $res=$con->query($req);
        }

    }


}
?>
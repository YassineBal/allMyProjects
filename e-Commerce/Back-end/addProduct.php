<?php
// Include Customer/class file
include 'products.php';
//Create customer object
$productObj = new Products();
// Insert Record into customer table
if(isset($_POST['submit'])){
    $productObj->insertData($_POST);
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css"/>
    <title>Customer </title>
</head>
<body>



 <div class='card text-center' style='padding:15px;color:#0713A0'>
    <h4 class="h5">PRODUCTS ADDING FORM</h4>
    </div> 
<div class="row mt-1 ml-5 border border-primary rounded-lg" style="width:300px">
        <div class="col ">

                <form   method="post" enctype="multipart/form-data" action="add.php" class="">
                <label class="h6" for="">Catégories</label><br>
                <input class="w-100" type="text" id="categorie" name="categorie" required><br>
                

                <label class="h6" for="">Description</label><br>
                <textarea class="w-100"  type="textarea" id="description" name="description" required></textarea><br>
               

                <label class="h6" for="">Couleur</label><br>
                <input class="w-100" type="text" id="couleur" name="couleur" required><br>
              

                <label class="h6" for="">Occasion</label><br>
                <select class="form-select" aria-label="Default select example" name="occasion" id="occasion" required ><br>
                <option value="anniversaire">Anniversaire</option>
                <option value="mariage">Mariage</option>
                <option value="nouveaubebe">Nouveau bébe</option>
                <option value="saintvalentin">Saint Valentin</option><br>
                </select>
                
                <br>

                <label class="h6" for="">Utilisation</label><br>
                
                <input class="ml-3 form-check-input" type="radio" id="bouquet" name="utilisation" value="Bouquets">
                <label class="ml-5 mr-5" for="html">Bouquets</label>

                <input class="form-check-input" type="radio" id="vase" name="utilisation" value="Vase">
                <label for="css">Vase</label><br>
               


                <label class="h6" for="photo">Photo</label><br>
                <input type="file" class="form-control-file" id="photo" name="photo" required><br><br>


                <label class="h6" for="">Prix</label><br>
                <input class="w-100" type="text" id="prix" name="prix" required><br>

                <label class="h6" for="">Stock</label><br>
                <input class="w-100" type="text" id="stock" name="stock"vrequired><br>


                <br>
                <input class="btn mb-1 btn-success ml-1" type="submit" value="Enregistrement des fleurs" name="submit">
                </form>

        </div>
        <div class="col"></div>
        <div class="col"></div>


     
</div>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>



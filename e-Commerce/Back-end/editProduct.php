<?php
// Include Products/class file
include 'products.php';

//Create Products object
$productObj = new Products();
// Insert Record into Products table

if(isset($_GET['editId'])){    
    $editId = $_GET['editId'];
    $product = $productObj->displayRecordById($editId);
}

// Update Record into Products table
if(isset($_POST['update'])){
    $productObj->updateRecord($_POST);
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
    <title>Edit Product</title>
</head>
<body>



<div class='card text-center' style='padding:15px;color:#0713A0'>
    <h4 class="h5">PRODUCTS EDITING FORM</h4>
    </div> 
<div class="row mt-1 ml-5 border border-primary rounded-lg" style="width:300px">
        <div class="col-10 ">

                <form   method="post" enctype="multipart/form-data" action="editProduct.php?editId=<?php echo $editId ?>" class="">
                              
                <input class="w-100" type="hidden" id="id_product" name="id_produit" value="<?php echo $product["id_produit"] ?>" required><br>
                
                <label class="h6" for="">Catégories</label><br>
                <input class="w-100" type="text" id="categorie" name="categorie" value="<?php echo $product["categorie"] ?>" required><br>
                

                <label class="h6" for="">Description</label><br>
                <textarea class="w-100"  type="textarea" id="description" name="description" value="" required>
                    <?php echo $product["description"] ?></textarea><br>
               

                <label class="h6" for="">Couleur</label><br>
                <input class="w-100" type="text" id="couleur" name="couleur" value="<?php echo $product["couleur"] ?>" required><br>
              

                <label class="h6" for="">Occasion</label><br>
                <select class="form-select" aria-label="Default select example" name="occasion" id="occasion" required><br>
                <option value="anniversaire" <?php if($product["occasion"]=="anniversaire"){echo "selected";} ?> >Anniversaire</option>
                <option value="mariage" <?php if($product["occasion"]=="mariage"){echo "selected";} ?>>Mariage</option>
                <option value="nouveaubebe" <?php if($product["occasion"]=="nouveaubebe"){echo "selected";} ?>>Nouveau bébe</option>
                <option value="saintvalentin" <?php if($product["occasion"]=="saintvalentin"){echo "selected";} ?>>Saint Valentin</option><br>
                </select>
                
                <br>

                <label class="h6" for="">Utilisation</label><br>
                <input class="ml-1 mr-1 form-check-input" type="radio" id="bouquet" name="utilisation" value="Bouquets" value="Bouquets" <?php if($product["utilisation"]=="Bouquets"){echo "checked";} ?>>
                <label class="ml-4 mr-1" for="html">Bouquets</label>

                <input class="ml-1 mr-1 form-check-input" type="radio" id="vase" name="utilisation" value="Vase" value="Vase" <?php if($product["utilisation"]=="Vase"){echo "checked";} ?>>
                <label class="ml-4 mr-1" for="css">Vase</label><br>
               


                <label class="h6" for="photo">Photo</label><br>
                <input type="file" class="form-control-file" id="photo" name="photo" ><br>
                <img src="<?php echo $product["photo"] ?>" alt="" style="width:50px;height:50px"><br> 
               

                <label class="h6" for="">Prix</label><br>
                <input class="w-100" type="text" id="prix" name="prix" value="<?php echo $product["prix"] ?>" required><br>

                <label class="h6" for="">Stock</label><br>
                <input class="w-100" type="text" id="stock" name="stock" value="<?php echo $product["stock"] ?>" required><br>


                <br>
                <input class="btn mb-1 btn-success ml-1 w-100" type="submit" value="Update" name="update">
                </form>

        </div>
        <div class="col"></div>
        <div class="col"></div>


     
</div>















    
   
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
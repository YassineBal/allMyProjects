


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



<div class='card text-center'  style='padding:15px;color:#0713A0'>
    <h4 class="h5">PRODUCT CRUD OPERATIONS PAGE</h4>
    </div>
    <div class="container">
       
        <h2 style="color:#0713A0">View records
            <a href="addProduct.php" class="btn btn-primary" style="float:right;background-color:#0713A0"> Add New Record</a>
        </h2>
        <table class="table table-hover">
            <thead>                
            <tr>
                <th>Id</th>
                <th>Catégorie</th>
                <th>Couleur</th>
                <th>Description</th>
                <th>Occasion</th>
                <th>Prix</th>
                <th>Stock</th>
                <th>Utilisation</th>
                <th>Photo</th>
                <th>Action</th>
            </tr>            
            </thead>
            <tbody>
                <?php
                  // Include customers class
                    include 'products.php';
                    // Create object
                     $productObj = new Products();
                    $products = $productObj->displayData();
                    foreach ($products as $product) {                  
                    
                ?>
                <tr>
                <td><?php echo $product['id_produit'] ?></td>
                <td><?php echo $product['categorie'] ?></td>
                <td><?php echo $product['couleur'] ?></td>
                <td><?php echo $product['description'] ?></td>
                <td><?php echo $product['occasion'] ?></td>
                <td><?php echo $product['prix'] ?></td>
                <td><?php echo $product['stock'] ?></td>
                <td><?php echo $product['utilisation'] ?></td>
                <td>
                    <img src="<?php echo $product['photo'] ?>" alt="" style="width:50px;height:50px">
                    
                </td>
                 <td>
                     <a href="editProduct.php?editId=<?php echo $product['id_produit']?>" style="color:green;margin-right:25px;">                   
                        <i class="fa fa-pencil" aria-hidden=true></i></a>&nbsp
                    <a href="delete.php?deleteId=<?php echo $product['id_produit']?>" style="color:red" 
                                onclick="return confirm('Are you sure you want to delete this item?');" >
                    <!--           onclick="confirm('Are you sure want to delete this record?')">-->
                        <i class="fa fa-trash" aria-hidden=true></i></a>
                </td> 

                


                </tr>
                <?php
                    }
                ?>
            </tbody>
        </table>
        
    </div>

    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>

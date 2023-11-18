<?php
// Include Customer/class file
include 'products.php';
//Create customer object
$productObj = new Products();
// Insert Record into customer table
if(isset($_GET['deleteId'])){    
    $deleteId = $_GET['deleteId'];
    $product = $productObj->deleteRecord($deleteId);
}
?>


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
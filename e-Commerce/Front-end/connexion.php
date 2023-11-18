<?php

class Connexion{
    // Configurations DB
    private $servername = '127.0.0.1';
    private $username = 'root';
    private $password = '';
    private $database = 'site';
    public  $con;
    // Database Connection
    public function __construct(){
        $this->con = new mysqli($this->servername, $this->username,
         $this->password, $this->database);
         if(mysqli_connect_error()){ 
            trigger_error("Failed to connect MYSQL: " .mysqli_connect_error()); //trigger_error est utilisé pour
                                                                                // déclencher une erreur utilisateur.
         }
         else {
//            echo 'Connected Successfully!';
            return $this->con;
            
         }
    }
public  function getConnexion(){ //design pattern singleton
    if ($this->con==null)//verifier est ce que la variable $con contient les données de connexion ou pas
    { new Connexion();}// si $this-> est null, on va créer une instance de la classe connexion qui
                        // va aapeler le constructeur par défaut pour maj la variable con
    return $this->con;

}}
    ?>
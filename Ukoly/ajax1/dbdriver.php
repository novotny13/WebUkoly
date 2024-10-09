<?php
require_once "db.php";
class dbdriver{
private $cn;



function __construct ($conn) {

if ($conn==null) die; 

    $this->cn=$conn;
    

}

function query ($sql) {


$result = $this->cn -> query($sql);

// Associative array
$row = $result -> fetch_assoc();


return $row;
}


function select ($tab,$colm) {
$List="*";
$res=array();

if (is_array($colm)) 
    $List = implode(', ', $colm);
    else $List=$colm; 
        
$sql="select $List from $tab";

$result =$this->cn->query($sql);


$i=1;
if ($result = $this->cn -> query($sql)) {
  while ($row = $result -> fetch_assoc()) {
     
     $res[$i]=$row;
     $i++;
  }
}

return $res;

}

public function insertRow($arr) {

if (!is_array($arr)) return -1;

     
    
    $val="null";
    foreach ($arr as $key=>$value) {
    
        $val .=",'$value'";  	
    }
    
    
    $sql="INSERT INTO drinks values($val)";
    return $this->cn -> query($sql);
    
    
    
    }
    
public  function selectQ ($sql) {
  
    
  $i=0;
    if ($result = $this->cn -> query($sql)) {
      while ($row = $result -> fetch_row()) {
         
         $res[$i]=$row;
         $i++;
      }
    }
  
  return $res;
  
  }


}//class






?>
<?php
//echo getcwd();exit;
function cors() {
    
    // Allow from any origin
    if (isset($_SERVER['HTTP_ORIGIN'])) {
        // Decide if the origin in $_SERVER['HTTP_ORIGIN'] is one
        // you want to allow, and if so:
        header("Access-Control-Allow-Origin: {$_SERVER['HTTP_ORIGIN']}");
        header('Access-Control-Allow-Credentials: true');
        header('Access-Control-Max-Age: 86400');    // cache for 1 day
    }
    
    // Access-Control headers are received during OPTIONS requests
    if ($_SERVER['REQUEST_METHOD'] == 'OPTIONS') {
        
        if (isset($_SERVER['HTTP_ACCESS_CONTROL_REQUEST_METHOD']))
            // may also be using PUT, PATCH, HEAD etc
            header("Access-Control-Allow-Methods: GET, POST, OPTIONS");
        
        if (isset($_SERVER['HTTP_ACCESS_CONTROL_REQUEST_HEADERS']))
            header("Access-Control-Allow-Headers: {$_SERVER['HTTP_ACCESS_CONTROL_REQUEST_HEADERS']}");
    
        exit(0);
    }
    
 //   echo "You have CORS!";
}
cors();
require_once "db.php";
if (!(($_SERVER['PHP_AUTH_USER']) ||
     $_SERVER['PHP_AUTH_USER'] == "coffe" ||
     $_SERVER['PHP_AUTH_PW'] == "kafe")) {
    header('WWW-Authenticate: Basic realm="Coffe "');
    header('HTTP/1.0 401 Unauthorized');
    echo json_encode(array("msg"=>'Text to send if user hits Cancel button'));
    
    exit;} 
 
require_once "requests.php";
/*
1. zobrazení seznamu funkcí
2. get typy, people
3. uložení dat z formuláøe

4. statistika... za nìjaké datum

*/
header('Content-Type: application/json');





$r = new requests($conn);
  

/*
echo "<pre>";
print_r($_GET);
print_r($_POST);
print_r($_SERVER);
*/

?>
<?php
require_once "config.php";
// Create connection

$conn = new mysqli($host, $user, $pass,$db );

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);exit;
}

//echo "Connected successfully";
?>
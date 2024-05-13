<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require 'vendor/autoload.php';

$name = $_POST['name'];
$email = $_POST['email'];
$message = $_POST['message'];

$mail = new PHPMailer(true);

try {

    $mail->isSMTP();
    $mail->Host = 'smtp.prikladek.com';
    $mail->SMTPAuth = true;
    $mail->Username = 'mujmail@gmail.com.com';
    $mail->Password = 'MojeHeslo';
    $mail->SMTPSecure = 'tls';
    $mail->Port = 195;

    
    $mail->setFrom($email);
    $mail->addAddress('prijemce@gmail.com');

    
    $mail->isHTML(true);
    $mail->Subject = 'Contakt ze stránky';
    $mail->Body    = "OD: $name <br> z mailu: $email <br> Zpráva: $message";

    $mail->send();
    echo 'Email byl úspěšně odeslán';
} catch (Exception $e) {
    echo "Email se nepodařilo odeslat. Chyba: {$mail->ErrorInfo}";
}
?>

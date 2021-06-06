<?php
session_start();
    //echo '<pre>'.print_r($_POST, true).'</pre>'; die;
    $email_to = "desmonlatandos@gmail.com"; // change with your email
	$selectroom = $_POST['selectroom'];
	$stardate     = $_POST['stardate'];
	$enddate     = $_POST['enddate'];
	$phonebook     = $_POST['phonebook'];
	$person   = $_POST['person'];
    $name     = $_POST['name'];
    $email    = $_POST['email'];
    $subject   = $_POST['subject'];
	$mainmessage    = $_POST['message'];
    //$message    = $_POST['message'];
    $message    = "
    Select Room : $selectroom
    Date Book : $stardate
    End Book : $enddate
    Person : $person
    Name : $name
    Phone : $phonebook
    Email : $email
    Pesan : $mainmessage
    ";

    $headers  = "From: $email\r\n";
    $headers .= "Reply-To: $email\r\n";

    if(mail($email_to, $subject, $message, $headers)){
        echo "success";
    }
    else{
        echo "failed";
    }
?>

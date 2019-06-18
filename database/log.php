<?php
require "init.php";

$userName=$_POST["username"];

$password=$_POST["password"];


$mysqlQuery="Select * from reg where username='$userName' and password='$password' ";

$result=mysqli_query($con,$mysqlQuery);
if(mysqli_num_rows($result)>0)
{
 while($row = mysqli_fetch_assoc($result)) {
        echo   $row["username"]. "-" . $row["name"]."-". $row["age"];
    }
}
else
{
	echo "login unsuccessfull";
	
}

?>
<?php
require "init.php";



$name1=$_POST["name"];
$age1=$_POST["age"];
$userName1=$_POST["username"];
$password1=$_POST["password"];

$mysqlQuery="insert into reg(username,name,age,password)values('$userName1','$name1',$age1,'$password1')";

$result=mysqli_query($con,$mysqlQuery);
if($result===true)
{
 echo"insert successfull";
}
else
{
	echo mysqli_error($con);
	
}

?>
<?php
	if( isset($_POST['txtUser']) && isset($_POST['txtPwd']) && isset($_POST['txtName']) && isset($_POST['sex']) && isset($_POST['txtEmail']) && isset($_POST['txtDate'])) {
	$userName = $_POST['txtUser'];
	$password = $_POST['txtPwd'];
	$fullName = $_POST['txtName'];
	if($_POST['sex']=='male') $gender=true;
	else $gender=false;
	$email=$_POST['txtEmail'];
	$date=$_POST['txtDate'];
	
	$connection  = mysql_connect("localhost","root","");
	mysql_select_db("phpwebco_shop",  $connection);
	
	
	$sql = "SELECT mem_name
	        FROM tbl_member
			WHERE mem_name = '$userName'";
	$result = mysql_query($sql);
	
	if (mysql_num_rows($result) == 1) {
		header('Location: index.php?action=register&error=1'/* . urlencode('Username already taken. Choose another one')*/);
	}
	else {
		$sql   = "INSERT INTO tbl_member (mem_name, mem_password, mem_regdate, mem_ten, mem_phai, mem_email, mem_bday)
		          VALUES ('$userName', md5('$password'), NOW(), '$fullName', '$gender','$email','$date')";
	
		$result = mysql_query($sql);
		header('Location: index.php');
	}
	}
?>
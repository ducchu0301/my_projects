<?php
	$sql="SELECT counter FROM tbl_counter";
	$result=mysql_query($sql);
	$row = mysql_fetch_array($result);
	$i=$row[0];
	if(!isset($_SESSION['webpage'])) {
		$i=$i+1;
		$sql="UPDATE tbl_counter SET counter='$i'";
		mysql_query($sql);	
	}
	$_SESSION['webpage']=$i;
	$digit = strval($_SESSION['webpage']);
	echo "<p align='center'><font color='#0000FF'>Views:<br>";
	for ($i = 0; $i < strlen($_SESSION['webpage']); $i++) 
	{
		echo "<img src=images/count/$digit[$i].gif>";
	}
	echo "<b></b></font></p>";
?>

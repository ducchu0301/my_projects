<?php
		$shoppingReturnUrl = deleteGET('action');
		$error="";
		//session_start();
		if( isset($_POST["txtUser"]) && isset($_POST["txtPwd"]) ) {
			$username=$_POST["txtUser"];
			$password=$_POST["txtPwd"];
			//xet truong hop rong
			if($username=="") {
				header('Location: index.php?error=2');
			}
			else if($password=="") {
				header('Location: index.php?error=2');
			}
			else {
			// 1. Ket noi CSDL
			$connection  = mysql_connect("localhost","root","");
			mysql_select_db("phpwebco_shop",  $connection);
			// 2. Chuan  bi cau truy  van & 3. Thuc thi cau truy  van
			$sql = "SELECT mem_name, mem_ten
		        FROM tbl_member 
				WHERE mem_name = '$username' AND mem_password = md5('$password')";
			$result = mysql_query($sql);
			// 4.Xu ly du lieu tra ve
			if (mysql_num_rows($result) == 1) {
			$row = mysql_fetch_array($result);
			$_SESSION['username'] = $row['mem_name'];
			
			$_SESSION['name']=$row['mem_ten'];
			$sql   = "UPDATE tbl_member 
	          SET mem_last_login = NOW()
			  WHERE mem_name = '$username'";
			$result = mysql_query($sql);
			header('Location: index.php?action=search&'.$shoppingReturnUrl);
			exit;	
			} 
			else {
			header('Location: index.php?error=2');
			}			
		}
		}
	?>
<?php if( isset($_GET['error']) ) {
			$type=$_GET['error'];
			switch($type) {
				case 1:	echo "<font color='#FF0000'><i>Username already taken. Choose another one</i></font>";break;
				case 2: echo "<font color='#FF0000'><i>Wrong username or password</i></font>";
			}
		}
?>
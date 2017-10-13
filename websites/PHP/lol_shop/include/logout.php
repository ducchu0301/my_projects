
<?php
		$shoppingReturnUrl = deleteGET('action');
		if( isset($_SESSION['username']) ) {
			unset($_SESSION['username']);
			deleteAllCart();
			header("Location:index.php?".$shoppingReturnUrl);
		}
?>
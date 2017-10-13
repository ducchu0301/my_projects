<?php
if (!defined('WEB_ROOT')) {
	exit;
}

$cartContent = getCartContent();

$numItem = count($cartContent);	
$shoppingReturnUrl = deleteGET('action');
?>
<table width="100%" border="0" cellspacing="0" cellpadding="0" id="minicart" height="200px">
	<tr>
  		<td colspan="2" background="images/footer.png" height="11"></td>
 	</tr>
    <?php
		if ($numItem > 0 /*&& isset($_SESSION['username'])*/) {
	?>
    <tr>
    	<td colspan="2" align="center" height="10" valign="bottom"><?php echo "Hello ".$_SESSION['name'];
			?>&nbsp;&nbsp;&nbsp;<input type="button" value="Logout" onclick="window.location.href='index.php?action=logout&<?php echo $shoppingReturnUrl; ?>';" /><br /><hr align="center" width="90%">
		</td>
    </tr>
    <tr>
    	<td>
    		<table border="0" cellpadding="5" cellspacing="5" width="100%">
 			<tr>
 				 <td colspan="2"><font color="#0000FF"><b>Cart Content</b></font></td>
 			</tr>
			<?php
			$subTotal = 0;
			for ($i = 0; $i < $numItem; $i++) {
				extract($cartContent[$i]);
				$pd_name = "$ct_qty x $pd_name";
				$url = "index.php?c=$cat_id&p=$pd_id";
		
				$subTotal += $pd_price * $ct_qty;
			?>
 			<tr>
   				<td><a href="<?php echo $url; ?>"><?php echo $pd_name; ?></a></td>
   
  				<td width="30%" align="right"><?php echo displayAmount($ct_qty * $pd_price); ?></td>
 			</tr>
			<?php
			} // end while
			?>
  			<tr>
            	<td align="right"><b>Sub-total</b></td>
  				<td width="30%" align="right"><?php echo displayAmount($subTotal); ?></td>
			 </tr>
  			<tr>
            	<td align="right"><b>Shipping</b></td>
  				<td width="30%" align="right"><?php echo displayAmount($shopConfig['shippingCost']); ?></td>
 			</tr>
  			<tr>
            	<td align="right"><font color="#0000FF"><b>Total</b></font></td>
  				<td width="30%" align="right"><?php echo displayAmount($subTotal + $shopConfig['shippingCost']); ?></td>
 			</tr>
  			<tr>
            	<td colspan="2">&nbsp;</td>
            </tr>
  			<tr>
  				<td colspan="2" align="center"><a href="cart.php?action=view"> Go To Shopping Cart</a></td>
 			</tr>
 			</table>
        </td>
	</tr>
	<?php	
	} else if(isset($_SESSION['username'])) {
	?>
    <tr>
    	<td colspan="2" align="center" height="10" valign="bottom"><?php echo "Hello ".$_SESSION['name'];
			?>&nbsp;&nbsp;&nbsp;<input type="button" value="Logout" onclick="window.location.href='index.php?action=logout&<?php echo $shoppingReturnUrl; ?>';" /><br /><hr align="center" width="90%">
		</td>
    </tr>
  	<tr>
    	<td colspan="2" align="center" valign="middle"><font color="#0000FF"><b>Shopping Cart Is Empty</b></font></td>
	</tr>
    
	<?php
	} else if(!isset($_SESSION['username'])) {
		require_once 'include/login.php';
		require_once 'include/error.php';	
	}
	?> 
    <tr>
  		<td colspan="2" background="images/footer.png" height="11"></td>
 	</tr>
</table>
	

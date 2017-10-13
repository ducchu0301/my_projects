<?php
if (!defined('WEB_ROOT')) {
	exit;
}

$product = getProductDetail($pdId, $catId);
$shoppingReturnUrl=deleteGET('p');
$shoppingReturnUrl=substr($shoppingReturnUrl,0,strlen($shoppingReturnUrl)-1);
// we have $pd_name, $pd_price, $pd_description, $pd_image, $cart_url
extract($product);
?> 
<script>
	function toLogin() {
		document.formLogin.txtUser.focus();	
	}
</script>
<table width="100%" border="0" cellspacing="0" cellpadding="10" style="color:#000; padding:20px">
 <tr> 
  <td align="center"><img src="<?php echo $pd_image; ?>" border="0" alt="<?php echo $pd_name; ?>"></td>
  <td valign="middle">
<strong><?php echo $pd_name; ?></strong><br>
Price : <?php echo displayAmount($pd_price); ?><br><br />
<?php
// if we still have this product in stock
// show the 'Add to cart' button
if ($pd_qty > 0 && isset($_SESSION['username'])) {
?>
<input type="button" name="btnAddToCart" value="Add To Cart &gt;" onClick="window.location.href='<?php echo $cart_url; ?>';" class="addToCartButton">
<?php
} elseif($pd_qty<=0) {
	echo 'Out Of Stock';
} else { echo '<font color="#FF0000"><i>Login to buy</i></font>';}
?>
<br /><br />
<input type="button" value="Back" onClick="window.location.href='<?php echo 'index.php?'.$shoppingReturnUrl; ?>';" />
  </td>
 </tr>
 <tr align="left"> 
  <td colspan="2"><?php echo $pd_description; ?></td>
 </tr>
</table>

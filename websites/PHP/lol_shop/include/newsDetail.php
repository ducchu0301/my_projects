<?php

if (!defined('WEB_ROOT')) {
	exit;
}
$shoppingReturnUrl = isset($_SESSION['shop_return_url']) ? $_SESSION['shop_return_url'] : 'index.php';
if (isset($_GET['newsId']) && $_GET['newsId'] > 0) {
	$newsId = $_GET['newsId'];
} else {
	header('Location: index.php');
}
	$sql = "SELECT new_title, new_detail, new_image, new_date
			FROM tbl_new
			WHERE new_id = $newsId";
			
	$result = mysql_query($sql) or die('Cannot get news. ' . mysql_error());

$row = mysql_fetch_assoc($result);
extract($row);

if ($new_image) {
	$new_image = WEB_ROOT . 'images/news/' . $new_image;
} else {
	$new_image = WEB_ROOT . 'images/no-image-large.png';
}
?>
<table width="100%" border="0" cellspacing="0" cellpadding="10" style="color:#000; padding:20px">
 <tr> 
 <td valign="middle" align="center"><strong><?php echo $new_title; ?></strong><br></td>
 </tr>
 <tr> 
 <td valign="middle" align="right"><small><?php echo $new_date; ?></small><br></td>
 </tr>
 <tr>
  <td align="center"><img src="<?php echo $new_image; ?>" border="0" alt="<?php echo $new_title; ?>"></td>
 </tr>
 <tr align="left"> 
  <td><?php echo nl2br($new_detail); ?></td>
 </tr>
</table>
<?php
if (!defined('WEB_ROOT')) {
	exit;
}

// make sure a product id exists
if (isset($_GET['newsId']) && $_GET['newsId'] > 0) {
	$newsId = $_GET['newsId'];
} else {
	// redirect to index.php if product id is not present
	header('Location: index.php');
}

$sql = "SELECT new_id, new_title, new_detail, new_image, new_thumbnail
        FROM tbl_new
		WHERE new_id=$newsId";
$result = mysql_query($sql) or die('Cannot get news. ' . mysql_error());

$row = mysql_fetch_assoc($result);
extract($row);

if ($new_image) {
	$new_image = WEB_ROOT . 'images/news/' . $new_image;
} else {
	$new_image = WEB_ROOT . 'images/no-image-large.png';
}


?>
<p>&nbsp;</p>
<form action="processNews.php?action=addNews" method="post" enctype="multipart/form-data" name="frmAddNews" id="frmAddNews">
 <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" class="entryTable">
  <tr> 
   <td width="150" class="label">News Title</td>
   <td class="content"> <?php echo $new_title; ?></td>
  </tr>
  <tr> 
   <td width="150" class="label">Detail</td>
   <td class="content"><?php echo nl2br($new_detail); ?> </td>
  </tr>
  <tr> 
   <td width="150" class="label">Image</td>
   <td class="content"><img src="<?php echo $new_image; ?>"></td>
  </tr>
 </table>
 <p align="center"> 
  <input name="btnModifyProduct" type="button" id="btnModifyProduct" value="Modify News" onClick="window.location.href='index.php?view=modify&newsId=<?php echo $newsId; ?>';" class="box">
  &nbsp;&nbsp;
  <input name="btnBack" type="button" id="btnBack" value=" Back " onClick="window.history.back();" class="box">
 </p>
</form>

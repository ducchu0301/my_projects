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

// get product info
$sql = "SELECT new_id, new_title, new_detail, new_image, new_thumbnail
        FROM tbl_new
		WHERE new_id=$newsId";
$result = mysql_query($sql) or die('Cannot get news. ' . mysql_error());
$row    = mysql_fetch_assoc($result);
extract($row);


?> 
<form action="processNews.php?action=modifyNews&newsId=<?php echo $newsId; ?>" method="post" enctype="multipart/form-data" name="frmAddNews" id="frmAddNews">
 <p align="center" class="formTitle">Modify News</p>
 
 <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" class="entryTable">
  
  <tr> 
   <td width="150" class="label">News Title</td>
   <td class="content"> <input name="txtName" type="text" class="box" id="txtName" value="<?php echo $new_title; ?>" size="50" maxlength="100"></td>
  </tr>
  <tr> 
   <td width="150" class="label">Detail</td>
   <td class="content"> <textarea name="txtDetail" cols="70" rows="10" class="box" id="txtDetail"><?php echo $new_detail; ?></textarea></td>
  </tr>
  <tr> 
   <td width="150" class="label">Image</td>
   <td class="content"> <input name="fleImage" type="file" id="fleImage" class="box">
<?php
	if ($new_thumbnail != '') {
?>
    <br>
    <img src="<?php echo WEB_ROOT . NEWS_IMAGE_DIR . $new_thumbnail; ?>"> &nbsp;&nbsp;<a href="javascript:deleteNewsImage(<?php echo $new_id; ?>);">Delete 
    Image</a> 
    <?php
	}
?>    
    </td>
  </tr>
 </table>
 <p align="center"> 
  <input name="btnModifyProduct" type="submit" id="btnModifyProduct" value="Modify News" onClick="checkAddProductForm();" class="box">
  &nbsp;&nbsp;<input name="btnCancel" type="button" id="btnCancel" value="Cancel" onClick="window.location.href='index.php';" class="box">  
 </p>
</form>
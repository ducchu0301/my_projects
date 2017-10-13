<?php
if (!defined('WEB_ROOT')) {
	exit;
}

$newsId = (isset($_GET['newsId']) && $_GET['newsId'] > 0) ? $_GET['newsId'] : 0;

$categoryList = buildCategoryOptions($newsId);
?> 
<p>&nbsp;</p>
<form action="processNews.php?action=addNews" method="post" enctype="multipart/form-data" name="frmAddNews" id="frmAddNews">
  <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" class="entryTable">
  <tr><td colspan="2" id="entryTableHeader">Add News</td></tr>
  <tr> 
   <td width="150" class="label">News Title</td>
   <td class="content"> <input name="txtName" type="text" class="box" id="txtName" size="50" maxlength="100"><input name="newsId" type="text" hidden="1" value="<?php echo $newsId; ?>" /></td>
  </tr>
  <tr> 
   <td width="150" class="label">Detail</td>
   <td class="content"> <textarea name="txtDetail" cols="70" rows="10" class="box" id="txtDetail"></textarea></td>
  </tr>
  <tr> 
   <td width="150" class="label">Image</td>
   <td class="content"> <input name="fleImage" type="file" id="fleImage" class="box"> 
    </td>
  </tr>
 </table>
 <p align="center"> 
  <input name="btnAddNews" type="submit" id="btnAddNews" value="Add News" onClick="checkAddNewsForm();" class="box">
  &nbsp;&nbsp;<input name="btnCancel" type="button" id="btnCancel" value="Cancel" onClick="window.location.href='index.php';" class="box">  
 </p>
</form>

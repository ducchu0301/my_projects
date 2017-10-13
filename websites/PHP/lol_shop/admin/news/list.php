<script>
function deleteNews(newsId)
{
	if (confirm('Delete this news?')) {
		window.location.href = 'processNews.php?action=deleteNews&newsId=' + newsId;
	}
}
</script>
<?php
if (!defined('WEB_ROOT')) {
	exit;
}

if (isset($_GET['newsId']) && (int)$_GET['newsId'] > 0) {
	$newsId = (int)$_GET['newsId'];
	$queryString = "newsId=$newsId";
} else {
	$newsId = 0;
	$queryString = '';
}

// for paging
// how many rows to show per page
$rowsPerPage = 5;

$sql = "SELECT new_id, new_title, new_thumbnail
        FROM tbl_new
		ORDER BY new_last_update DESC";
$result     = dbQuery(getPagingQuery($sql, $rowsPerPage,'page'));
$pagingLink = getPagingLink($sql, $rowsPerPage, $queryString,'page');


?> 
<p>&nbsp;</p>
<form action="processNews.php?action=addNews" method="post"  name="frmListNews" id="frmListNews">
<br>
 <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" class="text">
  <tr align="center" id="listTableHeader"> 
   <td>News Title</td>
   <td width="75">Thumbnail</td>
   <td width="70">Modify</td>
   <td width="70">Delete</td>
  </tr>
  <?php
$parentId = 0;
if (dbNumRows($result) > 0) {
	$i = 0;
	
	while($row = dbFetchAssoc($result)) {
		extract($row);
		
		if ($new_thumbnail) {
			$new_thumbnail = WEB_ROOT . 'images/news/' . $new_thumbnail;
		} else {
			$new_thumbnail = WEB_ROOT . 'images/no-image-small.png';
		}	
		
		
		
		if ($i%2) {
			$class = 'row1';
		} else {
			$class = 'row2';
		}
		
		$i += 1;
?>
  <tr class="<?php echo $class; ?>"> 
   <td><a href="index.php?view=detail&newsId=<?php echo $new_id; ?>"><?php echo $new_title; ?></a></td>
   <td width="75" align="center"><img src="<?php echo $new_thumbnail; ?>"></td>
   <td width="70" align="center"><a href="index.php?view=modify&newsId=<?php echo $new_id; ?>">Modify</a></td>
   <td width="70" align="center"><a href="javascript:deleteNews(<?php echo $new_id; ?>);">Delete</a></td>
  </tr>
  <?php
	} // end while
?>
  <tr> 
   <td colspan="5" align="center">
   <?php 
echo $pagingLink;
   ?></td>
  </tr>
<?php	
} else {
?>
  <tr> 
   <td colspan="5" align="center">No News Yet</td>
  </tr>
  <?php
}
?>
  <tr> 
   <td colspan="5">&nbsp;</td>
  </tr>
  <tr> 
   <td colspan="5" align="right"><input name="btnAddProduct" type="button" id="btnAddProduct" value="Add News" class="box" onClick="window.location.href='index.php?view=add&newsId=<?php echo $newsId; ?>';"></td>
  </tr>
 </table>
 <p>&nbsp;</p>
</form>
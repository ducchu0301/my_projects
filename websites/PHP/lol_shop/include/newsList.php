<?php
if (!defined('WEB_ROOT')) {
	exit;
}

$productsPerRow = 1;
$productsPerPage = 3;
//delete element pageNews in link 
$shoppingReturnUrl = deleteGET('pageNews');

$sql = "SELECT new_id, new_title, new_detail, new_thumbnail
		FROM tbl_new
		ORDER BY new_date DESC";
	

$result     = dbQuery(getPagingQuery($sql, $productsPerPage,'pageNews'));
$pagingLink = getPagingLink($sql, $productsPerPage, $shoppingReturnUrl,'pageNews');
$numProduct = dbNumRows($result);

// the product images are arranged in a table. to make sure
// each image gets equal space set the cell width here
$columnWidth = (int)(100 / $productsPerRow);
?>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="color:#000" height="200" >
	<tr>
  		<td colspan="3" background="images/footer.png" height="11"></td>
 	</tr>
	<tr align="center"><td colspan="3"><font color="#0000FF"><b>News</b></font></td>
    </tr>
<?php 
if ($numProduct > 0 ) {

	$i = 0;
	while ($row = dbFetchAssoc($result)) {
	
		extract($row);
		if ($new_thumbnail) {
			$new_thumbnail = WEB_ROOT . 'images/news/' . $new_thumbnail;
		} else {
			$new_thumbnail = WEB_ROOT . 'images/no-image-small.png';
		}
	
		if ($i % $productsPerRow == 0) {
			echo '<tr>';
		}
		$array=explode(" ",$new_title);
		$str='';
		// format how we display the price
		for($i=0;$i<count($array);$i++) {
			$str=$str.$array[$i]." ";
			if($i==3) {
				break;	
			}
		}
		
		
		echo "<td>&nbsp;&nbsp;&nbsp;</td><td width=\"$columnWidth%\" align=\"center\" valign=\"middle\"><a href=\"" . $_SERVER['PHP_SELF'] . "?action=viewNewsDetail&newsId=$new_id" . "\"><img src=\"$new_thumbnail\" border=\"0\" align=\"left\"/>$str</a>";

		// if the product is no longer in stock, tell the customer
		
		
		echo "</td><td>&nbsp;&nbsp;&nbsp;</td>\r\n";
	
		if ($i % $productsPerRow == $productsPerRow - 1) {
			echo '</tr>';
		}
		
		$i += 1;
	}
	
	if ($i % $productsPerRow > 0) {
		echo '<td colspan="' . ($productsPerRow - ($i % $productsPerRow)) . '">&nbsp;</td>';
	}
	
} else {
?>
	<tr><td width="100%" align="center" valign="center">No news</td></tr>
<?php	
}	
?>
	<tr>
    	<td colspan="3"><p align="center"><?php echo $pagingLink; ?></p></td>
    </tr>
	<tr>
  		<td colspan="3" background="images/footer.png" height="11"></td>
 	</tr>
</table>
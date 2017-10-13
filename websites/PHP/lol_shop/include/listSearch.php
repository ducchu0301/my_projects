<?php
if (!defined('WEB_ROOT')) {
	exit;
}

$productsPerRow = 3;
$productsPerPage = 9;
$shoppingReturnUrl = deleteGET('pageSearch');

 if ( isset($_GET['word']) ) {
	$word=strtolower($_GET['word']);
	$word=ucfirst($word);
 }

if( isset($_GET['min']) ){
	$min=(float)$_GET['min'];
	
}

if( isset($_GET['max']) ) {
	$max=(float)$_GET['max'];
	if($max=='MAX') $max=100000;
}
if (isset($_GET['pageSearch']) && (int)$_GET['pageSearch'] > 1) {
			$pageNumber = (int)$_GET['pageSearch'];
} 
else {
			$pageNumber = 1;
}


	$sql = "SELECT pd_id, pd_name, pd_price, pd_thumbnail, pd_qty
		FROM tbl_product
		WHERE pd_name like '%$word%' AND pd_price >= '$min' AND pd_price <= '$max'
		ORDER BY pd_name";
	

$result     = dbQuery(getPagingQuery($sql, $productsPerPage,'pageSearch'));
$pagingLink = getPagingLink($sql, $productsPerPage, $shoppingReturnUrl,'pageSearch');
$numProduct = dbNumRows($result);

// the product images are arranged in a table. to make sure
// each image gets equal space set the cell width here
$columnWidth = (int)(100 / $productsPerRow);
?>
<table width="100%" border="0" cellspacing="0" cellpadding="20" style="color:#000; padding:20px" id="tblListSearch">
<?php 
if ($numProduct > 0 ) {

	$i = 0;
	while ($row = dbFetchAssoc($result)) {
	
		extract($row);
		if ($pd_thumbnail) {
			$pd_thumbnail = WEB_ROOT . 'images/product/' . $pd_thumbnail;
		} else {
			$pd_thumbnail = WEB_ROOT . 'images/no-image-small.png';
		}
	
		if ($i % $productsPerRow == 0) {
			echo '<tr>';
		}

		// format how we display the price
		$pd_price = displayAmount($pd_price);
		
		echo "<td width='$columnWidth%' align='center'><a href='" . $_SERVER['PHP_SELF']."?";
		if($pageNumber>1) echo "pageSearch=".$pageNumber."&";
		echo $shoppingReturnUrl."&p=".$pd_id."'><img src=\"$pd_thumbnail\" border=\"0\"><br>$pd_name</a><br>Price : $pd_price";

		// if the product is no longer in stock, tell the customer
		if ($pd_qty <= 0) {
			echo "<br>Out Of Stock";
		}
		
		echo "</td>\r\n";
	
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
	<tr><td width="100%" align="center" valign="center">No products in this category</td></tr>
<?php	
}	
?>
</table>
<p align="center"><?php echo $pagingLink; ?></p>
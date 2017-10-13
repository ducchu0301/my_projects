<?php
	if (!isset($_SESSION['username'])) {
		header('Location: index.php');
		exit;
	}
	$word="";
	$min="0";
	$max="MAX";
	if(isset($_GET['word'])) $word=$_GET['word'];
	if(isset($_GET['min'])) $min=$_GET['min'];
	if(isset($_GET['max'])) $max=$_GET['max'];
?>
<script>
	function search() {
		var word=window.document.formSearch.txtSearch.value;
		var priceform=window.document.formSearch.txtMin.value;
		var priceto=window.document.formSearch.txtMax.value;
		window.location.href="index.php?action=result&word="+word+"&min="+priceform+"&max="+priceto;
	}
</script>
<form action="" method="post" style="padding:30px" id="formSearch" name="formSearch">
			 By Name: <input type="text" name="txtSearch" value="<?php echo $word; ?>"><br />
             By Price: From<input type="text" size="5" name="txtMin" value="<?php echo $min; ?>"/> To <input type="text" size="5" name="txtMax" value="<?php echo $max; ?>"  /><br />
             <hr />
			<input type="button" value="Search" onclick="search();">
</form>
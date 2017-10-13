<!-- <link rel="shortcut icon" href="images/rp_logo.png"/>
<body style=" background-image:url(images/page-bg.jpg); background-size:100%; background-repeat:no-repeat; background-color:#0A0616; color:#FFF"> -->
<?php
require_once 'library/config.php';
require_once 'library/category-functions.php';
require_once 'library/product-functions.php';
require_once 'library/cart-functions.php';
$_SESSION['shop_return_url'] = $_SERVER['REQUEST_URI'];

$catId  = (isset($_GET['c']) && $_GET['c'] != '1') ? $_GET['c'] : 0;
$pdId   = (isset($_GET['p']) && $_GET['p'] != '') ? $_GET['p'] : 0;
//
$action= (isset($_GET['action'])) ? $_GET['action'] : "";

require_once 'include/header.php';
?>
<table width="1125" border="0" align="center" cellpadding="0" cellspacing="0">
 <tr> 
  <td colspan="3" >
  <?php require_once 'include/top.php'; ?>
  </td>
 </tr>
</table>
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
 <tr valign="top"> 
  <td width="200" height="800" id="leftnav">
  <font color="#FFFFFF">
<?php
	//
	
	if ($action=="xuli_login") require_once 'include/xuli_login.php';
	else if($action=="logout") require_once 'include/logout.php';
	
require_once 'include/leftNav.php';

		
?></font>
  </td>
  <td style="background-image:url(images/main.jpg); background-size:100%; color:#000">
<?php

if ($action=="xuli_register")
	require_once 'include/xuli_register.php';
if ($action=="search"||isset($_SESSION['username'])&&$action!='viewNewsDetail')
	require_once 'include/search.php';
if ($action=="register")
	require_once 'include/register.php';
else if ($action=="result"&&$pdId==0)
	require_once 'include/listSearch.php';
else if ($action=="viewNewsDetail")
	require_once 'include/newsDetail.php';
else if ($pdId) {
	require_once 'include/productDetail.php';
} else if ($catId) {
	require_once 'include/productList.php';
} else {
	require_once 'include/categoryList.php';
}
?>  
  </td>
  <td width="250" align="center">
  <div id="rightNav1">
	<?php
	require_once 'include/miniCart.php';
	
 	 ?>
  
  </div>
  <div id="rightNav2">
  <?php require_once 'include/newsList.php';?>
  </div>
   </td>
 </tr>
 <tr>
 	<td></td>
    <td background="images/footer.png" height="11"></td>
    <td></td>
 </tr>
 <tr>
 	<td></td>
    <td><?php
require_once 'include/footer.php';
?>
<?php
require_once 'include/counter.php';
?></td>
    <td></td>
 </tr>
</table>


</body>
</html>

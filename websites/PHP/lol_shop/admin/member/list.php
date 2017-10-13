<?php
if (!defined('WEB_ROOT')) {
	exit;
}

$sql = "SELECT mem_id, mem_name, mem_regdate, mem_last_login, mem_ten, mem_phai, mem_email, mem_bday
        FROM tbl_member
		ORDER BY mem_name";
$result = dbQuery($sql);

?> 
<p>&nbsp;</p>
<form action="processUser.php?action=addUser" method="post"  name="frmListUser" id="frmListUser">
 <table width="100%" border="0" align="center" cellpadding="2" cellspacing="1" class="text">
  <tr align="center" id="listTableHeader"> 
   <td>Member Name</td>
   <td width="120">Register Date</td>
   <td width="120">Last login</td>
   <td width="300">Full name</td>
   <td width="120">Gender</td>
   <td width="120">Email</td>
   <td width="120">Birthday</td>
   <td width="120">Change Password</td>
   <td width="70">Delete</td>
  </tr>
<?php
while($row = dbFetchAssoc($result)) {
	extract($row);
	
	if ($i%2) {
		$class = 'row1';
	} else {
		$class = 'row2';
	}
	
	$i += 1;
?>
  <tr class="<?php echo $class; ?>"> 
   <td><?php echo $mem_name; ?></td>
   <td width="120" align="center"><?php echo $mem_regdate; ?></td>
   <td width="120" align="center"><?php echo $mem_last_login; ?></td>
   <td width="300" align="center"><?php echo $mem_ten; ?></td>
   <td width="120" align="center"><?php echo $mem_phai; ?></td>
   <td width="120" align="center"><?php echo $mem_email; ?></td>
   <td width="120" align="center"><?php echo $mem_bday; ?></td>
   <td width="120" align="center"><a href="javascript:changePassword(<?php echo $mem_id; ?>);">Modify</a></td>
   <td width="70" align="center"><a href="javascript:deleteUser(<?php echo $mem_id; ?>);">Delete</a></td>
  </tr>
<?php
} // end while

?>
  <tr> 
   <td colspan="5">&nbsp;</td>
  </tr>
  <tr> 
   <td colspan="5" align="right"><input name="btnAddUser" type="button" id="btnAddUser" value="Add Member" class="box" onClick="addUser()"></td>
  </tr>
 </table>
 <p>&nbsp;</p>
</form>
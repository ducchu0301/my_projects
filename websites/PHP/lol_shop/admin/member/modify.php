<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<script language="JavaScript" type="text/javascript">
	function checkName()
	{
		theForm = window.document.form1;
		if(theForm.txtUser.value=='') {
			alert('Enter your member name');
			theForm.txtUser.focus();
			return false;	
		}
		else return true;
	}
	function checkHoten()
	{
		theForm = window.document.form1;
		if(theForm.txtName.value=='') {
			alert('Enter your full name');
			theForm.txtName.focus();
			return false;	
		}
		else return true;
	}
	
	function checkPwd()
	{
		theForm = window.document.form1;
	
	if (theForm.txtPwd.value == '') {
		alert('Enter password');
		theForm.txtPwd.focus();
		return false;
	} else if (theForm.txtPwd2.value == '') {
		alert('Repeat new password');
		theForm.txtPwd2.focus();
		return false;
	} else if (theForm.txtPwd.value != theForm.txtPwd2.value) {
		alert('password don\'t match');
		theForm.txtPwd2.focus();
		return false;
	} else {
		return true;
	}
	}
	
	function IsEmailValid(FormName,ElemName)
	{
		var EmailOk  = true
		var Temp     = ElemName
		var AtSym    = Temp.value.indexOf('@')
		var Period   = Temp.value.lastIndexOf('.')
		var Space    = Temp.value.indexOf(' ')
		var Length   = Temp.value.length - 1   // Array is from 0 to length-1
		if ((AtSym < 1) ||                     // '@' cannot  be in first position
		(Period <= AtSym+1) ||             // Must be atleast  one valid char btwn '@' and '.'
		(Period == Length ) ||             // Must be atleast one valid char after '.'
		(Space  != -1))                    // No empty spaces permitted
		{  
			EmailOk = false
			alert('Please enter a valid e-mail address!')
			Temp.focus()
		}
		return EmailOk
	}
	
	function check()
	{
		n1=document.form1.txtUser.value;
		p1=document.form1.txtPwd.value;
		p2=document.form1.txtPwd2.value;
		h1=document.form1.txtName.value;
		
		if( n1=="") {
			alert('Type your member name');
			document.form1.txtUser.focus();
			return false;
		}
		else if( p1=="") {
			alert('Type your password');
			document.form1.txtPwd.focus();
			return false;
			
		}
		else if( p2=="") {
			alert('Retype your password');
			document.form1.txtPwd2.focus();
			return false;
		}
		else if( h1=="") {
			alert('Type your Full name');
			document.form1.txtName.focus();
			return false
		}
		else if(!IsEmailValid('form1',form1.txtEmail)) {
			return false;
		}
		else {
			document.form1.submit();	
		}
	}

</script>
<?php
if (!defined('WEB_ROOT')) {
	exit;
}

if (isset($_GET['userId']) && (int)$_GET['userId'] > 0) {
	$userId = (int)$_GET['userId'];
} else {
	header('Location: index.php');
}

$errorMessage = (isset($_GET['error']) && $_GET['error'] != '') ? $_GET['error'] : '&nbsp;';

$sql = "SELECT mem_name, mem_password, mem_ten, mem_phai, mem_email, mem_bday
        FROM tbl_member
        WHERE mem_id = $userId";
$result = dbQuery($sql);		
extract(dbFetchAssoc($result));
if($mem_phai==true) {
	$nam="checked";
	$nu="";
}
else {
	$nam="";
	$nu="checked";	
}


?> 
<p class="errorMessage"><?php echo $errorMessage; ?></p>
<form action="processUser.php?action=modify" method="post" name="form1" id="form1">
 <table width="100%" border="0" align="center" cellpadding="5" cellspacing="1" class="entryTable">
  <tr> 
   <td width="150" class="label">Member Name</td>
   <td class="content"> <input type="text" name="txtUser" onblur="checkName()" value="<?php echo $mem_name; ?>" readonly="readonly"/></td>
  </tr>
  <tr> 
   <td width="150" class="label">New Password</td>
   <td class="content"> <input type="password" name="txtPwd" /></td>
  </tr>
  <tr> 
   <td width="150" class="label">Retype Password</td>
   <td class="content"> <input type="password" name="txtPwd2" onblur="checkPwd()" /></td>
  </tr>
  <tr> 
   <td width="150" class="label">Full Name</td>
   <td class="content"> <input type="text" name="txtName" onblur="checkHoten()" value="<?php echo $mem_ten; ?>" /></td>
  </tr>
  <tr> 
   <td width="150" class="label">Gender</td>
   <td class="content"> <input type="radio" name="sex" value="male" <?php echo $nam; ?> />Nam
<input type="radio" name="sex" value="female" <?php echo $nu; ?> />Nữ</td>
  </tr>
  <tr> 
   <td width="150" class="label">Birth Day</td>
   <td class="content"> <input type="date" name="txtDate" value="<?php echo $mem_bday; ?>" /></td>
  </tr>
  <tr> 
   <td width="150" class="label">Email</td>
   <td class="content"> <input type="text" name="txtEmail" onblur="IsEmailValid('form1',form1.txtEmail)" value="<?php echo $mem_email; ?>" /></td>
  </tr>
 </table>
 <p align="center"> 
  <input name="btnModifyMember" type="button" id="btnModifyMember" value="Modify Member" onclick="check();" class="box">
  &nbsp;&nbsp;<input name="btnCancel" type="button" id="btnCancel" value="Cancel" onClick="window.location.href='index.php';" class="box">  
 </p>
</form>
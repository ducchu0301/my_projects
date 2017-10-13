<?php 
	$shoppingReturnUrl = deleteGET(' ');
?>
<tr>
	<td>
    <form action="index.php?action=xuli_login&<?php echo $shoppingReturnUrl; ?>" method="post" id="formLogin" name="formLogin">
    <table border="0" cellpadding="5" cellspacing="5" width="100%">
 		<tr>
 			<td colspan="2"><font color="#0000FF"><b>&nbsp;Login</b></font></td>
 		</tr>
        <tr>
            <td align="right"><b>&nbsp;Username</b></td>
  			<td width="30%" align="right"><input type="text" name="txtUser" /></td>
		</tr>
  		<tr>
            <td align="right"><b>&nbsp;Password</b></td>
  			<td width="30%" align="right"><input type="password" name="txtPwd" /></td>
 		</tr>
        <tr>
        	<td colspan="2" align="center">
        <input type="submit" value="Login"/>
        <input type="button" onclick="window.location.href='index.php?action=register';" value="Register" />
        	</td>
		</tr>
	</table>
    </form>
	</td>
</tr>
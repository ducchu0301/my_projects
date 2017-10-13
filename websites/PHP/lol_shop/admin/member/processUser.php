<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<?php
require_once '../../library/config.php';
require_once '../library/functions.php';

checkUser();

$action = isset($_GET['action']) ? $_GET['action'] : '';

switch ($action) {
	
	case 'add' :
		addUser();
		break;
		
	case 'modify' :
		modifyUser();
		break;
		
	case 'delete' :
		deleteUser();
		break;
    

	default :
	    // if action is not defined or unknown
		// move to main user page
		header('Location: index.php');
}


function addUser()
{
    $userName = $_POST['txtUser'];
	$password = $_POST['txtPwd'];
	$fullName = $_POST['txtName'];
	if($_POST['sex']=='male') $gender=true;
	else $gender=false;
	$email=$_POST['txtEmail'];
	$date=$_POST['txtDate'];
	/*
	// the password must be at least 6 characters long and is 
	// a mix of alphabet & numbers
	if(strlen($password) < 6 || !preg_match('/[a-z]/i', $password) ||
	!preg_match('/[0-9]/', $password)) {
	  //bad password
	}
	*/	
	// check if the username is taken
	$sql = "SELECT mem_name
	        FROM tbl_member
			WHERE mem_name = '$userName'";
	$result = dbQuery($sql);
	
	if (dbNumRows($result) == 1) {
		header('Location: index.php?view=add&error=' . urlencode('Username already taken. Choose another one'));	
	} else {			
		$sql   = "INSERT INTO tbl_member (mem_name, mem_password, mem_regdate, mem_ten, mem_phai, mem_email, mem_bday)
		          VALUES ('$userName', md5('$password'), NOW(), '$fullName', '$gender','$email','$date')";
	
		dbQuery($sql);
		header('Location: index.php');	
	}
}

/*
	Modify a user
*/
function modifyUser()
{
	$mem   = $_POST['txtUser'];	
	$password = $_POST['txtPwd'];
	$fullName = $_POST['txtName'];
	if($_POST['sex']=='male') $gender=true;
	else $gender=false;
	$email=$_POST['txtEmail'];
	$date=$_POST['txtDate'];
	
	$sql   = "UPDATE tbl_member 
	          SET mem_password = md5('$password'), mem_ten = '$fullName', mem_phai = '$gender', mem_bday = '$date', mem_email = '$email'
			  WHERE mem_name = '$mem'";

	dbQuery($sql);
	header('Location: index.php');	

}

/*
	Remove a user
*/
function deleteUser()
{
	if (isset($_GET['userId']) && (int)$_GET['userId'] > 0) {
		$userId = (int)$_GET['userId'];
	} else {
		header('Location: index.php');
	}
	
	
	$sql = "DELETE FROM tbl_member 
	        WHERE mem_id = $userId";
	dbQuery($sql);
	
	header('Location: index.php');
}
?>
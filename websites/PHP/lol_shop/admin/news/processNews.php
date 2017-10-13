<?php
require_once '../../library/config.php';
require_once '../library/functions.php';

checkUser();

$action = isset($_GET['action']) ? $_GET['action'] : '';

switch ($action) {
	
	case 'addNews' :
		addNews();
		break;
		
	case 'modifyNews' :
		modifyNews();
		break;
		
	case 'deleteNews' :
		deleteNews();
		break;
	
	case 'deleteImage' :
		deleteImage();
		break;
    

	default :
	    // if action is not defined or unknown
		// move to main product page
		header('Location: index.php');
}


function addNews()
{
	$newsId = $_POST['newsId'];
    $name        = $_POST['txtName'];
	$description = $_POST['txtDetail'];
	
	$images = uploadNewsImage('fleImage', SRV_ROOT . 'images/news/');

	$mainImage = $images['image'];
	$thumbnail = $images['thumbnail'];
	
	$sql   = "INSERT INTO tbl_new (new_id, new_title, new_detail, new_image, new_thumbnail, new_date, new_last_update)
	          VALUES ('$newsId', '$name', '$description', '$mainImage', '$thumbnail', NOW(), NOW())";

	$result = dbQuery($sql);
	
	header("Location: index.php?newsId=$newsId");	
}

/*
	Upload an image and return the uploaded image name 
*/
function uploadNewsImage($inputName, $uploadDir)
{
	$image     = $_FILES[$inputName];
	$imagePath = '';
	$thumbnailPath = '';
	
	// if a file is given
	if (trim($image['tmp_name']) != '') {
		$ext = substr(strrchr($image['name'], "."), 1); //$extensions[$image['type']];

		// generate a random new file name to avoid name conflict
		$imagePath = md5(rand() * time()) . ".$ext";
		
		list($width, $height, $type, $attr) = getimagesize($image['tmp_name']); 

		// make sure the image width does not exceed the
		// maximum allowed width
		if (LIMIT_PRODUCT_WIDTH && $width > MAX_NEWS_IMAGE_WIDTH) {
			$result    = createThumbnail($image['tmp_name'], $uploadDir . $imagePath, MAX_NEWS_IMAGE_WIDTH);
			$imagePath = $result;
		} else {
			$result = move_uploaded_file($image['tmp_name'], $uploadDir . $imagePath);
		}	
		
		if ($result) {
			// create thumbnail
			$thumbnailPath =  md5(rand() * time()) . ".$ext";
			$result = createThumbnail($uploadDir . $imagePath, $uploadDir . $thumbnailPath, THUMBNAIL_WIDTH);
			
			// create thumbnail failed, delete the image
			if (!$result) {
				unlink($uploadDir . $imagePath);
				$imagePath = $thumbnailPath = '';
			} else {
				$thumbnailPath = $result;
			}	
		} else {
			// the product cannot be upload / resized
			$imagePath = $thumbnailPath = '';
		}
		
	}

	
	return array('image' => $imagePath, 'thumbnail' => $thumbnailPath);
}

/*
	Modify a product
*/
function modifyNews()
{
	$newsId   = (int)$_GET['newsId'];	
    $name        = $_POST['txtName'];
	$description = $_POST['txtDetail'];
	
	$images = uploadNewsImage('fleImage', SRV_ROOT . 'images/news/');

	$mainImage = $images['image'];
	$thumbnail = $images['thumbnail'];

	// if uploading a new image
	// remove old image
	if ($mainImage != '') {
		_deleteImage($newsId);
		
		$mainImage = "'$mainImage'";
		$thumbnail = "'$thumbnail'";
	} else {
		// if we're not updating the image
		// make sure the old path remain the same
		// in the database
		$mainImage = 'new_image';
		$thumbnail = 'new_thumbnail';
	}
			
	$sql   = "UPDATE tbl_new
	          SET new_title = '$name', new_detail = '$description', new_image = $mainImage, new_thumbnail = $thumbnail, new_last_update = NOW()
			  WHERE new_id = $newsId";  

	$result = dbQuery($sql);
	
	header('Location: index.php');			  
}

/*
	Remove a product
*/
function deleteNews()
{
	if (isset($_GET['newsId']) && (int)$_GET['newsId'] > 0) {
		$newsId = (int)$_GET['newsId'];
	} else {
		header('Location: index.php');
	}
	
	
			
			
	// get the image name and thumbnail
	$sql = "SELECT new_image, new_thumbnail
	        FROM tbl_new
			WHERE new_id = $newsId";
			
	$result = dbQuery($sql);
	$row    = dbFetchAssoc($result);
	
	// remove the product image and thumbnail
	if ($row['new_image']) {
		unlink(SRV_ROOT . 'images/news/' . $row['new_image']);
		unlink(SRV_ROOT . 'images/news/' . $row['new_thumbnail']);
	}
	
	// remove the news from database;
	$sql = "DELETE FROM tbl_new
	        WHERE new_id = $newsId";
	dbQuery($sql);
	
	header('Location: index.php?newsId=' . $_GET['newsId']);
}


/*
	Remove a product image
*/
function deleteImage()
{
	if (isset($_GET['newsId']) && (int)$_GET['newsId'] > 0) {
		$newsId = (int)$_GET['newsId'];
	} else {
		header('Location: index.php');
	}
	
	$deleted = _deleteImage($newsId);

	// update the image and thumbnail name in the database
	$sql = "UPDATE tbl_new
			SET new_image = '', new_thumbnail = ''
			WHERE new_id = $newsId";
	dbQuery($sql);		

	header("Location: index.php?view=modify&newsId=$newsId");
}

function _deleteImage($newsId)
{
	// we will return the status
	// whether the image deleted successfully
	$deleted = false;
	
	$sql = "SELECT new_image, new_thumbnail 
	        FROM tbl_new
			WHERE new_id = $newsId";
	$result = dbQuery($sql) or die('Cannot delete news image. ' . mysql_error());
	
	if (dbNumRows($result)) {
		$row = dbFetchAssoc($result);
		extract($row);
		
		if ($new_image && $new_thumbnail) {
			// remove the image file
			$deleted = @unlink(SRV_ROOT . "images/news/$new_image");
			$deleted = @unlink(SRV_ROOT . "images/news/$new_thumbnail");
		}
	}
	
	return $deleted;
}




?>
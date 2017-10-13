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
	
	$images = uploadProductImage('fleImage', SRV_ROOT . 'images/news/');

	$mainImage = $images['image'];
	$thumbnail = $images['thumbnail'];
	
	$sql   = "INSERT INTO tbl_product (new_id, new_title, new_detail, new_image, new_thumbnail, new_date, new_last_update)
	          VALUES ('$newsId', '$name', '$description', '$mainImage', '$thumbnail', NOW(), NOW())";

	$result = dbQuery($sql);
	
	header("Location: index.php?catId=$catId");	
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
		if (LIMIT_PRODUCT_WIDTH && $width > MAX_PRODUCT_IMAGE_WIDTH) {
			$result    = createThumbnail($image['tmp_name'], $uploadDir . $imagePath, MAX_PRODUCT_IMAGE_WIDTH);
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
	$productId   = (int)$_GET['productId'];	
    $catId       = $_POST['cboCategory'];
    $name        = $_POST['txtName'];
	$description = $_POST['mtxDescription'];
	$price       = str_replace(',', '', $_POST['txtPrice']);
	$qty         = $_POST['txtQty'];
	
	$images = uploadProductImage('fleImage', SRV_ROOT . 'images/product/');

	$mainImage = $images['image'];
	$thumbnail = $images['thumbnail'];

	// if uploading a new image
	// remove old image
	if ($mainImage != '') {
		_deleteImage($productId);
		
		$mainImage = "'$mainImage'";
		$thumbnail = "'$thumbnail'";
	} else {
		// if we're not updating the image
		// make sure the old path remain the same
		// in the database
		$mainImage = 'pd_image';
		$thumbnail = 'pd_thumbnail';
	}
			
	$sql   = "UPDATE tbl_product 
	          SET cat_id = $catId, pd_name = '$name', pd_description = '$description', pd_price = $price, 
			      pd_qty = $qty, pd_image = $mainImage, pd_thumbnail = $thumbnail
			  WHERE pd_id = $productId";  

	$result = dbQuery($sql);
	
	header('Location: index.php');			  
}

/*
	Remove a product
*/
function deleteNews()
{
	if (isset($_GET['productId']) && (int)$_GET['productId'] > 0) {
		$productId = (int)$_GET['productId'];
	} else {
		header('Location: index.php');
	}
	
	// remove any references to this product from
	// tbl_order_item and tbl_cart
	$sql = "DELETE FROM tbl_order_item
	        WHERE pd_id = $productId";
	dbQuery($sql);
			
	$sql = "DELETE FROM tbl_cart
	        WHERE pd_id = $productId";	
	dbQuery($sql);
			
	// get the image name and thumbnail
	$sql = "SELECT pd_image, pd_thumbnail
	        FROM tbl_product
			WHERE pd_id = $productId";
			
	$result = dbQuery($sql);
	$row    = dbFetchAssoc($result);
	
	// remove the product image and thumbnail
	if ($row['pd_image']) {
		unlink(SRV_ROOT . 'images/product/' . $row['pd_image']);
		unlink(SRV_ROOT . 'images/product/' . $row['pd_thumbnail']);
	}
	
	// remove the product from database;
	$sql = "DELETE FROM tbl_product 
	        WHERE pd_id = $productId";
	dbQuery($sql);
	
	header('Location: index.php?catId=' . $_GET['catId']);
}


/*
	Remove a product image
*/
function deleteImage()
{
	if (isset($_GET['productId']) && (int)$_GET['productId'] > 0) {
		$productId = (int)$_GET['productId'];
	} else {
		header('Location: index.php');
	}
	
	$deleted = _deleteImage($productId);

	// update the image and thumbnail name in the database
	$sql = "UPDATE tbl_product
			SET pd_image = '', pd_thumbnail = ''
			WHERE pd_id = $productId";
	dbQuery($sql);		

	header("Location: index.php?view=modify&productId=$productId");
}

function _deleteImage($productId)
{
	// we will return the status
	// whether the image deleted successfully
	$deleted = false;
	
	$sql = "SELECT pd_image, pd_thumbnail 
	        FROM tbl_product
			WHERE pd_id = $productId";
	$result = dbQuery($sql) or die('Cannot delete product image. ' . mysql_error());
	
	if (dbNumRows($result)) {
		$row = dbFetchAssoc($result);
		extract($row);
		
		if ($pd_image && $pd_thumbnail) {
			// remove the image file
			$deleted = @unlink(SRV_ROOT . "images/product/$pd_image");
			$deleted = @unlink(SRV_ROOT . "images/product/$pd_thumbnail");
		}
	}
	
	return $deleted;
}




?>
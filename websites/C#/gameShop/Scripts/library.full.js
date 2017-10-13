// JavaScript Document

//Play file format : swf, flv, wma, wmv, avi, mp3, wav, dat
function playfile(file, width, height, autoplay, image, slink, flashvars){
	file=file.toLowerCase();
	if (Right(file,3)=="swf" || Right(file,3)=="xml"){
		EmbedFlash(file, width, height, flashvars);
	}
	if (Right(file,3)=="flv"){
		PlayFlash(file, width, height, autoplay, image, slink, flashvars);
	}
	if (Right(file,3)=="mp3" || Right(file,3)=="wma" || Right(file,3)=="wmv" || Right(file,3)=="avi" || Right(file,3)=="wav" || Right(file,3)=="dat"){
		PlayVideo(file, width, height, autoplay, flashvars);
	}
	if (Right(file,3)=="jpg" || Right(file,4)=="jpeg" || Right(file,3)=="gif" || Right(file,3)=="png" || Right(file,3)=="bmp"){
		PlayImage(file, width, height, flashvars);
	}
}

function PlayFlash(path, width, height, autoplay, image, slink, flashvars){
	auto=false; if (autoplay == true){auto=true;} var str_link=""; if(slink.length > 0){str_link="&link=" + slink + "&linktarget=_blank";} var str="<embed name=\"PlayerVideo\" id=\"PlayerVideo\" wmode=\"transparent\" type=\"application/x-shockwave-flash\" src=\"js/player.swf\" bgcolor=\"#FFFFFF\" quality=\"high\" allowscriptaccess=\"always\" allowfullscreen=\"true\" flashvars=\"file=" + path + "&image=" + image + str_link + "&autostart=" + auto + "&volume=100&overstretch=fit&showeq=true&linkfromdisplay=true&duration=auto\" width=\"" + width + "\" height=\"" + height + "\"></embed>"; if(flashvars != ""){ $Get(flashvars).innerHTML=str;} else{document.write(str);} }

function PlayImage(path, width, height, flashvars){
	str="<img src=\"" + path + "\" width=\"" + width + "\" height=\"" + height + "\" />"; if(flashvars != ""){ $Get(flashvars).innerHTML=str;} else{document.write(str);} 
}
	
function PlayVideo(path, width, height, autoplay, flashvars){
	auto=false; if (autoplay == true){auto = true;} str="<object id=\"MediaPlayer\" classid=\"CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6\"  codeBase=\"http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=6,4,5,715\" width=\"" + width + "\" height=\"" + height + "\"> <param name=\"autoplay\" value=\"" + auto + "\"/> <param name=\"autostart\" value=\"" + auto + "\"/> <param name=\"showcontrols\" value=\"true\">  <param name=\"EnableContextMenu\" value=\"true\"/> <param name=\"showstatusbar\" value=\"false\"/> <param name=\"URL\" value=\"" + path + "\"/><param name=\"wmode\" value=\"transparent\"><embed name=\"MediaPlayer\" type=\"application/x-mplayer2\" src=\"" + path + "\" autoplay=\"" + auto + "\" autostart=\"" + auto + "\" showcontrols=\"true\" enablecontextmenu=\"true\" showstatusbar=\"false\" pluginspage=\"http://www.microsoft.com/windows/windowsmedia/download\" wmode=\"transparent\" width=\"" + width + "\" height=\"" + height + "\"></embed> </object>"; if(flashvars != ""){ $Get(flashvars).innerHTML=str;} else{document.write(str);} }

function EmbedFlash(path, width, height, flashvars){if(height.length == 0){height="100%";} if(width.length == 0){width="100%";}str="<object id=\"FlashContent\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\"  codeBase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0\" quality=\"high\" width=\"" + width + "\" height=\"" + height + "\"> <param name=\"flashvars\" value=\"" + flashvars + "\"/> <param name=\"allowScriptAccess\" value=\"always\">  <param name=\"allowFullScreen\" value=\"true\"/> <param name=\"movie\" value=\"" + path + "\"/> <param name=\"src\" value=\"" + path + "\"/> <param name=\"quality\" value=\"high\"/> <param name=\"wmode\" value=\"transparent\"/> <param name=\"bgcolor\" value=\"#000000\"/> <embed name=\"FlashContent\" src=\"" + path + "\" quality=\"high\" flashvars=\"" + flashvars + "\" allowFullScreen=\"true\"  allowScriptAccess=\"always\" wmode=\"transparent\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + width + "\" height=\"" + height + "\"></embed> </object>"; document.write(str);}

function ChangeImage(path, pic_width, swf_height, flashvars){document.write('<object id="FlashContent" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="'+ pic_width +'" height="'+ swf_height +'" style="margin: 0px 0px 0px 0px;"> <param name="movie" value="'+ path +'"> <param name="quality" value="high"> <param name="wmode" value="transparent"> <param name="FlashVars" value="'+flashvars+'"> <embed style="margin: 0px 0px 0px 0px;" src="'+ path +'" FlashVars="'+flashvars+'" quality="high" width="'+ pic_width +'" height="'+ swf_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" wmode="transparent" pluginspage="http://www.macromedia.com/go/getflashplayer"> </object>');}

function $Get(idname) {
	if (document.getElementById) {
		return document.getElementById(idname);
	}
	else if (document.all) {
		return document.all[idname];
	}
	else if (document.layers) {
		return document.layers[idname];
	}
	else{
		return null;
	}
}

function Trim(iStr){
    while (iStr.charCodeAt(0) <= 32){iStr = iStr.substr(1);} while (iStr.charCodeAt(iStr.length - 1) <= 32) {iStr = iStr.substr(0, iStr.length - 1);} return iStr;
}

function Left(str, n) {
    if (n <= 0) {return "";} else if (n > String(str).length) {return str;} else {return String(str).substring(0, n);}
}

function Right(str, n) {if (n <= 0) return "";else if (n > String(str).length) return str;else {var iLen = String(str).length; return String(str).substring(iLen, iLen - n);}
}

function chkSelect_OnMouseMove(tableRow) { var checkBox = tableRow.childNodes[1].childNodes[1]; if (checkBox.checked == false) tableRow.style.backgroundColor = "#ffffcc"; }
function chkSelect_OnMouseOut(tableRow, rowIndex) { var checkBox = tableRow.childNodes[1].childNodes[1]; if (checkBox.checked == false) { var bgColor; if (rowIndex % 2 == 0) bgColor = "#ffffff"; else bgColor = "#f5f5f5"; tableRow.style.backgroundColor = bgColor; } }
function chkSelect_OnClick(checkBox, rowIndex) { var bgColor; var tableRow = checkBox.parentNode.parentNode; if (rowIndex % 2 == 0) bgColor = "#ffffff"; else bgColor = "#f5f5f5"; if (checkBox.checked == true) tableRow.style.backgroundColor = "#b0c4de"; else tableRow.style.backgroundColor = bgColor; }
function chkSelectAll_OnClick(checkBox) { re = new RegExp('chkSelect'); re2 = new RegExp('chkSelectAll'); for (i = 0; i < document.forms[0].elements.length; i++) { elm = document.forms[0].elements[i]; if (elm.type == 'checkbox') { if (re.test(elm.id) && re2.test(elm.id) == false) { elm.checked = checkBox.checked; var tableId = elm.parentNode.parentNode.id; var rowIndex = tableId.substring(tableId.length - 1, tableId.length); chkSelect_OnClick(elm, rowIndex); } } } }

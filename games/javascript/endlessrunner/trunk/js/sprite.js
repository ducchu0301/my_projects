/*jslint node: true */
/*global ActiveXObject */
/*global config */
/*global alert */
"use strict";
function Sprite() {
    var image, width, height, frameSequence = [], framesArray = [], currentFrameSequence, currentFrame;
    //Functions get and set Image to Sprite
    this.setImage = function (source) {
        if (!image) {
            image = new Image();
        }
        image.src = source;
    };
    this.getImage = function () {
        return image;
    };
    
    //Funtioncs get, set Width and Height
    this.setWidth = function (w) {
        width = w;
    };
    this.getWidth = function () {
        return width;
    };
    this.setHeight = function (h) {
        height = h;
    };
    this.getHeight = function () {
        return height;
    };
    
    //Functions FrameSequence
    this.addFrameSequence = function (name, startIndex, nCount) {
        if (name !== undefined && name !== null && name !== "") {
            frameSequence[name] = {
                startFrame: startIndex || 0,
                frameCount: nCount || 1
            };
            currentFrameSequence = currentFrameSequence || frameSequence[name];
            currentFrame = (currentFrame !== undefined) ? currentFrame : frameSequence[name].startFrame;
        }
    };
    this.getFrameSequence = function (name) {
        if (frameSequence.hasOwnProperty(name)) {
            return {
                startFrame: frameSequence[name].startFrame,
                frameCount: frameSequence[name].frameCount
            };
        } else {
            return {
                startFrame: undefined,
                frameCount: undefined
            };
        }
    };
    this.getCurrentFrameSequence = function () {
        return {
            startFrame: currentFrameSequence.startFrame,
            frameCount: currentFrameSequence.frameCount
        };
    };
    this.setFrameSequence = function (name) {
        if (frameSequence.hasOwnProperty(name)) {
            if (currentFrameSequence !== frameSequence[name]) {
                currentFrameSequence = frameSequence[name];
                currentFrame = frameSequence[name].startFrame;
            }
        }
    };
    this.deleteFrameSequence = function (name) {
        if (frameSequence[name]) {
            delete frameSequence[name];
        }
    };
    
    //Funtions FrameData to framesArry
    this.addFrameData = function (x, y, w, h) {
        framesArray[framesArray.length] = {
            frameX: x || 0,
            frameY: y || 0,
            frameW: w || width,
            frameH: h || height
        };
        currentFrame = (currentFrame !== undefined) ? currentFrame : framesArray.length - 1;
    };
    this.getFrameData = function (index) {
        if (index >= 0 && index < framesArray.length) {
            return {
                frameX: framesArray[index].frameX,
                frameY: framesArray[index].frameY,
                frameW: framesArray[index].frameW,
                frameH: framesArray[index].frameH
            };
        } else {
            return {
                frameX: undefined,
                frameY: undefined,
                frameW: undefined,
                frameH: undefined
            };
        }
    };
    this.getFrameDataLength = function () {
        return framesArray.length;
    };
    this.getCurrentFrame = function () {
        return currentFrame;
    };
    this.deleteFrameData = function (index) {
        if (index >= 0 && index < framesArray.length) {
            framesArray.splice(index, 1);
        }
    };
    
    //Functions set next and prev currentFrame
    this.nextFrame = function () {
        currentFrame += 1;
        if (currentFrame >= currentFrameSequence.startFrame + currentFrameSequence.frameCount) {
            currentFrame = currentFrameSequence.startFrame;
        }
    };
    this.prevFrame = function () {
        currentFrame -= 1;
        if (currentFrame < currentFrameSequence.startFrame) {
            currentFrame = currentFrameSequence.startFrame + currentFrameSequence.frameCount - 1;
        }
    };
    
    //Functions draw with different method but can't use separatelly. They have to use in image.onload function once.
    this.draw = function (context, positionX, positionY) {
        var scaleWidth = config.scale.scaleWidth, scaleHeight = config.scale.scaleHeight;
        context.drawImage(image, this.getFrameData(currentFrame).frameX, this.getFrameData(currentFrame).frameY, this.getFrameData(currentFrame).frameW, this.getFrameData(currentFrame).frameH, positionX, positionY, width * scaleWidth, height * scaleHeight);
    };
    this.drawWithScaleData = function (context, positionX, positionY, scaleW, scaleH) {
        var scaleWidth = config.scale.scaleWidth, scaleHeight = config.scale.scaleHeight;
        context.drawImage(image, this.getFrameData(currentFrame).frameX, this.getFrameData(currentFrame).frameY, this.getFrameData(currentFrame).frameW, this.getFrameData(currentFrame).frameH, positionX, positionY, width * scaleWidth * scaleW, height * scaleHeight * scaleH);
    };
    this.drawFrame = function (context, framePositionX, framePositionY, frameWidth, frameHeight, positionX, positionY) {
        var scaleWidth = config.scale.scaleWidth, scaleHeight = config.scale.scaleHeight;
        context.drawImage(image, framePositionX, framePositionY, frameWidth, frameHeight, positionX, positionY, width * scaleWidth, height * scaleHeight);
    };
    this.drawFrameWithSizeData = function (context, framePositionX, framePositionY, frameWidth, frameHeight, positionX, positionY, sizeWidth, sizeHeight) {
        context.drawImage(image, framePositionX, framePositionY, frameWidth, frameHeight, positionX, positionY, sizeWidth, sizeHeight);
    };
    this.drawFrameAtIndex = function (context, index, positionX, positionY) {
        if (index >= 0 && index < framesArray.length) {
            var scaleWidth = config.scale.scaleWidth, scaleHeight = config.scale.scaleHeight;
            context.drawImage(image, this.getFrameData(index).frameX, this.getFrameData(index).frameY, this.getFrameData(index).frameW, this.getFrameData(index).frameH, positionX, positionY, width * scaleWidth, height * scaleHeight);
        }
    };
    
    //Functions get Data from XML File -> Auto add image, size, frameSequence, framesArray
    this.getDataFromXMLFile = function (linkToXML, variableName) {
        var xmlHttp, xmlDoc, xmlData, src, w, h, frames, i, start, count, group, title, frameX, frameY, frameW, frameH;
        if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
            xmlHttp = new XMLHttpRequest();
        } else {// code for IE6, IE5
            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        if (xmlHttp) {
            xmlHttp.open("GET", linkToXML, false);
            /*
            xmlHttp.setRequestHeader('Content-Type', 'text/xml');
            xmlHttp.onreadystatechange = function () {
                if (xmlHttp.readyState === 4) {
                    alert(xmlHttp.responseXML);
                    xmlDoc = xmlHttp.responseXML;
                }
            };*/
            xmlHttp.send();
            xmlDoc = xmlHttp.responseXML;
            xmlData = xmlDoc.getElementsByTagName("images")[0];
            xmlData = xmlData.getElementsByTagName(variableName)[0];
            if (xmlData) {
                src = xmlData.getElementsByTagName("source")[0].childNodes[0].nodeValue;
                w = xmlData.getElementsByTagName("width")[0].childNodes[0].nodeValue;
                h = xmlData.getElementsByTagName("height")[0].childNodes[0].nodeValue;
                frames = xmlData.getElementsByTagName("frames")[0];
                this.setImage(src);
                this.setWidth(w);
                this.setHeight(h);
                if (frames) {
                    frames = frames.getElementsByTagName("frame");
                    start = 0;
                    count = 0;
                    group = frames[0].getElementsByTagName("group")[0].childNodes[0].nodeValue;
                    title = frames[0].getElementsByTagName("title")[0].childNodes[0].nodeValue;
                    for (i = 0; i < frames.length; i += 1) {
                        frameX = frames[i].getElementsByTagName("frameX")[0].childNodes[0].nodeValue;
                        frameY = frames[i].getElementsByTagName("frameY")[0].childNodes[0].nodeValue;
                        frameW = frames[i].getElementsByTagName("frameW")[0].childNodes[0].nodeValue;
                        frameH = frames[i].getElementsByTagName("frameH")[0].childNodes[0].nodeValue;
                        this.addFrameData(frameX, frameY, frameW, frameH);
                        if (group === frames[i].getElementsByTagName("group")[0].childNodes[0].nodeValue) {
                            count += 1;
                            
                        } else {
                            this.addFrameSequence(title, start, count);
                            start = i;
                            count = 1;
                            group = frames[i].getElementsByTagName("group")[0].childNodes[0].nodeValue;
                            title = frames[i].getElementsByTagName("title")[0].childNodes[0].nodeValue;
                        }
                        if (i === frames.length - 1) {
                            this.addFrameSequence(title, start, count);
                        }
                    }
                } else {
                    this.addFrameData(0, 0, w, h);
                    this.addFrameSequence(variableName, 0, 1);
                }
            }
        }
        //alert(xmlData);
        
    };
}
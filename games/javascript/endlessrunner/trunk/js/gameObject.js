/*jslint node: true */
/*global config */
"use strict";
//spritesArray was created, indexOf:
//typeGameObject use for background
//0 - skyMoon, 1 - city1, 2 - city2, 3 - trees, 4 - bush, 5 - platform
//use for objects
//6 - tires, 7 - oneway, 8 - coin
//not use this index
//9 - player
function GameObject() {
    var objectSprites = [], speeds = [], positions = [], collisionLayers = [], numberObjects = 0, typeGameObject = "", limitFrame = 0;
    //Functions get set objectSprites
    this.getObjectSprite = function (index) {
        if (index >= 0 && index < objectSprites.length) {
            return objectSprites[index];
        } else {
            return undefined;
        }
    };
    this.addObjectSprite = function (spriteObject) {
        if (spriteObject !== undefined) {
            objectSprites[objectSprites.length] = spriteObject;
        }
    };
    this.setObjectSpriteAtIndex = function (index, spriteObject) {
        if (index >= 0 && index < objectSprites.length) {
            objectSprites[index] = spriteObject;
        }
    };
    this.deleteObjectSprite = function (index) {
        if (index >= 0 && index < objectSprites.length) {
            objectSprites.splice(index, 1);
        }
    };
    //Functions get set speeds
    this.getSpeed = function (index) {
        if (index >= 0 && index < speeds.length) {
            return speeds[index];
        } else {
            return {
                speedX: undefined,
                speedY: undefined
            };
        }
    };
    this.addSpeed = function (aSpeedX, aSpeedY) {
        if (!isNaN(aSpeedX) && !isNaN(aSpeedY)) {
            speeds[speeds.length] = {
                speedX: aSpeedX,
                speedY: aSpeedY
            };
        }
    };
    this.setSpeedAtIndex = function (index, aSpeedX, aSpeedY) {
        if (index >= 0 && index < speeds.length) {
            if (!isNaN(aSpeedX) && !isNaN(aSpeedY)) {
                speeds[index] = {
                    speedX: aSpeedX,
                    speedY: aSpeedY
                };
            }
        }
    };
    this.setSpeedXAtIndex = function (index, aSpeedX) {
        if (index >= 0 && index < speeds.length) {
            if (!isNaN(aSpeedX)) {
                var aSpeedY = speeds[index].speedY;
                speeds[index] = {
                    speedX: aSpeedX,
                    speedY: aSpeedY
                };
            }
        }
    };
    this.setSpeedYAtIndex = function (index, aSpeedY) {
        if (index >= 0 && index < speeds.length) {
            if (!isNaN(aSpeedY)) {
                var aSpeedX = speeds[index].speedX;
                speeds[index] = {
                    speedX: aSpeedX,
                    speedY: aSpeedY
                };
            }
        }
    };
    this.deleteSpeed = function (index) {
        if (index >= 0 && index < objectSprites.length) {
            speeds.splice(index, 1);
        }
    };
    //Functions get set positions
    this.getPosition = function (index) {
        if (index >= 0 && index < positions.length) {
            return positions[index];
        } else {
            return {
                positionX: undefined,
                positionY: undefined
            };
        }
    };
    this.addPosition = function (aPositionX, aPositionY) {
        if (!isNaN(aPositionX) && !isNaN(aPositionY)) {
            positions[positions.length] = {
                positionX: aPositionX,
                positionY: aPositionY
            };
        }
    };
    this.setPositionAtIndex = function (index, aPositionX, aPositionY) {
        if (index >= 0 && index < positions.length) {
            if (!isNaN(aPositionX) && !isNaN(aPositionY)) {
                positions[index] = {
                    positionX: aPositionX,
                    positionY: aPositionY
                };
            }
        }
    };
    this.setPositionXAtIndex = function (index, aPositionX) {
        if (index >= 0 && index < positions.length) {
            if (!isNaN(aPositionX)) {
                var aPositionY = positions[index].positionY;
                positions[index] = {
                    positionX: aPositionX,
                    positionY: aPositionY
                };
            }
        }
    };
    this.setPositionYAtIndex = function (index, aPositionY) {
        if (index >= 0 && index < positions.length) {
            if (!isNaN(aPositionY)) {
                var aPositionX = positions[index].positionX;
                positions[index] = {
                    positionX: aPositionX,
                    positionY: aPositionY
                };
            }
        }
    };
    this.deletePosition = function (index) {
        if (index >= 0 && index < objectSprites.length) {
            positions.splice(index, 1);
        }
    };
    //Functions get set collisionLayers
    this.getCollisionLayer = function (index) {
        if (index >= 0 && index < collisionLayers.length) {
            return collisionLayers[index];
        } else {
            return undefined;
        }
    };
    this.addCollisionLayer = function (value) {
        if (!isNaN(value)) {
            collisionLayers[collisionLayers.length] = value;
        }
    };
    this.setCollisionLayerAtIndex = function (index, value) {
        if (index >= 0 && index < collisionLayers.length) {
            if (!isNaN(value)) {
                collisionLayers[index] = value;
            }
        }
    };
    this.deleteCollisionLayer = function (index) {
        if (index >= 0 && index < objectSprites.length) {
            collisionLayers.splice(index, 1);
        }
    };
    //Functions get set numberObjects
    this.getNumberObjects = function () {
        return numberObjects;
    };
    this.setNumberObjects = function (value) {
        if (!isNaN(value)) {
            numberObjects = value;
        }
    };
    
    this.getTypeGameObject = function () {
        return typeGameObject;
    };
    this.setTypeGameObject = function (string) {
        typeGameObject = string;
    };
    
    //Functions get set limitFrame
    this.getLimitFrame = function () {
        return limitFrame;
    };
    this.setLimitFrame = function (value) {
        if (!isNaN(value)) {
            limitFrame = value;
        }
    };
    this.addGameObject = function (aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer) {
        if (aSprite !== undefined && !isNaN(aSpeedX) && !isNaN(aSpeedY) && !isNaN(aPositionX) && !isNaN(aPositionY) && !isNaN(aCollisionLayer)) {
            this.addObjectSprite(aSprite);
            this.addSpeed(aSpeedX, aSpeedY);
            this.addPosition(aPositionX, aPositionY);
            this.addCollisionLayer(aCollisionLayer);
            this.setNumberObjects(this.getNumberObjects() + 1);
        }
    };
    this.removeGameObject = function (index) {
        if (index >= 0 && index < this.getNumberObjects()) {
            this.deleteObjectSprite(index);
            this.deleteSpeed(index);
            this.deletePosition(index);
            this.deleteCollisionLayer(index);
            this.setNumberObjects(this.getNumberObjects() - 1);
        }
    };
    this.removeAllGameObjects = function () {
        objectSprites = [];
        speeds = [];
        positions = [];
        collisionLayers = [];
        numberObjects = 0;
    };
    //Functions for typeGameObject background
    this.initBackground = function (aSpritesArray) {
        var i, j, platformHeight = aSpritesArray[5].getHeight() * config.scale.scaleHeight, aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer, nPlatform = config.system.width / aSpritesArray[5].getWidth();
        this.setTypeGameObject("background");
        for (i = 0; i < 6; i += 1) {
            aSprite = aSpritesArray[i];
            aSpeedX = config.speeds[i];
            aSpeedY = 0;
            if (i < 4) {
                aPositionX = 0;
                aPositionY = config.canvasSize.height - aSpritesArray[i].getHeight() * config.scale.scaleHeight - platformHeight;
            } else if (i === 4) {
                aPositionX = 0;
                aPositionY = config.canvasSize.height + (0.5 - 1) * aSpritesArray[i].getHeight() * config.scale.scaleHeight - platformHeight;
            } else {
                for (j = 0; j < nPlatform; j += 1) {
                    aPositionX = j * aSpritesArray[i].getWidth() * config.scale.scaleWidth;
                    aPositionY = config.canvasSize.height - platformHeight;
                    aCollisionLayer = i;
                    this.addGameObject(aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer);
                }
            }
            aCollisionLayer = i;
            if (i !== 5) {
                this.addGameObject(aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer);
            }
        }
    };
    this.updateBackground = function (delta) {
        if (typeGameObject === "background") {
            var i;
            for (i = 0; i < this.getNumberObjects(); i += 1) {
                this.setPositionAtIndex(i, this.getPosition(i).positionX + delta * this.getSpeed(i).speedX, this.getPosition(i).positionY + delta * this.getSpeed(i).speedY);
                if (this.getPosition(i).positionX + this.getObjectSprite(i).getFrameData(this.getObjectSprite(i).getCurrentFrame()).frameW * config.scale.scaleWidth < 0) {
                    this.setPositionXAtIndex(i, this.getPosition(i).positionX + config.canvasSize.width);
                }
            }
        }
    };
    this.renderBackground = function (context) {
        if (typeGameObject === "background") {
            var i;
            for (i = 0; i < this.getNumberObjects(); i += 1) {
                if (i === 0) {
                    this.getObjectSprite(i).draw(context, this.getPosition(i).positionX, this.getPosition(i).positionY);
                } else if (i < 4) {
                    this.getObjectSprite(i).draw(context, this.getPosition(i).positionX, this.getPosition(i).positionY);
                    this.getObjectSprite(i).draw(context, this.getPosition(i).positionX + config.canvasSize.width, this.getPosition(i).positionY);
                } else if (i === 4) {
                    this.getObjectSprite(i).drawWithScaleData(context, this.getPosition(i).positionX, this.getPosition(i).positionY, 1, 0.5);
                    this.getObjectSprite(i).drawWithScaleData(context, this.getPosition(i).positionX + config.canvasSize.width, this.getPosition(i).positionY, 1, 0.5);
                } else {
                    this.getObjectSprite(i).draw(context, this.getPosition(i).positionX, this.getPosition(i).positionY);
                    this.getObjectSprite(i).draw(context, this.getPosition(i).positionX + config.canvasSize.width, this.getPosition(i).positionY);
                }
            }
        }
    };
    this.restartBackground = function () {
        var i, j, platformHeight, aPositionX, aPositionY;
        for (i = 0; i < this.getNumberObjects(); i += 1) {
            if (this.getCollisionLayer(i) === 5) {
                platformHeight = this.getObjectSprite(i).getHeight() * config.scale.scaleHeight;
                break;
            }
        }
        for (i = 0; i < this.getNumberObjects(); i += 1) {
            if (this.getCollisionLayer(i) < 4) {
                aPositionX = 0;
                aPositionY = config.canvasSize.height - this.getObjectSprite(i).getHeight() * config.scale.scaleHeight - platformHeight;
            } else if (i === 4) {
                aPositionX = 0;
                aPositionY = config.canvasSize.height + (0.5 - 1) * this.getObjectSprite(i).getHeight() * config.scale.scaleHeight - platformHeight;
            } else {
                for (j = 0; j < this.getNumberObjects() - i + 1; j += 1) {
                    aPositionX = j * this.getObjectSprite(i).getWidth() * config.scale.scaleWidth;
                    aPositionY = config.canvasSize.height - platformHeight;
                    this.setPositionAtIndex(i, aPositionX, aPositionY);
                }
            }
            if (i !== 5) {
                this.setPositionAtIndex(i, aPositionX, aPositionY);
            }
        }
    };
    
    //Functions for typeGameObject objects
    //i = 6 Tires
    this.addTires = function (aSpritesArray) {
        if (this.getTypeGameObject() === "objects") {
            var platformHeight = aSpritesArray[5].getHeight() * config.scale.scaleHeight, aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer;
            aSprite = aSpritesArray[6];
            aSpeedX = config.speeds[6];
            aSpeedY = 0;
            aPositionX = config.canvasSize.width;
            aPositionY = config.canvasSize.height - platformHeight / 2 - aSpritesArray[6].getHeight() * config.scale.scaleHeight;
            aCollisionLayer = 6;
            this.addGameObject(aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer);
        }
    };
    //i = 7 Oneway
    this.addOneWay = function (aSpritesArray) {
        if (this.getTypeGameObject() === "objects") {
            var platformHeight = aSpritesArray[5].getHeight() * config.scale.scaleHeight, aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer;
            aSprite = aSpritesArray[7];
            aSpeedX = config.speeds[7];
            aSpeedY = 0;
            aPositionX = config.canvasSize.width;
            aPositionY = config.canvasSize.height - platformHeight / 2 - aSpritesArray[6].getHeight() * config.scale.scaleHeight * 1.25;
            aCollisionLayer = 7;
            this.addGameObject(aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer);
        }
    };
    //i = 8 Coin
    this.addCoin = function (aSpritesArray, aRandomAddPositionY) {
        if (this.getTypeGameObject() === "objects") {
            var platformHeight = aSpritesArray[5].getHeight() * config.scale.scaleHeight, aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer;
            aSprite = aSpritesArray[8];
            aSpeedX = config.speeds[8];
            aSpeedY = 0;
            aPositionX = config.canvasSize.width;
            aPositionY = config.canvasSize.height - platformHeight / 2 - aSpritesArray[8].getHeight() * config.scale.scaleHeight * 1.25 - aRandomAddPositionY;
            aCollisionLayer = 8;
            this.addGameObject(aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer);
        }
    };
    this.initObjects = function (aSpritesArray) {
        this.setTypeGameObject("objects");
        this.setLimitFrame(config.system.limitFps);
    };
    this.updateObjects = function (delta) {
        if (typeGameObject === "objects") {
            var i, changedFrame = false;
            this.setLimitFrame(this.getLimitFrame() - 1);
            for (i = 0; i < this.getNumberObjects(); i += 1) {
                this.setPositionAtIndex(i, this.getPosition(i).positionX + delta * this.getSpeed(i).speedX, this.getPosition(i).positionY + delta * this.getSpeed(i).speedY);
                if (this.getPosition(i).positionX +  this.getObjectSprite(i).getFrameData(this.getObjectSprite(i).getCurrentFrame()).frameW * config.scale.scaleWidth < 0) {
                    this.removeGameObject(i);
                    i -= 1;
                }
                if (this.getCollisionLayer(i) === 8) {
                    if (this.getLimitFrame() === 0 && !changedFrame) {
                        this.getObjectSprite(i).nextFrame();
                        changedFrame = true;
                    }
                }
            }
            if (this.getLimitFrame() === 0) {
                this.setLimitFrame(config.system.limitFps);
            }
        }
    };
    this.renderObjects = function (context) {
        var i, thisTop, thisLeft, realWidth, realHeight;
        for (i = 0; i < this.getNumberObjects(); i += 1) {
            //use for draw to test collision between objects
            /*
            thisTop = this.getPosition(i).positionY;
            thisLeft = this.getPosition(i).positionX;
            realWidth = this.getObjectSprite(i).getFrameData(this.getObjectSprite(i).getCurrentFrame()).frameW * config.scale.scaleWidth;
            realHeight = this.getObjectSprite(i).getFrameData(this.getObjectSprite(i).getCurrentFrame()).frameH * config.scale.scaleHeight;
            context.fillRect(thisLeft, thisTop, realWidth, realHeight);
            */
            if (this.getCollisionLayer(i) === 8) {
                this.getObjectSprite(i).drawWithScaleData(context, this.getPosition(i).positionX, this.getPosition(i).positionY, 0.5, 0.5);
            } else {
                this.getObjectSprite(i).draw(context, this.getPosition(i).positionX, this.getPosition(i).positionY);
            }
        }
    };
    this.restartObjects = function () {
        objectSprites = [];
        speeds = [];
        positions = [];
        collisionLayers = [];
        numberObjects = 0;
    };
    this.spawnRandomObject = function (aSpritesArray) {
        if (this.getTypeGameObject() === "objects") {
            var lastIndex = this.getNumberObjects() - 1, rand;
            if (lastIndex < 0 || config.canvasSize.width - this.getPosition(lastIndex).positionX > 600 * config.scale.scaleWidth) {
                rand = Math.random();
                if (rand < 0.5) {
                    this.addCoin(aSpritesArray, Math.random() * 400 * config.scale.scaleHeight);
                } else if (rand < 0.8) {
                    this.addOneWay(aSpritesArray);
                } else {
                    this.addTires(aSpritesArray);
                }
            }
        }
    };
}
GameObject.prototype.init = function (typeGameObject, spritesArray) {
    if (typeGameObject === "background") {
        this.initBackground(spritesArray);
    } else if (typeGameObject === "objects") {
        this.initObjects(spritesArray);
    }
};
GameObject.prototype.update = function (delta) {
    if (this.getTypeGameObject() === "background") {
        this.updateBackground(delta);
    } else if (this.getTypeGameObject() === "objects") {
        this.updateObjects(delta);
    }
};
GameObject.prototype.render = function (context) {
    if (this.getTypeGameObject() === "background") {
        this.renderBackground(context);
    } else if (this.getTypeGameObject() === "objects") {
        this.renderObjects(context);
    }
};
GameObject.prototype.destroy = function () {
    this.removeAllGameObjects();
};
GameObject.prototype.restart = function () {
    if (this.getTypeGameObject() === "background") {
        this.restartBackground();
    } else if (this.getTypeGameObject() === "objects") {
        this.restartObjects();
    }
};
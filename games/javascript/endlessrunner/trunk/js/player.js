/*jslint node: true */
/*global config */
/*global GameObject */
"use strict";
function Player() {
    var onGround = false, groundPositionY = 0, a = 0, hasDie = false;
    GameObject.call(this);
    
    this.checkOnGround = function () {
        return onGround;
    };
    this.setOnGround = function () {
        onGround = true;
    };
    this.setInJumping = function () {
        onGround = false;
    };
    this.getGroundPositionY = function () {
        return groundPositionY;
    };
    this.setGroundPositionY = function (value) {
        if (!isNaN(value)) {
            groundPositionY = value;
        }
    };
    this.getA = function () {
        return a;
    };
    this.setA = function (value) {
        if (!isNaN(value)) {
            a = value;
        }
    };
    this.isDie = function () {
        return hasDie;
    };
    this.setDie = function () {
        hasDie = true;
    };
    this.setLive = function () {
        hasDie = false;
    };
    this.isCollideWithAFrame = function (aFrameX, aFrameY, aFrameW, aFrameH) {
        var thisTop, thisLeft, realWidth, realHeight, thisRight, thisBottom, frameTop, frameLeft, frameRight, frameBottom;
        thisTop = this.getPosition(0).positionY;
        thisLeft = this.getPosition(0).positionX;
        realWidth = this.getObjectSprite(0).getFrameData(this.getObjectSprite(0).getCurrentFrame()).frameW * config.scale.scaleWidth * 0.85;
        realHeight = this.getObjectSprite(0).getFrameData(this.getObjectSprite(0).getCurrentFrame()).frameH * config.scale.scaleHeight;
        thisRight = thisLeft + realWidth;
        thisBottom = thisTop + realHeight;
        frameTop = aFrameY;
        frameLeft = aFrameX;
        frameRight = frameLeft + aFrameW;
        frameBottom = frameTop + aFrameH;
        return !(thisLeft > frameRight || thisRight < frameLeft || thisTop > frameBottom || thisBottom < frameTop);
    };
}
Player.prototype = Object.create(GameObject.prototype);

Player.prototype.init = function (aSpritesArray) {
    var platformHeight = aSpritesArray[5].getHeight() * config.scale.scaleHeight, aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY, aCollisionLayer;
    aSprite = aSpritesArray[9];
    aSpeedX = config.speeds[9];
    aSpeedY = 0;
    aPositionX = 200 * config.scale.scaleWidth;
    aPositionY = config.canvasSize.height - platformHeight / 2 - aSpritesArray[9].getFrameData(aSpritesArray[9].getCurrentFrame()).frameH * config.scale.scaleHeight;
    aCollisionLayer = 9;
    this.setLimitFrame(config.system.limitFps);
    this.addGameObject(aSprite, aSpeedX, aSpeedY, aPositionX, aPositionY  - 400 * config.scale.scaleHeight, aCollisionLayer);
    
    this.setGroundPositionY(aPositionY);
    //
    this.setSpeedAtIndex(0, config.speeds[9], 0);
    this.setPositionAtIndex(0, 200 * config.scale.scaleWidth, this.getGroundPositionY() - 400 * config.scale.scaleWidth);
    this.setLive();
    this.jump_down();
    //
    
};
Player.prototype.restart = function () {
    this.setSpeedAtIndex(0, config.speeds[9], 0);
    this.setPositionAtIndex(0, 200 * config.scale.scaleWidth, this.getGroundPositionY() - 400 * config.scale.scaleWidth);
    this.setLive();
    this.jump_down();
};
Player.prototype.update = function (delta, event) {
    if (!this.isDie()) {
        if (this.checkOnGround()) {
            if (event === "jump") {
                this.jump_up();
            } else {
                this.setLimitFrame(this.getLimitFrame() - 1);
                if (this.getLimitFrame() === 0) {
                    this.getObjectSprite(0).nextFrame();
                    this.setLimitFrame(config.system.limitFps);
                }
            }
        } else if (event !== "jump") {
            this.setPositionYAtIndex(0, this.getPosition(0).positionY + delta * this.getSpeed(0).speedY);
            this.setSpeedYAtIndex(0, this.getSpeed(0).speedY + this.getA());
            if (this.getSpeed(0).speedY + this.getA() >= 0 && this.getSpeed(0).speedY + this.getA() <= this.getA()) {
                this.jump_down();
            }
            if (this.getGroundPositionY() - this.getPosition(0).positionY <= 0) {
                this.run();
                this.setPositionYAtIndex(0, this.getGroundPositionY());
            }
        }
    } else {
        this.setPositionYAtIndex(0, this.getPosition(0).positionY + delta * this.getSpeed(0).speedY);
        this.setSpeedYAtIndex(0, this.getSpeed(0).speedY + this.getA());
    }
};

Player.prototype.render = function (context) {
    //FillRect use for test display collision of player
    /*
    var thisTop, thisLeft, realWidth, realHeight;
    thisTop = this.getPosition(0).positionY;
    thisLeft = this.getPosition(0).positionX;
    realWidth = this.getObjectSprite(0).getFrameData(this.getObjectSprite(0).getCurrentFrame()).frameW * config.scale.scaleWidth * 0.85;
    realHeight = this.getObjectSprite(0).getFrameData(this.getObjectSprite(0).getCurrentFrame()).frameH * config.scale.scaleHeight;
    context.fillRect(thisLeft, thisTop, realWidth, realHeight);
    */
    if (this.getObjectSprite(0) !== undefined) {
        this.getObjectSprite(0).drawWithScaleData(context, this.getPosition(0).positionX, this.getPosition(0).positionY, 0.15, 0.5);
    }
};

Player.prototype.destroy = function () {
    this.removeAllGameObjects();
};

Player.prototype.jump_up = function () {
    this.getObjectSprite(0).setFrameSequence("jump_up");
    this.setInJumping();
    var v = config.jump * config.scale.scaleHeight;
    this.setA(2);
    v += ((config.system.fps / 2) * (config.system.fps / 2)) / 2 * this.getA();
    v = v / (config.system.fps / 2);
    v = Math.floor(v - 1);
    this.setSpeedYAtIndex(0, -v);
};
Player.prototype.jump_down = function () {
    this.getObjectSprite(0).setFrameSequence("jump_down");
    this.setInJumping();
    this.setA(2);
    this.setSpeedYAtIndex(0, 0);
};
Player.prototype.run = function () {
    this.getObjectSprite(0).setFrameSequence("run");
    this.setSpeedYAtIndex(0, 0);
    this.setOnGround();
};

Player.prototype.collide = function (gameObjectsContainer) {
    if (gameObjectsContainer.getTypeGameObject() === "objects") {
        if (!this.isDie()) {
            var i, frameX, frameY, frameW, frameH, thisTop, thisLeft, realWidth, realHeight, thisRight, thisBottom, addHeight;
            for (i = 0; i < gameObjectsContainer.getNumberObjects(); i += 1) {
                frameX = gameObjectsContainer.getPosition(i).positionX;
                frameY = gameObjectsContainer.getPosition(i).positionY;
                //check jump on oneway - collisionLayer 7
                if (gameObjectsContainer.getCollisionLayer(i) === 7) {
                    frameW = gameObjectsContainer.getObjectSprite(i).getFrameData(gameObjectsContainer.getObjectSprite(i).getCurrentFrame()).frameW * config.scale.scaleWidth;
                    frameH = gameObjectsContainer.getObjectSprite(i).getFrameData(gameObjectsContainer
                                                                              .getObjectSprite(i).getCurrentFrame()).frameH * config.scale.scaleHeight;
                    thisTop = this.getPosition(0).positionY;
                    thisLeft = this.getPosition(0).positionX;
                    realWidth = this.getObjectSprite(0).getFrameData(this.getObjectSprite(0).getCurrentFrame()).frameW * config.scale.scaleWidth * 0.85;
                    realHeight = this.getObjectSprite(0).getFrameData(this.getObjectSprite(0).getCurrentFrame()).frameH * config.scale.scaleHeight;
                    thisRight = thisLeft + realWidth;
                    thisBottom = thisTop + realHeight;
                    if (thisRight > frameX && thisLeft < frameX + frameW && this.getSpeed(0).speedY > 0) {
                        if (thisBottom >= frameY - frameH / (6.4 * config.scale.scaleHeight) && thisBottom <= frameY + frameH / (6.4 * config.scale.scaleHeight)) {
                            if (i > 0) {
                                if (gameObjectsContainer.getCollisionLayer(i - 1) !== 7) {
                                    this.run();
                                    this.setPositionYAtIndex(0, frameY - realHeight);
                                    return 7;
                                }
                            } else {
                                this.run();
                                this.setPositionYAtIndex(0, frameY - realHeight);
                                return 7;
                            }
                        }
                    } else if (thisLeft >= frameX + frameW) {
                        if (this.checkOnGround() && thisTop < this.getGroundPositionY()) {
                            this.jump_down();
                        }
                    }
                } else {
                    frameW = gameObjectsContainer.getObjectSprite(i).getFrameData(gameObjectsContainer.getObjectSprite(i).getCurrentFrame()).frameW * config.scale.scaleWidth;
                    frameH = gameObjectsContainer.getObjectSprite(i).getFrameData(gameObjectsContainer
                                                                              .getObjectSprite(i).getCurrentFrame()).frameH * config.scale.scaleHeight;
                }
                if (this.isCollideWithAFrame(frameX, frameY, frameW, frameH)) {
                    if (gameObjectsContainer.getCollisionLayer(i) === 6) {
                        //collide with 6 - tires -> die
                        this.die();
                        return 6;
                    } else if (gameObjectsContainer.getCollisionLayer(i) === 8) {
                        //collide with 8 - coin -> pick up
                        gameObjectsContainer.removeGameObject(i);
                        i -= 1; //decrease 1 because this index is replace with index + 1
                        return 8;
                    }
                }
            }
        }
    }
    return 0;
};

Player.prototype.die = function () {
    this.getObjectSprite(0).setFrameSequence("die");
    this.setDie();
    this.setA(2);
    this.setSpeedYAtIndex(0, -config.dieBounce);
};
Player.prototype.checkGameOver = function () {
    if (this.getPosition(0).positionY >= config.canvasSize.height * 2 && this.isDie()) {
        return true;
    }
    return false;
};
    
/*jslint node: true */
/*global config */
/*global Sprite */
/*global GameObject */
/*global Player */
/*global t_last */
"use strict";
var Game = (function () {
    // Instance stores a reference to the Singleton
    var instance;

    function application() {
        // Singleton
        // Private methods and variables
        var context, sprites, bg = new GameObject(), obj = new GameObject(), player = new Player(), currentScore = 0, highScore, isBling = false, backgroundMusic;
        function createSprites() {
            sprites = [];
            var i;
            for (i = 0; i < config.sources.length; i += 1) {
                sprites[i] = new Sprite();
                sprites[i].getDataFromXMLFile(config.linkXML, config.sources[i]);
            }
        }
        function loadSprites(callback) {
            var loadedSprites = 0, numSprites = sprites.length, i;
            for (i = 0; i < numSprites; i += 1) {
                sprites[i].getImage().onload = function () {
                    loadedSprites += 1;
                    if (loadedSprites >= numSprites) {
                        callback();
                    }
                };
            }
        }
        function destroySprites() {
            sprites = [];
        }
        function setBling() {
            isBling = true;
        }
        function setNoBling() {
            isBling = false;
        }
        function getBling() {
            return isBling;
        }
        function saveHighScore(value) {
            if (typeof (Storage) !== "undefined") {
                // Store
                if (!isNaN(value)) {
                    localStorage.setItem("highscore", value);
                }
            }
        }
        function loadHighScore() {
            if (typeof (Storage) !== "undefined") {
                //Retrive
                highScore = localStorage.getItem("highscore");
            } else {
                highScore = undefined;
            }
        }
        function setCurrentScore(value) {
            if (!isNaN(value)) {
                currentScore = value;
            }
        }
        function getCurrentScore() {
            return currentScore;
        }
        function checkAndSetHighScore() {
            if (currentScore > highScore || highScore === undefined) {
                highScore = currentScore;
                saveHighScore(currentScore);
            }
        }
        function displayHighScore(context) {
            context.font = "bold 30px Verdana";
            context.fillStyle = "white";
            if (highScore !== undefined && highScore !== null) {
                context.fillText("HIGH SCORE: " + highScore, 50 * config.scale.scaleWidth, 50 * config.scale.scaleHeight);
            } else {
                context.fillText("HIGH SCORE: 0", 50 * config.scale.scaleWidth, 50 * config.scale.scaleHeight);
            }
        }
        function displayCurrentScore() {
            context.font = "bold 30px Verdana";
            if (getBling()) {
                context.fillStyle = "yellow";
                setNoBling();
            } else {
                context.fillStyle = "white";
            }
            context.fillText("SCORE: " + currentScore, 50 * config.scale.scaleWidth, 100 * config.scale.scaleHeight);
        }
        return {
            // Public methods and variables
            // INIT prepare environment, load necessary resources
            init: function () {
                //document.getElementById("init").innerHTML = "INIT Application " + t_last;
                context = document.getElementById("myCanvas").getContext("2d");
                var i;
                //audio
                backgroundMusic = new Audio("resources/POL-mushroom-trail-short.wav");
                backgroundMusic.loop = true;
                backgroundMusic.volume = 1;
                backgroundMusic.load();
                createSprites();
                loadSprites(function () {
                    loadHighScore();
                    setCurrentScore(0);
                    bg.init("background", sprites);
                    bg.render(context);
                    obj.init("objects", sprites);
                    obj.render(context);
                    player.init(sprites);
                    player.render(context);
                    displayHighScore(context);
                    displayCurrentScore(context);
                });
            },
            // UPDATE game usually do calculate in this
            update: function (delta) {
                //document.getElementById("update").innerHTML = "UPDATE Application " + t_last;
                if (!player.checkGameOver()) {
                    setCurrentScore(getCurrentScore() + 1);
                    bg.update(delta);
                    obj.spawnRandomObject(sprites);
                    obj.update(delta);
                    var result = player.collide(obj);
                    if (result === 8) {
                        setBling();
                        setCurrentScore(getCurrentScore() + 100);
                    }
                    player.update(delta, "");
                } else {
                    this.restart();
                }
            },
            // RENDER draw objects to screen
            render: function () {
                //document.getElementById("render").innerHTML = "RENDER Application " + t_last;
                bg.render(context);
                obj.render(context);
                player.render(context);
                displayHighScore(context);
                displayCurrentScore(context);
            },
            // DESTROY free all resource, save game state
            destroy: function () {
                //document.getElementById("destroy").innerHTML = "DESTROY Application " + t_last;
                checkAndSetHighScore();
                bg.destroy();
                obj.destroy();
                player.destroy();
            },
            handleEvent: function (event) {
                player.update(0, event);
            },
            restart: function () {
                checkAndSetHighScore();
                setCurrentScore(0);
                bg.restart();
                obj.restart();
                player.restart();
            }
        };
    }

    return {
        // Get the Singleton instance if one exists
        // or create one if it doesn't
        getInstance: function () {
            if (!instance) {
                instance = application();
            }
            return instance;
        }
    };
}());
// var aaa = new Game();
// var aaa = Game();
// var aaa = Game;
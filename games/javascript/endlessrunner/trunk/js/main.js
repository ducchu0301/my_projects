/*jslint node: true */
/*global requestAnimationFrame */
/*global Game */
/*global config */
"use strict";
var t_now, t_last, canvas = document.getElementById("myCanvas"), isKeyDown = false;

function run() {
    t_now = Date.now();
    
    if (!t_last) {
        t_last = t_now;
    }
    
    var delta = t_now - t_last;
    
    
    if (delta > config.system.interval) {
        t_last = t_now - (delta % config.system.interval);
        Game.getInstance().update(0.65);
        Game.getInstance().render();
    }
    requestAnimationFrame(run);
}
function main() {
    Game.getInstance().init();
    requestAnimationFrame(run);
}
function keydown(key) {
    if (key.keyCode === 32 && !isKeyDown) {
        isKeyDown = true;
        Game.getInstance().handleEvent("jump");
    }
}
function keyup(key) {
    if (key.keyCode === 32) {
        isKeyDown = false;
    }
}
function mousedown() {
    Game.getInstance().handleEvent("jump");
}
window.addEventListener("load", main);

window.addEventListener("keydown", keydown);

window.addEventListener("keyup", keyup);

canvas.addEventListener("mousedown", mousedown);

function myConfirmation() {
    return 'Endless Runner';
}

window.onbeforeunload = myConfirmation;
window.onunload = Game.getInstance().destroy;
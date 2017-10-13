/*jslint node: true */
"use strict";

//Class Player
var Player = function (symbol, value) {
    this.symbol = symbol;
    this.value = value;
};
Player.prototype.getSymbol = function () {
    return this.symbol;
};
Player.prototype.getValue = function () {
    return this.value;
};

//init 2 players
var player1 = new Player('O', 1);
var player2 = new Player('X', 2);
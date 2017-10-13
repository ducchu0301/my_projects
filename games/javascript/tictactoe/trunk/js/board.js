/*jslint node: true */
"use strict";
//var Square = require("square.js");
//var Player = require("player.js");

//init symbol + for empty square;
//symbols from player 1 and player 2
var Symbol = ['+', player1.getSymbol(), player2.getSymbol()];
//class Board
var Board = function (size) {
    this.size = size || 3;
    this.grid = [];
    this.filledSquare = 0;
};
Board.prototype.getSize = function () {
    return this.size;
};
Board.prototype.createBoard = function () {
    var i, j;
    for (i = 0; i < this.getSize(); i += 1) {
        this.grid[i] = [];
        for (j = 0; j < this.getSize(); j += 1) {
            this.grid[i][j] = new Square();
        }
    }
};
Board.prototype.resetBoard = function () {
    var i, j;
    for (i = 0; i < this.getSize(); i += 1) {
        for (j = 0; j < this.getSize(); j += 1) {
            this.grid[i][j].setEmpty();
        }
    }
    this.filledSquare = 0;
};
//update a square in board, return true if succeed, else return false
Board.prototype.update = function (row, col, value) {
    if (row > 0 && row <= this.getSize() && col > 0 && col <= this.getSize()) {
        if (this.grid[row - 1][col - 1].setValue(value)) {
            this.filledSquare += 1;
            return true;
        } else {
            return false;
        }
    }
};
//display to console log
Board.prototype.display = function () {
    var i, j, line;
    for (i = 0; i < this.getSize(); i += 1) {
        for (j = 0; j < this.getSize(); j += 1) {
            line += Symbol[this.grid[i][j].getValue()] + " ";
        }
        line = line.trim();
        console.log(line);
        line = "";
    }
};
Board.prototype.hasWinner = function () {
    var i, j, flag, count = 1;
    //check case
	//* * *
	for (i = 0; i < this.getSize(); i += 1) {
        flag = this.grid[i][0].getValue();
        if (flag !== 0) {
            for (j = 1; j < this.getSize(); j += 1) {
                if (flag === this.grid[i][j].getValue()) {
                    count += 1;
                } else {
                    count = 1;
                    break;
                }
            }
            if (count === this.getSize()) {
                return flag;
            } else {
                count = 1;
            }
        }
	}
    
	//check case
	//*
	//*
	//*
    for (i = 0; i < this.getSize(); i += 1) {
        flag = this.grid[0][i].getValue();
        if (flag !== 0) {
            for (j = 1; j < this.getSize(); j += 1) {
                if (flag === this.grid[j][i].getValue()) {
                    count += 1;
                } else {
                    count = 1;
                    break;
                }
            }
            if (count === this.getSize()) {
                return flag;
            } else {
                count = 1;
            }
        }
	}
	
	//check case
	//*
	//  *
	//    *
    flag = this.grid[0][0].getValue();
	for (i = 1; i < this.getSize(); i += 1) {
        if (flag !== 0) {
            if (flag === this.grid[i][i].getValue()) {
                count += 1;
            } else {
                count = 1;
                break;
            }
        }
    }
    if (count === this.getSize()) {
        return flag;
    } else {
        count = 1;
    }
    //check case
	//    *
	//  *
	//*
    flag = this.grid[0][this.getSize() - 1].getValue();
	for (i = 1; i < this.getSize(); i += 1) {
        if (flag !== 0) {
            if (flag === this.grid[i][this.getSize() - i - 1].getValue()) {
                count += 1;
            } else {
                count = 1;
                break;
            }
        }
    }
    if (count === this.getSize()) {
        return flag;
    } else {
        count = 1;
    }
	return 0;
};
//check is the Game over or not
Board.prototype.isOver = function () {
    var checkWinner = this.hasWinner();
    if (this.filledSquare === this.getSize() * this.getSize()) {
        if (checkWinner === 0) {
            return 3;
        } else {
            return checkWinner;
        }
    } else {
        return checkWinner;
    }
};

//display Board to HTML files by return string
Board.prototype.displayBoard = function () {
    var i, j, string = "", disable = "";
    for (i = 0; i < this.getSize(); i += 1) {
        for (j = 0; j < this.getSize(); j += 1) {
            if (this.grid[i][j].getValue() > 0) {
                disable = this.grid[i][j].getValue() === 1 ? " disable btn-primary" : " disable btn-info";
            }
            
            string += '<li id="cell' + (i + 1) + (j + 1) + '" class="btn span1' + disable + '" onclick="updateGame(' + (i + 1) + ', ' + (j + 1) + ')">' + Symbol[this.grid[i][j].getValue()] + '</li>';
            disable = "";
        }
    }
    return string;
};
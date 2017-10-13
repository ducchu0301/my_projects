/*jslint node: true */
/*global alert */
"use strict";
//var Cookie = require("cookie.js");
//var Square = require("square.js");
//var Player = require("player.js");
//var Square = require("board.js");

var ticTacToeBoard = new Board(3);
//set turn currentplayer is player1
var currentPlayer = player1.getValue();

//get cookie data
var player1win = Cookie.prototype.checkCookie("player1win") ? parseInt(Cookie.prototype.getCookie("player1win"), 10) : 0;
var player2win = Cookie.prototype.checkCookie("player2win") ? parseInt(Cookie.prototype.getCookie("player2win"), 10) : 0;

//load player1 and player2 win to index.htm
function loadStatus() {
    document.getElementById("player-1-name").innerHTML = player1.getSymbol() + " won";
    document.getElementById("player-1-win").innerHTML = player1win;
    document.getElementById("player-2-name").innerHTML = player2.getSymbol() + " won";
    document.getElementById("player-2-win").innerHTML = player2win;
}
//load history from cookie and update to ticTacToeBoard
function loadHistory() {
    if (Cookie.prototype.checkCookie("history")) {
        var history = Cookie.prototype.getCookie("history"), i, row, col, curPlayer;
        if (history.length % 3 === 0) {
            for (i = 0; i < history.length; i += 3) {
                row = parseInt(history.charAt(i + 1), 10);
                col = parseInt(history.charAt(i + 2), 10);
                curPlayer = parseInt(history.charAt(i), 10);
                ticTacToeBoard.update(row, col, curPlayer);
                if (i === history.length - 3) {
                    currentPlayer = curPlayer === player1.getValue() ? player2.getValue() : player1.getValue();
                }
            }
        }
    }
}
//create Board and load status, history from cookie
function loadGame() {
    ticTacToeBoard.createBoard();
    loadStatus();
    loadHistory();
    //display to index.htm
    document.getElementById("game").innerHTML = ticTacToeBoard.displayBoard();
}
//reset history, tiTacToeBoard, currentplayer and update to index.htm
function resetGame() {
    Cookie.prototype.setCookie("history", "", 7);
    ticTacToeBoard.resetBoard();
    currentPlayer = player1.getValue();
    document.getElementById("game").innerHTML = ticTacToeBoard.displayBoard();
}
//update game whenever player click a square in ticTacToeBoard
function updateGame(row, col) {
    var result = ticTacToeBoard.isOver(), temp = "";
    //check result, if game is Over, print result, else update value in the square.
    switch (result) {
    case 1:
        alert(player1.getSymbol() + " has won the game. Start a new game.");
        resetGame();
        return;
    case 2:
        alert(player2.getSymbol() + " has won the game. Start a new game.");
        resetGame();
        return;
    case 3:
        alert("It's a tie. It will restart.");
        resetGame();
        return;
    }
    //update return true if sucess, else return false
    if (ticTacToeBoard.update(row, col, currentPlayer)) {
        //save game history to cookie
        if (Cookie.prototype.checkCookie("history")) {
            temp = Cookie.prototype.getCookie("history").toString();
        }
        temp += currentPlayer.toString() + row.toString() + col.toString();
        Cookie.prototype.setCookie("history", temp, 7);
        //change turn of player
        currentPlayer = currentPlayer === player1.getValue() ? player2.getValue() : player1.getValue();
        //update game board to index.htm
        document.getElementById("game").innerHTML = ticTacToeBoard.displayBoard();
        //check winner and save status in cookie
        result = ticTacToeBoard.isOver();
        if (result > 0) {
            if (result === 1) {
                alert(player1.getSymbol() + " wins.");
                player1win += 1;
                Cookie.prototype.setCookie("player1win", player1win, 7);
                document.getElementById("player-1-win").innerHTML = player1win;
            } else if (result === 2) {
                alert(player2.getSymbol() + " wins.");
                player2win += 1;
                Cookie.prototype.setCookie("player2win", player2win, 7);
                document.getElementById("player-2-win").innerHTML = player2win;
            }
        }
    } else {
        //if a square is already had a value. print error
        alert("Already Seleted!");
    }
}


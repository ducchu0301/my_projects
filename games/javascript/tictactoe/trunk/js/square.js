/*jslint node: true */
"use strict";
//Class Square
var Square = function () {
    this.value = 0;
    this.isBlocked = false;
};

Square.prototype.getValue = function () {
    return this.value;
};
//if the Square is blocked, can't set the value
Square.prototype.setValue = function (aValue) {
    if (this.isBlocked) {
        return false;
    } else {
        this.value = aValue;
        this.isBlocked = true;
        return true;
    }
};
Square.prototype.checkBlock = function () {
    if (this.isBlocked) {
        return true;
    } else {
        return false;
    }
};
Square.prototype.setEmpty = function () {
    this.value = 0;
    this.isBlocked = false;
};
/*jslint node: true */
"use strict";
//Class Cookie
var Cookie = function () {};

Cookie.prototype.getCookie = function getCookie(cName) {
    var name = cName + "=", ca = document.cookie.split(';'), i, c;
    for (i = 0; i < ca.length; i += 1) {
        c = ca[i];
        while (c.charAt(0) === ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) === 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
};
Cookie.prototype.setCookie = function setCookie(cName, cValue, exDays) {
    var d = new Date(), expires = "";
    d.setTime(d.getTime() + (exDays * 24 * 60 * 60 * 1000));
    expires = "expires=" + d.toGMTString();
    document.cookie = cName + "=" + cValue + "; " + expires;
};

//if cName field had value, return true, else return false
Cookie.prototype.checkCookie = function checkCookie(cName) {
    var field = Cookie.prototype.getCookie(cName);
    if (field !== "" && field !== null && field !== undefined) {
        return true;
    } else {
        return false;
    }
};
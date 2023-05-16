﻿


//cookie ekler
function SetCookie(cname, cvalue, exminutes) {
    var d = new Date();
    d.setTime(d.getTime() + (exminutes * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function formatDateSecond(seconds) {
    var date = new Date(seconds * 1000);
    var year = date.getUTCFullYear() - 1970;
    var month = date.getUTCMonth();
    var day = date.getUTCDate() - 1;
    var hours = date.getUTCHours();
    var minutes = date.getUTCMinutes();
    var second = date.getUTCSeconds();

    var result = "";
    if (year > 0) {
        result += year + " yıl, ";
    }
    if (month > 0 || result !== "") {
        result += month + " ay, ";
    }
    if (day > 0 || result !== "") {
        result += day + " gün, ";
    }
    if (hours > 0 || result !== "") {
        result += hours + " saat, ";
    }
    if (minutes > 0 || result !== "") {
        result += minutes + " dakika, ";
    }
    result += second + " saniye";

    return result;
}

function formatDateSecondV1(seconds) {
    var date = new Date(seconds * 1000);
    var year = date.getUTCFullYear() - 1970;
    var month = date.getUTCMonth();
    var day = date.getUTCDate() - 1;
    var hours = date.getUTCHours();
    var minutes = date.getUTCMinutes();
    var second = date.getUTCSeconds();

    var result = "";
    if (year > 0) {
        result += year + ":";
    }
    if (month > 0 || result !== "") {
        result += month + ":";
    }
    if (day > 0 || result !== "") {
        result += day + ":";
    }
    if (hours > 0 || result !== "") {
        result += hours + ":";
    }
    if (minutes > 0 || result !== "") {
        result += minutes + ":";
    }
    result += second;

    return result;
}

function formatDate(date) {
    const options = {
        year: "numeric",
        month: "2-digit",
        day: "2-digit",
        hour: "2-digit",
        minute: "2-digit",
        second: "2-digit"
    };

    return new Intl.DateTimeFormat("tr-TR", options).format(date);
}

function getParameterInUrlByName(name) {
    var url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}


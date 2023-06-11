

function generateUUID() {
    let dt = new Date().getTime();
    const uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        const r = (dt + Math.random() * 16) % 16 | 0;
        dt = Math.floor(dt / 16);
        return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
    });
    return uuid;
}

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

//function getIpAddress() {
//    //$.get("https://ipinfo.io", function (response) {
//    // return response.ip;
//    //}, "json")

//    $.get("https://api.ipify.org?format=json", function (response) {
//        return response.ip;
//    });
//}

function getIpAddress() {
    return new Promise((resolve, reject) => {
        $.get("https://api.ipify.org?format=json", function (response) {
            resolve(response.ip);
        }).fail(function (error) {
            reject(error);
        });
    });
}


function downloadQRCode(serialNumber, itemId, itemType) {
    //generateQRCode(`serialNumber:${serialNumber}-id:${itemId}-itemType:${itemType}`);
    var parameter = {
        SerialNumber: serialNumber,
        ItemId: itemId,
        ItemType: itemType
    }
    generateQRCode(JSON.stringify(parameter));

    downloadQRCodeImage();
}
function downloadQRCodeV1(itemId, itemType) {
    //generateQRCode(`id:${itemId}-itemType:${itemType}`);
    var parameter = {
        ItemId: itemId,
        ItemType: itemType
    }
    generateQRCode(JSON.stringify(parameter));

    downloadQRCodeImage();
}
function generateQRCode(qrCodeText) {
    var qrcode = new QRCode("qrcode", qrCodeText);
}
function downloadQRCodeImage() {
    var qrCodeImage = document.querySelector("#qrcode img");

    qrCodeImage.onload = function () {
        var qrcodeDiv = document.getElementById('qrcode');
        var linkElement = qrcodeDiv.querySelector('img');
        var srcValue = linkElement.getAttribute('src');

        var img = new Image();
        img.src = srcValue;

        img.onload = function () {
            var canvas = document.createElement("canvas");
            canvas.width = img.width;
            canvas.height = img.height;
            var ctx = canvas.getContext("2d");
            ctx.drawImage(img, 0, 0);

            var dataURL = canvas.toDataURL("image/png");

            var link = document.createElement("a");
            link.href = dataURL;
            //link.download = `${$scope.Item.Name}-qrcode.png`;
            link.download = `qrcode.png`;
            link.click();

            $("#qrcode").empty();
        };
    };
}


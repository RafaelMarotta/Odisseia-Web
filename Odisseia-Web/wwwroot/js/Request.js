

function Request(type, url) {

    var httpRequest;

    if (window.XMLHttpRequest) { 
        httpRequest = new XMLHttpRequest();
    } else if (window.ActiveXObject) { 
        try {
            httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (e) { }
        }
    }

    if (!httpRequest) {
        return false;
    }
    httpRequest.open(type, url, false);
    httpRequest.send();

    if (httpRequest.readyState === 4) {
        if (httpRequest.status === 200) {
            return httpRequest.responseText;
        }
    }
}

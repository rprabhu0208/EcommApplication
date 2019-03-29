function OnlyDecimals(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 46)
        return false;
    else {
        var len = evt.srcElement.value.length;
        var index = evt.srcElement.value.indexOf('.');
        if (index == -1 && charCode == 46 && evt.srcElement.value.length == 0)
            evt.srcElement.value = '0' + evt.srcElement.value;
        if (index > 0 && charCode == 46) {
            return false;
        }
        if (index > 0) {
            var CharAfterdot = (len + 1) - index;
            if (CharAfterdot > 3) {
                return false;
            }
        }

    }
    return true;
}

if (window.addEventListener) {
    window.addEventListener('load', general_Load, false);
}
else {
    window.attachEvent('onload', general_Load);
}


var toStr = function (e) {
    return e == null || e == "null" ? "" : e.toString();
};

var toInt = function (e) {
    return e == null || e == "" ? null : parseInt(e);
};

var toIntNull = function (e) {
    return e == -1 || e == null || e == "" ? 0 : parseInt(e);
};

var toDouble = function (e) {
    return e == null || e == "" ? null : parseFloat(e);
};

var isNull = function (e) {
    return e == null || e == "undefined" || e == undefined ? "" : e;
};


function general_Load() {

    window.onbeforeunload = setClick;
}

var Base64 = {
    _keyStr: "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=", encode: function (e) {
        var t = ""; var n, r, i, s, o, u, a; var f = 0; e = Base64._utf8_encode(e); while (f < e.length) { n = e.charCodeAt(f++); r = e.charCodeAt(f++); i = e.charCodeAt(f++); s = n >> 2; o = (n & 3) << 4 | r >> 4; u = (r & 15) << 2 | i >> 6; a = i & 63; if (isNaN(r)) { u = a = 64 } else if (isNaN(i)) { a = 64 } t = t + this._keyStr.charAt(s) + this._keyStr.charAt(o) + this._keyStr.charAt(u) + this._keyStr.charAt(a) } return t
    }, decode: function (e) { var t = ""; var n, r, i; var s, o, u, a; var f = 0; e = e.replace(/[^A-Za-z0-9+/=]/g, ""); while (f < e.length) { s = this._keyStr.indexOf(e.charAt(f++)); o = this._keyStr.indexOf(e.charAt(f++)); u = this._keyStr.indexOf(e.charAt(f++)); a = this._keyStr.indexOf(e.charAt(f++)); n = s << 2 | o >> 4; r = (o & 15) << 4 | u >> 2; i = (u & 3) << 6 | a; t = t + String.fromCharCode(n); if (u != 64) { t = t + String.fromCharCode(r) } if (a != 64) { t = t + String.fromCharCode(i) } } t = Base64._utf8_decode(t); return t }, _utf8_encode: function (e) { e = e.replace(/rn/g, "n"); var t = ""; for (var n = 0; n < e.length; n++) { var r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r) } else if (r > 127 && r < 2048) { t += String.fromCharCode(r >> 6 | 192); t += String.fromCharCode(r & 63 | 128) } else { t += String.fromCharCode(r >> 12 | 224); t += String.fromCharCode(r >> 6 & 63 | 128); t += String.fromCharCode(r & 63 | 128) } } return t }, _utf8_decode: function (e) { var t = ""; var n = 0; var r = c1 = c2 = 0; while (n < e.length) { r = e.charCodeAt(n); if (r < 128) { t += String.fromCharCode(r); n++ } else if (r > 191 && r < 224) { c2 = e.charCodeAt(n + 1); t += String.fromCharCode((r & 31) << 6 | c2 & 63); n += 2 } else { c2 = e.charCodeAt(n + 1); c3 = e.charCodeAt(n + 2); t += String.fromCharCode((r & 15) << 12 | (c2 & 63) << 6 | c3 & 63); n += 3 } } return t }
};

var postArray = [];
function ajax(url, data, successMethod, error) {
    if (typeof data != "string" && data != null) {
        data = JSON.stringify(data);
    }

    //url = baseUrl + url;
    var post = $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: url,
        data: data,
        dataType: "json",
        success: successMethod,
        error: function (e, exception) {
            componentError = e;
            if (error) {
                error = errorSend(e, exception);
                console.log(error);
            }

        }
    });
    postArray.push(post);
}

function ajax2(url, data, successMethod, error) {

    //url = baseUrl + url;
    var post = $.ajax({
        type: "POST",
        url: url,
        data: data,
        contentType: false,
        processData: false,
        dataType: false,
        success: successMethod,
        error: function (e, exception) {
            componentError = e;
            if (error) {
                error = errorSend(e, exception);
                console.log(error);
            }

        }
    });
    postArray.push(post);
}



function toForm(id) {//serialize data function
    formArray = $(id).serializeArray();
    returnArray = {};

    for (var i = 0; i < formArray.length; i++) {
        var finame = toStr(formArray[i]['name']);
        var fivalue = toStr(formArray[i]['value']);
        if (finame.indexOf("Id") != -1 && fivalue == "-1") {
            returnArray[formArray[i]['name']] = null;
        }
        else {
            returnArray[formArray[i]['name']] = fivalue;
        }
    }
    $(id + ' select[disabled]').each(function () {
        returnArray[$(this).attr('name')] = $(this).val();
    });
    $(id + ' input[disabled]').each(function () {
        returnArray[$(this).attr('name')] = $(this).val();
    });

    $(id + ' textarea').each(function () {
        returnArray[$(this).attr('name')] = $(this).val();
    });

    return returnArray;
}

function toFormData(id) {
    var fdata = new FormData();
    //var formArray = $(id).serializeArray();

    $(id + ' input[type="text"]').each(function () {
        fdata.append($(this).attr('name'), $(this).val());
    });

    $(id + ' input[type="hidden"]').each(function () {
        fdata.append($(this).attr('name'), $(this).val());
    });

    $(id + ' select[disabled]').each(function () {
        fdata.append($(this).attr('name'), $(this).val());
    });

    $(id + ' input[disabled]').each(function () {
        fdata.append($(this).attr('name'), $(this).val());
    });

    $(id + ' textarea').each(function () {
        fdata.append($(this).attr('name'), $(this).val());
    });

    $(id + ' input[type="file"]').each(function (a, b) {
        var fileInput = $(this)[a];
        if (fileInput.files.length > 0) {
            var file = fileInput.files[0];
            fdata.append($(this).attr('name'), file);
        }
    });

    return fdata;
}

var _validFileExtensions = [".png", ".jpg", ".jpeg"];
function UploadValid(oInput) {
    if (oInput.type == "file") {
        var sFileName = oInput.value;
        if (sFileName.length > 0) {
            var blnValid = false;
            for (var j = 0; j < _validFileExtensions.length; j++) {
                var sCurExtension = _validFileExtensions[j];
                if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                    blnValid = true;
                    break;
                }
            }

            if (!blnValid) {
                bootbox.alert(sFileName + " geçeriz uzantı. Desteklenen uzantılar :  " + _validFileExtensions.join(", "));
                oInput.value = "";
                return false;
            }
        }
    }
    return true;
}



function setClick() {
    for (var i = 0; i < postArray.length; i++) {
        postArray[i].abort();
    }
    // cl();
}

function errorSend(e, exception) {
    var error = '';
    if (e.status == 0) {
        error = 'Not connect. Verify Network.';
    } else if (e.status == 404) {
        error = 'Requested page not found. [404]';
    } else if (e.status == 500) {
        error = 'Internal Server Error [500].';
    } else if (exception === 'parsererror') {
        error = 'Requested JSON parse failed.';
    } else if (exception === 'timeout') {
        error = 'Time out error.';
    } else if (exception === 'abort') {
        error = 'Ajax request aborted.';
    } else {
        error = 'Uncaught Error. \n' + error.responseText;
    }
    var data = { error: error };
    //AjaxPOST("/Pages/Methods.aspx/sendErrorMail", data, null, false, null);

    return error;
}


/*Convert*/
function isBool(variable) {
    if (typeof (variable) === "boolean") {
        return true;
    }
    else {
        return false;
    }
}

function toBool(value) {
    return value == true ? "True" : "False";
}

function isNumeric(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function toDate(date, format) {
    if (!date) return dates;
    var dates = new Date(parseInt(date.replace('/Date(', '').replace(')/', '')));
    dates = $.datepicker.formatDate('dd' + format + 'mm' + format + 'yy', dates);
    return dates;
}


function DateParse(date) {
    if (date == null) return null;
    var result = new Date(parseInt(date.replace('/Date(', '').replace(')/', '')));
    return result;
}

function todayDate(format) {
    var dates = $.datepicker.formatDate('dd' + format + 'mm' + format + 'yy', new Date());
    return dates;
}

function toDateScript(date, format) {
    var dates = $.datepicker.formatDate('dd' + format + 'mm' + format + 'yy', date);
    return dates;
}

function toStrDate(date, format) {
    date = date.split(format);
    return new Date(date[2], parseInt(date[1]) - 1, date[0]);
}

function toStrDateNew(date, format) {
    date = date.split(format);
    return new Date(date[0], parseInt(date[1]) - 1, date[2]);
}


var toDateList = function (obj, format) {
    for (var i = 0; i < obj.length; i++) {
        var value = obj[i];
        var array = $.map(value, function (value, index) {
            return [value];
        });
        var properties = Object.keys(value);
        array.forEach(function (subValue, key) {
            if (subValue && !isNumeric(subValue) && !isBool(subValue) && subValue.indexOf('/Date(') > -1) {
                var property = properties[key];
                value[property] = toDate(subValue, format);
            }
        });
    }
    return obj;
}


Array.prototype.toObject = function () {
    var Obj = {};
    for (var i in this) {
        if (typeof this[i] != "function") {
            Obj[i] = this[i];
        }
    }
    return Obj;
}

function forData(obj, data) {
    for (var i = 0; i < data.length; i++) {
        obj.push(data[i]);
    }
    return obj;
}

function getRow(data, el) {
    var obj = null;
    for (var i = 0; i < data.length; i++) {
        if (data[i].value.indexOf(el) != -1) {
            obj = data[i];
            break;
        }
    }
    return obj;
}



function toArray(d) {
    var dd = new Array();
    for (var i = 0; i < d.length; i++) {
        var arr = new Array();
        for (var j in d[i]) {
            arr.push(d[i][j]);
        }
        dd.push(arr);
    }
    return dd;
}

function toData(datas) {
    if (!datas) return null;
    if (!datas && !datas.d) return null;
    else {
        if (datas.d)
            datas = datas.d;
    }
    if (datas.MethodResultType && datas.MethodResultType == parseInt(MethodResultType.Error)) {
        var error = datas.Result;
        logMessage(error);
        datas = [];
    }
    return datas;
}




function getObjects(obj, key, val) {
    var objects = [];
    for (var i in obj) {
        if (!obj.hasOwnProperty(i)) continue;
        if (typeof obj[i] == 'object') {
            objects = objects.concat(getObjects(obj[i], key, val));
        } else
            if (i == key && obj[i] == val || i == key && val == '') { //
                objects.push(obj);
            } else if (obj[i] == val && key == '') {
                if (objects.lastIndexOf(obj) == -1) {
                    objects.push(obj);
                }
            }
    }
    return objects;
}

function getObjName(obj) {
    return (wrap = { obj }) && eval('for(p in obj){p}') && (wrap = null);
}

NodeList.prototype.getattr = function (key) {
    var d = [];
    for (var i = 0; i < $(this).length; i++) {
        d[i] = $(this)[i].attr(key);
    }
    return d;
}

NodeList.prototype.setattr = function (key, value) {
    var d = [];
    for (var i = 0; i < $(this).length; i++) {
        d[i] = $(this)[i].attr(key, value);
    }
    return d;
}

function setattr(data, key, value) {
    for (var i = 0; i < $(data).length; i++) {
        $(data)[i].attr(key, value);
    }
}



function getattr(data, key, type) {
    var d = [];
    for (var i = 0; i < $(data).length; i++) {
        if (type == "int")
            d[i] = parseInt($(data[i]).attr(key));
        else
            d[i] = $(data[i]).attr(key);
    }
    return d;
}


function getattrValue(data) {
    var d = [];
    for (var i = 0; i < $(data).length; i++) {
        d[i] = $(data[i]).val();
    }
    return d;
}


HTMLElement.prototype.setSelect = function (data, value, innerHTML, selectName, selectValue) {
    $("#select2-" + this.id + "-container").empty();
    this.clearContainer(0);
    if (selectName != "nan") {
        this.addOption("Hepsi", "", "true", "", "");
    }

    if (selectName == "disabled")
        this.setAttribute("disabled", "disabled");
    for (var i = 0; i < data.length; i++) {
        var d = data[i];
        var option = document.createElement("option");
        option.innerHTML = d[innerHTML];
        option.value = d[value];
        //option.style.backgroundImage = 'url(content/img/sub.png)';
        if ((selectValue && (selectValue == option.value)) || (selectName && selectName != 'nan' && (option.innerHTML.toLowerCase().indexOf(selectName.toLowerCase()) != -1))) {
            option.selected = true;
            option.setAttribute("selected", 'selected');
            $("#select2-" + this.id + "-container").text(option.innerHTML);
        }
        this.appendChild(option);

    }
}


jQuery.fn.setSelectText = function (item) {
    if (item || item == 0) {
        $(this).val(item);
        $("#" + $(this).attr("id") + " option[value='" + item + "']").prop('selected', "selected");
        $("#select2-" + $(this).attr("id") + "-container").text($("#" + $(this).attr("id") + " option[value='" + item + "']").text())
    }
}


$.fn.avg = function () {
    var sum = 0;
    for (var i = 0; i < this.length; i++) {
        sum += parseInt(elmt[i], 10); //don't forget to add the base
    }

    var avg = sum / this.length;

    return avg;
}



HTMLElement.prototype.addOption = function (text, value, select, attr, attrValue) {
    var option = document.createElement("option");
    option.value = value;
    option.innerHTML = text;
    if (attr)
        option.setAttribute(attr, attrValue);
    if (select)
        option.selected = true;
    $("#select2-" + this.id + "-container").text(option.innerHTML);
    this.appendChild(option);
}

HTMLElement.prototype.clearContainer = function (skipCount) {
    if (!skipCount || skipCount === 0) {
        this.innerHTML = "";
        return;
    }

    while (this.childElementCount > skipCount) {
        this.removeChild(this.childNodes[skipCount]);
    }
}

function PostAndRedirect(url, data, formname) {
    var form = document.createElement("form");
    form.action = url;
    form.method = "post";
    form.style.display = "none";
    form.name = formname;

    for (var item in data) {
        var input = document.createElement("input");
        input.type = "hidden";
        input.value = data[item];
        input.name = item;
        form.appendChild(input);
    }
    document.body.appendChild(form);
    console.log(form);
    form.submit();
}


var loadingdiv = loadingdiv || (function ($) {
    'use strict';
    return {
        show: function (message) {
            message = message || "Loading";
            $.blockUI({
                boxed: true,
                message: message
            });
        },
        hide: function (time) {
            $.unblockUI();
        }
    };

})(jQuery);


function alerts(message, button, call) {
    var but = [];
    if (button == "yesno") {
        but = {
            confirm: {
                label: "Yes",
                className: 'btn-success'
            },
            cancel: {
                label: "No",
                className: 'btn-danger'
            }
        };
    }
    else if (button == "ok") {
        but = {
            confirm: {
                label: "OK",
                className: 'btn-success'
            }
        };
    }

    if (call) {
        bootbox.confirm({
            message: message,
            buttons: but,
            callback: call,
        });
    }
    else {
        bootbox.alert(message);
    }

}




function toColumns(data) {

    var col = {
        columns: []
    };

    for (var i = 0; i < data.length; i++) {
        col.columns.push({ title: data[i] });
    }

    return col.columns;
}


function alertJson(baslik, data) {
    data = JSON.parse(data);
    var msg = "";
    $.each(data, function (index, item) {
        msg += baslik + ": " + item + "</br></br>";

    });
    bootbox.alert(msg);
}


function alertJsonText(baslik, msg) {
    bootbox.alert(msg);
}





function getSelect(url, id, propID, propValue, select, func) {
    loadingdiv.show();
    ajax(url, null,function (dataResult) {
        id.setSelect(dataResult.Result, propID, propValue, "", select);
        $("#" + id.id).change(function () {
            if (func != null)
                func();
        });
        loadingdiv.hide();
    }, function () { loadingdiv.hide(); });
}



function yenile() {
    location.reload();
}





$.fn.digits = function () {
    return this.each(function () {
        $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1."));
    });
};


function clearIntervalAll() {
    var interval_id = window.setInterval("", 9999); // Get a reference to the last
    // interval +1
    for (var i = 1; i < interval_id; i++)
        window.clearInterval(i);
    //for clearing all intervals
}


function setFroala(id) {
    $(id).froalaEditor({
        toolbarButtons: ['bold', 'italic', 'underline', 'strikeThrough', 'subscript', 'superscript', 'fontFamily', 'fontSize', '|', 'specialCharacters', 'color', 'emoticons', 'inlineStyle', 'paragraphStyle', '|', 'paragraphFormat', 'align', 'formatOL', 'formatUL', 'outdent', 'indent', '-', 'quote', 'insertHR', 'insertLink', 'insertImage', 'insertVideo', 'insertFile', 'insertTable', '|', 'undo', 'redo', 'clearFormatting', 'selectAll', 'html', 'applyFormat', 'removeFormat', 'fullscreen', 'print', 'help'],
        language: 'tr',
        height: 300,
        setHTML: true,
        //htmlRemoveTags: ['script', 'style', 'base']
        //htmlUntouched: true
    });

}


function dtAyar() {
    jQuery.fn.dataTable.Api.register('sum()', function () {
        return this.flatten().reduce(function (a, b) {
            if (typeof a === 'string') {
                a = a.replace(/[^\d.-]/g, '') * 1;
            }
            if (typeof b === 'string') {
                b = b.replace(/[^\d.-]/g, '') * 1;
            }

            return a + b;
        }, 0);
    });

    jQuery.fn.dataTable.Api.register('avg()', function () {
        var data = this.flatten();
        var sum = data.reduce(function (a, b) {
            return (a * 1) + (b * 1); // cast values in-case they are strings
        }, 0);

        return sum / data.length;
    });

    $.fn.dataTable.Api.register('column().title()', function () {
        var colheader = this.header();
        return $(colheader).text().trim();
    });



    //İNPUT FORM  CONTROL
    $("input[type*='number'],input[type*='text'],input[type*='password']").addClass("form-control");

    //İS NUMERİC
    jQuery('.isnumeric').keyup(function () {
        this.value = this.value.replace(/[^0-9\.]/g, '');
    });

    //DATE PİCKER
    $('.date-picker').datepicker({
        //rtl: App.isRTL(),
        //orientation: "left",
        autoclose: true,
        minDate: 0
    });
    //TİME PİCKER
    $('.timepicker-24').timepicker({
        autoclose: true,
        minuteStep: 5,
        showSeconds: false,
        showMeridian: false,
        defaultTime: false
    });


    function format(state) {
        return "<img  src='content/img/" + "sub" + ".png'/>" + state.text;
    }


    //SELECT
    $.fn.select2.defaults.set("theme", "bootstrap");
    var placeholder = "Hepsi";
    $("select").select2({
        placeholder: placeholder,
        width: null
        //formatResult: format,
        //formatSelection: format,
    });

    $("select").on("select2:open", function () {
        if ($(this).parents("[class*='has-']").length) {
            var classNames = $(this).parents("[class*='has-']")[0].className.split(/\s+/);
            for (var i = 0; i < classNames.length; ++i) {
                if (classNames[i].match("has-")) {
                    $("body > .select2-container").addClass(classNames[i]);
                }
            }
        }
    });

    $('#ajax').on('hidden.bs.modal', function () {
        $('#ajax .modal-content').empty();
    });

    $("#ajax").on("hide", function () {
        $("#ajax a.btn").off("click");
    });

    $("#ajax").on("hidden", function () {
        $("#ajax").remove();
    });

    $('#ajaxSub').on('hidden.bs.modal', function () {
        $('#ajaxSub .modal-content').empty();
    });

    $("#ajaxSub").on("hide", function () {
        $("#ajaxSub a.btn").off("click");
    });

    $("#ajaxSub").on("hidden", function () {
        $("#ajaxSub").remove();
    });

    $('#ajaxSubSub').on('hidden.bs.modal', function () {
        $('#ajaxSubSub .modal-content').empty();
    });

    $("#ajaxSubSub").on("hide", function () {
        $("#ajaxSubSub a.btn").off("click");
    });

    $("#ajaxSubSub").on("hidden", function () {
        $("#ajaxSubSub").remove();
    });




}



function confirmCustom(message, button, call) {
    var but = [];
    if (button == "yesno") {
        but = {
            confirm: {
                label: "Yes",
                className: 'btn-success'
            },
            cancel: {
                label: "No",
                className: 'btn-danger'
            }
        };
    }
    else if (button == "ok") {
        but = {
            confirm: {
                label: "OK",
                className: 'btn-success'
            }
        };
    }


    bootbox.confirm({
        message: message,
        buttons: but,
        callback: call
    });
}

function tcControl(tcno) {
    var tckontrol, toplam; tckontrol = tcno; tcno = tcno.value; toplam = Number(tcno.substring(0, 1)) + Number(tcno.substring(1, 2)) +
        Number(tcno.substring(2, 3)) + Number(tcno.substring(3, 4)) +
        Number(tcno.substring(4, 5)) + Number(tcno.substring(5, 6)) +
        Number(tcno.substring(6, 7)) + Number(tcno.substring(7, 8)) +
        Number(tcno.substring(8, 9)) + Number(tcno.substring(9, 10));
    strtoplam = String(toplam); onunbirlerbas = strtoplam.substring(strtoplam.length, strtoplam.length - 1);

    if (onunbirlerbas == tcno.substring(10, 11)) {
        //alert("doğru");
    } else {
        bootbox.alert("Tc Number Valid Error");
    }
}


function addParam(search, key, val) {
    var newParam = key + '=' + encodeURIComponent(val),
        params = '?' + newParam;

    // If the "search" string exists, then build params from it
    if (search) {
        // Try to replace an existance instance
        params = search.replace(new RegExp('([?&])' + key + '[^&]*'), '$1' + newParam);

        // If nothing was replaced, then add the new param to the end
        if (params === search) {
            params += '&' + newParam;
        }
    }

    return params;
}




function setResultModel(resultModel, StrMessage) {
    var msg = "";
    switch (resultModel.ResultType) {
        case RType.OK:
            {
                if (StrMessage) {

                    bootbox.alert(StrMessage);
                }
                $("#ajax button.closes").click();


            }
            break;
        case RType.Error:
            $.each(resultModel.MessageList, function (i, item) {
                msg += item + "</br>";
            });
            bootbox.alert(msg);
            break;
        case RType.Warning:
            $.each(resultModel.MessageList, function (i, item) {
                msg += item + "</br>";
            });
            bootbox.alert(msg);
            break;
    }

}




(function ($) {
    $.fn.ceo = function (ayarlar) {
        var ayar = $.extend({
            'source': "#" + $(this)[0].name,
            'target': "",
        }, ayarlar);

        $(ayar.source).on("keyup", function () {
            str = $(this).val();
            str = replaceSpecialChars(str);
            str = str.toLowerCase();
            str = str.replace(/\s\s+/g, ' ').replace(/[^a-z0-9\s]/gi, '').replace(/[^\w]/ig, "-");
            function replaceSpecialChars(str) {
                var specialChars = [["ş", "s"], ["ğ", "g"], ["ü", "u"], ["ı", "i"], ["_", "-"],
                ["ö", "o"], ["Ş", "S"], ["Ğ", "G"], ["Ç", "C"], ["ç", "c"],
                ["Ü", "U"], ["İ", "I"], ["Ö", "O"], ["ş", "s"]];
                for (var i = 0; i < specialChars.length; i++) {
                    str = str.replace(eval("/" + specialChars[i][0] + "/ig"), specialChars[i][1]);
                }
                return str;
            }
            $(ayar.target).val(str);
        });
    };

})(jQuery);

(function ($) {
    $.fn.dup = function (ayarlar) {
        var ayar = $.extend({
            'source': "#" + $(this)[0].name,
            'target': "",
        }, ayarlar);

        $(ayar.source).on("keyup", function () {
            str = $(this).val();
            $(ayar.target).val(str);
        });
    };

})(jQuery);



//function setResultModel(resultModel, StrMessage) {
//    var msg = "";
//    switch (resultModel.ResultType) {
//        case RType.OK:
//            {
//                if (StrMessage) {

//                    bootbox.alert(StrMessage);
//                }
//                $("#ajax button.closes").click();


//            }
//            break;
//        case RType.Error:
//            $.each(resultModel.MessageList, function (i, item) {
//                msg += item + "</br>";
//            });
//            bootbox.alert(msg);
//            break;
//        case RType.Warning:
//            $.each(resultModel.MessageList, function (i, item) {
//                msg += item + "</br>";
//            });
//            bootbox.alert(msg);
//            break;
//    }

//}


//String.prototype.turkishToUpper = function () {
//    var string = this;
//    var letters = { "i": "İ", "ş": "Ş", "ğ": "Ğ", "ü": "Ü", "ö": "Ö", "ç": "Ç", "ı": "I" };
//    string = string.replace(/(([iışğüçö]))/g, function (letter) { return letters[letter]; })
//    return string.toUpperCase();
//}

//String.prototype.turkishToLower = function () {
//    var string = this;
//    var letters = { "İ": "i", "I": "ı", "Ş": "ş", "Ğ": "ğ", "Ü": "ü", "Ö": "ö", "Ç": "ç" };
//    string = string.replace(/(([İIŞĞÜÇÖ]))/g, function (letter) { return letters[letter]; })
//    return string.toLowerCase();
//}
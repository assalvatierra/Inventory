﻿/* ********************************************************
* By Abel S. Salvatierra
* @ SCM Inventory Sytem
* 
*********************************************************** */

$(document).ready(function () {

    InitDatePicker();

})


function InitDatePicker() {
    var ddd1 = $('input[name="dtPo"]').val();

    $('input[name="dtPo"]').daterangepicker(
    {
        timePicker: false,
        timePickerIncrement: 30,
        singleDatePicker: true,
        showDropdowns: true,
        locale: {
            format: 'MM/DD/YYYY'
        }
    },
    function (start, end, label) {
        //alert(start.format('YYYY-MM-DD h:mm A'));

    }
    );


    $('input[name="dtPo"]').val(ddd1.substr(0, ddd1.indexOf(" ")));


}

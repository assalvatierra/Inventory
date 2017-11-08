/* ********************************************************
* By Abel S. Salvatierra
* @ SCM Inventory Sytem
*edited by jahdiel
************************************************************/

$(document).ready(function () {
    InitDatePicker();
    InitDatePicker2();
})


function InitDatePicker() {
    var ddd1 = $('input[name="dtOrder"]').val();

    $('input[name="dtOrder"]').daterangepicker(
    {
        timePicker: true,
        timePickerIncrement: 30,
        singleDatePicker: true,
        showDropdowns: true,
        locale: {
            format: 'MM/DD/YYYY hh:mm:ss A'
        }
    },
    function (start, end, label) {
        //alert(start.format('YYYY-MM-DD h:mm A'));

    }
    );

    $('input[name="dtOrder"]').val(ddd1.substr(0, ddd1.indexOf(" ")));

}


function InitDatePicker2() {
    var ddd1 = $('input[name="dtDelivery"]').val();

    $('input[name="dtDelivery"]').daterangepicker(
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

    $('input[name="dtDelivery"]').val(ddd1.substr(0, ddd1.indexOf(" ")));

}

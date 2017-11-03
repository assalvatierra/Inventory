/* ********************************************************
* By Abel S. Salvatierra
* @ SCM Inventory Sytem
*
************************************************************/

$(document).ready(function () {
    InitDatePicker();
    InitDatePicker2();
})


function InitDatePicker() {
    var ddd1 = $('input[name="PostedDate"]').val();

    $('input[name="PostedDate"]').daterangepicker(
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

    $('input[name="PostedDate"]').val(ddd1.substr(0, ddd1.indexOf(" ")));

}


function InitDatePicker2() {
    var ddd1 = $('input[name="ExpiryDate"]').val();

    $('input[name="ExpiryDate"]').daterangepicker(
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

    $('input[name="ExpiryDate"]').val(ddd1.substr(0, ddd1.indexOf(" ")));

}

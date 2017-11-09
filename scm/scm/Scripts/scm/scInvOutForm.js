/* ********************************************************
* By Abel S. Salvatierra
* @ SCM Inventory Sytem
* edited by jahdiel
*********************************************************** */

$(document).ready(function () {
    InitDatePicker();

})


function InitDatePicker() {
    var ddd1 = $('input[name="dtOut"]').val();

    $('input[name="dtOut"]').daterangepicker(
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


    $('input[name="dtOut"]').val(ddd1.substr(0, ddd1.indexOf(" ")));


}

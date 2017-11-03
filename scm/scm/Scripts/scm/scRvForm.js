/* ********************************************************
* By Abel S. Salvatierra
* @ SCM Inventory Sytem
*
************************************************************/

$(document).ready(function () {
    InitDatePicker();

})


function InitDatePicker() {
    var ddd1 = $('input[name="dtRcv"]').val();

    $('input[name="dtRcv"]').daterangepicker(
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


    $('input[name="dtRcv"]').val(ddd1.substr(0, ddd1.indexOf(" ")));


}

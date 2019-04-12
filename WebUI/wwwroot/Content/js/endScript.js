
var dataTable = null;

function dtTablePage(columns, id,startPage) {

    columns = (columns != null && columns.length > 0 ? toColumns(columns) : null);
    if (id) {
        id = id + " ";
    }
    if (columns != null && columns.length > 0) {
        dataTable = $(id + 'table').dataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            },
            dom: 'lBfrtip',
            "lengthMenu": [[startPage, 250, 500, 1000, -1], [startPage, 250, 500, 1000, "All"]],
            buttons: [
                { extend: 'excel', className: 'btn default' },
                { extend: 'pdf', className: 'btn default' },
                { extend: 'print', className: 'btn default' },
                { extend: 'copy', className: 'btn default' },
                { extend: 'colvis', className: 'btn default', text: 'Columns' },
                //{
                //    className: 'btn default',
                //    text: 'JSON',
                //    action: function (e, dt, button, config) {
                //        var data = dt.buttons.exportData();
                //        $.fn.dataTable.fileSave(
                //            new Blob([JSON.stringify(data)]),
                //            'Export_' + id.replace("#dt_", "") + '.json'
                //        );
                //    }
                //}
            ],
            columns: columns,
            //columnDefs: [
            //    { width: 120, targets: 0 }
            //],
            order: [],
            "scrollX": true,
        });
    }
    else {
        dataTable = $(id + 'table').dataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            },
            dom: 'lBfrtip',
            "lengthMenu": [[startPage, 250, 500, 1000, -1], [startPage, 250, 500, 1000, "All"]],

            buttons: [
                { extend: 'excel', className: 'btn default' },
                { extend: 'pdf', className: 'btn default' },
                { extend: 'print', className: 'btn default' },
                { extend: 'copy', className: 'btn default' },
                { extend: 'colvis', className: 'btn default', text: 'Columns' },
                //{
                //    className: 'btn default',
                //    text: 'JSON',
                //    action: function (e, dt, button, config) {
                //        var data = dt.buttons.exportData();
                //        $.fn.dataTable.fileSave(
                //            new Blob([JSON.stringify(data)]),
                //            'Export_' + id.replace("#dt_", "") + '.json'
                //        );
                //    }
                //}
            ],
            //columnDefs: [
            //    { width: 120, targets: 0 }
            //],
            order: [],
            "scrollX": true,
        });
    }
    //tdRight("");


    dtAyar();

}


function dtTable(columns, id) {

    columns = (columns != null && columns.length > 0 ? toColumns(columns) : null);
    if (id) {
        id = id + " ";
    }
    if (columns != null && columns.length > 0) {
        dataTable = $(id + 'table').dataTable({
             "language": {
             "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
             },
            dom: 'lBfrtip',
            "lengthMenu": [[50, 250, 500, 1000, -1], [50, 250, 500, 1000, "All"]],
            buttons: [
                { extend: 'excel', className: 'btn default' },
                { extend: 'pdf', className: 'btn default' },
                { extend: 'print', className: 'btn default' },
                { extend: 'copy', className: 'btn default' },
                { extend: 'colvis', className: 'btn default', text: 'Columns' },
                //{
                //    className: 'btn default',
                //    text: 'JSON',
                //    action: function (e, dt, button, config) {
                //        var data = dt.buttons.exportData();
                //        $.fn.dataTable.fileSave(
                //            new Blob([JSON.stringify(data)]),
                //            'Export_' + id.replace("#dt_", "") + '.json'
                //        );
                //    }
                //}
            ],
            columns: columns,
            //columnDefs: [
            //    { width: 120, targets: 0 }
            //],
            order: [],
            "scrollX": true,
        });
    }
    else {
        dataTable = $(id + 'table').dataTable({
             "language": {
             "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
             },
            dom: 'lBfrtip',
            "lengthMenu": [[50, 250, 500, 1000, -1], [50, 250, 500, 1000, "All"]],

            buttons: [
                { extend: 'excel', className: 'btn default' },
                { extend: 'pdf', className: 'btn default' },
                { extend: 'print', className: 'btn default' },
                { extend: 'copy', className: 'btn default' },
                { extend: 'colvis', className: 'btn default', text: 'Columns' },
                //{
                //    className: 'btn default',
                //    text: 'JSON',
                //    action: function (e, dt, button, config) {
                //        var data = dt.buttons.exportData();
                //        $.fn.dataTable.fileSave(
                //            new Blob([JSON.stringify(data)]),
                //            'Export_' + id.replace("#dt_", "") + '.json'
                //        );
                //    }
                //}
            ],
            //columnDefs: [
            //    { width: 120, targets: 0 }
            //],
            order: [],
            "scrollX": true,
        });
    }
      //tdRight("");


    dtAyar();
   
}

function dtTableClass() {
    dataTable = $('.table').dataTable({
         "language": {
         "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
         },
        dom: 'lBfrtip',
        "lengthMenu": [[50, 250, 500, 1000, -1], [50, 250, 500, 1000, "All"]],
        buttons: [
            { extend: 'excel', className: 'btn default' },
            { extend: 'pdf', className: 'btn default' },
            { extend: 'print', className: 'btn default' },
            { extend: 'copy', className: 'btn default' },
            { extend: 'colvis', className: 'btn default', text: 'Columns' },
            //{
            //    className: 'btn default',
            //    text: 'JSON',
            //    action: function (e, dt, button, config) {
            //        var data = dt.buttons.exportData();
            //        $.fn.dataTable.fileSave(
            //            new Blob([JSON.stringify(data)]),
            //            'Export_' + id.replace("#dt_", "") + '.json'
            //        );
            //    }
            //}
        ],
        //columnDefs: [
        //    { width: 120, targets: 0 }
        //],
        order: [],
        "scrollX": true,
    });

    dtAyar();

}


function tdRight(id) {
    var tdRight = $(id + " table td," + id + " table th");
    $.each(tdRight, function (i, item) {
        if ($.isNumeric($(this).text()) == true || $(this).text().indexOf("%") != -1) {
            $(this).addClass("tdRight");
        }
    });
}

$('.closed').click(function () {
    $('.close').click();

});


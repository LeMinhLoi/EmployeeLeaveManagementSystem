// Shorthand for $( document ).ready()
$(function () {
    $('#dataTableLeaveType').DataTable({
        "processing": true, //show processing announcement
        "serverSide": true,
        "filter": true,//Displays the Search Box
        "ajax": {
            "url": "leavetype/get-paging",
            "type": "POST",
            "datatype": "json",
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false,
            },
        ],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "name", "name": "Name", "autoWidth": true },
            { "data": "defaultDays", "name": "Default Days", "autoWidth": true },
            {
                "render": function (data, type, row) { return "<button type='button' data-id='" + row.id + "' class='btn btn-danger deleteBtn'><i class='far fa-trash-alt'></i> Delete</button>"; }
            },
            {
                "render": function (data, type, row) { return "<button class='btn btn-warning editBtn' data-id='"+ row.id +"'><i class='fas fa-pencil-alt'></i> Edit</button>"; }
            },
            {
                "render": function (data, type, row) { return "<button class='btn btn-secondary detailBtn' data-id='" + row.id + "'><i class='fas fa-info-circle'></i> Detail</button>"; }
            },
            {
                "render": function (data, type, row) { return "<button type='button' class='btn btn-success'><i class='fas fa-band-aid'></i> Allocate</button>"; }
            },
        ]
    });

    $(document).on("click", ".deleteBtn", function () {
        swal({
            title: "Are you sure?",
            text: "Are you sure you want to delete this record?",
            icon: "warning",
            buttons: true,
            dangerMode: true
        }).then((confirm) => {
            if (confirm) {
                var btn = $(this);
                var id = btn.data("id");
                $('#leaveTypeIdToDelete').val(id);
                $('#deleteFrom').submit();
                console.log(id)
            }
        });
    });

    $(document).on("click", ".editBtn", function () {
        var btn = $(this);
        var id = btn.data("id");
        $('#leaveTypeIdToEdit').val(id);
        $('#toPageEdit').submit();
        console.log(id)
    });

    $(document).on("click", ".detailBtn", function (e) {
        e.preventDefault();
        var that = $(this).data('id');
        $.ajax({
            type: "GET",
            url: "/leavetype/get-detail",
            data: { id: that },
            dataType: "json",
            success: function (response) {
                var result = response;
                $('#txtName').val(result.name);
                $('#txtDefaultDays').val(result.defaultDays);
                $('#txtDateCreated').val(result.dateCreated);
                $('#txtDateModified').val(result.dateModified);
                $('#titleModal').val(result.name);
                $('#bttGoToPageEdit').data('id', result.id);
                $('#modalDetailLeaveType').modal('show');

            },
            error: function () {
                console.log("error")
            }
        });
    });

    $(document).on("click", "#bttGoToPageEdit", function () {
        var btn = $(this);
        var id = btn.data("id");
        $('#leaveTypeIdToEdit').val(id);
        $('#toPageEdit').submit();
        console.log(id)
    });
});
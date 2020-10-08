var dataTable

$(document).ready(function () {
    loadDataTable()
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Movie/GetAll"
        },
        "columns": [
            { "data": "title", "width": "13%" },
            { "data": "isbn", "width": "13%" },
            { "data": "price", "width": "13%" },
            { "data": "director", "width": "13%" },
            { "data": "category.name", "width": "13%" },

            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="text-center">
    <a href="/Admin/Movie/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
        <i class="fas fa-edit"></i>
    </a>
    <a onclick=Delete("/Admin/Movie/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
        <i class="fas fa-trash-alt"></i>
    </a>
</div> `
                },"width":"40%"
            }
        ]

    })
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You cannot restore data once deleted!!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((WillDelete) => {
        if (WillDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message)
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}
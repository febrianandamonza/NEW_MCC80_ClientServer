// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function deleteEmployee(Guid) {
    Swal.fire({
        title: 'R u Sure?',
        text: 'Changes cant be reverted!',
        icon: 'Warn!',
        showCancelButton: true,
        confirmationButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Delete Data'
    }).then((result) => {
        $.ajax({
            url: "https://localhost:7040/api/employees/?guid=" + Guid,
            type: "DELETE",
        }).done((result) => {
            Swal.fire(
                'Deleted',
                'Your Data Has Been Succesfully Deleted',
                'Success'
            ).then(() => {
                location.reload();
            }).fail((error) => {
                alert("Failed to delete data. Please Try Again!")
            });

        });

    });
}
function Insert() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
//ini ngambil value dari tiap inputan di form nya
    obj.firstName = $("#firstName").val();
    obj.lastName = $("#lastName").val();
    obj.birthDate = $("#birthDate").val();
    obj.gender = parseInt($("#gender").val());
    obj.hiringDate = $("#hiringDate").val();
    obj.email = $("#email").val();
    obj.phoneNumber = $("#phoneNumber").val();
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        /*url : "https://localhost:7040/api/employees",
        type: "POST",
        headers: {
            'Content-Type':'application/json'
        },
        data: obj*/
        url: "https://localhost:7040/api/employees",
        type: "POST",
        headers: {
            'Content-Type':'application/json'
        },
        data: JSON.stringify(obj)
        }).done((result) => {
        Swal.fire
        (
            'Data Has Been Successfuly Inserted',
            'Success'
        ).then(() => {
            location.reload();
        })
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops',
            text: 'Failed to insert data, Please Try Again',
        })
    })
}


$(document).ready(function () {
    var table = $('#employeeTable').DataTable({
        dom: 'Blftip',
        buttons: [
            {
                extend: 'colvis',
                collectionLayout: 'fixed three-column',
                postfixButtons: [ 'colvisRestore' ],
                className : "btn btn-primary"
            },
            {
                extend: 'copy',
                className : "btn btn-primary"
            },
            {
                extend: 'csv',
                className : "btn btn-primary"
            },
            {
                extend: 'excel',
                className : "btn btn-primary"
            },
            {
                extend: 'pdf',
                className : "btn btn-primary"
            },
            {
                extend: 'print',
                className : "btn btn-primary"
            }
            
        ]
    });

    $('#example thead .employee-search-input').on('click', function(e){
        e.stopPropagation();
    });    
});






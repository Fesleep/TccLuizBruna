var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        pagingType: 'full',
        language: {
            search: 'Pesquisar',
            lengthMenu: "Mostrar _MENU_ resultados.",
            info: "Mostrando de _START_ até _END_ de _TOTAL_ resultados.",
            infoEmpty: "Mostrando de 0 até 0 de 0 resultados.",
            infoFiltered: "(filtrado do total de _MAX_ items)",
            zeroRecords: "Sem resultados correspondentes encontrados.",
            paginate: {
                first: '«',
                previous: '‹',
                next: '›',
                last: '»'
            },
            aria: {
                paginate: {
                    first: 'Primeiro',
                    previous: 'Anterior',
                    next: 'Próximo',
                    last: 'Último'
                }
            }
        },
        "columns": [
            { "data": "nome", "width": "25%" },
            { "data": "email", "width": "15%" },
            { "data": "role", "width": "15%" },
            {
                "data": { id: "id", lockoutEnd: "lockoutEnd" }, "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        //locked
                        return `
                            <div class="text-end">
                                <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-lock-open"></i> Ativar
                                </a>
                            </div>
                            `
                    }
                    else {
                        return `
                            <div class"text-center">
                                <a onclick=LockUnlock('${data.id}') class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-lock"></i> Desativar
                                </a>
                            </div>
                            `
                    }
                }, "width": "25%"
            }
        ]
    })
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    })
}
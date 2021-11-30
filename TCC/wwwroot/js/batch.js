var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Employee/Batch/GetAll"
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
            { "data": "id", "width": "5%" },
            { "data": "nome", "width": "5%" },
            {
                "data": "hectares", "render": function (data) {
                    return (Math.round(data * 100) / 100).toFixed(2)
                }, "width": "10%"
            },
            {
                "data": "metrosQuadrados", "render": function (data) {
                    return (Math.round(data * 100) / 100).toFixed(2)
                }, "width": "10%"
            },
            {
                "data": "dataCriacao", "render": function (data) {
                    if (data != null)
                        return new Date(data).toLocaleDateString();
                    else return "";
                }, "width": "10%"
            },
            {
                "data": "dataAtualizacao", "render": function (data) {
                    if (data != null)
                        return new Date(data).toLocaleDateString();
                    else return "";
                }, "width": "10%"
            },
            {
                "data": "id", "render": function (data) {
                    return `
                            <div class="text-end">
                                <a href="/Employee/Batch/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class='bx bx-edit' ></i>
                                </a>
                                <a onclick=Delete("/Employee/Batch/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class='bx bxs-trash' ></i>
                                </a>
                                <a onclick=Report("/Employee/Batch/BatchReport/${data}") class="btn btn-primary text-white" title="Relatório" style="cursor:pointer">
                                    <i class='bx bxs-report'></i>
                                </a>
                            </div>
                            `
                }, "width": "5%"
            }
        ]
    })
}

function Delete(url) {
    swal({
        title: "Você tem certeza que deseja deletar?",
        text: "Você não conseguirá restaurar os dados!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
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
    });
}

function Report(url) {
    swal({
        title: "Gerar relatório deste lote?",
        text: "Será gerado um csv com os dados dessa plantação!",
        icon: "info",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "GET",
                url: url,
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
    });
}
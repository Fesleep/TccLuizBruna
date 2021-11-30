var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Employee/Culture/GetAll"
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
            { "data": "nome", "width": "15%" },
            {
                "data": "espacamentoEntreLinhas", "render": function (data) {
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
                                <a href="/Employee/Culture/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class='bx bx-edit' ></i>
                                </a>
                                <a onclick=Delete("/Employee/Culture/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class='bx bxs-trash' ></i>
                                </a>
                            </div>
                            `
                }, "width": "3%"
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
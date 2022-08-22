// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let ids = [];

$("#botaoEnviar").click(function () {
    if ($("input:checked").length != 16) {
        alert("É necessário selecionar 16 lutadores para começar a luta");
        return;
    }

    $("input:checked").each(function () {
        ids.push($(this).attr("id"));
    });

    var request = { lutadores: ids };

    $.ajax('/Lutador/Luta', {
        method: 'post',
        contentType: 'application/json',
        dataType: 'json',
        data: JSON.stringify(request),
        traditional: true,
        success: function (response) {
            if (response.success) {
                alert(response.responseText);
                location.reload();
            } else {
                alert(response.responseText);
            }
        },
        error: function (response) {
            alert("error!");
        }
    });
});
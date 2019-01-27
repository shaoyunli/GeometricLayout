const uri = 'api/layout/';
let todos = null;

function drawTriangle(convas, x1, y1, x2, y2, x3, y3, row, column) {
    var canvas = document.getElementById(convas);
    if (canvas.getContext) {
        var context = canvas.getContext('2d');
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.beginPath();
        context.moveTo(x1, y1);
        context.lineTo(x2, y2);
        context.lineTo(x3, y3);
        context.fillStyle = "green";
        context.fill();

        context.beginPath();
        context.fillStyle = "black";
        var y = 7 + y2;
        if (column % 2 == 0) {
            y = 7 + y1;
        }
        context.fillText(row + column.toString(), x1 + 2, y);
        context.fill();
    }
}

function getTriangleByRowColumn() {
    const item = {
        row: $('#row').val(),
        column: $('#column').val()
    };

    $.ajax({
        type: 'GET',
        accepts: 'application/json',
        url: uri + 'row/' + item.row + '/column/' + item.column,
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        },
        success: function (result) {
            drawTriangle('canvas1', result.x1, result.y1, result.x2, result.y2, result.x3, result.y3, item.row, item.column);
            $('#row').val('');
            $('#column').val('');
        }
    });
}

function getTriangleByCoordinates() {
    const item = {
        x1: $('#x1').val(),
        x1: $('#y1').val(),
        x1: $('#x2').val(),
        x1: $('#y2').val(),
        x1: $('#x3').val(),
        x1: $('#y3').val()
    };

    $.ajax({
        type: 'GET',
        accepts: 'text/plain',
        url: uri + 'x1/${x1}/y1/${y1}/x2/${x2}/y2/${y2}/x3/${x3}/y3/${y3}',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        },
        success: function (result) {
            drawTriangle('canvas2', result.x1, result.y1, result.x2, result.y2, result.x3, result.y3, item.row, item.column);

            $('#x1').val('');
            $('#y1').val('');
            $('#x2').val('');
            $('#y2').val('');
            $('#x3').val('');
            $('#y3').val('');
        }
    });
}

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}

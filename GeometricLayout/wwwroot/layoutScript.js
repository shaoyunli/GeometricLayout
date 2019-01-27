const uri = 'api/layout/';
let todos = null;

function drawTriangle(x1, y1, x2, y2, x3, y3, row, column) {
    var dpr = window.devicePixelRatio * 10;
    var canvas = document.getElementById('displayArea');
    canvas.width = canvas.width * dpr;
    canvas.height = canvas.height * dpr;
    var textX = Math.min(x1, x2, x3) + 10;
    var textY = Math.min(y1, y2, y3) + 5;
    var context = canvas.getContext('2d');
    context.scale(dpr, dpr);
    context.clearRect(0, 0, canvas.width, canvas.height);
    context.beginPath();
    context.moveTo(x1, y1);
    context.lineTo(x2, y2);
    context.lineTo(x3, y3);
    context.fillStyle = "green";
    context.fill();

    context.beginPath();
    context.fillStyle = "black";
    context.font = "2px Arial";
    context.fillText(row + column, textX, textY);
    context.fill();
}

function getTriangleByRowColumn() {
    const item = {
        row: $('#row').val(),
        column: $('#column').val()
    };

    $.ajax({
        type: 'GET',
        accepts: 'application/json',
        url: uri + `row/${item.row}/column/${item.column}`,
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        },
        success: function (result) {
            drawTriangle(result.x1, result.y1, result.x2, result.y2, result.x3, result.y3, item.row, item.column);
            $('#row').val('');
            $('#column').val('');
        }
    });
}

function getTriangleByCoordinates() {
    const item = {
        x1: $('#x1').val(),
        y1: $('#y1').val(),
        x2: $('#x2').val(),
        y2: $('#y2').val(),
        x3: $('#x3').val(),
        y3: $('#y3').val()
    };
    var url = uri + `x1/${item.x1}/y1/${item.y1}/x2/${item.x2}/y2/${item.y2}/x3/${item.x3}/y3/${item.y3}`;
    $.ajax({
        type: 'GET',
        accepts: 'application/json',
        url: url,
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert(jqXHR.responseText);
        },
        success: function (result) {
            drawTriangle(item.x1, item.y1, item.x2, item.y2, item.x3, item.y3, result.row, result.column);

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

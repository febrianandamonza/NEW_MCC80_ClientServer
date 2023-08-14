// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$.ajax({
    url: "https://localhost:7040/api/employees/count-gender"
}).done((result) => {
    var xValues = ["Male", "Female"];
    var yValues = [result.data.resultPria, result.data.resultWanita];
    new Chart($('#myChart') , {
        type: 'pie',
        data: {
            labels: xValues,
            datasets: [{
                label: 'Jumlah',
                data: yValues,
                backgroundColor: getRandomColor(xValues),
                hoverOffset: 4
            }]
        }
    });
    console.log(xValues.length)   
});
$.ajax({
    url: "https://localhost:7040/api/employees/CountDetailUniversitas"
}).done((result) => {
    var xValues = result.data.map(function (obj) {
        return obj.name;
    });
    var yValues = result.data.map(function (obj) {
        return obj.result;
    });
    new Chart($('#myChart2') , {
        type: 'bar',
        data: {
            labels: xValues,
            datasets: [{
                label: 'Jumlah',
                data: yValues,
                backgroundColor: getRandomColor(result.data),
                hoverOffset: 4
            }]
        }

    });
    console.log(result.data);
});
function getRandomColor(count) { //generates random colours and puts them in string
    var colors = [];
    for (var i = 0; i < count.length; i++) {
        var letters = '0123456789ABCDEF'.split('');
        var color = '#';
        for (var x = 0; x < 6; x++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        colors.push(color);
    }
    return colors;
}

/*$.ajax({
    url: "https://localhost:7040/api/employees/count-gender"
}).done((result) => {
    let temp = "";
    $.each(result.results, (key, val) => {
        temp += `
                <tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td><button onclick="detailSW('${val.url}')" data-bs-toggle="modal" data-bs-target="#modalSW" class="btn btn-primary">Detail</button></td>
                </tr>
            `;
    })
    $("#tbodySW").html(temp);
});*/





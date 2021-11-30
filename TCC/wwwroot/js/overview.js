

$(document).ready(function () {
    let nomes = [];
    let ids = [];
    let dataCultures = [];
    let cultures = [];
    var polygoneCoords = [];

    for (const c in currentBatchs) {
        nomes.indexOf(currentBatchs[c].semente.cultura.nome) === -1 ? nomes.push(currentBatchs[c].semente.cultura.nome) : -1;
        ids.indexOf(currentBatchs[c].semente.cultura.id) === -1 ? ids.push(currentBatchs[c].semente.cultura.id) : -1;
        cultures.push(currentBatchs[c].semente.cultura);
    }

    var existingCultures = cultures.reduce(function (existingCultures, culture) {
        (existingCultures[culture.id] = existingCultures[culture.id] || []).push(culture);
        return existingCultures;
    }, {})

    for (const i in ids) {
        dataCultures.push(existingCultures[ids[i]].length);
    }

    destroyChart(document.getElementById('pie'), 'pie');
    var pieChart = document.getElementById('pie').getContext('2d');
    pieChart.canvas.width = 10;
    pieChart.canvas.height = 10;
    var myChart = new Chart(pieChart, {
        type: 'doughnutLabels',
        data: {
            datasets: [{
                data: dataCultures,
                backgroundColor: [
                    "#F7464A",
                    "#46BFBD",
                    "#FDB45C",
                    "#949FB1",
                    "#4D5360",
                ],
                label: 'Pie Chart',
            }],
            labels: nomes,
        },
        options: {
            responsive: true,
            legend: {
                position: 'bottom',
                labels: {
                    fontColor: '#ffffff',
                    fontSize: 20
                }
            },
            title: {
                display: true,
                text: 'Gráfico Tipo de Cultura',
                fontSize: 20,
                fontColor: "#ffffff"
            },
            animation: {
                animateScale: true,
                animateRotate: true
            }
        }
    });
});

function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        zoom: 17,
        streetViewControl: false,
        center: { lat: data.latitude, lng: data.longitude },
        mapTypeId: "satellite",
    });
    for (const c in currentBatchs) {
        polygoneCoords = [];
        var points = currentBatchs[c].lote.coordinates.split(';');
        points.pop();
        for (const p in points) {
            const l = points[p].split(',');
            polygoneCoords.push({ lat: Number(l[0]), lng: Number(l[1]) });
        }
        var myPolygon = new google.maps.Polygon({
            paths: polygoneCoords,
            strokeColor: '#FF0000',
            strokeOpacity: 0.8,
            strokeWeight: 2,
            fillColor: '#FF0000',
            fillOpacity: 0.35
        });
        myPolygon.setMap(map);
        var batchPlantations = getPlantations(currentBatchs[c]);
        addInfo(myPolygon, batchPlantations);
    }
}

function getPlantations(currentBatch) {
    for (var p in plantations) {
        if (plantations[p].lote.id == currentBatch.lote.id) {
            return plantations[p].plantacoes;
        }
    }
}

function addInfo(rectangle, batchPlantations) {
    rectangle.addListener("click", () => {
        document.getElementById('bottomItems').style.display = "block";
        $('html,body').animate({
            scrollTop: $(".infoCards").offset().top
        },
            'slow');
    });
    rectangle.addListener("click", () => {
        document.getElementById("graphsDiv").style.display = "none";
        var productionArray = [];
        if (batchPlantations.length > 2 ) {
            for (var p in batchPlantations) {
                var i = Number(batchPlantations.length - 1 - p);
                productionArray.push(batchPlantations[i].pesoTotalSementes);
            }
            mountLineChart(productionArray);
            mountBarChart(batchPlantations[2].custoTotalPlantacao, batchPlantations[1].custoTotalPlantacao, batchPlantations[0].custoTotalPlantacao);
        }
        mountCards(batchPlantations[0]);
    });
}
function mountCards(c) {
    document.getElementById("hectares").getElementsByTagName("p")[0].innerText = (Math.round(c.lote.hectares * 100) / 100).toFixed(2).replace('.', ',') + " hectares";
    document.getElementById("metragemLinear").getElementsByTagName("p")[0].innerText = (Math.round(c.metragemLinear * 100) / 100).toFixed(2).replace('.', ',') + " metros";
    document.getElementById("custoPlantacao").getElementsByTagName("p")[0].innerText = toLocaleCurrencyString(c.custoTotalPlantacao);
}

function mountLineChart(ar) {
    document.getElementById("graphsDiv").style.display = "block";
    destroyChart(document.getElementById('line'), 'line');
    var lineChart = document.getElementById('line').getContext('2d');
    var myChart = new Chart(lineChart, {
        type: 'line',
        data: {
            labels: ['Ano Safra 1', 'Ano Safra 2', 'Ano Safra 3'],
            datasets: [{
                label: 'Line Chart',
                data: ar,
                fill: false,
                backgroundColor: 'black',
                borderColor: 'gray',
            }]
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,
                        callback: function (value, index, values) {
                            if (parseInt(value) >= 1000) {
                                return value.toString() + ' Kg';
                            } else {
                                return value + ' Kg';
                            }
                        }
                    }
                }]
            },
            legend: {
                display: false,
            },
            tooltips: {
                callbacks: {
                    label: function (tooltipItem) {
                        return tooltipItem.yLabel;
                    }
                }
            },
            title: {
                display: true,
                text: 'Gráfico De Produção (Peso total de Sementes)'
            },
        }
    });
}

function mountBarChart(val1, val2, val3) {
    destroyChart(document.getElementById('bar'), 'bar');
    var barChart = document.getElementById('bar').getContext('2d');
    var myChart = new Chart(barChart, {
        type: 'bar',
        data: {
            datasets: [{
                data: [val1],
                backgroundColor: [
                    "#F7464A"
                ],
                label: 'Ano Safra 1'
            },
            {
                data: [val2],
                backgroundColor: [
                    "#46BFBD"
                ],
                label: 'Ano Safra 2'
            },
            {
                data: [val3],
                backgroundColor: [
                    "#FDB45C"
                ],
                label: 'Ano Safra 3'
            }],
            labels: []
        },
        options: {
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true,
                        callback: function (value, index, values) {
                            if (parseInt(value) >= 1000) {
                                return 'R$' + value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
                            } else {
                                return 'R$' + value;
                            }
                        }
                    }
                }]
            },
            responsive: true,
            legend: {
                position: 'bottom',
            },
            title: {
                display: true,
                text: 'Gráfico de Custos (Custo total do planejamento da plantação)'
            },
            tooltips: {
                callbacks: {
                    label: function (item) {
                        return toLocaleCurrencyString(item.yLabel);
                    }
                }
            },
        }
    });
}

function destroyChart(ctx, id) {
    var parent = ctx.parentElement;
    ctx.remove();
    var canvas = document.createElement('canvas');
    canvas.classList.add("my-4,h-25");
    canvas.id = id;
    parent.appendChild(canvas);
}


$("button").click(function () {
    $('html,body').animate({
        scrollTop: $(".second").offset().top
    },
        'slow');
});

function toLocaleCurrencyString(value) {
    return 'R$' + ((Math.round(value * 100) / 100).toFixed(2).toLocaleString('pt-br', { style: 'currency', currency: 'BRL' })).replace('.', ',');
}
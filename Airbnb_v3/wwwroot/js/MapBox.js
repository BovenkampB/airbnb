createAvgPricePerNeighbourhoodChart();
createAvgRatingPerNeighbourhoodChart();


mapboxgl.accessToken = 'pk.eyJ1IjoiYm92ZW5rYW1wYiIsImEiOiJjamc2OWkyN24xcmxnMzNtbzY1ZmlpMXk5In0.wZO5EUCXogq6QJS7p_xUUg';
var map = new mapboxgl.Map({
    container: 'map',
    style: 'mapbox://styles/bovenkampb/cjh911gie1leh2rlo81r9bs4x',
    center: [4.9, 52.36], // starting position [lng, lat]
    zoom: 11 // starting zoom
});

map.addControl(new mapboxgl.NavigationControl());



fetch('/Listings/GetListings')
    .then((resp) => resp.json())
    .then(function (data) {
        var geojson = { features: [] }
        for (var i = 0; i < data.length; i++) {
            var longtitudestring = String(data[i].longitude);
            longtitudestring = longtitudestring.replace(".", "");
            var longtitudefloat = parseFloat([longtitudestring.slice(0, 1) + "." + longtitudestring.slice(1)].join(''));

            var latitudestring = String(data[i].latitude);
            latitudestring = latitudestring.replace(".", "");
            var latitudefloat = parseFloat([latitudestring.slice(0, 2) + "." + latitudestring.slice(2)].join(''));

            var currentGeo = {
                type: 'Feature',
                geometry: {
                    type: 'Point',

                    coordinates: [longtitudefloat, latitudefloat]
                },
                properties: {
                    name: data[i].name,
                    id: data[i].id,
                    thumbnailurl: data[i].thumbnailurl,
                    price: data[i].price,
                    description: data[i].description,
                    neighbourhood: data[i].neighbourhood,
                    reviewscoresrating: data[i].reviewscoresrating,
                    availability: data[i].availability365
                }
            }

            geojson.features.push(currentGeo);
        }

        loadGeoJSON(geojson);
    });

function loadGeoJSON(geojson) {
    map.addSource("geolistings", {
        type: "geojson",
        data: geojson,
        cluster: true,
        clusterMaxZoom: 14,
        clusterRadius: 50
    });

    map.addLayer({
        id: "clusters",
        type: "circle",
        source: "geolistings",
        filter: ["has", "point_count"],
        paint: {
            "circle-color": [
                "step",
                ["get", "point_count"],
                "#ffb1a0",
                100,
                "#ff8970",
                750,
                "#ff5c3a"
            ],
            "circle-radius": [
                "step",
                ["get", "point_count"],
                20,
                100,
                30,
                750,
                40
            ]
        }
    });

    map.addLayer({
        id: "cluster-count",
        type: "symbol",
        source: "geolistings",
        filter: ["has", "point_count"],
        layout: {
            "text-field": "{point_count_abbreviated}",
            "text-font": ["DIN Offc Pro Medium", "Arial Unicode MS Bold"],
            "text-size": 12
        }
    });

    map.addLayer({
        id: "unclustered-point",
        type: "circle",
        source: "geolistings",
        filter: ["!has", "point_count"],
        paint: {
            "circle-color": "#ff0000",
            "circle-radius": 5,
            "circle-stroke-width": 1,
            "circle-stroke-color": "#fff"
        }
    });

    // When a click event occurs on a feature in the places layer, open a popup at the
    // location of the feature, with description HTML from its properties.
    map.on('click', 'unclustered-point', function (e) {
        var coordinates = e.features[0].geometry.coordinates.slice();
        var description = e.features[0].properties.description;

        // Ensure that if the map is zoomed out such that multiple
        // copies of the feature are visible, the popup appears
        // over the copy being pointed to.
        while (Math.abs(e.lngLat.lng - coordinates[0]) > 180) {
            coordinates[0] += e.lngLat.lng > coordinates[0] ? 360 : -360;
        }

        new mapboxgl.Popup()
            .setLngLat(coordinates)
            .setHTML('<h3>' + e.features[0].properties.name + '</h3> <br/> <img src=\"' + e.features[0].properties.thumbnailurl + '\" alt="Thumbnail" height="144" width="216" /> <p>' + e.features[0].properties.price + '</p><p> <a href="http://localhost:9001/Listings/Details/ ' + e.features[0].properties.id + '">Toon meer details</a></p>')
            .addTo(map);


        createLocationSpecificCharts(e.features[0].properties.id);

        var availabilityChart = document.getElementById('availabilityPerYear').getContext('2d');

        var dataAvailability = {
            datasets: [{
                data: [e.features[0].properties.availability, 365 - e.features[0].properties.availability],
                backgroundColor: ['rgb(0, 255, 0)', 'rgb(255, 0, 0)'],
            }],

            // These labels appear in the legend and in the tooltips when hovering different arcs
            labels: [
                'Available',
                'Not available'
            ]
        };

        var availableChart = new Chart(availabilityChart, {
            type: 'pie',
            data: dataAvailability,
            options: {
                title: {
                    display: true,
                    text: 'Availability per year'
                }
            }
        });
    });
}

function createLocationSpecificCharts(e) {
    fetch("/SummaryReviews/getReviewsPerYear?id=" + e)
        .then((resp) => resp.json())
        .then(function (data) {

            var yearObject = [];
            var reviewsObject = [];

            for (i = 0; i < data.length; i++) {
                yearObject.push(data[i].year);
                reviewsObject.push(data[i].numberOfReviews);
            }

            var reviewPerYear = document.getElementById('reviewPerYear').getContext('2d');

            var dataReviews = {
                datasets: [{
                    label: 'Reviews per year',
                    data: reviewsObject
                }],

                // These labels appear in the legend and in the tooltips when hovering different arcs
                labels: yearObject
            };



            var reviewsPerYear = new Chart(reviewPerYear, {
                type: 'bar',
                data: dataReviews,
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    },
                    title: {
                        display: true,
                        text: 'Reviews per year'
                    }
                }
            });
        });
}

function createAvgPricePerNeighbourhoodChart() {
    fetch("/Listings/getAveragePricePerNeighbourhood")
            .then((resp) => resp.json())
            .then(function (data) {

                var neighbourhoodObject = [];
                var priceObject = [];

                for (i = 0; i < data.length; i++) {
                    neighbourhoodObject.push(data[i].neighbourhood);
                    priceObject.push(data[i].price);
                }

                var pricePerNeighbourhood = document.getElementById('averagePricePerNeighbourhood').getContext('2d');

                var dataPrices = {
                    datasets: [{
                        label: 'Average price per neighbourhood',
                        data: priceObject
                    }],

                    // These labels appear in the legend and in the tooltips when hovering different arcs
                    labels: neighbourhoodObject
                };

                var reviewsPerYear = new Chart(pricePerNeighbourhood, {
                    type: 'bar',
                    data: dataPrices,
                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: false
                                }
                            }]
                        },
                        title: {
                            display: true,
                            text: 'Reviews per year'
                        }
                    }
                });
            });
}


function createAvgRatingPerNeighbourhoodChart() {
    fetch("/Listings/getAverageRatingPerNeighbourhood")
        .then((resp) => resp.json())
        .then(function (data) {

            var neighbourhoodObject = [];
            var ratingObject = [];

            for (i = 0; i < data.length; i++) {
                neighbourhoodObject.push(data[i].neighbourhood);
                ratingObject.push(data[i].rating);
            }

            var ratingPerNeighbourhood = document.getElementById('averageRatingPerNeighbourhood').getContext('2d');

            var dataRatings = {
                datasets: [{
                    label: 'Average rating per neighbourhood',
                    data: ratingObject
                }],

                // These labels appear in the legend and in the tooltips when hovering different arcs
                labels: neighbourhoodObject
            };

            var reviewsPerYear = new Chart(ratingPerNeighbourhood, {
                type: 'bar',
                data: dataRatings,
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: false
                            }
                        }]
                    },
                    title: {
                        display: true,
                        text: 'Average rating per year'
                    }
                }
            });
        });
}



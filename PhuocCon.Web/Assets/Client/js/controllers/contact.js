var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        //This example displays a marker at the center of Australia.
        //When the user clicks the marker, an info window opens.
        contact.initMap();
    },
    initMap: function () {
        var location = { lat: parseFloat($('#hidLat').val()), lng: parseFloat($('#hidLng').val()) };
        var map = new google.maps.Map(document.getElementById('map'), {
            zoom: 4,
            center: location
        });
        var contentString = $('#hidContactDetail').val();
        var infowindow = new google.maps.InfoWindow({
            content: contentString
        });
        var marker = new google.maps.Marker({
            position: location,
            map: map,
            title: $('#hidname').val()
        });
        infowindow.open(map, marker);
    }
}
contact.init();
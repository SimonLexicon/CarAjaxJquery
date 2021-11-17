function getAllCars() {
    $.get("/Ajax/GetCars", null, function (data) {
        $("#CarList").html(data);
    });
}

function getCarByID() {
    var carIDValue = document.getElementById('CarIdInput').value;
    $.post("/Ajax/FindCarById", { carID: carIDValue }, function (data) {
        $("#CarList").html(data);
    });
}

function deleteCarByID() {
    var carIDValue = document.getElementById('CarIdInput').value;
    $.post("/Ajax/DeleteCarById", { carID: carIDValue }, function (data) {

    })
        .done(function () {
            document.getElementById('errorMessages').innerHTML = "Successfully Deleted car.";
            getAllCars();
        })
        .fail(function () {
            document.getElementById('errorMessages').innerHTML = "Could not delete car.";
        });

}
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

    $.ajax({
        type: "POST",
        url: '@Url.Action("createStudent")',
        data: '{std: ' + JSON.stringify(std) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            // alert("Data has been added successfully.");  
            LoadData();
        },
        error: function () {
            alert("Error while inserting data");
        }
    });

}
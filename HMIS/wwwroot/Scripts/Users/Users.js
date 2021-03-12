app.controller('AddUser', ["$scope", "$http", function ($scope, $http) {
  //  $scope.diseases = ['Diabetes', 'Hypertension', 'Diabetes & Hypertension'];
    $scope.AddEditPatient = {
        UserID : "",
        Username: "",
        Email: "",
        CNIC: "",
        ContactNumber: "",
        Password: "",
        ConfirmPassword: "",
        HealthFacilityCode: "",
        Active: false
    }
    $scope.SaveUser = function () {
        var data = JSON.stringify($scope.AddEditPatient);
        $http({
            url: "/api/User/Register",
            method: "POST",
            data: data,
            transformRequest: angular.identity,
            contentType: 'application/json',
        }).then(function (res) {
            if (res.data.messages != "") {
                alert(res.data.messages);
            }
            else {
                alert("Failure");
            }
        });
    };
}]);


app.controller('UserController', ["$scope", "$http", function ($scope, $http) {
  //  $scope.diseases = ['Diabetes', 'Hypertension', 'Diabetes & Hypertension'];

    $scope.DataObject = {
        Page: 1, PageSize: "1", TotalRecords: 0
    };
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
            url: "/api/Authenticate/Register",
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

    $scope.OpenUserRoleList = function (UserID) {
        window.open("/Users/RolesList?ID=" + UserID);
    };

    $scope.GetUserList = function () {
        $http({
            url: "/api/User/GetAllUsers",
            method: "POST",
            data: JSON.stringify($scope.DataObject),
            transformRequest: angular.identity,
            contentType: 'application/json',
        }).then(function (res) {
            $scope.UserList = res.data.data;
                console.log($scope.UserList)
        });
    };
    angular.element(document).ready(function () {
        $scope.GetUserList();
    });
}]);



angular.module("myApp").requires.push('ngSanitize');
angular.module("myApp").requires.push('ui.select');
angular.module("myApp").requires.push('ui.select');
app.controller('UserList', ["$scope", "$http", function ($scope, $http) {
    $scope.divisionList = [];
    $scope.districtList = [];
    $scope.tehsilList = [];
    $scope.facilityList = [];

    $scope.DataObject = {
        Page: 1, PageSize: 1, TotalRecords: 0
    };
    $scope.GetUserList = function () {
        try {
            var data = JSON.stringify($scope.DataObject);
            var table = $('#dataTable').DataTable({
                "proccessing": true,
                "serverSide": true,
                "ajax": {
                    url: "/api/User/GetAllUsers",
                    type: 'POST',
                    data: function (d) {
                        return JSON.stringify({
                            Draw: d.draw, Search: d.search.value,
                            Page: d.start, PageSize: d.length,
                            SortBy: d.order[0].dir, SortIndex: d.order[0].column, ShowRevoked: false
                        })
                    },
                    contentType: 'application/json'
                },
                "language": {
                    "search": "",
                    "searchPlaceholder": "Search..."
                },
                "columns": [
                    {
                        data: null,
                        render: function (data, type, row, meta) {
                            return meta.row + 1;
                        }
                    },
                    { "data": "userName" },
                    { "data": "email" },
                    { "data": "cnic" },
                    { "data": "phoneNumber" },
                    { "data": "createdOn" },
                    {
                        data: null,
                        render: function (data, type, row, meta) {
                            return '<a href="/Users/Roleslist?Id=' + data.id + '" target="_blank" class="btn-success btn-sm">Manage Roles</a>&nbsp<a href="/Users/AddUser?Id=' + data.id + '" target="_blank" class="btn-success btn-sm">Edit</a>';
                            return '';
                        }
                    }
                ]
            });
        }
        catch (ee) { }
    };

    angular.element(document).ready(function () {
        $scope.GetUserList();
    });
}]);


app.controller('AddUser', ["$scope", "commonService", "$http", function ($scope, commonService, $http) {
    $scope.divisionList = [];
    $scope.districtList = [];
    $scope.tehsilList = [];
    $scope.facilityList = [];

    $scope.DataObject = {
        Page: 1, PageSize: 1, TotalRecords: 0
    };
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
                toastr.success(res.data.messages);
               // alert(res.data.messages);
            }
            else {
                alert("Failure");
            }
        });
    };


    $scope.GetUserDetails = function () {
        $http({
            url: "/api/User/GetUserForupdate?userId=" + $scope.UserID,
            method: "GET",
            transformRequest: angular.identity,
            contentType: 'application/json',
        }).then(function (res) {
            if (res.data != null) {
                $scope.AddEditPatient = res.data;
                if ($scope.AddEditPatient.division.code != null && $scope.AddEditPatient.division.code)
                    $scope.LoadDropdowns("Districts")
                if ($scope.AddEditPatient.district.code != null && $scope.AddEditPatient.district.code)
                    $scope.LoadDropdowns("Tehsils")
                if ($scope.AddEditPatient.tehsil.code != null && $scope.AddEditPatient.tehsil.code)
                    $scope.LoadDropdowns("HealthFacilities")
            }
        });
    };


    $scope.LoadDropdowns = function (item) {
        if (item == "Divisions") {
            var Data = commonService.getDivisions().then(function (res) {
                $scope.divisionList = res.data;
            });
        }
        else if (item == "Districts") {
            var Data = commonService.getDistricts($scope.AddEditPatient.division.code).then(function (res) {
                $scope.districtList = res.data;
            });
        }
        else if (item == "Tehsils") {
            var Data = commonService.getTehsils($scope.AddEditPatient.district.code).then(function (res) {
                $scope.tehsilList = res.data;
            });
        }
        else if (item == "HealthFacilities") {
            var Data = commonService.getHealthFacilities($scope.AddEditPatient.tehsil.code).then(function (res) {
                $scope.facilityList = res.data;
            });
        }
    };
    angular.element(document).ready(function () {
        debugger
        $scope.LoadDropdowns("Divisions")
        var UserID = $("#UserID").val();
        $scope.UserID = UserID;
        if ($scope.UserID != null && $scope.UserID != "" && $scope.UserID != undefined) {
            $scope.GetUserDetails();
        }
    });
}]);


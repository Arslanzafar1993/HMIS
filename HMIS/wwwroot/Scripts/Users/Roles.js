app.controller('RolesController', ["$scope", "$http", function ($scope, $http) {
    $scope.RoleName = "";
    $scope.UserRolesList = [];
    $scope.UserRoleManage = true;

    $scope.UserID = "";

    $scope.AddRoleId = [];
    $scope.DeleteRoleId = [];

    $scope.AddRole = function () {
        $http({
            url: "/api/Authenticate/CreateRole/" + $scope.RoleName,
            method: "POST",
            transformRequest: angular.identity,
            contentType: 'application/json',
        }).then(function (res) {
            if (res.data.userroles != null && res.data.userroles.length > 0) {
                $scope.UserRolesList = res.data.userroles;
                $scope.RoleName = "";
            }
        });
    };

    $scope.GetAllRoles = function () {
        $http({
            url: "/api/Authenticate/Roles",
            method: "GET",
            transformRequest: angular.identity,
            contentType: 'application/json',
        }).then(function (res) {
            if (res.data.userroles != null && res.data.userroles.length > 0) {
                $scope.UserRolesList = res.data.userroles;
            }
        });
    };
    $scope.GetUserRoles = function (userId) {
        $http({
            url: "/api/User/GetUserRoles?userId=" + userId,
            method: "GET",
            transformRequest: angular.identity,
            contentType: 'application/json',
        }).then(function (res) {
            if (res.data != null) {
                $scope.UserRolesList = res.data;
                $scope.UserRoleManage = true;
                setTimeout(function () {
                    if ($scope.UserRolesList.allRoles.length > 0) {
                        for (var a = 0; a < $scope.UserRolesList.allRoles.length; a++) {
                            let index = $scope.UserRolesList.userRoles.findIndex(record => record === $scope.UserRolesList.allRoles[a]);
                            if (index >= 0) {
                                $("#" + [a]).prop("checked", true);
                            }
                        }
                    }
                }, 400);
            }
        });
    };



    $scope.AssignedRoles = function () {
        if ($scope.UserRolesList.allRoles.length > 0) {
            for (var a = 0; a < $scope.UserRolesList.allRoles.length; a++) {
                var value = $("#" + [a]).prop("checked");
                if (value) {
                    $scope.AddRoleId.push($scope.UserRolesList.allRoles[a]);
                }
                else {
                    $scope.DeleteRoleId.push($scope.UserRolesList.allRoles[a]);
                }
            }
        }
        var Data = {
            UserId : $scope.UserID,
            AddRoleId: $scope.AddRoleId,
            DeleteRoleId: $scope.DeleteRoleId

        }
        var data = JSON.stringify(Data);
        try {
            $http({
                url: "/api/User/AssignUserRoles",
                method: "POST",
                data: data,
                transformRequest: angular.identity,
                contentType: 'application/json',
            }).then(function (res) {
                if (res.data.status != null && res.data.status == "Succeed") {
                    alert(res.data.message)
                }
                else {
                    alert("Error")
                }
            });
        }
        catch (ee) { alert(ee) }
    };
    angular.element(document).ready(function () {
        var UserID = $("#UserID").val();
        $scope.UserID = UserID;
        if (UserID != "" && UserID != null && UserID != undefined) {
            $scope.GetUserRoles(UserID);
        }
        else {
            $scope.UserRoleManage = false;
            $scope.GetAllRoles();
        }
    });
}]);


app.controller('formCtrl', ["$scope",  "$http", function ($scope, $http) {
    $scope.fetchPatientRecord = function () {
        //alert("sdkdsflj")
        //$http({
        //    method: "POST",
        //    url: '/api/Authenticate/login',
        //    data: {
        //        username: "string",
        //        password: "string"
        //    },
        //}).then(function (res) {
        //    //$scope.data = res.data;
        //    //$scope.gridOptions.api.setRowData($scope.data);
        //    ////$.unblockUI();
        //});
        $('#StockModal').modal('show');
    };
}]);


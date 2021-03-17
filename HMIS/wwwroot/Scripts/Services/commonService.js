app.factory("commonService", ["$http", function ($http) {
    return {
        getDivisions: function () {
            return $http({
                method: "GET",
                url: "/api/Common/GetDivisionList"
            }).then(function (res) {
                return res.data;
            });
        },
        getDistricts: function (DivisionCode) {
            return $http({
                method:"GET",
                url: "/api/Common/GetDistrictList/" + DivisionCode ,
            }).then(function (res) {
                return res.data;
            });
        },
        getTehsils: function (DistrictCode) {
            return $http({
                method: "GET",
                url: "/api/Common/GetTehsilList/" + DistrictCode,
            }).then(function (res) {
                return res.data;
            });
        },
        getHealthFacilities: function (TehsilCode) {
            return $http({
                method: "GET",
                url: "/api/Common/GetHealthFacilityList/" + TehsilCode
            }).then(function (res) {
                return res.data;
            });
        }
    }
}
]);
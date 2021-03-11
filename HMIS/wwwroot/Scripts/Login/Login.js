function Login() {
    try {
debugger;
        var Object = {
            Username: $("#UserName").val(),
            Password: $("#password").val()
        };

        $.ajax({
            url: '/api/user/login',
            type: 'POST',
            data: Object,
            dataType: 'json',
            success: function (data) {
                alert('Data: ' + data);
            },
            error: function (request, error) {
                alert("Request: " + JSON.stringify(request));
            }
        });
    }
    catch (ee) { alert(ee);  }
}
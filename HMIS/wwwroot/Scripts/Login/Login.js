function Login() {
    try {
        var Object = {
            Username: $("#UserName").val(),
            Password: $("#password").val()
        };
        if (Object.Username == null || Object.Username == '' || Object.Username == undefined) {
            alert("Please Enter UserName")
            return;
        }
        if (Object.Password == null || Object.Password == '' || Object.Password == undefined) {
            alert("Please Enter Password")
            return;
        }
        $.ajax({
            url: '/api/Authenticate/login',
            type: 'POST',
            data: JSON.stringify(Object),
            // dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                if (data != null && data != undefined && (data.token != null && data.token != '' && data.token != undefined)) {
                    window.location.replace('/Users/adduser');
                }
                else {
                    alert("UserName or Password is Incorrect")
                }
            },
            error: function (request, error) {
                alert("UserName or Password is Incorrect")
            }
        });
    }
    catch (ee) { alert(ee);  }
}

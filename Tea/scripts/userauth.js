window.fbAsyncInit = function () {
    //SDK loaded, initialize it 
    FB.init({
        appId: datas.fb_id,
        xfbml: true,
        version: 'v2.9'
    });

    //check user session and refresh it
    FB.getLoginStatus(function (response) {
        if (response.status === 'connected') {
            //user is authorized
            //getUserData();
            var btnn = document.getElementById('loginBtn');
            if (btnn && btnn.style) { btnn.style.display = 'none'; }
        } else {
            //user is not authorized
        }
    });
};

function getUserData() {
    FB.api('/me', function (response) {
        $.ajax({
            type: 'post',
            url: '/fb.aspx',
            data: { op: 'fblogin', id: response.id, name: response.name },
            success: function (ea) {
                //alert(ea);
                if (ea == "1") {
                    window.top.location.href = "/Default.aspx";
                }
                if (ea == "2") {
                    alert('請補填寫您的電子郵箱');
                    window.top.location.href = "/users/edituser.aspx";
                }
                if (ea == "3") {
                    window.top.location.href = "/Default.aspx";
                }
                if (ea == "4") {
                    window.top.location.href = "/shop/cart.aspx";
                }
            }
        });
    });
}


$(function (ea) {
    $('#fb_login').on('click', function (ea) {

                FB.login(function (response) {
                    if (response.authResponse) {
                        getUserData();
                    }
                }, { scope: 'email,public_profile', return_scopes: true });
                return false;
    });

});
function InitialiseFacebook(appId) {
    window.fbAsyncInit = function () {
        FB.init({
            appId: appId,
            cookie: true,
            status: true,
            xfbml: true,
            oauth: true
        });

        function authStuff(response) {
            var button = document.getElementById('fb-auth');
            //assuming logged in    
            if (response.authResponse) {
                console.log('Welcome! Fetching your information...');
                var userInfo = document.getElementById('user-info');
                FB.api('/me', function (response) {
                    userInfo.innerHTML = 'Welcome, ' + response.name + ' <img src="https://graph.facebook.com/'
                    + response.id + '/picture">';
                    button.innerHTML = 'Logout';
                });
                //onClick to logout
                button.onclick = function () {
                    FB.logout(function (response) {
                        var userInfo = document.getElementById('user-info');
                        userInfo.innerHTML = "";
                    });
                };
            } else {
                button.innerHTML = 'Login';

                button.onclick = function () {
                    FB.login(function (response) {
                        if (response.authResponse) {
                            FB.api('/me', function (response) {
                                var userInfo = document.getElementById('user-info');
                                userInfo.innerHTML = response.name
                                + ' <img src="https://graph.facebook.com/'
                                + response.id + '/picture">';
                            });
                        } else {
                            console.log('User cancelled login or did not fully authorize.');
                        }
                    }, { scope: 'email,publish_stream' });
                }
            }
        }
        FB.getLoginStatus(authStuff);
        FB.Event.subscribe('auth.statusChange', authStuff);
    };

    (function () {
        var e = document.createElement('script');
        e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
        e.async = true;
        document.getElementById('fb-root').appendChild(e);
    } ());
}

/*
function InitialiseFacebook(appId) {

    window.fbAsyncInit = function () {
        FB.init({
            appId: appId,
            status: true,
            cookie: true,
            xfbml: true
        });

        FB.Event.subscribe('auth.login', function (response) {
            var credentials = { FBid: response.authResponse.userID, accessToken: response.authResponse.accessToken };
            SubmitLogin(credentials);
        });

        FB.getLoginStatus(function (response) {
            if (response.status === 'connected') {
                console.log('user is logged into fb');
            }
            else if (response.status === 'not_authorized') { console.log('user is not authorised'); }
            else { console.log('user is not conntected to facebook'); }

        });

        function SubmitLogin(credentials) {
            $.ajax({
                url: "/account/facebooklogin",
                type: "POST",
                data: credentials,
                error: function () {
                    console.log('error logging in to your facebook account.');
                },
                success: function () {
                    window.location.reload();
                }
            });
        }

    };

    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) {
            return;
        }
        js = d.createElement('script');
        js.id = id;
        js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    } (document));

}
*/
function InitialiseFacebook(appId) {
    window.fbAsyncInit = function () {
        FB.init({
            appId: appId,
            cookie: true,
            status: true,
            xfbml: true,
            oauth: true
        });

        var userInfo = document.getElementById('user-info');

        FB.Event.subscribe('auth.login', function (response) {
            if (response.authResponse) {
                FB.api('/me', function (response) {
                    userInfo.innerHTML = 'Welcome ' + response.name
                    + ' <img src="https://graph.facebook.com/'
                    + response.id + '/picture">';
                });
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        });

        FB.Event.subscribe('auth.logout', function (response) {
            userInfo.innerHTML = "";
        });

        function authCheck(response) {
            if (response.authResponse) {
                FB.api('/me', function (response) {
                    userInfo.innerHTML = 'Welcome ' + response.name
                    + ' <img src="https://graph.facebook.com/'
                    + response.id + '/picture">';
                });
            } else {
                console.log('Error, not logged in.');
            }
        }

        FB.Event.subscribe('auth.statusChange', authCheck);
    };

    (function () {
        var e = document.createElement('script');
        e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
        e.async = true;
        document.getElementById('fb-root').appendChild(e);
    } ());
}
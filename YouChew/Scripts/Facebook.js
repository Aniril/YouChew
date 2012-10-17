function InitialiseFacebook(appId) {
    window.fbAsyncInit = function () {
        FB.init({
            appId: appId,
            cookie: true,
            status: true,
            xfbml: true,
            oauth: true
        });

        FB.Event.subscribe('auth.login', function(response) {  
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
        });

        FB.Event.subscribe('auth.logout', function(response) {
            var userInfo = document.getElementById('user-info');
            userInfo.innerHTML = "";
        });  
    };

    (function () {
        var e = document.createElement('script');
        e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
        e.async = true;
        document.getElementById('fb-root').appendChild(e);
    } ());
}
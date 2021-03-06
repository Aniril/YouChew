﻿function InitialiseFacebook(appId) {
    window.fbAsyncInit = function () {
        FB.init({
            appId: appId,
            cookie: true,
            status: true,
            xfbml: true,
            oauth: true
        });

        var facebookInfo = document.getElementById('user-info');
//        var infoBtn = document.getElementById('infoBtn');

        //Facebook login event
        FB.Event.subscribe('auth.login', function (response) {
            if (response.authResponse) {
                FB.api('/me', function (response) {
                    facebookInfo.innerHTML = 'Welcome, '
                    + '<a href="' + response.link + '">' + response.name + '</a>.  ';
                });
//                infoBtn.style.display = 'block';
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        });
        //Facebook logout event
        FB.Event.subscribe('auth.logout', function (response) {
            facebookInfo.innerHTML = "";
//            infoBtn.style.display = 'none';
        });
        //Displays info when page is changed
        function authCheck(response) {
            if (response.authResponse) {
                FB.api('/me', function (response) {
                    facebookInfo.innerHTML = 'Welcome, '
                    + '<a href="' + response.link + '">' + response.name + '</a>.  ';
                });
//                infoBtn.style.display = 'block';
            } else {
                console.log('Error, not logged in.');
            }
        }

        FB.Event.subscribe('auth.statusChange', authCheck);

        //Displays info on user page
        function userInfo(response) {
            var username = document.getElementById('username');
            var email = document.getElementById('email');
            var picture = document.getElementById('picture');
            FB.api('/me', function (response) {
                username.innerHTML = response.name;
                email.innerHTML = response.email;
                picture.innerHTML = '<img src="https://graph.facebook.com/'
                    + response.id + '/picture">';
            });
        }

        FB.Event.subscribe('auth.statusChange', userInfo);

    };

    (function () {
        var e = document.createElement('script');
        e.src = document.location.protocol + '//connect.facebook.net/en_US/all.js';
        e.async = true;
        document.getElementById('fb-root').appendChild(e);
    } ());
}
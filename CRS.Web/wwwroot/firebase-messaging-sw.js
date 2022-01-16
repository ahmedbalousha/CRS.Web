importScripts('https://www.gstatic.com/firebasejs/9.1.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/9.1.1/firebase-messaging.js');

var config = {
    apiKey: "AIzaSyBpEzffsqEiMTDPMsFmHNmpRNjWEFkNQc0",
    authDomain: "crsa-b0a4b.firebaseapp.com",
    projectId: "crsa-b0a4b",
    storageBucket: "crsa-b0a4b.appspot.com",
    messagingSenderId: "525382095637",
    appId: "1:525382095637:web:3790249a7f82b6f7e38f1c",
    measurementId: "G-S4VFST2RLD"
};

firebase.initializeApp(config);

const messaging = firebase.messaging();

messaging.setBackgroundMessageHandler(function(payload) {
    //// Customize notification here
    var notificationTitle = 'My Titile';
    var notificationOptions = {
        body: payload.data.body
    };

    return self.registration.showNotification(notificationTitle,
        notificationOptions);
});
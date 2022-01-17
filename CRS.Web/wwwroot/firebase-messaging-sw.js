<script type="module">
  // Import the functions you need from the SDKs you need
    import {initializeApp} from "https://www.gstatic.com/firebasejs/9.6.3/firebase-app.js";
    import {getAnalytics} from "https://www.gstatic.com/firebasejs/9.6.3/firebase-analytics.js";
    // TODO: Add SDKs for Firebase products that you want to use
    // https://firebase.google.com/docs/web/setup#available-libraries

    // Your web app's Firebase configuration
    // For Firebase JS SDK v7.20.0 and later, measurementId is optional
    const firebaseConfig = {
        apiKey: "AIzaSyDCD-OxhduEfdvosDnkx1rdrsBAV5B8h3I",
    authDomain: "crsweb-23359.firebaseapp.com",
    projectId: "crsweb-23359",
    storageBucket: "crsweb-23359.appspot.com",
    messagingSenderId: "290847023071",
    appId: "1:290847023071:web:8ac3422494b9ed3652ee6a",
    measurementId: "G-HG9XS7RR5W"
  };

    // Initialize Firebase
    const app = initializeApp(firebaseConfig);
    const analytics = getAnalytics(app);
</script>

//firebase.initializeApp(config);

//const messaging = firebase.messaging();

//messaging.setBackgroundMessageHandler(function(payload) {
//    //// Customize notification here
//    var notificationTitle = 'My Titile';
//    var notificationOptions = {
//        body: payload.data.body
//    };

//    return self.registration.showNotification(notificationTitle,
//        notificationOptions);
//});
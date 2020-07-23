using System;
using Firebase.Database;
using Firebase.Database.Query;


namespace XamarinFirebase.Model
{

    public class Person
    {
        FirebaseClient firebase = new FirebaseClient("https://weinstore-334f3.firebaseio.com/");
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

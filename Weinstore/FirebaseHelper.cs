using XamarinFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;

using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace XamarinFirebase.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://weinstore-fd7d9.firebaseio.com/");

        public async Task<List<Person>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Password = item.Object.Password,
                  Username = item.Object.Username,
                  Email = item.Object.Email
              }).ToList();
        }

        public async Task AddPerson(string username, string password, string email)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Person() { Username = username, Password = password, Email = email });
        }

        public async Task<Person> GetPerson(string username)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.Username == username).FirstOrDefault();
        }

        public async Task UpdatePerson(string username, string password, string email)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>
              ()).Where(a => a.Object.Username == username).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { Username = username, Password = password, Email = email });
        }

        public async Task DeletePerson(string username)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>
              ()).Where(a => a.Object.Username == username).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        }
    }

}

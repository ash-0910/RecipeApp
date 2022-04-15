using Firebase.Auth;
using Firebase.Database;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing_Library
{
    public class LibraryHelper
    {

        List<Users> user = new List<Users>
        {
            new Users{Email="jdhedden@msn.com", Password="jdh234"},
            new Users{Email="gavinls@hotmail.com", Password="inls423"},
            new Users{Email="caronni@icloud.com", Password="caron4"},
            new Users{Email="mike23@gmail.com", Password="mike249"},
            new Users{Email="bryan09@yahoo.com", Password="bryan23"},
            new Users{Email="testingemail@hotmail.com", Password="testingpassword"},
            new Users{Email="bestemail@gmail.com", Password="bestemail45"},
            new Users{Email="metro@outlook.com", Password="metro09"},
            new Users{Email="chocolates@yahoo.com", Password="chocolate87"},
            new Users{Email="kelly@gmail.com", Password="kelly54"}

        };

        IFirebaseClient client;
        bool result;
        FirebaseAuthProvider auth = new FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig("AIzaSyB2fK-fhnqN1eVSU4DMpN11R1uL6cfFFlc"));

        IFirebaseConfig config = new FireSharp.Config.FirebaseConfig()
        {
            BasePath = "https://recipewebapp-2b062-default-rtdb.firebaseio.com/"
        };

        public bool GetRecipeNames()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse res = client.Get(@"Recipes");
            Dictionary<string, RecipeModel> data = JsonConvert.DeserializeObject<Dictionary<string, RecipeModel>>(res.Body.ToString());

            if (data != null)
            {
                 result = true;
            }

            return result;

           /* var data = firebaseDatabase
                .Child("Recipes")
                

            await firebaseDatabase
              .Child("Messages")
              .PostAsync(new TextFile() { textMessage = message });*/
        }

        public async Task<bool> FirebaseRegistration()
        {

            for(int i=0; i< user.Count; i++)
            {
                var registerauth = await auth.CreateUserWithEmailAndPasswordAsync(user[i].Email,user[i].Password);

                string token = registerauth.FirebaseToken;

                if (token != null)
                {
                    result = true;
                    break;
                }
                else
                {
                    continue;
                }
            }

           

            return result;
        }



    }
}

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

        IFirebaseClient client;
        bool result;

        IFirebaseConfig config = new FirebaseConfig()
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



    }
}

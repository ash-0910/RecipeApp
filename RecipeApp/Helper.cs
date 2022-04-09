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

namespace RecipeApp
{
    public class Helper
    {
        FirebaseClient firebaseDatabase = new FirebaseClient("https://recipewebapp-2b062-default-rtdb.firebaseio.com/");

        IFirebaseClient client;

        IFirebaseConfig config = new FirebaseConfig()
        {
            BasePath = "https://recipewebapp-2b062-default-rtdb.firebaseio.com/"
        };

        public Dictionary<string, RecipeModel> GetRecipeNames()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse res = client.Get(@"Recipes");
            Dictionary<string, RecipeModel> data = JsonConvert.DeserializeObject<Dictionary<string, RecipeModel>>(res.Body.ToString());
            //PopulateData(data);
            return data;

           /* var data = firebaseDatabase
                .Child("Recipes")
                

            await firebaseDatabase
              .Child("Messages")
              .PostAsync(new TextFile() { textMessage = message });*/
        }


        void PopulateData(Dictionary<string, RecipeModel> data)
        {
            foreach(var item in data)
            {
                string value = item.Key + "\n";
            }
        }

    }
}

using Bometh.FirebaseDatabase;
using Firebase.Database;
using Firebase.Database.Query;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using RecipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;

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

        
            
            return data;

        //    var response = firebaseDatabase.Child("Recipes");

                

           /* await firebaseDatabase
              .Child("Messages")
              .PostAsync(new TextFile() { textMessage = message });*/
        }

        /*    public Dictionary<string, RecipeModel> GetSpecificRecipeTitle()
            {
                client = new FireSharp.FirebaseClient(config);
                FirebaseResponse res = client.Get(@"Recipes");
                Dictionary<string, RecipeModel> data = JsonConvert.DeserializeObject<Dictionary<string, RecipeModel>>(res.Body.ToString());



                         //  var cq = firebaseDatabase.Child("Recipes").Child("Indian");


                return data;

                /* var data = firebaseDatabase
                     .Child("Recipes")


                 await firebaseDatabase
                   .Child("Messages")
                   .PostAsync(new TextFile() { textMessage = message });
            }
        */

        public async Task<List<RecipeModel>> GetIndianRecipes()
        {
            var response = (await firebaseDatabase.Child("Recipes").Child("Indian").OnceAsync<RecipeModel>()).Select(item => new RecipeModel()
            {
                Title = item.Object.Title,
                Ingredients = item.Object.Ingredients,
                Instructions = item.Object.Instructions,
                Image=item.Object.Image
                

            }).ToList();

            return response;

        }

        public async Task<List<RecipeModel>> GetItalianRecipes()
        {
            var response = (await firebaseDatabase.Child("Recipes").Child("Italian").OnceAsync<RecipeModel>()).Select(item => new RecipeModel()
            {
                Title = item.Object.Title,
                Ingredients = item.Object.Ingredients,
                Instructions = item.Object.Instructions,
                Image = item.Object.Image


            }).ToList();

            return response;

        }



    }
}

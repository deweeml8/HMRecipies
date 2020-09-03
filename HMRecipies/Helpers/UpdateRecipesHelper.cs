using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using HMRecipies.Models;
using Newtonsoft.Json;

namespace HMRecipies.Helpers
{
    public class UpdateRecipesHelper
    {
        public UpdateRecipesHelper()
        {
        }

        public static void GetRecipeJson()
        {
            string jsonFileName = "recipes.json";
            var ObjContactList = new System.Collections.Generic.List<Models.Recipe>();
            var assembly = typeof(Views.HomeView).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Data.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                var result = JsonConvert.DeserializeObject<List<Recipe>>(jsonString);
                Helpers.DatabaseHelper.SaveUpdateListToDB(result);
            }
        }
    }
}

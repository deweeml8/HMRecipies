using System;
using System.Collections.Generic;
using HMRecipies.Models;
using System.IO;
using SQLite;

namespace HMRecipies.Helpers
{
    
    public class DatabaseHelper
    {
        public DatabaseHelper()
        {
        }
        public static void SaveUpdateListToDB(List<Recipe> recipeList)
        {
            if (File.Exists(App.FilePath))
            {
                CreateDatabase();
            }
            InsertData(recipeList);
        }
        private static void CreateDatabase()
        {
            using (var conn = DBConnection())
            {
                //DropTable();
                conn.CreateTable<Recipe>();
            }
            
        }
        private static void DropTable()
        {
            using (var conn = DBConnection())
            {
                conn.DropTable<Recipe>();
            }

        }
        private static SQLiteConnection DBConnection()
        {
            return new SQLiteConnection(App.FilePath);
        }
        private static int InsertData(List<Recipe> recipeList)
        {
            using (var conn = DBConnection())
            {
                var i = 0;
                try
                {
                    foreach (var item in recipeList)
                    {
                        i = conn.Insert(item);
                    }
                    App.Current.MainPage.DisplayAlert("Recipie List has been successfully updated", "", "OK");
                }
                catch
                {
                    App.Current.MainPage.DisplayAlert("Unable to update recipie list", "", "OK");
                }
                
                return i;
            }
        }
        public static List<Recipe> GetAllData()
        {
            using (var conn = DBConnection())
            {
                return conn.Query<Recipe>($"SELECT * FROM Recipe");
            }
        }
    }
}
    
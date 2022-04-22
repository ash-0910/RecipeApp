using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp.Controllers;
using RecipeApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing_Library;
using Xunit;

namespace RecipesTest
{
    [TestClass]
    public class RecipeAppTesting
    {


        private LibraryHelper _libraryhelper = new LibraryHelper();

        [TestMethod]
        public void GetAllRecipesTest()
        {
            bool result = _libraryhelper.GetRecipeNames();

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void registrationTesting()
        {
            Task<bool> result = _libraryhelper.FirebaseRegistration();

            Assert.IsTrue(result.Result);

        }

        [TestMethod]
        public void LoginTesting()
        {
            Task<bool> result = _libraryhelper.FirebaseLogin();

            Assert.IsTrue(result.Result);

        }
      
        [TestMethod]
        public void getIndianRecipeTesting()
        {
            Task<bool> result = _libraryhelper.GetIndianRecipes();

            Assert.IsTrue(result.Result);

        }

        [TestMethod]
        public void GetitalianRecipes()
        {
            Task<bool> result = _libraryhelper.GetItalianRecipes();

            Assert.IsTrue(result.Result);

        }
    }
}

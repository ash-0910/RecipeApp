using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApp.Controllers;
using RecipeApp.Models;
using System.Collections.Generic;
using Testing_Library;
using Xunit;

namespace RecipesTest
{
    [TestClass]
    public class RecipeAppTesting
    {

        private readonly HomeController _controller;
        private LibraryHelper _libraryhelper;

        [TestMethod]
        public void GetAllRecipesTest()
        {
            _libraryhelper = new LibraryHelper();

            bool result = _libraryhelper.GetRecipeNames();

            Assert.IsTrue(result);

        }
    }
}

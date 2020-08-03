using System.IO;
using System.Net;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilverHorseBackend;
using SilverHorseBackend.Controllers;

namespace SilverHorseBackend.Tests.Controllers
{
    public class BaseTest
    {
        protected string getResourceText(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream("SilverHorseBackend.Tests.TestData." + resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

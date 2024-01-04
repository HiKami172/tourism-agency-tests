using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism.Geography;

namespace Tourism.Tests.Geography;

[TestClass]
[TestSubject(typeof(City))]
public class CityTest
{
    private City _city;
    private Country _country;

    [TestInitialize]
    public void TestInitialize()
    {
        _country = new Country("Test Country", "Test Code");
        _city = new City(_country, "Test City");
    }

    [TestMethod]
    public void Test_City_Name()
    {
        Assert.AreEqual("Test City", _city.Name);
    }

    [TestMethod]
    public void Test_City_LocationCountry()
    {
        Assert.AreEqual(_country, _city.LocationCountry);
    }

    [TestMethod]
    public void Test_City_Constructor()
    {
        var city = new City(_country, "New City");
        
        Assert.AreEqual("New City", city.Name);
        Assert.AreEqual(_country, city.LocationCountry);
    }
}
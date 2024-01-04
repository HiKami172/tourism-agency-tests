using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism.Geography;

namespace Tourism.Tests.Geography;

[TestClass]
[TestSubject(typeof(Country))]
public class CountryTest
{
    private Country _country;
     
    [TestInitialize]
    public void Setup()
    {
        _country = new Country("Test Country", "TC");
    }

    [TestMethod]
    public void Verify_Country_Name()
    {
        Assert.AreEqual("Test Country", _country.Name);
    }

    [TestMethod]
    public void Check_Country_Code()
    {
        Assert.AreEqual("TC", _country.Code);
    }

    [TestMethod]
    public void Confirm_Country_Constructor()
    {
        var country = new Country("New Country", "NC");
        
        Assert.AreEqual("New Country", country.Name);
        Assert.AreEqual("NC", country.Code);
        Assert.IsTrue(country.Cities.Count == 0);
    }

    [TestMethod]
    public void Validate_City_Addition()
    {
        var city = _country.AddCity("New City");
        
        Assert.AreEqual("New City", city.Name);
        Assert.AreEqual(_country, city.LocationCountry);
        Assert.IsTrue(_country.Cities.Contains(city));
    }
}
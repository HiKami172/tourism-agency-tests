using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism.Cabs;

namespace Tourism.Tests.Cabs;

[TestClass]
[TestSubject(typeof(Cab))]
public class CabTest
{
    private Cab _cab;

    [TestInitialize]
    public void TestInitialize()
    {
        _cab = new Cab("Test Cab", "Test Description", CabType.Aero);
    }

    [TestMethod]
    public void Test_Cab_Name()
    {
        Assert.AreEqual("Test Cab", _cab.Name);
    }

    [TestMethod]
    public void Test_Cab_Description()
    {
        Assert.AreEqual("Test Description", _cab.Description);
    }

    [TestMethod]
    public void Test_Cab_CabType()
    {
        Assert.AreEqual(CabType.Aero, _cab.CabType);
    }

    [TestMethod]
    public void Test_Cab_Constructor()
    {
        var cab = new Cab("New Cab", "New Description", CabType.Railway);
        
        Assert.AreEqual("New Cab", cab.Name);
        Assert.AreEqual("New Description", cab.Description);
        Assert.AreEqual(CabType.Railway, cab.CabType);
    }
}
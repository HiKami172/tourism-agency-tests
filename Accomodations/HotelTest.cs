using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism.Accomodations;

namespace Tourism.Tests.Accomodations;

[TestClass]
[TestSubject(typeof(Hotel))]
public class HotelTests
{
    [TestMethod]
    public void StarsTest()
    {
        int stars = 5;
        var hotel = new Hotel("Address", "Description", "Phone", "Email", stars);
        hotel.Stars = stars;
        Assert.AreEqual(stars, hotel.Stars);
    }
}
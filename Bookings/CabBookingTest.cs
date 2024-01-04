using System;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism.Bookings;
using Tourism.Cabs;
using Tourism.Geography;

namespace Tourism.Tests.Bookings;

[TestClass]
[TestSubject(typeof(CabBooking))]
public class CabBookingTest
{
    private CabBooking _cabBooking;
    private DateTime _startTime;
    private DateTime _finishTime;
    private float _price;
    private City _source;
    private City _destination;
    private Cab _cab;

    [TestInitialize]
    public void TestInitialize()
    {
        _startTime = DateTime.Now;
        _finishTime = _startTime.AddDays(1);
        _price = 200f;
        _source = new City(new Country("TestCountry", "TC"), "TestCitySource");
        _destination = new City(new Country("TestCountry", "TC"), "TestCityDestination");
        _cab = new Cab("TestCab", "Test Cab Description", CabType.Aero);

        _cabBooking = new CabBooking(_startTime, _finishTime, _price,
            _source, _destination, _cab);
    }

    [TestMethod]
    public void Test_CabBooking_Source()
    {
        Assert.AreEqual(_source, _cabBooking.Source);
    }

    [TestMethod]
    public void Test_CabBooking_Destination()
    {
        Assert.AreEqual(_destination, _cabBooking.Destination);
    }

    [TestMethod]
    public void Test_CabBooking_BookedCab()
    {
        Assert.AreEqual(_cab, _cabBooking.BookedCab);
    }

    [TestMethod]
    public void Test_CabBooking_Constructor()
    {
        Assert.AreEqual(_startTime, _cabBooking.StartTime);
        Assert.AreEqual(_finishTime, _cabBooking.FinishTime);
        Assert.AreEqual(_price, _cabBooking.Price, 0.0001f);
    }
}
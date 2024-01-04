using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism;
using Tourism.Accomodations;
using Tourism.Bookings;
using Tourism.Cabs;
using Tourism.Geography;
using Tourism.Users;

namespace Tourism.Tests;

[TestClass]
[TestSubject(typeof(Tour))]
public class TourTest
{
    private Tour _tour;
    private Customer _customer;
    private Country _country;
    private List<AccomodationBooking> _accommodationBookings;
    private Hotel _accomodation;
    private List<CabBooking> _cabBookings;

    [TestInitialize]
    public void TestInitialize()
    {
        _customer = new Customer("TestLogin", "TestPassword", "TestEmail", "TestAddress", "TestPhone");
        _accomodation = new Hotel("address", "description", "123123123", "email@gmail.com", 3);
        _accommodationBookings = new List<AccomodationBooking>
        {
            new AccomodationBooking(DateTime.Now, DateTime.Now, 100f, _accomodation, RoomType.Lux)
        };
        
        _country = new Country("England", "EN");
        City sourceCity = _country.AddCity("London");
        City destinationCity = _country.AddCity("Birmingham");
        Cab cab = new Cab("Airlines" , "description", CabType.Aero);
        _cabBookings = new List<CabBooking> 
        {
            new CabBooking(DateTime.Now, DateTime.Now.AddDays(5), 200f, sourceCity, destinationCity, cab)
        };

        _tour = new Tour("Test Tour", "Test Description", 5.0F, _customer, _accommodationBookings, _cabBookings);
    }

    [TestMethod]
    public void Test_Tour_Name()
    {
        Assert.AreEqual("Test Tour", _tour.Name);
    }

    [TestMethod]
    public void Test_Tour_Description()
    {
        Assert.AreEqual("Test Description", _tour.Description);
    }

    [TestMethod]
    public void Test_Tour_Rating()
    {
        Assert.AreEqual(5.0F, _tour.Rating);
    }

    [TestMethod]
    public void Test_Tour_Customer()
    {
        Assert.AreEqual(_customer, _tour.Customer);
    }

    [TestMethod]
    public void Test_Tour_AddCabBooking()
    {   
        Country country = new Country("England", "EN");
        City source = _country.Cities[1];
        City destination = _country.Cities[0];
        Cab cab = new Cab("Railways", "description", CabType.Railway);
        var cabBooking = new CabBooking(DateTime.Now, DateTime.Now.AddDays(5), 200f, source, destination, cab);
        _tour.AddCabBooking(cabBooking);

        bool result = _tour.CabBookings.Contains(cabBooking);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Test_Tour_AddAccommodationBooking()
    {
        
        _tour.AddAccommodationBooking(_accommodationBookings[0]);

        bool result = _tour.AccommodationBookings.Contains(_accommodationBookings[0]);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void Test_Tour_CalculatePrice()
    {
        float expectedTotal = _accommodationBookings.Sum(b => b.Price) + _cabBookings.Sum(b => b.Price);

        var actualTotal = _tour.CalculatePrice();

        Assert.AreEqual(expectedTotal, actualTotal);
    }
}
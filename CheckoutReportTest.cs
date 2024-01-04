using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism;
using Tourism.Bookings;
using Tourism.Geography;
using Tourism.Users;

namespace Tourism.Tests;

[TestClass]
[TestSubject(typeof(CheckoutReport))]
public class CheckoutReportTest
{
    private CheckoutReport _checkoutReport;
    private Tour _tour;
    private Customer _customer;
    private Country _country;

    [TestInitialize]
    public void TestInitialize()
    {
        _country = new Country("England", "EN");
        City city1 = _country.AddCity("London");
        City ctiy2 = _country.AddCity("Birmingham");
        _customer = new Customer("TestLogin", "TestPassword", "TestEmail", "TestAddress", "TestPhone"); 
        var accommodationBooking = new AccomodationBooking(DateTime.Now, DateTime.Now, 100f, null, RoomType.Lux);
        var cabBooking = new CabBooking(DateTime.Now, DateTime.Now.AddDays(5), 200f, city1, city1, null);
        _tour = new Tour("Test Tour", "Test Description", 5.0F, _customer, new List<AccomodationBooking> { accommodationBooking }, new List<CabBooking> { cabBooking });

        _checkoutReport = new CheckoutReport(_tour, _customer, PaymentMethod.Cash);
    }

    [TestMethod]
    public void Test_CheckoutReport_Tour()
    {
        Assert.AreEqual(_tour, _checkoutReport.Tour);
    }

    [TestMethod]
    public void Test_CheckoutReport_Customer()
    {
        Assert.AreEqual(_customer, _checkoutReport.Customer);
    }

    [TestMethod]
    public void Test_CheckoutReport_PaymentMethod()
    {
        Assert.AreEqual(PaymentMethod.Cash, _checkoutReport.PaymentMethod);
    }

    [TestMethod]
    public void Test_CheckoutReport_Price()
    {
        var expectedPrice = _tour.CalculatePrice();
        Assert.AreEqual(expectedPrice, _checkoutReport.Price);
    }
}
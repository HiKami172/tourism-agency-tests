using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tourism.Accomodations;
using Tourism.Users;
using System;
using JetBrains.Annotations;

namespace Tourism.Tests.Accomodations;

[TestClass]
[TestSubject(typeof(Apartment))]
public class ApartmentTests
{
    private const string ValidAddress = "Address";
    private const string ValidDescription = "Description";
    private const string ValidPhone = "Phone";
    private const string ValidEmail = "Email";
    private Owner CreateOwner()
    {
        return new Owner("login", "password", ValidEmail, ValidAddress, ValidPhone);
    }
   
    private Apartment CreateValidApartment()
    {
        return new Apartment(CreateOwner(), ValidAddress, ValidDescription, ValidPhone, ValidEmail);
    }

    [TestMethod]
    public void OwnerTest_ValidOwner()
    {
        var apartment = CreateValidApartment();
        Assert.AreEqual(apartment.Owner, apartment.Owner);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void OwnerTest_NullOwner()
    {
        var apartment = new Apartment(null, ValidAddress, ValidDescription, ValidPhone, ValidEmail);
    }
}
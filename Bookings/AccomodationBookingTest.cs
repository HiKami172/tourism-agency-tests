using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tourism.Accomodations;
using Tourism.Bookings;

namespace Tourism.Tests.Bookings
{
    [TestClass]
    public class AccomodationBookingTests
    {
        private Accomodation _accomodation;
        [TestMethod]
        public void AccomodationBookingConstructorTest()
        {
            DateTime startTime = DateTime.Now;
            DateTime finishTime = DateTime.Now.AddDays(5);
            float price = 1000f;
            _accomodation = new Hotel("address", "description", "123123123", "email@gmail.com", 3);
            var roomType = RoomType.Lux;

            var accomodationBooking = new AccomodationBooking(startTime, finishTime, price, _accomodation, roomType);

            Assert.AreEqual(startTime, accomodationBooking.StartTime);
            Assert.AreEqual(finishTime, accomodationBooking.FinishTime);
            Assert.AreEqual(price, accomodationBooking.Price);
            Assert.AreEqual(_accomodation, accomodationBooking.BookedAccomodation);
            Assert.AreEqual(roomType, accomodationBooking.RoomType);
        }
    }
}
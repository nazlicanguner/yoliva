using System;
using System.Collections.Generic;
using System.Text;

using Yoliva.Domain;

namespace Yoliva.Domain.Tests;

public class JourneyTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenPassengerSeatCapacityIsLessThanOne(
        int passengerSeatCapacity)
    {
        // Arrange
        var driverId = Guid.NewGuid();
        var vehicleId = Guid.NewGuid();

        var meetingPoint = JourneyLocation.Create(
            "Alexanderplatz",
            52.5200,
            13.4050);

        var destination = JourneyLocation.Create(
            "Gisma University",
            52.5370,
            13.6070);

        var departureAt = DateTimeOffset.UtcNow.AddDays(1);

        // Act
        var action = () => Journey.Create(
            driverId,
            vehicleId,
            meetingPoint,
            destination,
            departureAt,
            passengerSeatCapacity);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Create_ShouldThrowArgumentException_WhenDriverIdIsEmpty()
    {
        // Arrange
        var driverId = Guid.Empty;
        var vehicleId = Guid.NewGuid();

        var meetingPoint = JourneyLocation.Create(
            "Alexanderplatz",
            52.5200,
            13.4050);

        var destination = JourneyLocation.Create(
            "Gisma University",
            52.5370,
            13.6070);

        var departureAt = DateTimeOffset.UtcNow.AddDays(1);
        const int passengerSeatCapacity = 3;

        // Act
        var action = () => Journey.Create(
            driverId,
            vehicleId,
            meetingPoint,
            destination,
            departureAt,
            passengerSeatCapacity);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Create_ShouldThrowArgumentException_WhenVehicleIdIsEmpty()
    {
        // Arrange
        var driverId = Guid.NewGuid();
        var vehicleId = Guid.Empty;

        var meetingPoint = JourneyLocation.Create(
            "Alexanderplatz",
            52.5200,
            13.4050);

        var destination = JourneyLocation.Create(
            "Gisma University",
            52.5370,
            13.6070);

        var departureAt = DateTimeOffset.UtcNow.AddDays(1);
        const int passengerSeatCapacity = 3;

        // Act
        var action = () => Journey.Create(
            driverId,
            vehicleId,
            meetingPoint,
            destination,
            departureAt,
            passengerSeatCapacity);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Create_ShouldThrowArgumentNullException_WhenMeetingPointIsNull()
    {
        // Arrange
        var driverId = Guid.NewGuid();
        var vehicleId = Guid.NewGuid();

        JourneyLocation? meetingPoint = null;

        var destination = JourneyLocation.Create(
            "Gisma University",
            52.5370,
            13.6070);

        var departureAt = DateTimeOffset.UtcNow.AddDays(1);
        const int passengerSeatCapacity = 3;

        // Act
        var action = () => Journey.Create(
            driverId,
            vehicleId,
            meetingPoint!,
            destination,
            departureAt,
            passengerSeatCapacity);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void Create_ShouldThrowArgumentNullException_WhenDestinationIsNull()
    {
        // Arrange
        var driverId = Guid.NewGuid();
        var vehicleId = Guid.NewGuid();

        var meetingPoint = JourneyLocation.Create(
            "Alexanderplatz",
            52.5200,
            13.4050);

        JourneyLocation? destination = null;

        var departureAt = DateTimeOffset.UtcNow.AddDays(1);
        const int passengerSeatCapacity = 3;

        // Act
        var action = () => Journey.Create(
            driverId,
            vehicleId,
            meetingPoint,
            destination!,
            departureAt,
            passengerSeatCapacity);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void Create_ShouldCreateJourney_WhenValuesAreValid()
    {
        // Arrange
        var driverId = Guid.NewGuid();
        var vehicleId = Guid.NewGuid();

        var meetingPoint = JourneyLocation.Create(
            "Alexanderplatz",
            52.5200,
            13.4050);

        var destination = JourneyLocation.Create(
            "Gisma University",
            52.5370,
            13.6070);

        var departureAt = DateTimeOffset.UtcNow.AddDays(1);
        const int passengerSeatCapacity = 3;

        // Act
        var journey = Journey.Create(
            driverId,
            vehicleId,
            meetingPoint,
            destination,
            departureAt,
            passengerSeatCapacity);

        // Assert
        Assert.NotEqual(Guid.Empty, journey.Id);
        Assert.Equal(driverId, journey.DriverId);
        Assert.Equal(vehicleId, journey.VehicleId);
        Assert.Equal(meetingPoint, journey.MeetingPoint);
        Assert.Equal(destination, journey.Destination);
        Assert.Equal(departureAt, journey.DepartureAt);
        Assert.Equal(passengerSeatCapacity, journey.PassengerSeatCapacity);
    }
}

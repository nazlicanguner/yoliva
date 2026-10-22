using System;
using System.Collections.Generic;
using System.Text;
using Yoliva.Domain;

namespace Yoliva.Domain.Tests;

public class JourneyLocationTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_ShouldThrowArgumentException_WhenDisplayNameIsEmpty(
        string displayName)
    {
        // Arrange
        const double latitude = 52.5200;
        const double longitude = 13.4050;

        // Act
        var action = () => JourneyLocation.Create(
            displayName,
            latitude,
            longitude);

        // Assert
        Assert.Throws<ArgumentException>(action);
    }

    [Theory]
    [InlineData(-90.1)]
    [InlineData(90.1)]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenLatitudeIsInvalid(
    double latitude)
    {
        // Arrange
        const string displayName = "Alexanderplatz";
        const double longitude = 13.4050;

        // Act
        var action = () => JourneyLocation.Create(
            displayName,
            latitude,
            longitude);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Theory]
    [InlineData(-180.1)]
    [InlineData(180.1)]
    public void Create_ShouldThrowArgumentOutOfRangeException_WhenLongitudeIsInvalid(
    double longitude)
    {
        // Arrange
        const string displayName = "Alexanderplatz";
        const double latitude = 52.5200;

        // Act
        var action = () => JourneyLocation.Create(
            displayName,
            latitude,
            longitude);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void Create_ShouldCreateJourneyLocation_WhenValuesAreValid()
    {
        // Arrange
        const string displayName = "Alexanderplatz";
        const double latitude = 52.5200;
        const double longitude = 13.4050;

        // Act
        var location = JourneyLocation.Create(
            displayName,
            latitude,
            longitude);

        // Assert
        Assert.Equal(displayName, location.DisplayName);
        Assert.Equal(latitude, location.Latitude);
        Assert.Equal(longitude, location.Longitude);
    }
}

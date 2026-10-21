using System;
using System.Collections.Generic;
using System.Text;

namespace Yoliva.Domain;

public sealed record JourneyLocation
{
    public string DisplayName { get; }
    public double Latitude { get; }
    public double Longitude { get; }

    private JourneyLocation(
        string displayName,
        double latitude,
        double longitude)
    {
        DisplayName = displayName;
        Latitude = latitude;
        Longitude = longitude;
    }

    public static JourneyLocation Create(
        string displayName,
        double latitude,
        double longitude)
    {
        if (string.IsNullOrWhiteSpace(displayName))
        {
            throw new ArgumentException(
                "Display name cannot be empty.",
                nameof(displayName));
        }

        if (latitude is < -90 or > 90)
        {
            throw new ArgumentOutOfRangeException(
                nameof(latitude),
                "Latitude must be between -90 and 90.");
        }

        return new JourneyLocation(
            displayName,
            latitude,
            longitude);
    }
}

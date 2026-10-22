using System;
using System.Collections.Generic;
using System.Text;

namespace Yoliva.Domain;

public sealed class Journey
{
    public Guid Id { get; }
    public Guid DriverId { get; }
    public Guid VehicleId { get; }
    public JourneyLocation MeetingPoint { get; }
    public JourneyLocation Destination { get; }
    public DateTimeOffset DepartureAt { get; }
    public int PassengerSeatCapacity { get; }

    private Journey(
        Guid id,
        Guid driverId,
        Guid vehicleId,
        JourneyLocation meetingPoint,
        JourneyLocation destination,
        DateTimeOffset departureAt,
        int passengerSeatCapacity)
    {
        Id = id;
        DriverId = driverId;
        VehicleId = vehicleId;
        MeetingPoint = meetingPoint;
        Destination = destination;
        DepartureAt = departureAt;
        PassengerSeatCapacity = passengerSeatCapacity;
    }

    public static Journey Create(
        Guid driverId,
        Guid vehicleId,
        JourneyLocation meetingPoint,
        JourneyLocation destination,
        DateTimeOffset departureAt,
        int passengerSeatCapacity,
        DateTimeOffset now)
    {

        if (driverId == Guid.Empty)
        {
            throw new ArgumentException(
                "Driver id cannot be empty.",
                nameof(driverId));
        }

        if (vehicleId == Guid.Empty)
        {
            throw new ArgumentException(
                "Vehicle id cannot be empty.",
                nameof(vehicleId));
        }

        ArgumentNullException.ThrowIfNull(meetingPoint);

        ArgumentNullException.ThrowIfNull(destination);

        if (departureAt <= now)
        {
            throw new ArgumentOutOfRangeException(
                nameof(departureAt),
                "Departure time must be in the future.");
        }

        if (passengerSeatCapacity < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(passengerSeatCapacity),
                "Passenger seat capacity must be at least 1.");
        }

        return new Journey(
            Guid.NewGuid(),
            driverId,
            vehicleId,
            meetingPoint,
            destination,
            departureAt,
            passengerSeatCapacity);
    }
}

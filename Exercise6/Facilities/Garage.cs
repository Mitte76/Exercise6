using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Exercise6.Vehicles;

namespace Exercise6.Facilities
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
    [JsonDerivedType(typeof(CarGarage), "CarGarage")]
    [JsonDerivedType(typeof(Hangar), "Hangar")]
    [JsonDerivedType(typeof(Marina), "Marina")]
    [JsonDerivedType(typeof(MCGarage), "MCGarage")]
    internal abstract class Garage
    {
        public abstract List<VehicleType> VehicleTypes { get; }

        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public int OccupiedSlots
        {
            get
            {
                int count = 0;
                foreach (ParkingSpot spot in parkingSpots)
                {
                    if (spot.IsOccupied)
                        count++;
                }
                return count;
            }
        }

        public int AvailableSlots
        {
            get
            {
                int count = 0;
                foreach (ParkingSpot spot in parkingSpots)
                {
                    if (!spot.IsOccupied)
                        count++;
                }
                return count;
            }
        }

        private List<ParkingSpot> parkingSpots;

        protected Garage(string name, int capacity)
        {
            parkingSpots = [];
            Capacity = capacity;

            for (int i = 0; i < capacity; i++)
            {
                parkingSpots.Add(new ParkingSpot(i + 1));
            }

            Name = name;
        }

        [JsonInclude]
        public List<ParkingSpot> ParkingSpots
        {
            get => parkingSpots;
            private set => parkingSpots = value;
        }

        public Dictionary<VehicleType, int> GetVehicleTypeCounts()
        {
            var counts = new Dictionary<VehicleType, int>();

            foreach (VehicleType type in VehicleTypes)
            {
                counts[type] = 0;
            }

            foreach (ParkingSpot parkingSpot in ParkingSpots)
            {
                if (parkingSpot.Vehicle is null)
                    continue;

                VehicleType type = parkingSpot.Vehicle switch
                {
                    Car => VehicleType.Car,
                    Bus => VehicleType.Bus,
                    Motorcycle => VehicleType.Motorcycle,
                    Boat => VehicleType.Boat,
                    Airplane => VehicleType.Airplane,
                    _ => throw new ArgumentOutOfRangeException(),
                };

                counts[type]++;
            }

            return counts;
        }

        public ParkingSpot? GetFirstAvailableParkignSpot()
        {
            foreach (ParkingSpot spot in parkingSpots)
            {
                if (!spot.IsOccupied)
                    return spot;
            }
            return null;
        }

        public List<ParkingSpot> GetAllOccupiesSpots()
        {
            List<ParkingSpot> occupiedSpots = [];
            foreach (ParkingSpot parkingSpot in parkingSpots)
            {
                if (parkingSpot.IsOccupied)
                    occupiedSpots.Add(parkingSpot);
            }
            return occupiedSpots;
        }

        public string ParkCar(Vehicle vehicle)
        {
            ParkingSpot? spot = GetFirstAvailableParkignSpot();
            if (spot == null)
                return "No available parking spot found";
            spot.AddVehicle(vehicle);
            return $"Car parked successfully {AvailableSlots} slots available. {OccupiedSlots} Vehicles currenty parked";
        }
    }
}

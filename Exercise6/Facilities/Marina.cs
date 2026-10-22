using System.Collections.Generic;
using Exercise6.Vehicles;

namespace Exercise6.Facilities
{
    internal class Marina(string name, int capacity) : Garage(name, capacity)
    {
        public override List<VehicleType> VehicleTypes => [VehicleType.Boat];
    }
}

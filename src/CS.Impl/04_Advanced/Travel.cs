using System;
using System.Collections.Generic;

namespace CS.Impl._04_Advanced
{
    public class Travel
    {
        public TravelRoadmap BuildTravelRoadmap(City initial, City destination)
        {
            TravelRoadmap travelRoadmap = new TravelRoadmap();
            List<TransportMode> listModes = new List<TransportMode>();

            DistanceHelper distanceHelper = new DistanceHelper();
            switch (distanceHelper.GetDistance(initial, destination))
            {
                case Distance.Short:
                    listModes.Add(TransportMode.Foot);
                    listModes.Add(TransportMode.Car);
                    listModes.Add(TransportMode.Train);
                    break;
                case Distance.Medium:
                    listModes.Add(TransportMode.Car);
                    listModes.Add(TransportMode.Train);
                    listModes.Add(TransportMode.Plane);
                    break;
                case Distance.Long:
                    listModes.Add(TransportMode.Boat);
                    listModes.Add(TransportMode.Plane);
                    break;
            }

            travelRoadmap.Modes = listModes;

            return travelRoadmap;
        }
    }

    public class TravelRoadmap
    {
        public IEnumerable<TransportMode> Modes { get; set; }
    }

    public enum City
    {
        Barcelona,
        London,
        Sydney
    }

    public enum TransportMode
    {
        Foot,
        Car,
        Train,
        Boat,
        Plane
    }

    public class DistanceHelper
    {
        public Distance GetDistance(City initial, City destination)
        {
            if (initial == destination) return Distance.Short;

            if ((initial == City.Barcelona && destination == City.London) || (initial == City.London && destination == City.Barcelona))
                return Distance.Medium;

            return Distance.Long;
        }
    }

    public enum Distance
    {
        Short,
        Medium,
        Long
    }
}
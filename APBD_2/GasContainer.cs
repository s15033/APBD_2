using System;

namespace APBD_2
{
    public class GasContainer : Container, IHazardNotifier
    {
        
        public float atmPressure;
        
        public GasContainer(float height, float nettoWeight, float maxWeight, float depth, float atmPressure, float maxAtmPressure) : 
            base(height, nettoWeight,  maxWeight, depth, "Gas", 'G')
        {
            this.atmPressure = atmPressure;
            this.maxAtmPressure = maxAtmPressure;
        }
        
        public void NotifyHazard(string message, string serialNumber)
        {
            Console.WriteLine("There was a hazard in container " + serialNumber + ": " + message);
        }
        
        
        
    }
}
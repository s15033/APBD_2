using System;

namespace APBD_2
{
    public class GasContainer : Container, IHazardNotifier
    {
        
        private float atmPressure;
        private float maxAtmPressure;
        
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
        
        public void Fill(float weight, float pressure)
        {
            float newPressure = atmPressure + pressure;
            
            if (newPressure > maxAtmPressure)
            {
                NotifyHazard("The pressure is too high!", GetSerialNumber());
            }
            
            this.atmPressure = newPressure;
            
            base.Fill(weight);
        }
        
        public void Unload(float weight, float pressure)
        {
            
            float newPressure = atmPressure - pressure;
            float minAtmPressure = maxAtmPressure * 0.05f;
            float unloadedWeight = weight;
            
            if (newPressure < minAtmPressure)
            {
                NotifyHazard("The pressure is too low!", GetSerialNumber());
                newPressure = minAtmPressure;
                unloadedWeight = weight - (weight * newPressure / pressure);
            }
            
            this.atmPressure = newPressure;
            
            base.Unload(unloadedWeight);
        }
        
        public void Describe()
        {
            base.Describe();
            Console.WriteLine("Gas container with pressure " + atmPressure + " atm.");
        }
    }
}
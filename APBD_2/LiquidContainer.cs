using System;

namespace APBD_2
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        private bool isDangerous;
        
        public LiquidContainer(float height, float nettoWeight, float maxWeight, float depth, bool isDangerous = false) : 
            base(height, nettoWeight,  maxWeight, depth, "Liquid", 'L')
        {
            this.isDangerous = isDangerous;
        }

        public void NotifyHazard(string message, string serialNumber)
        {
            Console.WriteLine("There was a hazard in container " + serialNumber + ": " + message);
        }
        
        public void Fill(float weight)
        {
            float allowedWeight;
            if (isDangerous)
            {
                allowedWeight = maxWeight * 0.5f;
            }
            else
            {
                allowedWeight = maxWeight * 0.9f;
            }
            
            if (loadWeight + weight > allowedWeight)
            {
                NotifyHazard("The container is overfilled!", GetSerialNumber());
            }
            
            base.Fill(weight);
        }
        
        public void Describe()
        {
            base.Describe();
            Console.WriteLine("Liquid container " + (isDangerous ? "(dangerous)." : "(non dangerous)."));
        }
    }
}
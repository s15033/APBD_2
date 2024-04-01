using System;

namespace APBD_2
{
    public abstract class Container
    {
        protected float loadWeight = 0;
        protected float maxWeight;
        private float height;
        protected float nettoWeight;
        private float depth;
        private string serialNumber;
        private string type { get; }
        private char typeLetter;
        
        protected Container(float height, float nettoWeight, float maxWeight, float depth, string type, char typeLetter)
        {
            this.height = height;
            this.nettoWeight = nettoWeight;
            this.depth = depth;
            this.type = type;
            this.typeLetter = typeLetter;
            this.maxWeight = maxWeight;
            ContainerManager.RegisterContainer(this);
        }
        
        public string GetType()
        {
            return type;
        }
        
        public string GetSerialNumber()
        {
            return serialNumber;
        }
        
        public char GetTypeLetter()
        {
            return typeLetter;
        }

        public void SetSerialNumber(string serialNumber)
        {
            this.serialNumber = serialNumber;
        }
        
        public void Fill (float weight)
        {
            if (loadWeight + weight > maxWeight)
            {
                throw new OverfillException(
                    "Cannot fill the container with " + weight + " kg of " + type + ", it would exceed the weight of " + maxWeight + " kg."
                    );
            }
            
            loadWeight += weight;
        }
        
        public void Unload(float weight)
        {
            loadWeight = 0;
        }
        
        
        public class OverfillException : Exception
        {
            public OverfillException(string message) : base(message)
            {
            }
        }
    }
}
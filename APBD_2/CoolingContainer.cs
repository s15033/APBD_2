using System;
using System.Collections.Generic;

namespace APBD_2
{
    public class CoolingContainer : Container
    {
        private string productType;
        private float temperature;
        
        private Dictionary<string, float> requiredTemperatures = new Dictionary<string, float>()
        {
            { "Bananas", 13.3f },
            { "Chocolate", 18f },
            { "Fish", 2f },
            { "Meat", -15f },
            { "Ice cream", -18f },
            { "Frozen pizza", -30f },
            { "Cheese", 7.2f },
            { "Sausages", 5f },
            { "Butter", 20.5f },
            { "Eggs", 19f }
        };
        
         
        public CoolingContainer(float height, float nettoWeight, float maxWeight, float depth, float temperature) :
            base(height, nettoWeight, maxWeight, depth, "Cooling", 'C')
        {
            this.temperature = temperature;
        }
        
        public void Load(float weight, string productType)
        {
            if (!IsEmpty() && this.productType != productType)
            {
                throw new ContainerNotEmptyException("Cannot load a different product type into a container that is not empty.");
            }
            
            float requiredTemperature = getTemperatureForProductType(productType);

            if (temperature < requiredTemperature)
            {
                throw new TemperatureTooLowException(
                    "Cannot load " + productType + " into a container with temperature " + temperature + "°C, required temperature is " + requiredTemperature + "°C."
                    );
            }
            
            base.Fill(weight);
            this.productType = productType;
        }
        
        public void Unload(float weight)
        {
            base.Unload(weight);
            if (IsEmpty())
            {
                this.productType = null;
            }
        }

        public class TemperatureTooLowException : Exception
        {
            public TemperatureTooLowException(string message) : base(message)
            {
            }
        }

        private float getTemperatureForProductType(string type)
        {
            requiredTemperatures.TryGetValue(type, out float temperature);
            return temperature;
        }

        public void setTemperature(float temperature)
        {
            if (loadWeight > 0)
            {
                throw new ContainerNotEmptyException("Cannot change the temperature of a container that is not empty.");
            }
            
            this.temperature = temperature;
        }

        public class ContainerNotEmptyException : Exception
        {
            public ContainerNotEmptyException(string message) : base(message)
            {
            }
        }
        
        public void Describe()
        {
            base.Describe();
            Console.WriteLine("Cooling container with temperature " + temperature + "°C. and product type " +
                              productType);
        }
    }
}
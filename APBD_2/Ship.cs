using System;
using System.Collections.Generic;

namespace APBD_2
{
    public class Ship
    {
        private float maxSpeed;
        static List<Container> containers = new List<Container>();
        private int maxContainers;
        private float maxWeight;
        
        public Ship(float maxSpeed, int maxContainers, float maxWeight)
        {
            this.maxSpeed = maxSpeed;
            this.maxContainers = maxContainers;
            this.maxWeight = maxWeight;
        }
        
        public void AddContainer(Container container)
        {
            if (containers.Count >= maxContainers)
            {
                throw new OverfillException("Cannot add more containers to the ship, it would exceed the limit of " + maxContainers + " containers.");
            }
            
            if (GetTotalWeight() + container.GetLoadWeight() > maxWeight * 1000)
            {
                throw new OverfillException("Cannot add the container to the ship, it would exceed the weight limit of " + maxWeight + " tons.");
            }
            
            containers.Add(container);
        }
        
        public void AddContainers (List<Container> containers)
        {
            foreach (Container container in containers)
            {
                this.AddContainer(container);
            }
        }
        
        public void RemoveContainer(Container container)
        {
            containers.Remove(container);
        }
        
        public void ReplaceContainer(string oldContainerSerialNumber, Container newContainer)
        {
            Container oldContainer = containers.Find(container => container.GetSerialNumber() == oldContainerSerialNumber);
            containers.Remove(oldContainer);
            containers.Add(newContainer);
        }
        
        public void MoveContainerToShip(Container container, Ship ship)
        {
            this.RemoveContainer(container);
            ship.AddContainer(container);
        }

        private float GetTotalWeight()
        {
            float totalWeight = 0;
            foreach (Container container in containers)
            {
                totalWeight += container.GetLoadWeight();
            }
            
            return totalWeight;
        }

        public class OverfillException : Exception
        {
            public OverfillException(string message) : base(message)
            {
            }
        }

        public void Describe()
        {
            Console.WriteLine("Ship with max speed " + maxSpeed + " knots, " + containers.Count + " containers and total weight of " + GetTotalWeight() + " kg.");
            Console.WriteLine("Including containers:");
            foreach (Container container in containers)
            {
                container.Describe();
            }
        }
    }
}
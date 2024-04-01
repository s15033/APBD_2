using System.Collections.Generic;

namespace APBD_2
{
    public class ContainerManager
    {
        static List<Container> containers = new List<Container>();
        
        public static string RegisterContainer(Container container)
        {
            List<Container> containersByType = GetContainersByType(container.GetType());
            
            int nextSerialNumber = containersByType.Count + 1;
            string serialNumber = "KON-" + container.GetTypeLetter() + "-" + nextSerialNumber;
            
            container.SetSerialNumber(serialNumber);
            containers.Add(container);

            return serialNumber;
        }
        
        public static Container GetContainerBySerialNumber(string serialNumber)
        {
            return containers.Find(container => container.GetSerialNumber() == serialNumber);
        }
        
        public static List<Container> GetContainersByType(string type)
        {
            return containers.FindAll(container => container.GetType() == type);
        }
    }
}
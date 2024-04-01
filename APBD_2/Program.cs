using System;

namespace APBD_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            LiquidContainer liquid_container = new LiquidContainer(10, 10, 100, 10, true);
            LiquidContainer liquid_container_2 = new LiquidContainer(10, 10, 100, 10);
            
            liquid_container.Describe();
            liquid_container_2.Describe();
            
            GasContainer gasContainer = new GasContainer(10, 10, 100, 10, 0, 10);
            GasContainer gasContainer_2 = new GasContainer(10, 10, 100, 10, 1, 10);
            
            gasContainer.Describe();
            gasContainer_2.Describe();
            
            liquid_container.Fill(50);
            liquid_container.Fill(10);
            liquid_container.Fill(35);
            
            liquid_container_2.Fill(50);
            liquid_container_2.Fill(10);
            
            gasContainer.Fill(50, 5);
            gasContainer.Fill(50, 5);
            gasContainer.Unload(100, 10);
            gasContainer.Describe();

            try
            {
                gasContainer_2.Fill(500, 5);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            CoolingContainer coolingContainer = new CoolingContainer(10, 10, 100, 10, 0);
            coolingContainer.Describe();
            
            coolingContainer.Load(50, "Meat");
            coolingContainer.Describe();

            try
            {
                coolingContainer.setTemperature(-30);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                coolingContainer.Load(50, "Bananas");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            coolingContainer.Unload(50);
            
            try
            {
                coolingContainer.Load(50, "Bananas");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            coolingContainer.setTemperature(13.3f);
            
            coolingContainer.Load(50, "Bananas");
            coolingContainer.Describe();
            
            Ship ship = new Ship(100, maxContainers: 5, maxWeight: 1);
            
            ship.AddContainer(liquid_container);
            ship.Describe();
            
            ship.AddContainers(new System.Collections.Generic.List<Container> {liquid_container_2, gasContainer, coolingContainer});
            
            ship.Describe();
            
            LiquidContainer liquid_container_3 = new LiquidContainer(10, 10, 3000, 10);
            liquid_container_3.Fill(2300);
            
            try
            {
                ship.AddContainer(liquid_container_3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Ship ship_2 = new Ship(100, maxContainers: 1, maxWeight: 1);

            try
            {
                ship.MoveContainerToShip(liquid_container, ship_2);
                ship.MoveContainerToShip(gasContainer, ship_2);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            ship.Describe();
            
            LiquidContainer liquid_container_4 = new LiquidContainer(10, 10, 100, 10);
            
            ship.ReplaceContainer(liquid_container_2.GetSerialNumber(), liquid_container_4);
            
            ship.Describe();

            

            






        }
    }
}
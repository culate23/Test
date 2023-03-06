using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Logic
{
    public class Test
    {
        public string cnn = "";

        public List<Model.Output> calcularCosto(int units, int hours)
        {
            List<Model.Output> Listoutput = new List<Model.Output>();

            List<Model.Region> regions = new Logic.Region().GetRegions(cnn);

            foreach (Model.Region region in regions)
            {
                float total = 0;
                List<Model.RegionType> regionTypes = new Logic.RegionType().GetRegions(cnn, "Where rt.idRegion = " + region.IdRegion).OrderByDescending(x => x.IdCapacityType).ToList();

                List<Model.Machines> machines = calculaUnidades(regionTypes, units);

                Model.Output output = new Model.Output();
                string regionNombre = "";

                foreach (Model.Machines machine in machines)
                {
                    
                    float costo = 0;
                    

                    foreach (Model.RegionType item in regionTypes)
                    {
                        if (machine.Name.Equals(item.CapacityName))
                        {
                            costo = item.Cost;
                            regionNombre = item.RegionName;

                            total += costo * machine.Quantity * hours;

                            break;
                        }
                        
                    }

                }
                output.Total_cost = total;
                output.Machines = machines;
                output.Region = regionNombre;

                Listoutput.Add(output);

            }

            return Listoutput;
        }

        public List<Model.Machines> calculaUnidades(List<Model.RegionType> regionTypes, int unit)
        {
            List<Model.Machines> capacity = new List<Model.Machines>();

            int unitadesRestantes = unit;
           

            foreach (Model.RegionType item in regionTypes)
            {
                int cantidad = 0;
                Model.CapacityType capacityTypes = new Logic.CapacityType().GetcapacityTypes(cnn, "Where idTipoCapacidad = " + item.IdCapacityType)[0];
                Model.Machines machines = new Model.Machines();

                if (capacityTypes.QuantityUnits <= unitadesRestantes)
                {
                    while(capacityTypes.QuantityUnits <= unitadesRestantes)
                    {
                        unitadesRestantes -= capacityTypes.QuantityUnits;

                        cantidad += 1;
                    }
                }

                if (cantidad > 0)
                {
                    machines.Name = item.CapacityName;
                    machines.Quantity = cantidad;
                    capacity.Add(machines);
                }
                
            }
            
            return capacity;
        }
    }
}

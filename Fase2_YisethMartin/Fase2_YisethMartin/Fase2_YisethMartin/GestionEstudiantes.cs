using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase2_YisethMartin
{
    public class GestionEstudiantes
    {

        public string Identificacion { get; set; }
        public string Nombre {  get; set; }
        public string Genero { get; set; }
        public string Instrumento {  get; set; }
        public int NumeroClases {  get; set; }
        public DateTime FechaRegistro {  get; set; }
        //public decimal Costo {  get; set; }
        //public decimal TotalMatricula {  get; set; }


        public double CostoPorClase
        {
            get
            {
                if (Instrumento == "Piano")
                {
                    return 100000;
                }
                else if(Instrumento == "Guitarra")
                {
                    return 80000;
                }
                else if (Instrumento == "Violín")
                {
                    return 90000;
                }
                else if (Instrumento == "Batería")
                {
                    return 85000;
                }
                else if (Instrumento == "Canto")
                {
                    return 95000;
                }
                //else
                //{
                    return 0;
                //}
            }
        }

        public double CalcularCostoTotal()
        {
            return CostoPorClase* NumeroClases;
        }
        


        
    }
}

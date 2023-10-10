using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoAvaliativo1
{
    internal class Angulo
    {
        public int Graus { get; set; }
        public int Minutos { get; set; }
        public int Segundos { get; set; }

        public override string ToString()
        {
            return  Graus+ "º " + Minutos + "´ " + Segundos + "´´";
        }

    } 
}

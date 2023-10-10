using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrabalhoAvaliativo1
{
    internal class Estacao
    {
        public Angulo AngEstacao { get; set; }
        public Angulo Azimute { get; set; }
        public float Distancia { get; set; }
        public Deflex Deflexao;

        public override string ToString()
        {
            return AngEstacao.ToString() + " - " + Distancia + " - " + Deflexao;
        }

    }

    public enum Deflex
    {
        D,
        E
    }
}

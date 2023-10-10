using System.Collections.Generic;

namespace TrabalhoAvaliativo1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Poligonal poligonal = new Poligonal
            {
                Descricao = "Fazenda Rio Verde",
                AzGraus = 225,
                AzMinutos = 32,
                AzSegundos = 48,
                Estacoes = new List<Estacao>()
            };
            ConsoleKeyInfo keyInfo;

            double totalPag = 1;
            int pag = 1;
            string nomeArquivo = null;

            do
            {

                if (poligonal.GetCount() > 10)
                {
                    totalPag = Math.Ceiling(poligonal.GetCount() / 10.0);
                }
                else { totalPag = 1; };

                Console.Clear();
                DateTime dataAtual = DateTime.Now;
                string dataFormatada = dataAtual.ToString("dd/MM/yyyy");
                var linha = new String('=', Console.WindowWidth - 1);
                Console.WriteLine(linha);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Engenharia Cartográfica \t\t\t Sistema de Poligonais \t\t\t Data: "+dataFormatada);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(linha);
                Console.WriteLine($"Poligonal: {poligonal.Descricao}");
                Console.WriteLine(linha);
                Console.WriteLine("Estação\t\tÂngulo lido\t\tDeflexão\t\t\tDistância(m)\t\t\tAzimute");

                poligonal.Listar(pag);

                Console.SetCursorPosition(0, Console.WindowHeight - 4);
                Console.WriteLine("\n" + linha);
                Console.Write($"Perímetro: {poligonal.Perimetro()} metros");
                Console.WriteLine("\t\t\t\t\t\t\t\t\t\t    Pag.: "+pag+" de "+totalPag);
                Console.Write("<Esc> Sair \t\t ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("<F1> Inserir \t\t");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("<F2> Alterar \t\t");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("<F3> Excluir \t\t\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("<PgDn>  <PgUp>");

                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.F1:
                        poligonal.Inserir();
                        break;

                    case ConsoleKey.F2:
                        poligonal.Editar();
                        break;

                    case ConsoleKey.F3:
                        poligonal.Excluir();
                        break;

                    case ConsoleKey.PageDown:
                        if(pag > 1)
                        {
                            pag--;
                        }
                        break;

                    case ConsoleKey.PageUp:
                        if(pag < totalPag)
                        {
                            pag++;
                        }
                        break;

                    case ConsoleKey.S when keyInfo.Modifiers == ConsoleModifiers.Control:
                        nomeArquivo = poligonal.SalvaArquivo(nomeArquivo);
                        break;

                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
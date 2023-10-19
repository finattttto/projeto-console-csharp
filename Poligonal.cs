using System;
using System.Collections.Generic;

namespace TrabalhoAvaliativo1
{
    internal class Poligonal
    {
        public string Descricao { get; set; }
        public int AzGraus { get; set; }
        public int AzMinutos { get; set; }
        public int AzSegundos { get; set; }
        public List<Estacao> Estacoes { get; set; }

        public Poligonal()
        {
            Estacoes = new List<Estacao>();
        }

        public float Perimetro()
        {
            float cont = 0;
            foreach (var e in Estacoes)
            {
                cont += e.Distancia;
            }
            return cont;
        }

        public List<Estacao> GetEstacoes()
        {
            return Estacoes;
        }

        public void Inserir()
        {
            Console.Clear();
            Estacao estacao = new Estacao();
            bool entradaValida = false;

            while (!entradaValida)
            {
                Console.Write("Distancia: ");
                if (float.TryParse(Console.ReadLine(), out float valor))
                {
                    entradaValida = true;
                    estacao.Distancia = valor;
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido!");
                }
            }




            entradaValida = false;
            Deflex deflexao;
            while (!entradaValida)
            {
                Console.Write("Digite a deflexão (D ou E): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out _))
                {
                    Console.WriteLine("Entrada inválida.");
                }
                else if (Enum.TryParse(input.ToUpper(), out deflexao))
                {
                    entradaValida = true;
                    Console.WriteLine("Deflexão inserida: " + deflexao);
                    estacao.Deflexao = deflexao;
                }
                else
                {
                    Console.WriteLine("Deflexão inválida. Insira D ou E.");
                }
            }

            Angulo angEstacao = new Angulo();


            entradaValida = false;
            while (!entradaValida)
            {
                Console.Write("Graus da estação: ");
                if (int.TryParse(Console.ReadLine(), out int graus))
                {
                    if (graus >= 0 && graus <= 360)
                    {
                        entradaValida = true;
                        angEstacao.Graus = graus;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número válido (0º a 360º)!");

                    }
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número!");
                }
            }

            entradaValida = false;
            while (!entradaValida)
            {
                Console.Write("Minutos da estação: ");
                if (int.TryParse(Console.ReadLine(), out int minutos))
                {
                    if (minutos >= 0 && minutos <= 60)
                    {
                        entradaValida = true;
                        angEstacao.Minutos = minutos;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número válido (0 a 60)!");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número!");
                }

            }



            entradaValida = false;
            while (!entradaValida)
            {
                Console.Write("Segundos da estação: ");
                if (int.TryParse(Console.ReadLine(), out int segundos))
                {
                    if (segundos >= 0 && segundos <= 60)
                    {
                        entradaValida = true;
                        angEstacao.Segundos = segundos;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número válido (0 a 60)!");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número!");
                }

            }


            estacao.AngEstacao = angEstacao;

            Angulo azimute = new Angulo();

            if (Estacoes.Count == 0)
            {
                azimute.Graus = AzGraus;
                azimute.Minutos = AzMinutos;
                azimute.Segundos = AzSegundos;
            }
            else
            {
                azimute = CalculaAzimute(estacao);
            }

            estacao.Azimute = azimute;

            Estacoes.Add(estacao);
        }

        public void Editar()
        {

            if(Estacoes.Count == 0)
            {
                return;
            }

            Console.Write("\n\nDigite o número da estação a ser editada: ");
            int.TryParse(Console.ReadLine(), out int uuid);

            var id = uuid - 1;

            if (id >= 0 && id < Estacoes.Count)
            {
                Console.Clear();

                var linha = new String('-', Console.WindowWidth - 1);
                Console.WriteLine(linha);
                Console.WriteLine("Estação\t\tÂngulo lido\t\tDeflexão\t\t\tDistância(m)\t\t\tAzimute");
                Imprimir(id);
                Console.WriteLine(linha);

                bool entradaValida = false;


                while (!entradaValida)
                {
                    Console.Write("Distancia: ");
                    if (float.TryParse(Console.ReadLine(), out float novoValor))
                    {
                        entradaValida = true;
                        Estacoes[id].Distancia = novoValor;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número!");
                    }
                }


                entradaValida = false;
                Deflex deflexao;
                while (!entradaValida)
                {
                    Console.Write("Digite a deflexão (D ou E): ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out _))
                    {
                        Console.WriteLine("Entrada inválida.");
                    }
                    else if (Enum.TryParse(input.ToUpper(), out deflexao))
                    {
                        entradaValida = true;
                        Console.WriteLine("Deflexão inserida: " + deflexao);
                        Estacoes[id].Deflexao = deflexao;
                    }
                    else
                    {
                        Console.WriteLine("Deflexão inválida. Insira D ou E.");
                    }
                }


                entradaValida = false;
                while (!entradaValida)
                {
                    Console.Write("Graus da estação: ");
                    if (int.TryParse(Console.ReadLine(), out int graus))
                    {
                        if (graus >= 0 && graus <= 360)
                        {
                            entradaValida = true;
                            Estacoes[id].AngEstacao.Graus = graus;
                        }
                        else
                        {
                            Console.WriteLine("Por favor, digite um número válido (0º a 360º)!");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número!");
                    }
                }

                entradaValida = false;
                while (!entradaValida)
                {
                    Console.Write("Minutos da estação: ");
                    if (int.TryParse(Console.ReadLine(), out int minutos))
                    {
                        if (minutos >= 0 && minutos <= 60)
                        {
                            entradaValida = true;
                            Estacoes[id].AngEstacao.Minutos = minutos;
                        }
                        else
                        {
                            Console.WriteLine("Por favor, digite um número válido (0 a 60)!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número!");
                    }

                }



                entradaValida = false;
                while (!entradaValida)
                {
                    Console.Write("Segundos da estação: ");
                    if (int.TryParse(Console.ReadLine(), out int segundos))
                    {
                        if (segundos >= 0 && segundos <= 60)
                        {
                            entradaValida = true;
                            Estacoes[id].AngEstacao.Segundos = segundos;
                        }
                        else
                        {
                            Console.WriteLine("Por favor, digite um número válido (0 a 60)!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite um número!");
                    }

                }

                if (id == 0)
                {
                    Estacoes[id].Azimute.Graus = AzGraus;
                    Estacoes[id].Azimute.Minutos = AzMinutos;
                    Estacoes[id].Azimute.Segundos = AzSegundos;
                    id++;
                }

                RecalculaAzimute(id);

            }
            else
            {
                Console.WriteLine("ID de estação inválido.");
            }
        }

        public void Excluir()
        {

            if (Estacoes.Count == 0)
            {
                return;
            }

            Console.Write("\n\nDigite o número da estação a ser excluída: ");
            int.TryParse(Console.ReadLine(), out int uuid);

            var id = uuid - 1;

            if (id >= 0 && id < Estacoes.Count)
            {
                Console.Clear();
                var linha = new String('-', Console.WindowWidth - 1);
                Console.WriteLine(linha);
                Console.WriteLine("Estação\t\tÂngulo lido\t\tDeflexão\t\t\tDistância(m)\t\t\tAzimute");
                Imprimir(id);
                Console.WriteLine(linha);

                Console.Write("Deseja mesmo excluir? S ou N:  ");
                string opcao = Console.ReadLine();

                if (opcao != null && opcao.ToUpper().Equals("S"))
                {
                    Estacoes.RemoveAt(id);

                    if (Estacoes.Count == 0)
                    {
                        Console.Write("Estação excluida! Digite enter para continuar.");
                        Console.ReadLine();
                        return;
                    }

                    if (id == 0)
                    {
                        Estacoes[id].Azimute.Graus = AzGraus;
                        Estacoes[id].Azimute.Minutos = AzMinutos;
                        Estacoes[id].Azimute.Segundos = AzSegundos;
                        id++;
                    }

                    RecalculaAzimute(id);

                    Console.Write("Estação excluida! Digite enter para continuar.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.Write("ID de estação inválido. Digite enter para continuar.");
                Console.ReadLine();
            }
        }

        public void Listar(int pag)
        {
            int start = 0;
            if (pag > 1) { start = (pag - 1) * 10; };
            for (int i = start; i < start + 10; i++)
            {
                if (i < Estacoes.Count)
                {
                    Imprimir(i);
                }
                else { Console.WriteLine(""); };
            }
        }

        public void Imprimir(int id)
        {
            Console.WriteLine($"{(id + 1).ToString("D3")}\t\t{Estacoes[id].AngEstacao.ToString()}\t\t{Estacoes[id].Deflexao}\t\t\t\t{Estacoes[id].Distancia}\t\t\t\t{Estacoes[id].Azimute.ToString()}");
        }

        public int GetCount()
        {
            return Estacoes.Count;
        }

        public Angulo CalculaAzimute(Estacao estacao)
        {
            var x = Estacoes.Count - 1;
            Angulo azimute = new Angulo();

            if (estacao.Deflexao.Equals("D"))
            {
                azimute.Segundos = Estacoes[x].Azimute.Segundos + Estacoes[x].AngEstacao.Segundos;
                if (azimute.Segundos > 60)
                {
                    azimute.Minutos = 1 + Estacoes[x].Azimute.Minutos + Estacoes[x].AngEstacao.Minutos;
                    azimute.Segundos -= 60;
                }
                else
                {
                    azimute.Minutos = Estacoes[x].Azimute.Minutos + Estacoes[x].AngEstacao.Minutos;
                }

                if (azimute.Minutos > 60)
                {
                    azimute.Graus = 1 + Estacoes[x].Azimute.Graus + Estacoes[x].AngEstacao.Graus;
                    azimute.Minutos -= 60;
                }
                else
                {
                    azimute.Graus = Estacoes[x].Azimute.Graus + Estacoes[x].AngEstacao.Graus;
                }

                if (azimute.Graus > 359)
                {
                    azimute.Graus -= 360;
                }
            }
            else
            {
                azimute.Segundos = Estacoes[x].Azimute.Segundos - Estacoes[x].AngEstacao.Segundos;
                if (azimute.Segundos < 0)
                {
                    azimute.Minutos = Estacoes[x].Azimute.Minutos + Estacoes[x].AngEstacao.Minutos - 1;
                    azimute.Segundos += 60;
                }
                else
                {
                    azimute.Minutos = Estacoes[x].Azimute.Minutos - Estacoes[x].AngEstacao.Minutos;
                }

                if (azimute.Minutos < 0)
                {
                    azimute.Graus = Estacoes[x].Azimute.Graus - Estacoes[x].AngEstacao.Graus - 1;
                    azimute.Minutos += 60;
                }
                else
                {
                    azimute.Graus = Estacoes[x].Azimute.Graus - Estacoes[x].AngEstacao.Graus;
                }

                if (azimute.Graus < 0)
                {
                    azimute.Graus += 360;
                }
            }

            return azimute;
        }

        public void RecalculaAzimute(int start)
        {
            for(int i = start; i < Estacoes.Count; i++)
            {
                int x = i - 1;
                if (Estacoes[i].Deflexao.Equals("D"))
                {
                    Estacoes[i].Azimute.Segundos = Estacoes[x].Azimute.Segundos + Estacoes[x].AngEstacao.Segundos;
                    if (Estacoes[i].Azimute.Segundos > 60)
                    {
                        Estacoes[i].Azimute.Minutos = 1 + Estacoes[x].Azimute.Minutos + Estacoes[x].AngEstacao.Minutos;
                        Estacoes[i].Azimute.Segundos -= 60;
                    }
                    else
                    {
                        Estacoes[i].Azimute.Minutos = Estacoes[x].Azimute.Minutos + Estacoes[x].AngEstacao.Minutos;
                    }

                    if (Estacoes[i].Azimute.Minutos > 60)
                    {
                        Estacoes[i].Azimute.Graus = 1 + Estacoes[x].Azimute.Graus + Estacoes[x].AngEstacao.Graus;
                        Estacoes[i].Azimute.Minutos -= 60;
                    }
                    else
                    {
                        Estacoes[i].Azimute.Graus = Estacoes[x].Azimute.Graus + Estacoes[x].AngEstacao.Graus;
                    }

                    if (Estacoes[i].Azimute.Graus > 359)
                    {
                        Estacoes[i].Azimute.Graus -= 360;
                    }
                }
                else
                {
                    Estacoes[i].Azimute.Segundos = Estacoes[x].Azimute.Segundos - Estacoes[x].AngEstacao.Segundos;
                    if (Estacoes[i].Azimute.Segundos < 0)
                    {
                        Estacoes[i].Azimute.Minutos = Estacoes[x].Azimute.Minutos + Estacoes[x].AngEstacao.Minutos - 1;
                        Estacoes[i].Azimute.Segundos += 60;
                    }
                    else
                    {
                        Estacoes[i].Azimute.Minutos = Estacoes[x].Azimute.Minutos - Estacoes[x].AngEstacao.Minutos;
                    }

                    if (Estacoes[i].Azimute.Minutos < 0)
                    {
                        Estacoes[i].Azimute.Graus = Estacoes[x].Azimute.Graus - Estacoes[x].AngEstacao.Graus - 1;
                        Estacoes[i].Azimute.Minutos += 60;
                    }
                    else
                    {
                        Estacoes[i].Azimute.Graus = Estacoes[x].Azimute.Graus - Estacoes[x].AngEstacao.Graus;
                    }

                    if (Estacoes[i].Azimute.Graus < 0)
                    {
                        Estacoes[i].Azimute.Graus += 360;
                    }
                }
            }
        }

        public string SalvaArquivo(string nomeArquivo)
        {
            bool exist = false;
            if (nomeArquivo == null)
            {
                while (nomeArquivo == null)
                {
                    Console.Clear();
                    Console.Write("Digite o nome do arquivo: ");
                    nomeArquivo = Console.ReadLine();
                }
            }
            else
            {
                exist = true;
            }

            try
            {
                using (StreamWriter sw = File.CreateText(nomeArquivo + ".txt"))
                {
                    sw.WriteLine($"Poligonal: {Descricao}; Azimute: {AzGraus}º {AzMinutos}´ {AzSegundos}´´; Perimetro: {Perimetro()}\n");
                    int id = 1;
                    foreach (var estacao in Estacoes)
                    {
                        sw.WriteLine($"Estação: {id.ToString("D3")}; " +
                            $"Ângulo Lido: {estacao.AngEstacao.ToString()}; " +
                            $"Deflexão: {estacao.Deflexao}; " +
                            $"Distancia (m): {estacao.Distancia}; " +
                            $"Azimute: {estacao.Azimute.ToString()};");
                        id++;
                    }

                    Console.Clear();
                    Console.WriteLine("Dados salvos com sucesso.");
                    Console.WriteLine("\nDigite enter para continuar.");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Erro ao salvar os dados: " + e.Message);
                Console.WriteLine("\nDigite enter para continuar.");
                Console.ReadLine();
            }

            return nomeArquivo;
        }
    }
}

using CauaTobiasDeSouzaProenca.Models;

public class Sanepar
{
    public int id { get; set; }

    public string cpf { get; set; } = string.Empty;

    public int mes { get; set; }

    public int ano { get; set; }

    public double m3consumidos { get; set; }

    public string bandeira { get; set; } = string.Empty;

    public bool possuiEsgoto { get; set; }

    public double consumoFaturado { get; set; }

    public double tarifa { get; set; }

    public double valorAgua { get; set; }

    public double adicionalBandeira { get; set; }

    public double taxaEsgoto { get; set; }

    public double total { get; set; }


    // Cálculo 1
    public static double ConsumoMinimo(double m3consumidos, double consumoFaturado = 0)
    {
        if (m3consumidos < 10)
        {
            consumoFaturado = 10;
        }
        else
        {
            consumoFaturado = m3consumidos;
        }

        return consumoFaturado;
    }
    public static int GerarId(AppDataContext ctx)
    {
        /*

        Autor: Vitor Baraçal e Cauã Tobias
        Data de Criação: 20/10/2025
        Descrição: Metodo responsavel por gerar um ID para a tabela Sanepar.
        Args: ctx(AppDataContext)
        Return: id(int)

        */

        if (!ctx.Sanepar.Any())
        {
            return 1;
        }
        return ctx.Sanepar.Max(e => e.id) + 1;
    }

    public static Sanepar criarRegistro(string cpf, int mes, int ano, double m3consumidos, string bandeira, bool possuiEsgoto, double consumoFaturado = 0, double tarifa = 0, double adicionalBandeira = 0, double taxaEsgoto = 0, double valorAgua = 0, double total = 0)
    {
        /*

        Autor: Vitor Baraçal e Cauã Tobias
        Data de Criação: 20/10/2025
        Descrição: Metodo responsavel por criar uma leitura para a tabela Sanepar.
        Args: ctx(AppDataContext)
        Return: Sanepar(Sanepar)

        */

        // Cálculo 2
        consumoFaturado = ConsumoMinimo(m3consumidos);

        if (consumoFaturado == 10)
        {
            tarifa = 2.50;

        }
        else if (consumoFaturado > 11 && consumoFaturado < 21)
        {
            tarifa = 3.50;
        }
        else if (consumoFaturado > 20 && consumoFaturado < 51)
        {
            tarifa = 5;
        }
        else if (consumoFaturado > 50)
        {
            tarifa = 6.50;
        }

        // Cálculo 3
        if (bandeira.ToLower() == "verde")
        {
            adicionalBandeira = 0;
        }
        else if (bandeira.ToLower() == "amarela")
        {
            adicionalBandeira = 0.10;
        }
        else if (bandeira.ToLower() == "vermelha")
        {
            adicionalBandeira = 0.20;
        }

        // Cálculo Valor Água
        valorAgua = consumoFaturado * tarifa;

        // Cálculo 4
        if (possuiEsgoto == true)
        {
            taxaEsgoto = (valorAgua + (valorAgua * adicionalBandeira)) * 0.80;
        }
        else if (possuiEsgoto == false)
        {
            taxaEsgoto = 0;
        }

        // Cálculo 5
        total = valorAgua + adicionalBandeira + taxaEsgoto;

        return new Sanepar
        {

            cpf = cpf,
            mes = mes,
            ano = ano,
            m3consumidos = m3consumidos,
            consumoFaturado = consumoFaturado,
            tarifa = tarifa,
            valorAgua = valorAgua,
            adicionalBandeira = adicionalBandeira,
            taxaEsgoto = taxaEsgoto,
            total = total

        };

    }

    public static void DeletarRegistro(AppDataContext ctx, string cpf, int mes, int ano)
    {
        var saneparCpf = ctx.Sanepar.Find(cpf);
        var saneparMes = ctx.Sanepar.Find(mes);
        var saneparAno = ctx.Sanepar.Find(ano);
        
        if (saneparCpf is not null && saneparMes is not null && saneparAno is not null)
        {
            ctx.Sanepar.Remove(saneparCpf);
            ctx.SaveChanges();
        }        
    }
}
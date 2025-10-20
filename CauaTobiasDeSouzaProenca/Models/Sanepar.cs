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

    public static Sanepar criarRegistro (string cpf, int mes, int ano, double m3consumidos, string bandeira, bool possuiEsgoto)
    {
        /*

        Autor: Vitor Baraçal e Cauã Tobias
        Data de Criação: 20/10/2025
        Descrição: Metodo responsavel por criar uma leitura para a tabela Sanepar.
        Args: ctx(AppDataContext)
        Return: Sanepar(Sanepar)

        */

        return new Sanepar
        {

            cpf = cpf,
            mes = mes,
            ano = ano,
            m3consumidos = m3consumidos,
            bandeira = bandeira,
            possuiEsgoto = possuiEsgoto

        };
    }
}
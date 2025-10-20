/**

 * Autor: Vitor Baraçal e Cauã Tobias
 * Data de Criação: 20/10/2025
 * Descrição: Endpoints para CRUD da Sanepar

**/

using Microsoft.AspNetCore.Mvc;
using CauaTobiasDeSouzaProenca.Models;

namespace CauaTobiasDeSouzaProenca.Controllers

{
    public static class EndpointSanepar
    {
        public static void MapEndpointsSanepar(this WebApplication app)
        {

            app.MapGet("/api/consumo/listar", ([FromServices] AppDataContext ctx) =>
            {
                if (ctx.Sanepar.Any())
                {
                    return Results.Ok(ctx.Sanepar.ToList());
                }

                return Results.NotFound("Nenhum registro foi encontrado!");
            });

            app.MapPost("/api/consumo/cadastrar", ([FromBody] Sanepar sanepar, [FromServices] AppDataContext ctx) =>
            {
                /*

                Autor: Vitor Baraçal e Cauã Tobias
                Data de Criação: 20/10/2025
                Descrição: Endpoint Post para cadastrar um registro de leitura.
                Args: sanepar(Sanepar), ctx(AppDataContext)
                Return: Results.Created("", novoRegistro) ou Results.Conflict("Esse endereço já existe!")

                */

                if (sanepar.id != 0)
                {
                    Sanepar? resultado = ctx.Sanepar.FirstOrDefault(x => x.id == sanepar.id);

                    if (resultado is not null)
                    {
                        return Results.Conflict("Esse endereço já existe!");
                    }
                }

                // if (sanepar.mes > 1 && sanepar.mes < 12 && sanepar.ano > 2000 && sanepar.m3consumidos > 0)
                // {

                // }

                Sanepar novoRegistro = Sanepar.criarRegistro(sanepar.cpf, sanepar.mes, sanepar.ano, sanepar.m3consumidos, sanepar.bandeira, sanepar.possuiEsgoto);

                ctx.Sanepar.Add(novoRegistro);
                ctx.SaveChanges();

                return Results.Created("", novoRegistro);

            });
        }
    }
}
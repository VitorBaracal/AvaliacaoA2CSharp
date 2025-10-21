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

            app.MapGet("/api/consumo/buscar/{cpf}/{mes}/{ano}", ([FromServices] AppDataContext ctx, string cpf, int mes, int ano) =>
            {

                var registro = ctx.Sanepar.FirstOrDefault(x => x.cpf == cpf && x.mes == mes && x.ano == ano);

                if (registro is not null)
                {
                    return Results.Ok(registro);
                }
                else
                {
                    return Results.NotFound("Registro não encontrado para os parâmetros fornecidos.");
                }
            });

            app.MapGet("/api/consumo/total-geral", ([FromServices] AppDataContext ctx) =>
            {
                if (ctx.Sanepar.Any())
                {
                    return Results.Ok(ctx.Sanepar.FirstOrDefault());
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
                        return Results.Conflict("Esse registro de Id já existe!");
                    }
                }

                Sanepar? resultadoGeral = ctx.Sanepar.FirstOrDefault(x => x.cpf == sanepar.cpf && x.mes == sanepar.mes && x.ano == sanepar.ano);

                if (resultadoGeral != null)
                {
                    return Results.Conflict("Esse registro de CPF, Mês e Ano já existe!");
                }
                else
                {

                    Sanepar novoRegistro = Sanepar.criarRegistro(sanepar.cpf, sanepar.mes, sanepar.ano, sanepar.m3consumidos, sanepar.bandeira, sanepar.possuiEsgoto);

                    ctx.Sanepar.Add(novoRegistro);
                    ctx.SaveChanges();

                    return Results.Created("", novoRegistro);
                }

            });
            
            app.MapDelete("/api/consumo/remover/{cpf}/{mes}/{ano}", ([FromRoute] string cpf, int ano, int mes, [FromServices] AppDataContext ctx) =>
            {

              Sanepar? resultado = ctx.Sanepar.Find(cpf, ano, mes);

              if (resultado is null)
              {
                  return Results.NotFound("Cpf , ano e mês! Não encontrados");
              }

              Sanepar.DeletarRegistro(ctx, cpf, mes, ano);
              return Results.Ok(resultado);
          });
        }
    }
}
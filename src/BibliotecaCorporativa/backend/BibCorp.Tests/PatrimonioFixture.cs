using BibCorp.Application.Dto.Patrimonios;
using BibCorp.Domain.Models.Patrimonios;
using Bogus;

namespace BibCorp.Tests
{
  public class PatrimonioFixture
  {
    Faker faker =new Faker();
    public List<Patrimonio> ObterPatrimoniosMock()
    {
      return new List<Patrimonio> {
        new Patrimonio {
          Id = 1,
          Localizacao = "Matriz",
          Sala = null,
          Coluna = null,
          Prateleira = null,
          Posicao = null,
          ISBN = "9788532519474",
          //Origem = "Doação",
          //DetalheOrgiem = null,
          //Ativo = true,
          DataCadastro = faker.Date.Recent().ToString(),
          DataAtualizacao = faker.Date.Recent().ToString(),
          DataIndisponibilidade = null
        },
        new Patrimonio {
          Id = 2,
          Localizacao = "Matriz",
          Sala = null,
          Coluna = null,
          Prateleira = null,
          Posicao = null,
          ISBN = "9788532530844",
          //Origem = "Doação",
          //DetalheOrgiem = null,
          //Ativo = true,
          DataCadastro = faker.Date.Recent().ToString(),
          DataAtualizacao = faker.Date.Recent().ToString(),
          DataIndisponibilidade = null
        }
      };
    }

    public Patrimonio ObterApenasUmPatrimonioMock(int patrimonioId)
    {
      if (patrimonioId == 7) {
        return new Patrimonio {
          Id = 7,
          Localizacao = "Matriz",
          Sala = "77",
          Coluna = "177",
          Prateleira = "2207",
          Posicao = null,
          ISBN = "9788532530844",
          //Origem = "Compra",
          //DetalheOrgiem = null,
          //Ativo = false,
          DataCadastro = faker.Date.Recent().ToString(),
          DataAtualizacao = faker.Date.Recent().ToString(),
          DataIndisponibilidade = null
        };
      }

      return null;
    }
    public List<Patrimonio> ObterListaVaziaDePatrimoniosMock()
    {
      return new List<Patrimonio> { };
    }

    public Patrimonio CriarPatrimonioValidoMock()
    {
      return new Patrimonio {
        Id = 26,
        Localizacao = "Matriz",
        Sala = "77",
        Coluna = "177",
        Prateleira = "2207",
        Posicao = null,
        ISBN = "9788532530844",
        //Origem = "Compra",
        //DetalheOrgiem = null,
        //Ativo = true,
        DataCadastro = faker.Date.Recent().ToString(),
        DataAtualizacao = faker.Date.Recent().ToString(),
        DataIndisponibilidade = null
      };

    }

    public PatrimonioDto CriarPatrimonioValidoDtoMock()
    {
      return new PatrimonioDto {
        Id = 26,
        Localizacao = "Matriz",
        Sala = "77",
        Coluna = "177",
        Prateleira = "2207",
        Posicao = null,
        ISBN = "9788532530844",
        //Origem = "Compra",
        //DetalheOrgiem = null,
        //Ativo = true,
        DataCadastro = faker.Date.Recent().ToString(),
        DataAtualizacao = faker.Date.Recent().ToString(),
        DataIndisponibilidade = null
      };
    }

    public Patrimonio ObtePatrimonioCriadoMock(int patrimonioId)
    {
      if (patrimonioId == 26) {
        return new Patrimonio {
         Id = 26,
         Localizacao = "Matriz",
         Sala = "77",
         Coluna = "177",
         Prateleira = "2207",
         Posicao = null,
         ISBN = "9788532530844",
         //Origem = "Compra",
         //DetalheOrgiem = null,
         //Ativo = true,
         DataCadastro = faker.Date.Recent().ToString(),
         DataAtualizacao = faker.Date.Recent().ToString(),
         DataIndisponibilidade = null
       };
      }

      return null;
    }

    public Patrimonio CriarPatrimonioInvalidoMock()
    {
      return new Patrimonio {
        Localizacao = "Matriz",
        Sala = "77",
        Coluna = "177",
        Prateleira = "2207",
        Posicao = null,
        ISBN = "9788532530844",
        //Origem = "Compra",
        //DetalheOrgiem = null,
        //Ativo = true,
        DataCadastro = faker.Date.Recent().ToString(),
        DataAtualizacao = faker.Date.Recent().ToString(),
        DataIndisponibilidade = null
      };
    }

    public PatrimonioDto CriarPatrimonioInvalidoDtoMock()
    {
      return new PatrimonioDto {
        Localizacao = "Matriz",
        Sala = "77",
        Coluna = "177",
        Prateleira = "2207",
        Posicao = null,
        ISBN = "9788532530844",
        //Origem = "Compra",
        //DetalheOrgiem = null,
        //Ativo = true,
        DataCadastro = faker.Date.Recent().ToString(),
        DataAtualizacao = faker.Date.Recent().ToString(),
        DataIndisponibilidade = null
      };
    }
  }
}

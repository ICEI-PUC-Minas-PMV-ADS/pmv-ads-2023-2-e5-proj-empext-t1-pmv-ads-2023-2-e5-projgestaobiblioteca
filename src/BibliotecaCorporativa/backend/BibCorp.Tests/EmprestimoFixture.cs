using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Domain.Models.Emprestimos;
using Bogus;

namespace BibCorp.Tests
{
  public class EmprestimoFixture
  {

    Faker faker =new Faker();
    public List<Emprestimo> ObterEmprestimosMock()
    {
      return new List<Emprestimo> {
        new Emprestimo {
          Id = 1,
          UserName = faker.Internet.UserName(),
          //Devolvido = true,
          DataEmprestimo = faker.Date.Recent().ToString(),
          DataPrevistaDevolucao = faker.Date.Recent().ToString(),
          QtdeDiasEmprestimo = faker.Random.Number(),
          DataDevolucao = faker.Date.Recent().ToString(),
          QtdeDiasAtraso = faker.Random.Number(),
          AcervoId = 1,
          Acervos = { },
          PatrimonioId = 1,
          Patrimonios = { }
        },
        new Emprestimo {
          Id = 2,
          UserName = faker.Internet.UserName(),
          //Devolvido = true,
          DataEmprestimo = faker.Date.Recent().ToString(),
          DataPrevistaDevolucao = faker.Date.Recent().ToString(),
          QtdeDiasEmprestimo = faker.Random.Number(),
          DataDevolucao = faker.Date.Recent().ToString(),
          QtdeDiasAtraso = faker.Random.Number(),
          AcervoId = 1,
          Acervos = { },
          PatrimonioId = 1,
          Patrimonios = { }
        }
      };
    }

    public Emprestimo ObterApenasUmEmprestimoMock(int EmprestimoId)
    {
      if (EmprestimoId == 7) {
        return new Emprestimo {
          Id = 7,
          UserName = faker.Internet.UserName(),
          //Devolvido = true,
          DataEmprestimo = faker.Date.Recent().ToString(),
          DataPrevistaDevolucao = faker.Date.Recent().ToString(),
          QtdeDiasEmprestimo = faker.Random.Number(),
          DataDevolucao = faker.Date.Recent().ToString(),
          QtdeDiasAtraso = faker.Random.Number(),
          AcervoId = 1,
          Acervos = { },
          PatrimonioId = 1,
          Patrimonios = { }
        };
      }

      return null;
    }
    public List<Emprestimo> ObterListaVaziaDeEmprestimosMock()
    {
      return new List<Emprestimo> { };
    }

    public Emprestimo CriarEmprestimoValidoMock()
    {
      return new Emprestimo {
        Id = 26,
        UserName = faker.Internet.UserName(),
        //Devolvido = true,
        DataEmprestimo = faker.Date.Recent().ToString(),
        DataPrevistaDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasEmprestimo = faker.Random.Number(),
        DataDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasAtraso = faker.Random.Number(),
        AcervoId = 1,
        Acervos = { },
        PatrimonioId = 1,
        Patrimonios = { }
      };
    }

    public EmprestimoDto CriarEmprestimoValidoDtoMock()
    {
      return new EmprestimoDto {
        Id = 26,
        UserName = faker.Internet.UserName(),
        //Devolvido = true,
        DataEmprestimo = faker.Date.Recent().ToString(),
        DataPrevistaDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasEmprestimo = faker.Random.Number(),
        DataDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasAtraso = faker.Random.Number(),
        AcervoId = 1,
        Acervos = { },
        PatrimonioId = 1,
        Patrimonios = { }
      };
    }

    public Emprestimo ObteEmprestimoCriadoMock(int EmprestimoId)
    {
      if (EmprestimoId == 26) {
        return new Emprestimo {
         Id = 26,
         UserName = faker.Internet.UserName(),
         //Devolvido = true,
         DataEmprestimo = faker.Date.Recent().ToString(),
         DataPrevistaDevolucao = faker.Date.Recent().ToString(),
         QtdeDiasEmprestimo = faker.Random.Number(),
         DataDevolucao = faker.Date.Recent().ToString(),
         QtdeDiasAtraso = faker.Random.Number(),
         AcervoId = 1,
         Acervos = { },
         PatrimonioId = 1,
         Patrimonios = { }
       };
      }

      return null;
    }

    public Emprestimo CriarEmprestimoInvalidoMock()
    {
      return new Emprestimo {
        Id = 26,
        UserName = faker.Internet.UserName(),
        //Devolvido = true,
        DataEmprestimo = faker.Date.Recent().ToString(),
        DataPrevistaDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasEmprestimo = faker.Random.Number(),
        DataDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasAtraso = faker.Random.Number(),
        AcervoId = 1,
        Acervos = { },
        PatrimonioId = 1,
        Patrimonios = { }
      };
    }

    public EmprestimoDto CriarEmprestimoInvalidoDtoMock()
    {
      return new EmprestimoDto {
        Id = 26,
        UserName = faker.Internet.UserName(),
       //Devolvido = true,
        DataEmprestimo = faker.Date.Recent().ToString(),
        DataPrevistaDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasEmprestimo = faker.Random.Number(),
        DataDevolucao = faker.Date.Recent().ToString(),
        QtdeDiasAtraso = faker.Random.Number(),
        AcervoId = 1,
        Acervos = { },
        PatrimonioId = 1,
        Patrimonios = { }
      };
    }
  }
}

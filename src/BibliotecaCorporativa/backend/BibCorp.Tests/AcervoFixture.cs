using BibCorp.Application.Dto.Acervos;
using BibCorp.Domain.Models.Acervos;
using Bogus;


namespace BibCorp.Tests
{
  public class AcervoFixture
  {

    Faker faker =new Faker();
    public List<Acervo> ObterAcervosMock()
    {
      return new List<Acervo>
      {
        new Acervo
        {
          Id = 1,
          //PatrimonioId = 1,
          ISBN = "9788532519474",
          Titulo = faker.Lorem.Words(20).ToString(),
          SubTitulo = faker.Lorem.Words(20).ToString(),
          Resumo = faker.Lorem.Lines(5).ToString(),
          AnoPublicacao = "1994",
          Editora = faker.Lorem.Words(10).ToString(),
          Edicao = faker.Lorem.Words(2).ToString(),
          CapaUrl = faker.Internet.Url(),
          QtdeDisponivel = faker.Random.Number(),
          QtdeEmTransito = faker.Random.Number(),
          QtdeEmprestada = faker.Random.Number(),
          Patrimonios = {}

        },
        new Acervo
        {
          Id = 1,
          //PatrimonioId = 1,
          ISBN = "9788532519474",
          Titulo = faker.Lorem.Words(20).ToString(),
          SubTitulo = faker.Lorem.Words(20).ToString(),
          Resumo = faker.Lorem.Lines(5).ToString(),
          AnoPublicacao = "1994",
          Editora = faker.Lorem.Words(10).ToString(),
          Edicao = faker.Lorem.Words(2).ToString(),
          CapaUrl = faker.Internet.Url(),
          QtdeDisponivel = faker.Random.Number(),
          QtdeEmTransito = faker.Random.Number(),
          QtdeEmprestada = faker.Random.Number(),
          Patrimonios = {}
        }
      };
    }

    public Acervo ObterApenasUmAcervoMock(int patrimonioId)
    {
      if (patrimonioId == 7)
      {
        return
        new Acervo
        {
          Id = 7,
          //PatrimonioId = 1,
          ISBN = "9788532519474",
          Titulo = faker.Lorem.Words(20).ToString(),
          SubTitulo = faker.Lorem.Words(20).ToString(),
          Resumo = faker.Lorem.Lines(5).ToString(),
          AnoPublicacao = "1994",
          Editora = faker.Lorem.Words(10).ToString(),
          Edicao = faker.Lorem.Words(2).ToString(),
          CapaUrl = faker.Internet.Url(),
          QtdeDisponivel = faker.Random.Number(),
          QtdeEmTransito = faker.Random.Number(),
          QtdeEmprestada = faker.Random.Number(),
          Patrimonios = { }
        };
      }

      return null;

    }
    public List<Acervo> ObterListaVaziaDeAcervosMock()
    {
      return new List<Acervo> { };
    }

    public Acervo CriarAcervoValidoMock()
    {
      return
      new Acervo
      {
        Id = 26,
        //PatrimonioId = 1,
        ISBN = "9788532519474",
        Titulo = faker.Lorem.Words(20).ToString(),
        SubTitulo = faker.Lorem.Words(20).ToString(),
        Resumo = faker.Lorem.Lines(5).ToString(),
        AnoPublicacao = "1994",
        Editora = faker.Lorem.Words(10).ToString(),
        Edicao = faker.Lorem.Words(2).ToString(),
        CapaUrl = faker.Internet.Url(),
        QtdeDisponivel = faker.Random.Number(),
        QtdeEmTransito = faker.Random.Number(),
        QtdeEmprestada = faker.Random.Number(),
        Patrimonios = { }
      };

    }

    public AcervoDto CriarAcervoValidoDtoMock()
    {
      return
      new AcervoDto
      {
        Id = 26,
        //PatrimonioId = 1,
        ISBN = "9788532519474",
        Titulo = faker.Lorem.Words(20).ToString(),
        SubTitulo = faker.Lorem.Words(20).ToString(),
        Resumo = faker.Lorem.Lines(5).ToString(),
        AnoPublicacao = "1994",
        Editora = faker.Lorem.Words(10).ToString(),
        Edicao = faker.Lorem.Words(2).ToString(),
        CapaUrl = faker.Internet.Url(),
        QtdeDisponivel = faker.Random.Number(),
        QtdeEmTransito = faker.Random.Number(),
        QtdeEmprestada = faker.Random.Number(),
        Patrimonios = { }
      };

    }

    public Acervo ObteAcervoCriadoMock(int patrimonioId)
    {
      if (patrimonioId == 26)
      {
        return
       new Acervo
       {
         Id = 26,
         //PatrimonioId = 1,
         ISBN = "9788532519474",
         Titulo = faker.Lorem.Words(20).ToString(),
         SubTitulo = faker.Lorem.Words(20).ToString(),
         Resumo = faker.Lorem.Lines(5).ToString(),
         AnoPublicacao = "1994",
         Editora = faker.Lorem.Words(10).ToString(),
         Edicao = faker.Lorem.Words(2).ToString(),
         CapaUrl = faker.Internet.Url(),
         QtdeDisponivel = faker.Random.Number(),
         QtdeEmTransito = faker.Random.Number(),
         QtdeEmprestada = faker.Random.Number(),
         Patrimonios = { }
       };
      }

      return null;

    }

    public Acervo CriarAcervoInvalidoMock()
    {
      return
      new Acervo
      {
        Id = 26,
        //PatrimonioId = 1,
        ISBN = "9788532519474",
        Titulo = faker.Lorem.Words(20).ToString(),
        SubTitulo = faker.Lorem.Words(20).ToString(),
        Resumo = faker.Lorem.Lines(5).ToString(),
        AnoPublicacao = "1994",
        Editora = faker.Lorem.Words(10).ToString(),
        Edicao = faker.Lorem.Words(2).ToString(),
        CapaUrl = faker.Internet.Url(),
        QtdeDisponivel = faker.Random.Number(),
        QtdeEmTransito = faker.Random.Number(),
        QtdeEmprestada = faker.Random.Number(),
        Patrimonios = { }
      };

    }

    public AcervoDto CriarAcervoInvalidoDtoMock()
    {
      return
      new AcervoDto
      {
        Id = 26,
        //PatrimonioId = 1,
        ISBN = "9788532519474",
        Titulo = faker.Lorem.Words(20).ToString(),
        SubTitulo = faker.Lorem.Words(20).ToString(),
        Resumo = faker.Lorem.Lines(5).ToString(),
        AnoPublicacao = "1994",
        Editora = faker.Lorem.Words(10).ToString(),
        Edicao = faker.Lorem.Words(2).ToString(),
        CapaUrl = faker.Internet.Url(),
        QtdeDisponivel = faker.Random.Number(),
        QtdeEmTransito = faker.Random.Number(),
        QtdeEmprestada = faker.Random.Number(),
        Patrimonios = { }
      };

    }
  }
}

using AutoMapper;
using BibCorp.Persistence.Interfaces.Contracts.Shared;
using Moq;
using BibCorp.Application.Services.Contracts.Patrimonios;
using BibCorp.Application.Services.Packages.Patrimonios;
using BibCorp.Persistence.Interfaces.Contracts.Patrimonios;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Application.Dto.Patrimonios;

namespace BibCorp.Tests
{
  public class PatrimonioServiceTests
  {
    public readonly PatrimonioService _patrimonioServices;
    private readonly Mock<ISharedPersistence> sharedPersistenceMock;
    private readonly Mock<IPatrimonioPersistence> patrimonioPersistenceMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly PatrimonioFixture patrimonioFixture;

    public PatrimonioServiceTests()
    {
      patrimonioPersistenceMock = new Mock<IPatrimonioPersistence>();
      mapperMock = new Mock<IMapper>();
      patrimonioFixture = new PatrimonioFixture();
      sharedPersistenceMock = new Mock<ISharedPersistence>();


      _patrimonioServices = new PatrimonioService(
          patrimonioPersistenceMock.Object,
          mapperMock.Object
      );

    }

    [Fact]
    [Trait(nameof(IPatrimonioService.GetAllPatrimoniosAsync), "Sucesso")]
    public async Task GetAllPatrimoniosAsync_DeveRetornarAListaDePatrimoniosCadastrados_QuandoExistirPatrimoniosCadastrados()
    {
      //Arrange

      patrimonioPersistenceMock
          .Setup(p => p.GetAllPatrimoniosAsync())
          .ReturnsAsync(patrimonioFixture.ObterPatrimoniosMock());
      mapperMock
          .Setup(x => x.Map<PatrimonioDto[]> (It.IsAny<IEnumerable<Patrimonio>>()))
          .Returns((List<Patrimonio> src) => new PatrimonioDto[]
          {
                new PatrimonioDto
                {
                    Id = src[0].Id,
                    Localizacao = src[0].Localizacao,
                    Sala = src[0].Sala,
                    Coluna = src[0].Coluna,
                    Prateleira = src[0].Prateleira,
                    Posicao = src[0].Posicao,
                    ISBN = src[0].ISBN,
                    Origem = src[0].Origem,
                    DetalheOrgiem = src[0].DetalheOrgiem,
                    Ativo = src[0].Ativo,
                    DataCadastro = src[0].DataCadastro,
                    DataAtualizacao = src[0].DataAtualizacao,
                    DataIndisponibilidade = src[0].DataIndisponibilidade
                },

                new PatrimonioDto
                {
                    Id = src[1].Id,
                    Localizacao = src[1].Localizacao,
                    Sala = src[1].Sala,
                    Coluna = src[1].Coluna,
                    Prateleira = src[1].Prateleira,
                    Posicao = src[1].Posicao,
                    ISBN = src[1].ISBN,
                    Origem = src[1].Origem,
                    DetalheOrgiem = src[1].DetalheOrgiem,
                    Ativo = src[1].Ativo,
                    DataCadastro = src[1].DataCadastro,
                    DataAtualizacao = src[1].DataAtualizacao,
                    DataIndisponibilidade = src[1].DataIndisponibilidade
                }
          });

      //Act

      var patrimoniosConsultados = await _patrimonioServices.GetAllPatrimoniosAsync();

      //Assert

      Assert.True(patrimoniosConsultados.Count().Equals(2));
      patrimonioPersistenceMock.Verify(p => p.GetAllPatrimoniosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IPatrimonioService.GetAllPatrimoniosAsync), "Insucesso")]
    public async Task GetAllPatrimoniosAsync_DeveRetornarUmaListaVazia_QuandoNaoExistirPatrimoniosCadastrados()
    {
      //Arrange

      patrimonioPersistenceMock
          .Setup(p => p.GetAllPatrimoniosAsync())
          .ReturnsAsync(patrimonioFixture.ObterListaVaziaDePatrimoniosMock());


      mapperMock
      .Setup(x => x.Map<PatrimonioDto[]>(It.IsAny<IEnumerable<Patrimonio>>()))
      .Returns((List<Patrimonio> src) => new PatrimonioDto[]
          { });

      //Act

      var patrimoniosConsultados = await _patrimonioServices.GetAllPatrimoniosAsync();

      //Assert

      Assert.False(patrimoniosConsultados.Count() > 0);
      patrimonioPersistenceMock.Verify(p => p.GetAllPatrimoniosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IPatrimonioService.GetPatrimonioByIdAsync), "Sucesso")]
    public async Task GetPatrimonioByIdAsync_DeveRetornarOsDadosDoPatrimonio_QuandoOIdInformadoForValido()
    {
      //Arrange

      patrimonioPersistenceMock
          .Setup(p => p.GetPatrimonioByIdAsync(7))
          .Callback<int>(Id => Assert.Equal(7, Id))
          .ReturnsAsync(patrimonioFixture.ObterApenasUmPatrimonioMock(7));


      mapperMock
      .Setup(x => x.Map<PatrimonioDto>(It.IsAny<Patrimonio>()))
      .Returns((Patrimonio src) => new PatrimonioDto
                {
                    Id = src.Id,
                    Localizacao = src.Localizacao,
                    Sala = src.Sala,
                    Coluna = src.Coluna,
                    Prateleira = src.Prateleira,
                    Posicao = src.Posicao,
                    ISBN = src.ISBN,
                    Origem = src.Origem,
                    DetalheOrgiem = src.DetalheOrgiem,
                    Ativo = src.Ativo,
                    DataCadastro = src.DataCadastro,
                    DataAtualizacao = src.DataAtualizacao,
                    DataIndisponibilidade = src.DataIndisponibilidade
          });

      //Act

      var patrimonioConsultado = await _patrimonioServices.GetPatrimonioByIdAsync(7);

      //Assert

      Assert.Equal(7, patrimonioConsultado.Id);
      Assert.IsType<PatrimonioDto>(patrimonioConsultado);
      patrimonioPersistenceMock.Verify(p => p.GetPatrimonioByIdAsync(7), Times.Once);
    }

    [Fact]
    [Trait(nameof(IPatrimonioService.GetPatrimonioByIdAsync), "Insucesso")]
    public async Task GetPatrimonioByIdAsync_NaoDeveRetornarOsDadosDoPatrimonio_QuandoOIdInformadoForInvalido()
    {
      //Arrange

      patrimonioPersistenceMock
          .Setup(d => d.GetPatrimonioByIdAsync(100))
          .Callback<int>(Id => Assert.Equal(100, Id))
          .ReturnsAsync(patrimonioFixture.ObterApenasUmPatrimonioMock(100));


      mapperMock
      .Setup(x => x.Map<PatrimonioDto>(It.IsAny<Patrimonio>()))
      .Returns((Patrimonio src) => new PatrimonioDto
      {
        Id = src.Id,
        Localizacao = src.Localizacao,
        Sala = src.Sala,
        Coluna = src.Coluna,
        Prateleira = src.Prateleira,
        Posicao = src.Posicao,
        ISBN = src.ISBN,
        Origem = src.Origem,
        DetalheOrgiem = src.DetalheOrgiem,
        Ativo = src.Ativo,
        DataCadastro = src.DataCadastro,
        DataAtualizacao = src.DataAtualizacao,
        DataIndisponibilidade = src.DataIndisponibilidade
      });

      //Act

      var patrimonioConsultado = await _patrimonioServices.GetPatrimonioByIdAsync(100);

      //Assert

      Assert.Null(patrimonioConsultado);
      patrimonioPersistenceMock.Verify(p => p.GetPatrimonioByIdAsync(100), Times.Once);

    }

    [Fact]
    [Trait(nameof(IPatrimonioService.CreatePatrimonio), "Sucesso")]
    public async Task CreatePatrimonio_DeveRealizarAInclusaoDoPatrimonio_QuandoOsDadosForemValidos()
    {
      //Arrange

      var patrimonioDto = patrimonioFixture.CriarPatrimonioValidoDtoMock();
      var patrimonio = patrimonioFixture.CriarPatrimonioValidoMock();


      mapperMock
      .Setup(m => m.Map<Patrimonio>(It.IsAny<PatrimonioDto>()))
            .Returns((PatrimonioDto src) => new Patrimonio
            {
              Id = src.Id,
              Localizacao = src.Localizacao,
              Sala = src.Sala,
              Coluna = src.Coluna,
              Prateleira = src.Prateleira,
              Posicao = src.Posicao,
              ISBN = src.ISBN,
              Origem = src.Origem,
              DetalheOrgiem = src.DetalheOrgiem,
              Ativo = src.Ativo,
              DataCadastro = src.DataCadastro,
              DataAtualizacao = src.DataAtualizacao,
              DataIndisponibilidade = src.DataIndisponibilidade
            });

      mapperMock
      .Setup(m => m.Map<PatrimonioDto>(It.IsAny<Patrimonio>()))
            .Returns((Patrimonio source) => new PatrimonioDto
            {
              Id = source.Id,
              Localizacao = source.Localizacao,
              Sala = source.Sala,
              Coluna = source.Coluna,
              Prateleira = source.Prateleira,
              Posicao = source.Posicao,
              ISBN = source.ISBN,
              Origem = source.Origem,
              DetalheOrgiem = source.DetalheOrgiem,
              Ativo = source.Ativo,
              DataCadastro = source.DataCadastro,
              DataAtualizacao = source.DataAtualizacao,
              DataIndisponibilidade = source.DataIndisponibilidade
            });

      sharedPersistenceMock
          .Setup(c => c.Create<Patrimonio>(patrimonio));

      patrimonioPersistenceMock
          .Setup(s => s.SaveChangesAsync())
          .ReturnsAsync(true);

      patrimonioPersistenceMock
          .Setup(g => g.GetPatrimonioByIdAsync(patrimonio.Id))
          .Callback<int>(Id => Assert.Equal(26, Id))
          .ReturnsAsync(patrimonioFixture.ObtePatrimonioCriadoMock(patrimonio.Id));

      //Act

      var patrimonioCriado = await _patrimonioServices.CreatePatrimonio(patrimonioDto);

      //Assert

      Assert.Equal(26, patrimonioCriado.Id);
      Assert.IsType<PatrimonioDto>(patrimonioCriado);
      patrimonioPersistenceMock.Verify(p => p.GetPatrimonioByIdAsync(26), Times.Once);
      patrimonioPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IPatrimonioService.CreatePatrimonio), "Insucesso")]
    public async Task CreatePatrimonio_NaoDeveRealizarAInclusaoDoPatrimonio_QuandoOsDadosForemInvalidos()
    {
      //Arrange

      var patrimonioDto = patrimonioFixture.CriarPatrimonioInvalidoDtoMock();
      var patrimonio = patrimonioFixture.CriarPatrimonioInvalidoMock();

      mapperMock
     .Setup(m => m.Map<Patrimonio>(It.IsAny<PatrimonioDto>()))
           .Returns((PatrimonioDto src) => new Patrimonio
           {
             Localizacao = src.Localizacao,
             Sala = src.Sala,
             Coluna = src.Coluna,
             Prateleira = src.Prateleira,
             Posicao = src.Posicao,
             ISBN = src.ISBN,
             Origem = src.Origem,
             DetalheOrgiem = src.DetalheOrgiem,
             Ativo = src.Ativo,
             DataCadastro = src.DataCadastro,
             DataAtualizacao = src.DataAtualizacao,
             DataIndisponibilidade = src.DataIndisponibilidade
           });

      mapperMock
      .Setup(m => m.Map<PatrimonioDto>(It.IsAny<Patrimonio>()))
            .Returns((Patrimonio source) => new PatrimonioDto
            {
              Localizacao = source.Localizacao,
              Sala = source.Sala,
              Coluna = source.Coluna,
              Prateleira = source.Prateleira,
              Posicao = source.Posicao,
              ISBN = source.ISBN,
              Origem = source.Origem,
              DetalheOrgiem = source.DetalheOrgiem,
              Ativo = source.Ativo,
              DataCadastro = source.DataCadastro,
              DataAtualizacao = source.DataAtualizacao,
              DataIndisponibilidade = source.DataIndisponibilidade
            });

      sharedPersistenceMock
          .Setup(c => c.Create<Patrimonio>(patrimonio));

      patrimonioPersistenceMock
          .Setup(s => s.SaveChangesAsync())
          .ReturnsAsync(false);

      //Act

      var patrimonioCriado = await _patrimonioServices.CreatePatrimonio(patrimonioDto);

      //Assert

      Assert.Null(patrimonioCriado);
      patrimonioPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IPatrimonioService.DeletePatrimonio), "Sucesso")]
    public async Task DeletePatrimonio_DeveRealizarAExclusaoDoPatrimonio_QuandoOPatrimonioExistir()
    {
      //Arrange

      var patrimonio = patrimonioFixture.ObterApenasUmPatrimonioMock(7);

      patrimonioPersistenceMock
         .Setup(g => g.GetPatrimonioByIdAsync(7))
         .ReturnsAsync(patrimonioFixture.ObterApenasUmPatrimonioMock(7));

      sharedPersistenceMock
      .Setup(c => c.Delete<Patrimonio>(patrimonio));

      patrimonioPersistenceMock
          .Setup(s => s.SaveChangesAsync())
          .ReturnsAsync(true);

      //Act

      var patrimonioExcluido = await _patrimonioServices.DeletePatrimonio(patrimonio.Id);

      //Assert

      Assert.True(patrimonioExcluido);
      patrimonioPersistenceMock.Verify(p => p.GetPatrimonioByIdAsync(7), Times.Once);
      patrimonioPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IPatrimonioService.DeletePatrimonio), "Insucesso")]
    public async Task DeletePatrimonio_NaoDeveRealizarAExclusaoDoPatrimonio_QuandoOPatrimonioNaoExistir()
    {
      //Arrange

      var patrimonio = patrimonioFixture.ObterApenasUmPatrimonioMock(7);

      patrimonioPersistenceMock
         .Setup(g => g.GetPatrimonioByIdAsync(8))
         .ReturnsAsync(patrimonioFixture.ObterApenasUmPatrimonioMock(8));

      sharedPersistenceMock
      .Setup(c => c.Delete<Patrimonio>(patrimonio));


      //Act & Assert

      await Assert.ThrowsAsync<Exception>(() => _patrimonioServices.DeletePatrimonio(patrimonio.Id));

      patrimonioPersistenceMock.Verify(p => p.GetPatrimonioByIdAsync(7), Times.Once);

    }



  }


}

using AutoMapper;
using BibCorp.Persistence.Interfaces.Contracts.Shared;
using Moq;
using BibCorp.Application.Services.Contracts.Acervos;
using BibCorp.Application.Services.Packages.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Application.Dto.Acervos;
using BibCorp.Domain.Models.Patrimonios;


namespace BibCorp.Tests
{
  public class AcervoServiceTests
  {
    public readonly AcervoService _acervoServices;
    private readonly Mock<ISharedPersistence> sharedPersistenceMock;
    private readonly Mock<IAcervoPersistence> acervoPersistenceMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly AcervoFixture acervoFixture;

    public AcervoServiceTests()
    {
      acervoPersistenceMock = new Mock<IAcervoPersistence>();
      mapperMock = new Mock<IMapper>();
      acervoFixture = new AcervoFixture();
      sharedPersistenceMock = new Mock<ISharedPersistence>();


      _acervoServices = new AcervoService(
          acervoPersistenceMock.Object,
          mapperMock.Object
      );

    }

    [Fact]
    [Trait(nameof(IAcervoService.GetAllAcervosAsync), "Sucesso")]
    public async Task GetAllAcervosAsync_DeveRetornarAListaDeAcervosCadastrados_QuandoExistirAcervosCadastrados()
    {
      //Arrange

      acervoPersistenceMock
        .Setup(p => p.GetAllAcervosAsync())
        .ReturnsAsync(acervoFixture.ObterAcervosMock());
      mapperMock
        .Setup(x => x.Map<AcervoDto[]> (It.IsAny<IEnumerable<Acervo>>()))
        .Returns((List<Acervo> src) => new AcervoDto[] {
          new AcervoDto{
            Id = src[0].Id,
            //PatrimonioId = src[0].PatrimonioId,
            ISBN = src[0].ISBN,
            Titulo = src[0].Titulo,
            SubTitulo = src[0].SubTitulo,
            Resumo = src[0].Resumo,
            AnoPublicacao = src[0].AnoPublicacao,
            Editora = src[0].Editora,
            Edicao = src[0].Edicao,
            CapaUrl = src[0].CapaUrl,
            QtdeDisponivel = src[0].QtdeDisponivel,
            QtdeEmTransito = src[0].QtdeEmTransito,
            QtdeEmprestada = src[0].QtdeEmprestada,
            Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src[0].Patrimonios
          },
          new AcervoDto {
            Id = src[1].Id,
            //PatrimonioId = src[1].PatrimonioId,
            ISBN = src[1].ISBN,
            Titulo = src[1].Titulo,
            SubTitulo = src[1].SubTitulo,
            Resumo = src[1].Resumo,
            AnoPublicacao = src[1].AnoPublicacao,
            Editora = src[1].Editora,
            Edicao = src[1].Edicao,
            CapaUrl = src[1].CapaUrl,
            QtdeDisponivel = src[1].QtdeDisponivel,
            QtdeEmTransito = src[1].QtdeEmTransito,
            QtdeEmprestada = src[1].QtdeEmprestada,
            Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src[1].Patrimonios
          }
        });

      //Act
      var acervosConsultados = await _acervoServices.GetAllAcervosAsync();

      //Assert
      Assert.True(acervosConsultados.Count().Equals(2));
      acervoPersistenceMock.Verify(p => p.GetAllAcervosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IAcervoService.GetAllAcervosAsync), "Insucesso")]
    public async Task GetAllAcervosAsync_DeveRetornarUmaListaVazia_QuandoNaoExistirAcervosCadastrados()
    {
      //Arrange

      acervoPersistenceMock
        .Setup(p => p.GetAllAcervosAsync())
        .ReturnsAsync(acervoFixture.ObterListaVaziaDeAcervosMock());


      mapperMock
        .Setup(x => x.Map<AcervoDto[]>(It.IsAny<IEnumerable<Acervo>>()))
        .Returns((List<Acervo> src) => new AcervoDto[]
          { });

      //Act
      var acervosConsultados = await _acervoServices.GetAllAcervosAsync();

      //Assert
      Assert.False(acervosConsultados.Count() > 0);
      acervoPersistenceMock.Verify(p => p.GetAllAcervosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IAcervoService.GetAcervoByIdAsync), "Sucesso")]
    public async Task GetAcervoByIdAsync_DeveRetornarOsDadosDoAcervo_QuandoOIdInformadoForValido()
    {
      //Arrange

      acervoPersistenceMock
        .Setup(p => p.GetAcervoByIdAsync(7))
        .Callback<int>(Id => Assert.Equal(7, Id))
        .ReturnsAsync(acervoFixture.ObterApenasUmAcervoMock(7));


      mapperMock
        .Setup(x => x.Map<AcervoDto>(It.IsAny<Acervo>()))
        .Returns((Acervo src) => new AcervoDto {
          Id = src.Id,
          //PatrimonioId = src.PatrimonioId,
          ISBN = src.ISBN,
          Titulo = src.Titulo,
          SubTitulo = src.SubTitulo,
          Resumo = src.Resumo,
          AnoPublicacao = src.AnoPublicacao,
          Editora = src.Editora,
          Edicao = src.Edicao,
          CapaUrl = src.CapaUrl,
          QtdeDisponivel = src.QtdeDisponivel,
          QtdeEmTransito = src.QtdeEmTransito,
          QtdeEmprestada = src.QtdeEmprestada,
          Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src.Patrimonios
        });

      //Act
      var acervoConsultado = await _acervoServices.GetAcervoByIdAsync(7);

      //Assert
      Assert.Equal(7, acervoConsultado.Id);
      Assert.IsType<AcervoDto>(acervoConsultado);
      acervoPersistenceMock.Verify(p => p.GetAcervoByIdAsync(7), Times.Once);
    }

    [Fact]
    [Trait(nameof(IAcervoService.GetAcervoByIdAsync), "Insucesso")]
    public async Task GetAcervoByIdAsync_NaoDeveRetornarOsDadosDoAcervo_QuandoOIdInformadoForInvalido()
    {
      //Arrange

      acervoPersistenceMock
        .Setup(d => d.GetAcervoByIdAsync(100))
        .Callback<int>(Id => Assert.Equal(100, Id))
        .ReturnsAsync(acervoFixture.ObterApenasUmAcervoMock(100));


      mapperMock
      .Setup(x => x.Map<AcervoDto>(It.IsAny<Acervo>()))
      .Returns((Acervo src) => new AcervoDto {
        Id = src.Id,
        //PatrimonioId = src.PatrimonioId,
        ISBN = src.ISBN,
        Titulo = src.Titulo,
        SubTitulo = src.SubTitulo,
        Resumo = src.Resumo,
        AnoPublicacao = src.AnoPublicacao,
        Editora = src.Editora,
        Edicao = src.Edicao,
        CapaUrl = src.CapaUrl,
        QtdeDisponivel = src.QtdeDisponivel,
        QtdeEmTransito = src.QtdeEmTransito,
        QtdeEmprestada = src.QtdeEmprestada,
        Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src.Patrimonios
      });

      //Act
      var acervoConsultado = await _acervoServices.GetAcervoByIdAsync(100);

      //Assert
      Assert.Null(acervoConsultado);
      acervoPersistenceMock.Verify(p => p.GetAcervoByIdAsync(100), Times.Once);

    }

    [Fact]
    [Trait(nameof(IAcervoService.CreateAcervo), "Sucesso")]
    public async Task CreateAcervo_DeveRealizarAInclusaoDoAcervo_QuandoOsDadosForemValidos()
    {
      //Arrange
      var acervoDto = acervoFixture.CriarAcervoValidoDtoMock();
      var acervo = acervoFixture.CriarAcervoValidoMock();


      mapperMock
        .Setup(m => m.Map<Acervo>(It.IsAny<AcervoDto>()))
        .Returns((AcervoDto src) => new Acervo {
          Id = src.Id,
          //PatrimonioId = src.PatrimonioId,
          ISBN = src.ISBN,
          Titulo = src.Titulo,
          SubTitulo = src.SubTitulo,
          Resumo = src.Resumo,
          AnoPublicacao = src.AnoPublicacao,
          Editora = src.Editora,
          Edicao = src.Edicao,
          CapaUrl = src.CapaUrl,
          QtdeDisponivel = src.QtdeDisponivel,
          QtdeEmTransito = src.QtdeEmTransito,
          QtdeEmprestada = src.QtdeEmprestada,
          Patrimonios = (IEnumerable<Patrimonio>)src.Patrimonios
        });

      mapperMock
        .Setup(m => m.Map<AcervoDto>(It.IsAny<Acervo>()))
        .Returns((Acervo source) => new AcervoDto {
          Id = source.Id,
          //PatrimonioId = source.PatrimonioId,
          ISBN = source.ISBN,
          Titulo = source.Titulo,
          SubTitulo = source.SubTitulo,
          Resumo = source.Resumo,
          AnoPublicacao = source.AnoPublicacao,
          Editora = source.Editora,
          Edicao = source.Edicao,
          CapaUrl = source.CapaUrl,
          QtdeDisponivel = source.QtdeDisponivel,
          QtdeEmTransito = source.QtdeEmTransito,
          QtdeEmprestada = source.QtdeEmprestada,
          Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)source.Patrimonios
        });

      sharedPersistenceMock
        .Setup(c => c.Create<Acervo>(acervo));

      acervoPersistenceMock
        .Setup(s => s.SaveChangesAsync())
        .ReturnsAsync(true);

      acervoPersistenceMock
        .Setup(g => g.GetAcervoByIdAsync(acervo.Id))
        .Callback<int>(Id => Assert.Equal(26, Id))
        .ReturnsAsync(acervoFixture.ObteAcervoCriadoMock(acervo.Id));

      //Act
      var acervoCriado = await _acervoServices.CreateAcervo(acervoDto);

      //Assert

      Assert.Equal(26, acervoCriado.Id);
      Assert.IsType<AcervoDto>(acervoCriado);
      acervoPersistenceMock.Verify(p => p.GetAcervoByIdAsync(26), Times.Once);
      acervoPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IAcervoService.CreateAcervo), "Insucesso")]
    public async Task CreateAcervo_NaoDeveRealizarAInclusaoDoAcervo_QuandoOsDadosForemInvalidos()
    {
      //Arrange
      var acervoDto = acervoFixture.CriarAcervoInvalidoDtoMock();
      var acervo = acervoFixture.CriarAcervoInvalidoMock();

      mapperMock
        .Setup(m => m.Map<Acervo>(It.IsAny<AcervoDto>()))
        .Returns((AcervoDto src) => new Acervo {
          Id = src.Id,
          //PatrimonioId = src.PatrimonioId,
          ISBN = src.ISBN,
          Titulo = src.Titulo,
          SubTitulo = src.SubTitulo,
          Resumo = src.Resumo,
          AnoPublicacao = src.AnoPublicacao,
          Editora = src.Editora,
          Edicao = src.Edicao,
          CapaUrl = src.CapaUrl,
          QtdeDisponivel = src.QtdeDisponivel,
          QtdeEmTransito = src.QtdeEmTransito,
          QtdeEmprestada = src.QtdeEmprestada,
          Patrimonios = (IEnumerable<Patrimonio>)src.Patrimonios
        });

      mapperMock
        .Setup(m => m.Map<AcervoDto>(It.IsAny<Acervo>()))
        .Returns((Acervo source) => new AcervoDto {
          Id = source.Id,
          //PatrimonioId = source.PatrimonioId,
          ISBN = source.ISBN,
          Titulo = source.Titulo,
          SubTitulo = source.SubTitulo,
          Resumo = source.Resumo,
          AnoPublicacao = source.AnoPublicacao,
          Editora = source.Editora,
          Edicao = source.Edicao,
          CapaUrl = source.CapaUrl,
          QtdeDisponivel = source.QtdeDisponivel,
          QtdeEmTransito = source.QtdeEmTransito,
          QtdeEmprestada = source.QtdeEmprestada,
          Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)source.Patrimonios
        });

      sharedPersistenceMock
        .Setup(c => c.Create<Acervo>(acervo));

      acervoPersistenceMock
        .Setup(s => s.SaveChangesAsync())
        .ReturnsAsync(false);

      //Act

      var acervoCriado = await _acervoServices.CreateAcervo(acervoDto);

      //Assert

      Assert.Null(acervoCriado);
      acervoPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IAcervoService.DeleteAcervo), "Sucesso")]
    public async Task DeleteAcervo_DeveRealizarAExclusaoDoAcervo_QuandoOAcervoExistir()
    {
      //Arrange
      var acervo = acervoFixture.ObterApenasUmAcervoMock(7);

      acervoPersistenceMock
        .Setup(g => g.GetAcervoByIdAsync(7))
        .ReturnsAsync(acervoFixture.ObterApenasUmAcervoMock(7));

      sharedPersistenceMock
        .Setup(c => c.Delete<Acervo>(acervo));

      acervoPersistenceMock
        .Setup(s => s.SaveChangesAsync())
        .ReturnsAsync(true);

      //Act
      var acervoExcluido = await _acervoServices.DeleteAcervo(acervo.Id);

      //Assert
      Assert.True(acervoExcluido);
      acervoPersistenceMock.Verify(p => p.GetAcervoByIdAsync(7), Times.Once);
      acervoPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IAcervoService.DeleteAcervo), "Insucesso")]
    public async Task DeleteAcervo_NaoDeveRealizarAExclusaoDoAcervo_QuandoOAcervoNaoExistir()
    {
      //Arrange
      var acervo = acervoFixture.ObterApenasUmAcervoMock(7);

      acervoPersistenceMock
        .Setup(g => g.GetAcervoByIdAsync(8))
        .ReturnsAsync(acervoFixture.ObterApenasUmAcervoMock(8));

      sharedPersistenceMock
        .Setup(c => c.Delete<Acervo>(acervo));


      //Act & Assert
      await Assert.ThrowsAsync<Exception>(() => _acervoServices.DeleteAcervo(acervo.Id));

      acervoPersistenceMock.Verify(p => p.GetAcervoByIdAsync(7), Times.Once);
    }
  }
}

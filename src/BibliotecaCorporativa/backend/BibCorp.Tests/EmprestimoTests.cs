using AutoMapper;
using BibCorp.Persistence.Interfaces.Contracts.Shared;
using Moq;
using BibCorp.Application.Services.Contracts.Emprestimos;
using BibCorp.Application.Services.Packages.Emprestimos;
using BibCorp.Persistence.Interfaces.Contracts.Emprestimos;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Domain.Models.Patrimonios;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;

namespace BibCorp.Tests
{
  public class EmprestimoServiceTests
  {
    public readonly EmprestimoService _emprestimoServices;
    private readonly Mock<ISharedPersistence> sharedPersistenceMock;
    private readonly Mock<IEmprestimoPersistence> emprestimoPersistenceMock;
    private readonly Mock<IAcervoPersistence> acervoPersistenceMock;
    private readonly Mock<IMapper> mapperMock;
    private readonly EmprestimoFixture emprestimoFixture;

    public EmprestimoServiceTests()
    {
      emprestimoPersistenceMock = new Mock<IEmprestimoPersistence>();
      acervoPersistenceMock = new Mock<IAcervoPersistence>();
      mapperMock = new Mock<IMapper>();
      emprestimoFixture = new EmprestimoFixture();
      sharedPersistenceMock = new Mock<ISharedPersistence>();


      _emprestimoServices = new EmprestimoService(
          emprestimoPersistenceMock.Object,
          acervoPersistenceMock.Object,
          mapperMock.Object
      );

    }

    [Fact]
    [Trait(nameof(IEmprestimoService.GetAllEmprestimosAsync), "Sucesso")]
    public async Task GetAllEmprestimosAsync_DeveRetornarAListaDeEmprestimosCadastrados_QuandoExistirEmprestimosCadastrados()
    {
      //Arrange

      emprestimoPersistenceMock
        .Setup(p => p.GetAllEmprestimosAsync())
        .ReturnsAsync(emprestimoFixture.ObterEmprestimosMock());

      mapperMock
        .Setup(x => x.Map<EmprestimoDto[]> (It.IsAny<IEnumerable<Emprestimo>>()))
        .Returns((List<Emprestimo> src) => new EmprestimoDto[] {
          new EmprestimoDto {
            Id = src[0].Id,
            UserName = src[0].UserName,
            //Devolvido = src[0].Devolvido,
            DataEmprestimo = src[0].DataEmprestimo,
            DataPrevistaDevolucao = src[0].DataPrevistaDevolucao,
            QtdeDiasEmprestimo = src[0].QtdeDiasEmprestimo,
            DataDevolucao = src[0].DataDevolucao,
            QtdeDiasAtraso = src[0].QtdeDiasAtraso,
            AcervoId = src[0].AcervoId,
            Acervos = (IEnumerable<Application.Dto.Acervos.AcervoDto>)src[0].Acervos,
            PatrimonioId = src[0].PatrimonioId,
            Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src[0].Patrimonios
          },
          new EmprestimoDto {
            Id = src[1].Id,
            UserName = src[1].UserName,
            //Devolvido = src[1].Devolvido,
            DataEmprestimo = src[1].DataEmprestimo,
            DataPrevistaDevolucao = src[1].DataPrevistaDevolucao,
            QtdeDiasEmprestimo = src[1].QtdeDiasEmprestimo,
            DataDevolucao = src[1].DataDevolucao,
            QtdeDiasAtraso = src[1].QtdeDiasAtraso,
            AcervoId = src[1].AcervoId,
            Acervos = (IEnumerable<Application.Dto.Acervos.AcervoDto>)src[1].Acervos,
            PatrimonioId = src[1].PatrimonioId,
            Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src[1].Patrimonios
          }
        });

      //Act
      var emprestimosConsultados = await _emprestimoServices.GetAllEmprestimosAsync();

      //Assert
      Assert.True(emprestimosConsultados.Count().Equals(2));
      emprestimoPersistenceMock.Verify(p => p.GetAllEmprestimosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmprestimoService.GetAllEmprestimosAsync), "Insucesso")]
    public async Task GetAllEmprestimosAsync_DeveRetornarUmaListaVazia_QuandoNaoExistirEmprestimosCadastrados()
    {
      //Arrange
      emprestimoPersistenceMock
        .Setup(p => p.GetAllEmprestimosAsync())
        .ReturnsAsync(emprestimoFixture.ObterListaVaziaDeEmprestimosMock());


      mapperMock
        .Setup(x => x.Map<EmprestimoDto[]>(It.IsAny<IEnumerable<Emprestimo>>()))
        .Returns((List<Emprestimo> src) => new EmprestimoDto[] { });

      //Act
      var emprestimosConsultados = await _emprestimoServices.GetAllEmprestimosAsync();

      //Assert
      Assert.False(emprestimosConsultados.Count() > 0);
      emprestimoPersistenceMock.Verify(p => p.GetAllEmprestimosAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmprestimoService.GetEmprestimoByIdAsync), "Sucesso")]
    public async Task GetEmprestimoByIdAsync_DeveRetornarOsDadosDoEmprestimo_QuandoOIdInformadoForValido()
    {
      //Arrange
      emprestimoPersistenceMock
        .Setup(p => p.GetEmprestimoByIdAsync(7))
        .Callback<int>(Id => Assert.Equal(7, Id))
        .ReturnsAsync(emprestimoFixture.ObterApenasUmEmprestimoMock(7));


      mapperMock
        .Setup(x => x.Map<EmprestimoDto>(It.IsAny<Emprestimo>()))
        .Returns((Emprestimo src) => new EmprestimoDto {
          Id = src.Id,
          UserName = src.UserName,
          //Devolvido = src.Devolvido,
          DataEmprestimo = src.DataEmprestimo,
          DataPrevistaDevolucao = src.DataPrevistaDevolucao,
          QtdeDiasEmprestimo = src.QtdeDiasEmprestimo,
          DataDevolucao = src.DataDevolucao,
          QtdeDiasAtraso = src.QtdeDiasAtraso,
          AcervoId = src.AcervoId,
          Acervos = (IEnumerable<Application.Dto.Acervos.AcervoDto>)src.Acervos,
          PatrimonioId = src.PatrimonioId,
          Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src.Patrimonios
      });

      //Act
      var emprestimoConsultado = await _emprestimoServices.GetEmprestimoByIdAsync(7);

      //Assert
      Assert.Equal(7, emprestimoConsultado.Id);
      Assert.IsType<EmprestimoDto>(emprestimoConsultado);
      emprestimoPersistenceMock.Verify(p => p.GetEmprestimoByIdAsync(7), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmprestimoService.GetEmprestimoByIdAsync), "Insucesso")]
    public async Task GetEmprestimoByIdAsync_NaoDeveRetornarOsDadosDoEmprestimo_QuandoOIdInformadoForInvalido()
    {
      //Arrange
      emprestimoPersistenceMock
        .Setup(d => d.GetEmprestimoByIdAsync(100))
        .Callback<int>(Id => Assert.Equal(100, Id))
        .ReturnsAsync(emprestimoFixture.ObterApenasUmEmprestimoMock(100));


      mapperMock
      .Setup(x => x.Map<EmprestimoDto>(It.IsAny<Emprestimo>()))
      .Returns((Emprestimo src) => new EmprestimoDto {
        Id = src.Id,
        UserName = src.UserName,
        //Devolvido = src.Devolvido,
        DataEmprestimo = src.DataEmprestimo,
        DataPrevistaDevolucao = src.DataPrevistaDevolucao,
        QtdeDiasEmprestimo = src.QtdeDiasEmprestimo,
        DataDevolucao = src.DataDevolucao,
        QtdeDiasAtraso = src.QtdeDiasAtraso,
        AcervoId = src.AcervoId,
        Acervos = (IEnumerable<Application.Dto.Acervos.AcervoDto>)src.Acervos,
        PatrimonioId = src.PatrimonioId,
        Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)src.Patrimonios
      });

      //Act
      var emprestimoConsultado = await _emprestimoServices.GetEmprestimoByIdAsync(100);

      //Assert
      Assert.Null(emprestimoConsultado);
      emprestimoPersistenceMock.Verify(p => p.GetEmprestimoByIdAsync(100), Times.Once);

    }

    [Fact]
    [Trait(nameof(IEmprestimoService.CreateEmprestimo), "Sucesso")]
    public async Task CreateEmprestimo_DeveRealizarAInclusaoDoEmprestimo_QuandoOsDadosForemValidos()
    {
      //Arrange
      var emprestimoDto = emprestimoFixture.CriarEmprestimoValidoDtoMock();
      var emprestimo = emprestimoFixture.CriarEmprestimoValidoMock();


      mapperMock
        .Setup(m => m.Map<Emprestimo>(It.IsAny<EmprestimoDto>()))
        .Returns((EmprestimoDto src) => new Emprestimo {
          Id = src.Id,
          UserName = src.UserName,
          //Devolvido = src.Devolvido,
          DataEmprestimo = src.DataEmprestimo,
          DataPrevistaDevolucao = src.DataPrevistaDevolucao,
          QtdeDiasEmprestimo = src.QtdeDiasEmprestimo,
          DataDevolucao = src.DataDevolucao,
          QtdeDiasAtraso = src.QtdeDiasAtraso,
          AcervoId = src.AcervoId,
          Acervos = (IEnumerable<Acervo>)src.Acervos,
          PatrimonioId = src.PatrimonioId,
          Patrimonios = (IEnumerable<Patrimonio>)src.Patrimonios
        });

      mapperMock
        .Setup(m => m.Map<EmprestimoDto>(It.IsAny<Emprestimo>()))
        .Returns((Emprestimo source) => new EmprestimoDto {
          Id = source.Id,
          UserName = source.UserName,
          //Devolvido = source.Devolvido,
          DataEmprestimo = source.DataEmprestimo,
          DataPrevistaDevolucao = source.DataPrevistaDevolucao,
          QtdeDiasEmprestimo = source.QtdeDiasEmprestimo,
          DataDevolucao = source.DataDevolucao,
          QtdeDiasAtraso = source.QtdeDiasAtraso,
          AcervoId = source.AcervoId,
          Acervos = (IEnumerable<Application.Dto.Acervos.AcervoDto>)source.Acervos,
          PatrimonioId = source.PatrimonioId,
          Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)source.Patrimonios

        });

      sharedPersistenceMock
        .Setup(c => c.Create<Emprestimo>(emprestimo));

      emprestimoPersistenceMock
        .Setup(s => s.SaveChangesAsync())
        .ReturnsAsync(true);

      emprestimoPersistenceMock
        .Setup(g => g.GetEmprestimoByIdAsync(emprestimo.Id))
        .Callback<int>(Id => Assert.Equal(26, Id))
        .ReturnsAsync(emprestimoFixture.ObteEmprestimoCriadoMock(emprestimo.Id));

      //Act
      var emprestimoCriado = await _emprestimoServices.CreateEmprestimo(emprestimoDto);

      //Assert
      Assert.Equal(26, emprestimoCriado.Id);
      Assert.IsType<EmprestimoDto>(emprestimoCriado);
      emprestimoPersistenceMock.Verify(p => p.GetEmprestimoByIdAsync(26), Times.Once);
      emprestimoPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmprestimoService.CreateEmprestimo), "Insucesso")]
    public async Task CreateEmprestimo_NaoDeveRealizarAInclusaoDoEmprestimo_QuandoOsDadosForemInvalidos()
    {
      //Arrange
      var emprestimoDto = emprestimoFixture.CriarEmprestimoInvalidoDtoMock();
      var emprestimo = emprestimoFixture.CriarEmprestimoInvalidoMock();

      mapperMock
        .Setup(m => m.Map<Emprestimo>(It.IsAny<EmprestimoDto>()))
        .Returns((EmprestimoDto src) => new Emprestimo {
          Id = src.Id,
          UserName = src.UserName,
          //Devolvido = src.Devolvido,
          DataEmprestimo = src.DataEmprestimo,
          DataPrevistaDevolucao = src.DataPrevistaDevolucao,
          QtdeDiasEmprestimo = src.QtdeDiasEmprestimo,
          DataDevolucao = src.DataDevolucao,
          QtdeDiasAtraso = src.QtdeDiasAtraso,
          AcervoId = src.AcervoId,
          Acervos = (IEnumerable<Acervo>)src.Acervos,
          PatrimonioId = src.PatrimonioId,
          Patrimonios = (IEnumerable<Patrimonio>)src.Patrimonios
        });

      mapperMock
        .Setup(m => m.Map<EmprestimoDto>(It.IsAny<Emprestimo>()))
        .Returns((Emprestimo source) => new EmprestimoDto {
          Id = source.Id,
          UserName = source.UserName,
          //Devolvido = source.Devolvido,
          DataEmprestimo = source.DataEmprestimo,
          DataPrevistaDevolucao = source.DataPrevistaDevolucao,
          QtdeDiasEmprestimo = source.QtdeDiasEmprestimo,
          DataDevolucao = source.DataDevolucao,
          QtdeDiasAtraso = source.QtdeDiasAtraso,
          AcervoId = source.AcervoId,
          Acervos = (IEnumerable<Application.Dto.Acervos.AcervoDto>)source.Acervos,
          PatrimonioId = source.PatrimonioId,
          Patrimonios = (IEnumerable<Application.Dto.Patrimonios.PatrimonioDto>)source.Patrimonios
        });

      sharedPersistenceMock
        .Setup(c => c.Create<Emprestimo>(emprestimo));

      emprestimoPersistenceMock
        .Setup(s => s.SaveChangesAsync())
        .ReturnsAsync(false);

      //Act
      var emprestimoCriado = await _emprestimoServices.CreateEmprestimo(emprestimoDto);

      //Assert
      Assert.Null(emprestimoCriado);
      emprestimoPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmprestimoService.DeleteEmprestimo), "Sucesso")]
    public async Task DeleteEmprestimo_DeveRealizarAExclusaoDoEmprestimo_QuandoOEmprestimoExistir()
    {
      //Arrange
      var emprestimo = emprestimoFixture.ObterApenasUmEmprestimoMock(7);

      emprestimoPersistenceMock
        .Setup(g => g.GetEmprestimoByIdAsync(7))
        .ReturnsAsync(emprestimoFixture.ObterApenasUmEmprestimoMock(7));

      sharedPersistenceMock
        .Setup(c => c.Delete<Emprestimo>(emprestimo));

      emprestimoPersistenceMock
        .Setup(s => s.SaveChangesAsync())
        .ReturnsAsync(true);

      //Act
      var emprestimoExcluido = await _emprestimoServices.DeleteEmprestimo(emprestimo.Id);

      //Assert
      Assert.True(emprestimoExcluido);
      emprestimoPersistenceMock.Verify(p => p.GetEmprestimoByIdAsync(7), Times.Once);
      emprestimoPersistenceMock.Verify(s => s.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    [Trait(nameof(IEmprestimoService.DeleteEmprestimo), "Insucesso")]
    public async Task DeleteEmprestimo_NaoDeveRealizarAExclusaoDoEmprestimo_QuandoOEmprestimoNaoExistir()
    {
      //Arrange
      var emprestimo = emprestimoFixture.ObterApenasUmEmprestimoMock(7);

      emprestimoPersistenceMock
        .Setup(g => g.GetEmprestimoByIdAsync(8))
        .ReturnsAsync(emprestimoFixture.ObterApenasUmEmprestimoMock(8));

      sharedPersistenceMock
        .Setup(c => c.Delete<Emprestimo>(emprestimo));


      //Act & Assert
      await Assert.ThrowsAsync<Exception>(() => _emprestimoServices.DeleteEmprestimo(emprestimo.Id));
      emprestimoPersistenceMock.Verify(p => p.GetEmprestimoByIdAsync(7), Times.Once);
    }
  }
}

using AutoMapper;
using BibCorp.Application.Dto.Acervos;
using BibCorp.Application.Services.Contracts.Acervos;
using BibCorp.Domain.Models.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;
using BibCorp.Persistence.Utilities.Pages.Class;

namespace BibCorp.Application.Services.Packages.Acervos
{
  public class AcervoService : IAcervoService
  {
    private readonly IAcervoPersistence _acervoPersistence;
    private readonly IMapper _mapper;
    public AcervoService(
        IAcervoPersistence acervoPersistence,
        IMapper mapper)
    {
      _acervoPersistence = acervoPersistence;
      _mapper = mapper;
    }
    public async Task<AcervoDto> CreateAcervo(AcervoDto acervoDto)
    {
      try
      {
        var acervo = _mapper.Map<Acervo>(acervoDto);

        _acervoPersistence.Create<Acervo>(acervo);

        if (await _acervoPersistence.SaveChangesAsync())
        {
          var acervoRetorno = await _acervoPersistence.GetAcervoByIdAsync(acervo.Id);

          return _mapper.Map<AcervoDto>(acervoRetorno);
        }

        return null;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<bool> DeleteAcervo(int acervoId)
    {
      try
      {
        var acervo = await _acervoPersistence.GetAcervoByIdAsync(acervoId);

        if (acervo == null)
          throw new Exception("Acervo para deleção náo foi encontrado!");

        _acervoPersistence.Delete<Acervo>(acervo);

        return await _acervoPersistence.SaveChangesAsync();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<IEnumerable<AcervoDto>> GetAllAcervosAsync()
    {
      try
      {
        var acervos = await _acervoPersistence.GetAllAcervosAsync();

        if (acervos == null) return null;

        var acervosMappper = _mapper.Map<AcervoDto[]>(acervos);

        return acervosMappper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<AcervoDto> GetAcervoByIdAsync(int acervoId)
    {
      try
      {
        var acervo = await _acervoPersistence.GetAcervoByIdAsync(acervoId);

        if (acervo == null) return null;

        var acervoMapper = _mapper.Map<AcervoDto>(acervo);

        return acervoMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<AcervoDto> UpdateAcervo(int acervoId, AcervoDto acervoDto)
    {
      try
      {
        var acervo = await _acervoPersistence.GetAcervoByIdAsync(acervoId);

        if (acervo == null) return null;

        var acervoUpdate = _mapper.Map(acervoDto, acervo);

        _acervoPersistence.Update<Acervo>(acervoUpdate);

        if (await _acervoPersistence.SaveChangesAsync())
        {
          var acervoMapper = await _acervoPersistence.GetAcervoByIdAsync(acervoUpdate.Id);
          return _mapper.Map<AcervoDto>(acervoMapper);
        }

        return null;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<AcervoDto> GetAcervoByISBNAsync(string ISBN)
    {
      try
      {
        var acervo = await _acervoPersistence.GetAcervoByISBNAsync(ISBN);

        if (acervo == null) return null;

        var acervoMapper = _mapper.Map<AcervoDto>(acervo);

        return acervoMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
    public async Task<ListaDePaginas<AcervoDto>> GetAcervosRecentesAsync(ParametrosPaginacao parametrosPaginacao)
    {
      try
      {
        var acervos = await _acervoPersistence.GetAcervosRecentesAsync(parametrosPaginacao);
        Console.WriteLine("AquiService");

        if (acervos == null) return null;

        var acervosMappper = _mapper.Map<ListaDePaginas<AcervoDto>>(acervos);

        acervosMappper.PaginaCorrente = acervos.PaginaCorrente;
        acervosMappper.TotalDePaginas = acervos.TotalDePaginas;
        acervosMappper.TamanhoDaPagina = acervos.TamanhoDaPagina;
        acervosMappper.ContadorTotal = acervos.ContadorTotal;

        return acervosMappper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<ListaDePaginas<AcervoDto>> GetAcervosPaginacaoAsync(ParametrosPaginacao parametrosPaginacao)
    {
      try
      {
        var acervos = await _acervoPersistence.GetAcervosRecentesAsync(parametrosPaginacao);
        Console.WriteLine("AquiService");

        if (acervos == null) return null;

        var acervosMappper = _mapper.Map<ListaDePaginas<AcervoDto>>(acervos);

        acervosMappper.PaginaCorrente = acervos.PaginaCorrente;
        acervosMappper.TotalDePaginas = acervos.TotalDePaginas;
        acervosMappper.TamanhoDaPagina = acervos.TamanhoDaPagina;
        acervosMappper.ContadorTotal = acervos.ContadorTotal;

        return acervosMappper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

  }
}

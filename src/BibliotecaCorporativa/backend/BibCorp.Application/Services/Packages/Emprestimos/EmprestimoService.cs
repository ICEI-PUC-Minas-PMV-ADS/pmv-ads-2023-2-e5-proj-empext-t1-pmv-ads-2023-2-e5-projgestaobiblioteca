using AutoMapper;
using BibCorp.Application.Dto.Emprestimos;
using BibCorp.Application.Dtos.Emprestimos;
using BibCorp.Application.Services.Contracts.Emprestimos;
using BibCorp.Domain.Exceptions;
using BibCorp.Domain.Models.Emprestimos;
using BibCorp.Persistence.Interfaces.Contracts.Acervos;
using BibCorp.Persistence.Interfaces.Contracts.Emprestimos;
using BibCorp.Persistence.Interfaces.Contracts.Patrimonios;

namespace BibCorp.Application.Services.Packages.Emprestimos
{
  public class EmprestimoService : IEmprestimoService
  {
    private readonly IEmprestimoPersistence _emprestimoPersistence;
    private readonly IAcervoPersistence _acervoPersistence;
    private readonly IPatrimonioPersistence _patrimonioPersistence;
    private readonly IMapper _mapper;
    public EmprestimoService(
        IEmprestimoPersistence emprestimoPersistence,
        IAcervoPersistence acervoPersistence,
        IPatrimonioPersistence patrimonioPersistence,
        IMapper mapper)
    {
      _emprestimoPersistence = emprestimoPersistence;
      _acervoPersistence = acervoPersistence;
      _patrimonioPersistence = patrimonioPersistence;
      _mapper = mapper;
    }
    public async Task<EmprestimoDto> CreateEmprestimo(EmprestimoDto emprestimoDto)
    {

      var acervo = await _acervoPersistence.GetAcervoByIdAsync(emprestimoDto.AcervoId);
      var qtdeDisponivelAcervo = acervo.QtdeDisponivel;

      if (qtdeDisponivelAcervo > 0)
      {
        try
        {
          var emprestimo = _mapper.Map<Emprestimo>(emprestimoDto);

          _emprestimoPersistence.Create<Emprestimo>(emprestimo);

          if (await _emprestimoPersistence.SaveChangesAsync())
          {
            var emprestimoRetorno = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimo.Id);

            if (await _patrimonioPersistence.UpdatePatrimonioAposEmprestimo(emprestimo.PatrimonioId))
            {
              await _acervoPersistence.UpdateAcervoAposEmprestimo(emprestimo.AcervoId);
            }

            return _mapper.Map<EmprestimoDto>(emprestimoRetorno);
          }

          return null;
        }
        catch (CoreException e)
        {

          throw new CoreException(e.Message);
        }
      }

      throw new CoreException("Acervo não possui unidades disponíveis para empréstimo");

    }

    public async Task<bool> DeleteEmprestimo(int emprestimoId)
    {
      try
      {
        var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

        if (emprestimo == null)
          throw new Exception("Emprestimo para deleção não foi encontrado!");

        _emprestimoPersistence.Delete<Emprestimo>(emprestimo);

        return await _emprestimoPersistence.SaveChangesAsync();
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }
    public async Task<IEnumerable<EmprestimoDto>> GetAllEmprestimosAsync()
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetAllEmprestimosAsync();

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<EmprestimoDto> GetEmprestimoByIdAsync(int emprestimoId)
    {
      try
      {
        var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

        if (emprestimo == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto>(emprestimo);

        return emprestimoMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<EmprestimoDto> UpdateEmprestimo(int emprestimoId, EmprestimoDto emprestimoDto)
    {
      try
      {
        var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

        if (emprestimo == null) return null;

        var emprestimoUpdate = _mapper.Map(emprestimoDto, emprestimo);

        _emprestimoPersistence.Update<Emprestimo>(emprestimoUpdate);

        if (await _emprestimoPersistence.SaveChangesAsync())
        {
          var emprestimoMapper = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoUpdate.Id);
          return _mapper.Map<EmprestimoDto>(emprestimoMapper);
        }

        return null;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }


    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByUserNameAsync(string userName)
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetEmprestimosByUserNameAsync(userName);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByAcervoIdAsync(int acervoId)
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetEmprestimosByAcervoIdAsync(acervoId);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByPatrimonioIdAsync(int patrimonioId)
    {
      try
      {
        var emprestimos = await _emprestimoPersistence.GetEmprestimosByPatrimonioIdAsync(patrimonioId);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {

        throw new Exception(e.Message);
      }
    }

    public async Task<EmprestimoDto> RenovarEmprestimo(int emprestimoId)
    {
      var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

      if (emprestimo == null) return null;

      if (emprestimo.Status == TipoStatusEmprestimo.Renovado) throw new CoreException("Renovação não permitida pois o empréstimo já foi renovado anteriormente");

      var emprestimoRenovado = await _emprestimoPersistence.RenovarEmprestimo(emprestimoId);

      var emprestimoRenovadoMapper = _mapper.Map<EmprestimoDto>(emprestimoRenovado);

      return emprestimoRenovadoMapper;

    }

    public async Task<EmprestimoDto> AlterarLocalDeColeta(int emprestimoId, string novoLocalColeta)
    {
      var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

      if (emprestimo == null) return null;

      if (emprestimo.Status == TipoStatusEmprestimo.Devolvido) throw new CoreException("Não é possível alterar o local de coleta de um empréstimo já devolvido");

      var emprestimoAlterado = await _emprestimoPersistence.AlterarLocalDeColeta(emprestimoId, novoLocalColeta);

      var emprestimoAlteradoMapper = _mapper.Map<EmprestimoDto>(emprestimoAlterado);

      return emprestimoAlteradoMapper;

    }

    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByStatusAsync(TipoStatusEmprestimoDto[] status)
    {
      try
      {
        var statusMapper = _mapper.Map<TipoStatusEmprestimo[]>(status);

        var emprestimos = await _emprestimoPersistence.GetEmprestimosByStatusAsync(statusMapper);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<EmprestimoDto> GerenciarEmprestimos(int emprestimoId, GerenciamentoEmprestimo gerenciamentoEmprestimo)
    {
      try
      {
      
        var emprestimo = await _emprestimoPersistence.GetEmprestimoByIdAsync(emprestimoId);

        if (emprestimo == null) return null;

        var emprestimoAlterado = await _emprestimoPersistence.GerenciarEmprestimos(emprestimoId, gerenciamentoEmprestimo);

        if ( gerenciamentoEmprestimo.Acao == TipoAcaoEmprestimo.Devolver || gerenciamentoEmprestimo.Acao == TipoAcaoEmprestimo.Recusar)
        {
          if(await _patrimonioPersistence.UpdatePatrimonioAposDevolucaoOuRecusa(emprestimo.PatrimonioId))
          {
            await _acervoPersistence.UpdateAcervoAposDevolucaoOuRecusa(emprestimo.AcervoId);
          }
        }

        var emprestimoAlteradoMapper = _mapper.Map<EmprestimoDto>(emprestimoAlterado);

        return emprestimoAlteradoMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }

    public async Task<IEnumerable<EmprestimoDto>> GetEmprestimosByFiltrosAsync(FiltroEmprestimoDto filtroEmprestimoDto)
    {
      try
      {
        var filtroEmprestimoMapper = _mapper.Map<FiltroEmprestimo>(filtroEmprestimoDto);

        var emprestimos = await _emprestimoPersistence.GetEmprestimosByFiltrosAsync(filtroEmprestimoMapper);

        if (emprestimos == null) return null;

        var emprestimoMapper = _mapper.Map<EmprestimoDto[]>(emprestimos);

        return emprestimoMapper;
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
    }
  }
}


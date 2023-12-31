using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain.Biblioteca;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class UsuarioService : IUsuariosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IUsuarioPersist _usuarioPersist;

        public UsuarioService(IGeralPersist geralPersist, IUsuarioPersist usuarioPersist)
        {
            _usuarioPersist = usuarioPersist;
            _geralPersist = geralPersist;
            
        }
        public async Task<Usuario> AddUsuario(Usuario model)
        {
            try
            {
                _geralPersist.Add<Usuario>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    //opcional pois vc pode ou não retornar algo após salvar mudanças.
                    return await _usuarioPersist.GetUsuarioByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> UpdateUsuario(int usuarioId, Usuario model)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId, false);
                if(usuario == null) return null;

                model.Id = usuario.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    //opcional pois vc pode ou não retornar algo após salvar mudanças.
                    return await _usuarioPersist.GetUsuarioByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUsuario(int usuarioId)
        {
            try
            {
                var usuario = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId, false);
                if(usuario == null) throw new Exception("Usuario para Deletar não encontrado");


                _geralPersist.Delete<Usuario>(usuario);
                return await _geralPersist.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario[]> GetAllUsuariosByNomeAsync(string nome, bool includePalestrantes = false)
        {
            try
            {
                var usuarios = await _usuarioPersist.GetAllUsuariosByNomeAsync(nome, includePalestrantes);
                if(usuarios == null) return null;

                return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario[]> GetAllUsuariosAsync(bool includePalestrantes = false)
        {
            try
            {
                var usuarios = await _usuarioPersist.GetAllUsuariosAsync(includePalestrantes);
                if(usuarios == null) return null;

                return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int usuarioId, bool includePalestrantes = false)
        {
            try
            {
                var usuarios = await _usuarioPersist.GetUsuarioByIdAsync(usuarioId, includePalestrantes);
                if(usuarios == null) return null;

                return usuarios;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

    }
}
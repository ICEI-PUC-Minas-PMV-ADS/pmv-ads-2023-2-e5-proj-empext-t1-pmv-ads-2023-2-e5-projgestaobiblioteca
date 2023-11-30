namespace OnPeople.API.Controllers.Uploads
{
    public interface IUploadService
    {
        void DeleteImageUpload(int contaId, string nomeImagem, string destino);
        Task<string> SaveImageUpload(int contaId, IFormFile arquivoImagem, string destino);
    }

}

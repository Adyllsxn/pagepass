namespace PagePass.Application.Interfaces
{
    public interface ISistemeService
    {
        Task<QuantidadeItemsDTO> SelecionarQtdItems();
    }
}
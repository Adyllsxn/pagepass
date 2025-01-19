namespace PagePass.Domain.Interfaces
{
    public interface ISistemeRepository
    {
        Task<QuantidadeItensEntity> SelecionarQtdItems();
    }
}
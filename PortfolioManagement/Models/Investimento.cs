namespace PortfolioManagement.Models
{
    public class Investimento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int ProdutoFinanceiroId { get; set; }
        public ProdutoFinanceiro ProdutoFinanceiro { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDaCompra { get; set; }
        public DateTime? DataDaVenda { get; set; }
        public string Status { get; set; } // Ativo, Vendido
    }
}

namespace PortfolioManagement.Models
{
    public class ProdutoFinanceiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime DataDeVencimento { get; set; }
        public decimal TaxaDeRetorno { get; set; }
        public string Status { get; set; } // Disponível, Vendido, Vencido

        // Propriedade Cliente
        public Cliente Cliente { get; set; }
    }
}


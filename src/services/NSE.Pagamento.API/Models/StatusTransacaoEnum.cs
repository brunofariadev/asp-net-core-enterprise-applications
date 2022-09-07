namespace NSE.Pagamento.API.Models
{
    public enum StatusTransacaoEnum
    {
        Autorizado = 1,
        Pago,
        Negado,
        Estornado,
        Cancelado
    }
}

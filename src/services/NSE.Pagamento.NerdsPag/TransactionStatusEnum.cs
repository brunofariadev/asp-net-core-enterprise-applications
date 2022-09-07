namespace NSE.Pagamento.NerdsPag
{
    public enum TransactionStatusEnum
    {
        Authorized = 1,
        Paid,
        Refused,
        Chargedback,
        Cancelled
    }
}

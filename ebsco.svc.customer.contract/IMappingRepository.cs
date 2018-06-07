namespace ebsco.svc.customer.contract
{
    public interface IMappingRepository
    {
        string GetDDECustomerIdBySSDAccountNumber(string officeCode, int ebscoAccount);
    }
}

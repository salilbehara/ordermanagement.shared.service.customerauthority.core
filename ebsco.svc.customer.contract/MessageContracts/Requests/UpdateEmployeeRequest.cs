namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class UpdateEmployeeRequest: UpdateRequestBase
    {
        public Employee Employee { get; set; }
    }
}

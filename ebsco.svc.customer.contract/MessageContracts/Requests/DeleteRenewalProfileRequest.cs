﻿namespace ebsco.svc.customer.contract.MessageContracts.Requests
{
    public class DeleteRenewalProfileRequest : UpdateRequestBase
    {
        public int ProfileId { get; set; }
    }
}

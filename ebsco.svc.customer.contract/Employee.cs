using ebsco.svc.changehistory.contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ebsco.svc.customer.contract
{

    [ChangeHistory(Name = "Employee")]
    public class Employee : IValidatableObject
    {
        public Employee()
        {
            EmployeeLegacyMappings = new List<EmployeeLegacyMapping>();
            RolesList = new List<EmployeeRole>();
        }
        public int Id { get; set; }

        public string SecurityID { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }


        [MaxLength(2)]
        [ChangeHistory(Name = "AR Clerk Code")]
        public string ARClerkCode { get; set; }

        [MaxLength(3)]
        [ChangeHistory(Name = "Salesman Code")]
        public string SalesmanCode { get; set; }

        [ChangeHistory(Name = "Mainframe User ID")]
        public List<EmployeeLegacyMapping> EmployeeLegacyMappings { get; set; }

        [ChangeHistory(Name = "Employee Role")]
        public List<EmployeeRole> RolesList { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsInactive { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            //IRepository repository = null;
            //try
            //{
            //    repository = ServiceLocator.Current.GetInstance(typeof(IRepository)) as IRepository;
            //}
            //catch (ActivationException)
            //{
            //    //do nothing
            //}

            #region ARClerkCode
            if (RolesList.Exists(x => x.Role == "AR") && string.IsNullOrWhiteSpace(ARClerkCode))
            results.Add(new ValidationResult("AR Clerk Code is required for Accounts Receivable Representative.", new[] { "ARClerkCode" }));
            #endregion

            #region SalesmanCode
            if (RolesList.Exists(x => x.Role == "REP") && string.IsNullOrWhiteSpace(SalesmanCode))
                results.Add(new ValidationResult("Salesman Code is required if SSD Sales Representative.", new[] { "SalesmanCode" }));
            #endregion

            //if(repository != null)
            //{
            //    var previousEmp = repository.GetEmployee(this.Id);
            //    if (previousEmp != null)
            //    {
            //        //repository.GetCustomersHavingEmployee(this.Id);
            //        if (previousEmp.RolesList.Any(x => x.Role == "AR") && !this.RolesList.Any(x => x.Role == "AR"))
            //        {
            //            //AR was removed, check for accounts that employee is assigned as AR and throw validation if they exist
            //            if (repository.GetCustomersHavingEmployeeAndRole(this.Id, "AR").Any())
            //            {
            //                results.Add(new ValidationResult("Accounts found with employee assigned as Accounts Receiveable Representative."));
            //            }
            //        }
            //        if (previousEmp.RolesList.Any(x => x.Role == "REP") && !this.RolesList.Any(x => x.Role == "REP"))
            //        {
            //            //REP was removed, check for accounts that employee is assigned as REP and throw validation if they exist
            //            if (repository.GetCustomersHavingEmployeeAndRole(this.Id, "REP").Any())
            //            {
            //                results.Add(new ValidationResult("Accounts found with employee assigned as SSD Sales Representative."));
            //            }
            //        }
            //        if (previousEmp.RolesList.Any(x => x.Role == "ER") && !this.RolesList.Any(x => x.Role == "ER"))
            //        {
            //            //ER was removed, check for accounts that employee is assigned as ER and throw validation if they exist
            //            if (repository.GetCustomersHavingEmployeeAndRole(this.Id, "ER").Any())
            //            {
            //                results.Add(new ValidationResult("Accounts found with employee assigned as eResource Representative."));
            //            }
            //        }
            //        if (previousEmp.RolesList.Any(x => x.Role == "ASM") && !this.RolesList.Any(x => x.Role == "ASM"))
            //        {
            //            //ASM was removed, check for accounts that employee is assigned as ASM and throw validation if they exist
            //            if (repository.GetCustomersHavingEmployeeAndRole(this.Id, "ASM").Any())
            //            {
            //                results.Add(new ValidationResult("Accounts found with employee assigned as Account Service Manager."));
            //            }
            //        }
            //        if (previousEmp.RolesList.Any(x => x.Role == "CSR") && !this.RolesList.Any(x => x.Role == "CSR"))
            //        {
            //            //CSR was removed, check for accounts that employee is assigned as CSR and throw validation if they exist
            //            if (repository.GetCustomersHavingEmployeeAndRole(this.Id, "CSR").Any())
            //            {
            //                results.Add(new ValidationResult("Accounts found with employee assigned as Customer Service Representative."));
            //            }
            //        }
            //    }

            //}

            return results;
        }
    }
}

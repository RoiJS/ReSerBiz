using System.Collections.Generic;
using ReserbizAPP.LIB.Interfaces;

namespace ReserbizAPP.LIB.Models
{
    public class PaymentPaginationListDto : IPaymentPaginationListDto
    {
        public double TotalAmount { get; set; }
        public double TotalAmountFromDeposit { get; set; }
        public double DepositedAmountBalance { get; set; }
        public double SuggestedRentalAmount { get; set; }
        public double SuggestedElectricBillAmount { get; set; }
        public double SuggestedWaterBillAmount { get; set; }
        public double SuggestedMiscelleneousAmount { get; set; }
        public double SuggestedPenaltyAmount { get; set; }
        public int TotalItems { get; set; }
        public int Page { get; set; }
        public int NumberOfItemsPerPage { get; set; }
        public IEnumerable<IEntityDto> Items { get; set; }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using ReserbizAPP.LIB.Models;

namespace ReserbizAPP.LIB.Interfaces
{
    public interface IAccountStatementRepository<TEntity>
        : IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        AccountStatement RegisterNewAccountStament(Contract contract);
        PenaltyBreakdown RegisterNewPenaltyItem(AccountStatement accountStatement);
        Task<AccountStatement> GetSuggestedNewAccountStatement(int contractId);
        Task<AccountStatement> GetAccountStatementAsync(int id);
        Task<IEnumerable<AccountStatement>> GetActiveAccountStatementsPerContractAsync(int contractId);
        Task<IEnumerable<AccountStatement>> GetUnpaidAccountStatementsAsync();
        List<AccountStatement> GetFilteredAccountStatements(IList<AccountStatement> unfilteredAccountStatements, IAccountStatementFilter accountStatementFilter);
        Task GenerateContractAccountStatements(string dbHashName, int contractId);
        Task GenerateContractAccountStatementsForNewDatabase(int contractId, int currentUserId);
        Task GenerateContractAccountStatement(int contractId, bool markAsPaid, int currentUserId);
        Task GenerateAccountStatementPenalties(int tenantId);
        Task<AccountStatement> GetFirstAccountStatement(int contractId);
        float CalculateTotalAmountPaid(IEnumerable<PaymentBreakdown> paymentBreakdowns);
        float CalculateTotalAmountPaidUsingDeposit(IEnumerable<PaymentBreakdown> paymentBreakdowns);
        Task<double> CalculatedDepositedAmountBalance(int contractId, AccountStatement firstAccountStatement);
        double CalculatedSuggestedAmountForPayment(IEnumerable<PaymentBreakdown> paymentBreakdowns, AccountStatement firstAccountStatement, double depositedAmountBalance);
        double CalculateSuggestedAmountForElectricBill(IEnumerable<PaymentBreakdown> paymentBreakdowns, AccountStatement currentAccountStatement, double depositedAmountBalance);
        double CalculateSuggestedAmountForWaterBill(IEnumerable<PaymentBreakdown> paymentBreakdowns, AccountStatement currentAccountStatement, double depositedAmountBalance);
        double CalculateSuggestedAmountForMiscellaneousFees(IEnumerable<PaymentBreakdown> paymentBreakdowns, AccountStatement currentAccountStatement, double depositedAmountBalance);
        double CalculateSuggestedAmountForPenaltyAmount(IEnumerable<PaymentBreakdown> paymentBreakdowns, AccountStatement currentAccountStatement, double depositedAmountBalance);
        Task<float> CalculateOverAllPaymentUsedFromDepositedAmount(int contractId);
        Task<AccountStatementsAmountSummary> GetAccountStatementsAmountSummary();
        Task SendAccountStatement(int id);
    }
}
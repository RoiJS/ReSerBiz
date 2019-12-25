using System.Threading.Tasks;
using ReserbizAPP.LIB.Interfaces;
using ReserbizAPP.LIB.Models;

namespace ReserbizAPP.LIB.BusinessLogic
{
    public class ErrorLogRepository
        : BaseRepository<ErrorLog>, IErrorLogRepository<ErrorLog>
    {
        public ErrorLogRepository(IReserbizRepository<ErrorLog> reserbizRepository)
            : base(reserbizRepository, reserbizRepository.ClientDbContext)
        {

        }

        public async Task RegisterError(string source, string message, string stackTrace, int userId)
        {
            var newError = new ErrorLog()
            {
                Source = source,
                Message = message,
                Stacktrace = stackTrace,
                UserId = userId
            };

            await AddEntity(newError);
        }
    }
}
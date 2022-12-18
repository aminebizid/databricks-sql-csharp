using System.Threading;
using System.Threading.Tasks;

namespace DataBricks.Sql
{
    public interface IResultSet
    {
        bool HasMoreRows { get; set; }
        Task GetRemainingAsync();
        Task CloseAsync(CancellationToken cancellationToken = default);
    }
}
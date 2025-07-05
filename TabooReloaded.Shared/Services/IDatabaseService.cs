using TabooReloaded.Shared.Model;

namespace TabooReloaded.Shared.Services
{
    public interface IDatabaseService
    {
        Task<bool> ConnectAsync();

        Task<bool> DisconnectAsync();

        Task<TabooWordModel> GetTabooWordAsync();

        Task GetTabooWordListAsync(int n);
    }
}

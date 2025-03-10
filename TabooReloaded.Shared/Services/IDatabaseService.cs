namespace TabooReloaded.Shared.Services
{
    public interface IDatabaseService
    {
        Task<bool> ConnectAsync();

        Task<bool> DisconnectAsync();

        Task GetTabooWordAsync();

        Task GetTabooWordListAsync(int n);
    }
}

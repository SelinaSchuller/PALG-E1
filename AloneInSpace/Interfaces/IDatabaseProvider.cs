namespace AloneInSpace.Interfaces
{
    public interface IDatabaseProvider
    {
        //public Task SaveBulletsAsync(int i);
        //public Task<int> GetBulletsAsync();
        //public void DeleteBullets();

        Task<bool> GetShovelAsync();
        Task SaveShovelAsync(bool shovel);

		bool Shovel { get; }
		event EventHandler ShovelChanged;

		Task<bool> GetBackpackAsync();
		Task SaveBackpackAsync(bool backpack);

		bool Backpack { get; }
        event EventHandler BackpackChanged;

        //Task<bool> GetSaveAsync();
        Task<string> GetSaveAsync();
        Task SaveSaveAsync(string save);
        void DeleteSave();

        string Save { get; }
        event EventHandler SaveChanged;


    }
}
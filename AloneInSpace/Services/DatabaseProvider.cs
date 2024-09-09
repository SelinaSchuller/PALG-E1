using AloneInSpace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AloneInSpace.Services
{
	public class DatabaseProvider : IDatabaseProvider
	{

        private const string BACKPACK = "backpackPickedUp";
        private const string SHOVEL = "shovelPickedUp";
        private const string SAVE = "noSave";

        private bool _backpack;
        private bool _shovel;
        private string _save;

        public bool Backpack => _backpack;
        public bool Shovel => _shovel;
        public string Save => _save;

        public event EventHandler BackpackChanged;
        public event EventHandler ShovelChanged;
        public event EventHandler SaveChanged;

        public DatabaseProvider()
		{

		}

		private T Convert<T>(string convert)
		{
			try
			{
				return JsonSerializer.Deserialize<T>(convert);
			}
			catch
			{
				return default;
			}
		}


		private string Saveable<T>(T item)
		{
			return JsonSerializer.Serialize(item);
		}

        public async Task<bool> GetShovelAsync()
        {
            string strShovel = await SecureStorage.GetAsync(SHOVEL);
            bool.TryParse(strShovel, out bool boolShovel);
            _shovel = boolShovel;
            return boolShovel;
        }

        public async Task SaveShovelAsync(bool boolShovel)
        {
            await SecureStorage.SetAsync(SHOVEL, boolShovel.ToString());
            _shovel = boolShovel;
            ShovelChanged?.Invoke(this, EventArgs.Empty);
        }

        public async Task<bool> GetBackpackAsync()
        {
            string strBackpack = await SecureStorage.GetAsync(BACKPACK);
            bool.TryParse(strBackpack, out bool boolBackpack);
            _backpack = boolBackpack;
            return boolBackpack;
        }

        public async Task SaveBackpackAsync(bool boolBackpack)
        {
            await SecureStorage.SetAsync(BACKPACK, boolBackpack.ToString());
            _backpack = boolBackpack;
            BackpackChanged?.Invoke(this, EventArgs.Empty);
        }

        public void DeleteSave()
        {
            SecureStorage.Remove(SAVE);
        }

		//public async Task<bool> GetSaveAsync()
		//{
		//    string strSave = await SecureStorage.GetAsync(SAVE);
		//    bool.TryParse(strSave, out bool boolSave);
		//    return boolSave;
		//}

		public async Task<string> GetSaveAsync()
		{
			string strSave = await SecureStorage.GetAsync(SAVE);

			return string.IsNullOrEmpty(strSave) ? "noSave" : strSave;
		}

		public async Task SaveSaveAsync(string strSave)
        {
            await SecureStorage.SetAsync(SAVE, strSave);
            SaveChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}



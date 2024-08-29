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

		private const string BULLETS = "0";
		private const string GUN = "false";
        private bool _hasGun;

        public bool HasGun => _hasGun;

        public event EventHandler HasGunChanged;

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

		public void DeleteBullets()
		{
			SecureStorage.Remove(BULLETS);
		}

		public async Task<int> GetBulletsAsync()
		{
			string strBullets = await SecureStorage.GetAsync(BULLETS);
			int.TryParse(strBullets, out int intBullet);
			return intBullet;
		}

		public async Task SaveBulletsAsync(int intBullets)
		{
			string strBullets = intBullets.ToString();

			await SecureStorage.SetAsync(BULLETS, strBullets);
		}



		public void DeleteGun()
		{
			SecureStorage.Remove(GUN);
		}

		public async Task<bool> GetGunAsync()
		{
			string strGun = await SecureStorage.GetAsync(GUN);
			bool.TryParse(strGun, out bool boolGun);
			return boolGun;
		}

		public async Task SaveGunAsync(bool boolGun)
		{
			string strGun = boolGun.ToString();

			await SecureStorage.SetAsync(GUN, strGun);
            _hasGun = boolGun;
            HasGunChanged?.Invoke(this, EventArgs.Empty);

        }
    }
}



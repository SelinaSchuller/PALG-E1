using Microsoft.AspNetCore.Components;

namespace AloneInSpace.Services
{
	public interface INavigateToPage
	{
		void OnNavigatedTo(string destination);
	}

	public class NavigateToPage : INavigateToPage
	{
		private readonly NavigationManager _navigationManager;

		public NavigateToPage(NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}

		public void OnNavigatedTo(string destination)
		{
			_navigationManager.NavigateTo($"/{destination}");
		}
        public void OnNavigatedTo(string pageName, int id)
        {
            _navigationManager.NavigateTo($"{pageName}/{id}");
        }

    }
}

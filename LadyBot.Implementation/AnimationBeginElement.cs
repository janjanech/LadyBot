using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LadyBot.Implementation
{
	public class AnimationBeginElement : ComponentBase
	{
		private bool aFirstTime = true;

		[Parameter]
		public string Id { get; set; }

		[Inject]
		private IJSRuntime Js { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			await base.OnAfterRenderAsync(firstRender);
			if (this.aFirstTime)
				await this.Js.InvokeVoidAsync("beginAnimations", (object) this.Id);
			this.aFirstTime = false;
		}
	}
}

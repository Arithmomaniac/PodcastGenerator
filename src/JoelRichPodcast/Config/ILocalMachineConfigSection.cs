using System;

namespace JoelRichPodcast
{
	public interface ILocalMachineConfigSection
	{
		string OutputLocation
		{
			get;
			set;
		}
	}
}
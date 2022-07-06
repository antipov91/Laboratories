using JCMG.EntitasRedux;
using System;

namespace Laboratories.Game
{
    [Game]
    [Serializable]
	public class PossibleActionsComponent : IComponent
	{
		public Actions[] values;
	}
}
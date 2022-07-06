using JCMG.EntitasRedux;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories.Components.Game
{
    [Game]
    [Serializable]
	public class PlacementsComponent : IComponent
	{
		public List<GameObject> values;
	}
}
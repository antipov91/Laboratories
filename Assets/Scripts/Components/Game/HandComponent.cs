using JCMG.EntitasRedux;
using System;
using UnityEngine;

namespace Laboratories.Game
{
    [Game]
    [Serializable]
	public class HandComponent : IComponent
	{
		public Transform instance;
	}
}
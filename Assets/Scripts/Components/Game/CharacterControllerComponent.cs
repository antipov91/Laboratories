using JCMG.EntitasRedux;
using System;
using UnityEngine;

namespace Laboratories.Game
{
    [Game]
    [Serializable]
	public class CharacterControllerComponent : IComponent
	{
		public CharacterController instance;
	}
}
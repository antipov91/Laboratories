using JCMG.EntitasRedux;
using System;
using UnityEngine;

namespace Laboratories.Components.Game
{
    [Game]
    [Serializable]
	public class SocketComponent : IComponent
	{
		public Transform connectPivot;
		public string ownerDeviceName;
		public string id;
	}
}
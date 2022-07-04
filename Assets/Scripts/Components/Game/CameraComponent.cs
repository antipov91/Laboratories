using JCMG.EntitasRedux;
using System;
using UnityEngine;

namespace Laboratories.Components.Game
{
    [Game]
    [Unique]
    [Serializable]
	public class CameraComponent : IComponent
	{
        public Camera instance;
	}
}
//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity
{
	public Laboratories.Components.Game.SocketComponent Socket { get { return (Laboratories.Components.Game.SocketComponent)GetComponent(GameComponentsLookup.Socket); } }
	public bool HasSocket { get { return HasComponent(GameComponentsLookup.Socket); } }

	public void AddSocket(UnityEngine.Transform newConnectPivot, string newOwnerDeviceName, string newId)
	{
		var index = GameComponentsLookup.Socket;
		var component = (Laboratories.Components.Game.SocketComponent)CreateComponent(index, typeof(Laboratories.Components.Game.SocketComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.connectPivot = newConnectPivot;
		component.ownerDeviceName = newOwnerDeviceName;
		component.id = newId;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSocket(UnityEngine.Transform newConnectPivot, string newOwnerDeviceName, string newId)
	{
		var index = GameComponentsLookup.Socket;
		var component = (Laboratories.Components.Game.SocketComponent)CreateComponent(index, typeof(Laboratories.Components.Game.SocketComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.connectPivot = newConnectPivot;
		component.ownerDeviceName = newOwnerDeviceName;
		component.id = newId;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySocketTo(Laboratories.Components.Game.SocketComponent copyComponent)
	{
		var index = GameComponentsLookup.Socket;
		var component = (Laboratories.Components.Game.SocketComponent)CreateComponent(index, typeof(Laboratories.Components.Game.SocketComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.connectPivot = copyComponent.connectPivot;
		component.ownerDeviceName = copyComponent.ownerDeviceName;
		component.id = copyComponent.id;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSocket()
	{
		RemoveComponent(GameComponentsLookup.Socket);
	}
}

//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher
{
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherSocket;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Socket
	{
		get
		{
			if (_matcherSocket == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Socket);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherSocket = matcher;
			}

			return _matcherSocket;
		}
	}
}
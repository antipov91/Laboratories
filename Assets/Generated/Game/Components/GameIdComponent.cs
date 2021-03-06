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
	public Laboratories.Components.Game.IdComponent Id { get { return (Laboratories.Components.Game.IdComponent)GetComponent(GameComponentsLookup.Id); } }
	public bool HasId { get { return HasComponent(GameComponentsLookup.Id); } }

	public void AddId(string newValue)
	{
		var index = GameComponentsLookup.Id;
		var component = (Laboratories.Components.Game.IdComponent)CreateComponent(index, typeof(Laboratories.Components.Game.IdComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceId(string newValue)
	{
		var index = GameComponentsLookup.Id;
		var component = (Laboratories.Components.Game.IdComponent)CreateComponent(index, typeof(Laboratories.Components.Game.IdComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyIdTo(Laboratories.Components.Game.IdComponent copyComponent)
	{
		var index = GameComponentsLookup.Id;
		var component = (Laboratories.Components.Game.IdComponent)CreateComponent(index, typeof(Laboratories.Components.Game.IdComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveId()
	{
		RemoveComponent(GameComponentsLookup.Id);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherId;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Id
	{
		get
		{
			if (_matcherId == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Id);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherId = matcher;
			}

			return _matcherId;
		}
	}
}

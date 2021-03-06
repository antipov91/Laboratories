//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity
{
	public Laboratories.Components.Meta.GameStateComponent GameState { get { return (Laboratories.Components.Meta.GameStateComponent)GetComponent(MetaComponentsLookup.GameState); } }
	public bool HasGameState { get { return HasComponent(MetaComponentsLookup.GameState); } }

	public void AddGameState(Laboratories.GameState newValue)
	{
		var index = MetaComponentsLookup.GameState;
		var component = (Laboratories.Components.Meta.GameStateComponent)CreateComponent(index, typeof(Laboratories.Components.Meta.GameStateComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceGameState(Laboratories.GameState newValue)
	{
		var index = MetaComponentsLookup.GameState;
		var component = (Laboratories.Components.Meta.GameStateComponent)CreateComponent(index, typeof(Laboratories.Components.Meta.GameStateComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyGameStateTo(Laboratories.Components.Meta.GameStateComponent copyComponent)
	{
		var index = MetaComponentsLookup.GameState;
		var component = (Laboratories.Components.Meta.GameStateComponent)CreateComponent(index, typeof(Laboratories.Components.Meta.GameStateComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveGameState()
	{
		RemoveComponent(MetaComponentsLookup.GameState);
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
public sealed partial class MetaMatcher
{
	static JCMG.EntitasRedux.IMatcher<MetaEntity> _matcherGameState;

	public static JCMG.EntitasRedux.IMatcher<MetaEntity> GameState
	{
		get
		{
			if (_matcherGameState == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<MetaEntity>)JCMG.EntitasRedux.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.GameState);
				matcher.ComponentNames = MetaComponentsLookup.ComponentNames;
				_matcherGameState = matcher;
			}

			return _matcherGameState;
		}
	}
}

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
	public Laboratories.Components.Game.SpeedComponent Speed { get { return (Laboratories.Components.Game.SpeedComponent)GetComponent(GameComponentsLookup.Speed); } }
	public bool HasSpeed { get { return HasComponent(GameComponentsLookup.Speed); } }

	public void AddSpeed(float newValue)
	{
		var index = GameComponentsLookup.Speed;
		var component = (Laboratories.Components.Game.SpeedComponent)CreateComponent(index, typeof(Laboratories.Components.Game.SpeedComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceSpeed(float newValue)
	{
		var index = GameComponentsLookup.Speed;
		var component = (Laboratories.Components.Game.SpeedComponent)CreateComponent(index, typeof(Laboratories.Components.Game.SpeedComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopySpeedTo(Laboratories.Components.Game.SpeedComponent copyComponent)
	{
		var index = GameComponentsLookup.Speed;
		var component = (Laboratories.Components.Game.SpeedComponent)CreateComponent(index, typeof(Laboratories.Components.Game.SpeedComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveSpeed()
	{
		RemoveComponent(GameComponentsLookup.Speed);
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
	static JCMG.EntitasRedux.IMatcher<GameEntity> _matcherSpeed;

	public static JCMG.EntitasRedux.IMatcher<GameEntity> Speed
	{
		get
		{
			if (_matcherSpeed == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<GameEntity>)JCMG.EntitasRedux.Matcher<GameEntity>.AllOf(GameComponentsLookup.Speed);
				matcher.ComponentNames = GameComponentsLookup.ComponentNames;
				_matcherSpeed = matcher;
			}

			return _matcherSpeed;
		}
	}
}

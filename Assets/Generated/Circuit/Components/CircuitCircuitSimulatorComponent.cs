//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class CircuitContext
{
	public CircuitEntity CircuitSimulatorEntity { get { return GetGroup(CircuitMatcher.CircuitSimulator).GetSingleEntity(); } }

	public bool IsCircuitSimulator
	{
		get { return CircuitSimulatorEntity != null; }
		set
		{
			var entity = CircuitSimulatorEntity;
			if (value != (entity != null))
			{
				if (value)
				{
					CreateEntity().IsCircuitSimulator = true;
				}
				else
				{
					entity.Destroy();
				}
			}
		}
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
public partial class CircuitEntity
{
	static readonly Laboratories.Components.Circuit.CircuitSimulatorComponent CircuitSimulatorComponent = new Laboratories.Components.Circuit.CircuitSimulatorComponent();

	public bool IsCircuitSimulator
	{
		get { return HasComponent(CircuitComponentsLookup.CircuitSimulator); }
		set
		{
			if (value != IsCircuitSimulator)
			{
				var index = CircuitComponentsLookup.CircuitSimulator;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: CircuitSimulatorComponent;

					AddComponent(index, component);
				}
				else
				{
					RemoveComponent(index);
				}
			}
		}
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
public sealed partial class CircuitMatcher
{
	static JCMG.EntitasRedux.IMatcher<CircuitEntity> _matcherCircuitSimulator;

	public static JCMG.EntitasRedux.IMatcher<CircuitEntity> CircuitSimulator
	{
		get
		{
			if (_matcherCircuitSimulator == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<CircuitEntity>)JCMG.EntitasRedux.Matcher<CircuitEntity>.AllOf(CircuitComponentsLookup.CircuitSimulator);
				matcher.ComponentNames = CircuitComponentsLookup.ComponentNames;
				_matcherCircuitSimulator = matcher;
			}

			return _matcherCircuitSimulator;
		}
	}
}
//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class UiContext
{
	public UiEntity ManagerEntity { get { return GetGroup(UiMatcher.Manager).GetSingleEntity(); } }

	public bool IsManager
	{
		get { return ManagerEntity != null; }
		set
		{
			var entity = ManagerEntity;
			if (value != (entity != null))
			{
				if (value)
				{
					CreateEntity().IsManager = true;
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
public partial class UiEntity
{
	static readonly Laboratories.Components.Ui.ManagerComponent ManagerComponent = new Laboratories.Components.Ui.ManagerComponent();

	public bool IsManager
	{
		get { return HasComponent(UiComponentsLookup.Manager); }
		set
		{
			if (value != IsManager)
			{
				var index = UiComponentsLookup.Manager;
				if (value)
				{
					var componentPool = GetComponentPool(index);
					var component = componentPool.Count > 0
							? componentPool.Pop()
							: ManagerComponent;

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
public sealed partial class UiMatcher
{
	static JCMG.EntitasRedux.IMatcher<UiEntity> _matcherManager;

	public static JCMG.EntitasRedux.IMatcher<UiEntity> Manager
	{
		get
		{
			if (_matcherManager == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<UiEntity>)JCMG.EntitasRedux.Matcher<UiEntity>.AllOf(UiComponentsLookup.Manager);
				matcher.ComponentNames = UiComponentsLookup.ComponentNames;
				_matcherManager = matcher;
			}

			return _matcherManager;
		}
	}
}

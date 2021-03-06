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
	public Laboratories.Components.Ui.RadialMenuComponent RadialMenu { get { return (Laboratories.Components.Ui.RadialMenuComponent)GetComponent(UiComponentsLookup.RadialMenu); } }
	public bool HasRadialMenu { get { return HasComponent(UiComponentsLookup.RadialMenu); } }

	public void AddRadialMenu(Laboratories.RadialMenu newInstance)
	{
		var index = UiComponentsLookup.RadialMenu;
		var component = (Laboratories.Components.Ui.RadialMenuComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.RadialMenuComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = newInstance;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceRadialMenu(Laboratories.RadialMenu newInstance)
	{
		var index = UiComponentsLookup.RadialMenu;
		var component = (Laboratories.Components.Ui.RadialMenuComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.RadialMenuComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = newInstance;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyRadialMenuTo(Laboratories.Components.Ui.RadialMenuComponent copyComponent)
	{
		var index = UiComponentsLookup.RadialMenu;
		var component = (Laboratories.Components.Ui.RadialMenuComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.RadialMenuComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = copyComponent.instance;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveRadialMenu()
	{
		RemoveComponent(UiComponentsLookup.RadialMenu);
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
	static JCMG.EntitasRedux.IMatcher<UiEntity> _matcherRadialMenu;

	public static JCMG.EntitasRedux.IMatcher<UiEntity> RadialMenu
	{
		get
		{
			if (_matcherRadialMenu == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<UiEntity>)JCMG.EntitasRedux.Matcher<UiEntity>.AllOf(UiComponentsLookup.RadialMenu);
				matcher.ComponentNames = UiComponentsLookup.ComponentNames;
				_matcherRadialMenu = matcher;
			}

			return _matcherRadialMenu;
		}
	}
}

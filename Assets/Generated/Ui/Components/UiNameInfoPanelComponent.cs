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
	public Laboratories.Components.Ui.NameInfoPanelComponent NameInfoPanel { get { return (Laboratories.Components.Ui.NameInfoPanelComponent)GetComponent(UiComponentsLookup.NameInfoPanel); } }
	public bool HasNameInfoPanel { get { return HasComponent(UiComponentsLookup.NameInfoPanel); } }

	public void AddNameInfoPanel(Laboratories.NameInfoPanel newInstance)
	{
		var index = UiComponentsLookup.NameInfoPanel;
		var component = (Laboratories.Components.Ui.NameInfoPanelComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.NameInfoPanelComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = newInstance;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceNameInfoPanel(Laboratories.NameInfoPanel newInstance)
	{
		var index = UiComponentsLookup.NameInfoPanel;
		var component = (Laboratories.Components.Ui.NameInfoPanelComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.NameInfoPanelComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = newInstance;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyNameInfoPanelTo(Laboratories.Components.Ui.NameInfoPanelComponent copyComponent)
	{
		var index = UiComponentsLookup.NameInfoPanel;
		var component = (Laboratories.Components.Ui.NameInfoPanelComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.NameInfoPanelComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = copyComponent.instance;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveNameInfoPanel()
	{
		RemoveComponent(UiComponentsLookup.NameInfoPanel);
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
	static JCMG.EntitasRedux.IMatcher<UiEntity> _matcherNameInfoPanel;

	public static JCMG.EntitasRedux.IMatcher<UiEntity> NameInfoPanel
	{
		get
		{
			if (_matcherNameInfoPanel == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<UiEntity>)JCMG.EntitasRedux.Matcher<UiEntity>.AllOf(UiComponentsLookup.NameInfoPanel);
				matcher.ComponentNames = UiComponentsLookup.ComponentNames;
				_matcherNameInfoPanel = matcher;
			}

			return _matcherNameInfoPanel;
		}
	}
}

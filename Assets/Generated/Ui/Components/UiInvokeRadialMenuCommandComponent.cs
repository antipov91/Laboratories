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
	public Laboratories.Components.Ui.InvokeRadialMenuCommandComponent InvokeRadialMenuCommand { get { return (Laboratories.Components.Ui.InvokeRadialMenuCommandComponent)GetComponent(UiComponentsLookup.InvokeRadialMenuCommand); } }
	public bool HasInvokeRadialMenuCommand { get { return HasComponent(UiComponentsLookup.InvokeRadialMenuCommand); } }

	public void AddInvokeRadialMenuCommand(string newGameEntityId)
	{
		var index = UiComponentsLookup.InvokeRadialMenuCommand;
		var component = (Laboratories.Components.Ui.InvokeRadialMenuCommandComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.InvokeRadialMenuCommandComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.gameEntityId = newGameEntityId;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceInvokeRadialMenuCommand(string newGameEntityId)
	{
		var index = UiComponentsLookup.InvokeRadialMenuCommand;
		var component = (Laboratories.Components.Ui.InvokeRadialMenuCommandComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.InvokeRadialMenuCommandComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.gameEntityId = newGameEntityId;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyInvokeRadialMenuCommandTo(Laboratories.Components.Ui.InvokeRadialMenuCommandComponent copyComponent)
	{
		var index = UiComponentsLookup.InvokeRadialMenuCommand;
		var component = (Laboratories.Components.Ui.InvokeRadialMenuCommandComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.InvokeRadialMenuCommandComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.gameEntityId = copyComponent.gameEntityId;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveInvokeRadialMenuCommand()
	{
		RemoveComponent(UiComponentsLookup.InvokeRadialMenuCommand);
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
	static JCMG.EntitasRedux.IMatcher<UiEntity> _matcherInvokeRadialMenuCommand;

	public static JCMG.EntitasRedux.IMatcher<UiEntity> InvokeRadialMenuCommand
	{
		get
		{
			if (_matcherInvokeRadialMenuCommand == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<UiEntity>)JCMG.EntitasRedux.Matcher<UiEntity>.AllOf(UiComponentsLookup.InvokeRadialMenuCommand);
				matcher.ComponentNames = UiComponentsLookup.ComponentNames;
				_matcherInvokeRadialMenuCommand = matcher;
			}

			return _matcherInvokeRadialMenuCommand;
		}
	}
}
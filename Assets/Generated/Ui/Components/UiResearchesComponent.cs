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
	public Laboratories.Components.Ui.ResearchesComponent Researches { get { return (Laboratories.Components.Ui.ResearchesComponent)GetComponent(UiComponentsLookup.Researches); } }
	public bool HasResearches { get { return HasComponent(UiComponentsLookup.Researches); } }

	public void AddResearches(Laboratories.ResearchGroupPanel newInstance)
	{
		var index = UiComponentsLookup.Researches;
		var component = (Laboratories.Components.Ui.ResearchesComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.ResearchesComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = newInstance;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceResearches(Laboratories.ResearchGroupPanel newInstance)
	{
		var index = UiComponentsLookup.Researches;
		var component = (Laboratories.Components.Ui.ResearchesComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.ResearchesComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = newInstance;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyResearchesTo(Laboratories.Components.Ui.ResearchesComponent copyComponent)
	{
		var index = UiComponentsLookup.Researches;
		var component = (Laboratories.Components.Ui.ResearchesComponent)CreateComponent(index, typeof(Laboratories.Components.Ui.ResearchesComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.instance = copyComponent.instance;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveResearches()
	{
		RemoveComponent(UiComponentsLookup.Researches);
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
	static JCMG.EntitasRedux.IMatcher<UiEntity> _matcherResearches;

	public static JCMG.EntitasRedux.IMatcher<UiEntity> Researches
	{
		get
		{
			if (_matcherResearches == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<UiEntity>)JCMG.EntitasRedux.Matcher<UiEntity>.AllOf(UiComponentsLookup.Researches);
				matcher.ComponentNames = UiComponentsLookup.ComponentNames;
				_matcherResearches = matcher;
			}

			return _matcherResearches;
		}
	}
}

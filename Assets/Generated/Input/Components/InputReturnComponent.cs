//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity
{
	public Laboratories.Components.Input.ReturnComponent Return { get { return (Laboratories.Components.Input.ReturnComponent)GetComponent(InputComponentsLookup.Return); } }
	public bool HasReturn { get { return HasComponent(InputComponentsLookup.Return); } }

	public void AddReturn(bool newIsDown, bool newIsPessed, bool newIsUp)
	{
		var index = InputComponentsLookup.Return;
		var component = (Laboratories.Components.Input.ReturnComponent)CreateComponent(index, typeof(Laboratories.Components.Input.ReturnComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.isDown = newIsDown;
		component.isPessed = newIsPessed;
		component.isUp = newIsUp;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceReturn(bool newIsDown, bool newIsPessed, bool newIsUp)
	{
		var index = InputComponentsLookup.Return;
		var component = (Laboratories.Components.Input.ReturnComponent)CreateComponent(index, typeof(Laboratories.Components.Input.ReturnComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.isDown = newIsDown;
		component.isPessed = newIsPessed;
		component.isUp = newIsUp;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyReturnTo(Laboratories.Components.Input.ReturnComponent copyComponent)
	{
		var index = InputComponentsLookup.Return;
		var component = (Laboratories.Components.Input.ReturnComponent)CreateComponent(index, typeof(Laboratories.Components.Input.ReturnComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.isDown = copyComponent.isDown;
		component.isPessed = copyComponent.isPessed;
		component.isUp = copyComponent.isUp;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveReturn()
	{
		RemoveComponent(InputComponentsLookup.Return);
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
public sealed partial class InputMatcher
{
	static JCMG.EntitasRedux.IMatcher<InputEntity> _matcherReturn;

	public static JCMG.EntitasRedux.IMatcher<InputEntity> Return
	{
		get
		{
			if (_matcherReturn == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<InputEntity>)JCMG.EntitasRedux.Matcher<InputEntity>.AllOf(InputComponentsLookup.Return);
				matcher.ComponentNames = InputComponentsLookup.ComponentNames;
				_matcherReturn = matcher;
			}

			return _matcherReturn;
		}
	}
}
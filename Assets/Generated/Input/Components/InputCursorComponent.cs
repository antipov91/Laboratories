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
	public Laboratories.Components.Input.CursorComponent Cursor { get { return (Laboratories.Components.Input.CursorComponent)GetComponent(InputComponentsLookup.Cursor); } }
	public bool HasCursor { get { return HasComponent(InputComponentsLookup.Cursor); } }

	public void AddCursor(UnityEngine.Vector2 newValue)
	{
		var index = InputComponentsLookup.Cursor;
		var component = (Laboratories.Components.Input.CursorComponent)CreateComponent(index, typeof(Laboratories.Components.Input.CursorComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		AddComponent(index, component);
	}

	public void ReplaceCursor(UnityEngine.Vector2 newValue)
	{
		var index = InputComponentsLookup.Cursor;
		var component = (Laboratories.Components.Input.CursorComponent)CreateComponent(index, typeof(Laboratories.Components.Input.CursorComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = newValue;
		#endif
		ReplaceComponent(index, component);
	}

	public void CopyCursorTo(Laboratories.Components.Input.CursorComponent copyComponent)
	{
		var index = InputComponentsLookup.Cursor;
		var component = (Laboratories.Components.Input.CursorComponent)CreateComponent(index, typeof(Laboratories.Components.Input.CursorComponent));
		#if !ENTITAS_REDUX_NO_IMPL
		component.value = copyComponent.value;
		#endif
		ReplaceComponent(index, component);
	}

	public void RemoveCursor()
	{
		RemoveComponent(InputComponentsLookup.Cursor);
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
	static JCMG.EntitasRedux.IMatcher<InputEntity> _matcherCursor;

	public static JCMG.EntitasRedux.IMatcher<InputEntity> Cursor
	{
		get
		{
			if (_matcherCursor == null)
			{
				var matcher = (JCMG.EntitasRedux.Matcher<InputEntity>)JCMG.EntitasRedux.Matcher<InputEntity>.AllOf(InputComponentsLookup.Cursor);
				matcher.ComponentNames = InputComponentsLookup.ComponentNames;
				_matcherCursor = matcher;
			}

			return _matcherCursor;
		}
	}
}

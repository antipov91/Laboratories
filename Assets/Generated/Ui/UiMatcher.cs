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
	public static JCMG.EntitasRedux.IAllOfMatcher<UiEntity> AllOf(params int[] indices)
	{
		return JCMG.EntitasRedux.Matcher<UiEntity>.AllOf(indices);
	}

	public static JCMG.EntitasRedux.IAllOfMatcher<UiEntity> AllOf(params JCMG.EntitasRedux.IMatcher<UiEntity>[] matchers)
	{
		return JCMG.EntitasRedux.Matcher<UiEntity>.AllOf(matchers);
	}

	public static JCMG.EntitasRedux.IAnyOfMatcher<UiEntity> AnyOf(params int[] indices)
	{
		return JCMG.EntitasRedux.Matcher<UiEntity>.AnyOf(indices);
	}

	public static JCMG.EntitasRedux.IAnyOfMatcher<UiEntity> AnyOf(params JCMG.EntitasRedux.IMatcher<UiEntity>[] matchers)
	{
		return JCMG.EntitasRedux.Matcher<UiEntity>.AnyOf(matchers);
	}
}
//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher
{
	public static JCMG.EntitasRedux.IAllOfMatcher<MetaEntity> AllOf(params int[] indices)
	{
		return JCMG.EntitasRedux.Matcher<MetaEntity>.AllOf(indices);
	}

	public static JCMG.EntitasRedux.IAllOfMatcher<MetaEntity> AllOf(params JCMG.EntitasRedux.IMatcher<MetaEntity>[] matchers)
	{
		return JCMG.EntitasRedux.Matcher<MetaEntity>.AllOf(matchers);
	}

	public static JCMG.EntitasRedux.IAnyOfMatcher<MetaEntity> AnyOf(params int[] indices)
	{
		return JCMG.EntitasRedux.Matcher<MetaEntity>.AnyOf(indices);
	}

	public static JCMG.EntitasRedux.IAnyOfMatcher<MetaEntity> AnyOf(params JCMG.EntitasRedux.IMatcher<MetaEntity>[] matchers)
	{
		return JCMG.EntitasRedux.Matcher<MetaEntity>.AnyOf(matchers);
	}
}

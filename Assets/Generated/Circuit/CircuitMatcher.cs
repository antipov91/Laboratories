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
	public static JCMG.EntitasRedux.IAllOfMatcher<CircuitEntity> AllOf(params int[] indices)
	{
		return JCMG.EntitasRedux.Matcher<CircuitEntity>.AllOf(indices);
	}

	public static JCMG.EntitasRedux.IAllOfMatcher<CircuitEntity> AllOf(params JCMG.EntitasRedux.IMatcher<CircuitEntity>[] matchers)
	{
		return JCMG.EntitasRedux.Matcher<CircuitEntity>.AllOf(matchers);
	}

	public static JCMG.EntitasRedux.IAnyOfMatcher<CircuitEntity> AnyOf(params int[] indices)
	{
		return JCMG.EntitasRedux.Matcher<CircuitEntity>.AnyOf(indices);
	}

	public static JCMG.EntitasRedux.IAnyOfMatcher<CircuitEntity> AnyOf(params JCMG.EntitasRedux.IMatcher<CircuitEntity>[] matchers)
	{
		return JCMG.EntitasRedux.Matcher<CircuitEntity>.AnyOf(matchers);
	}
}

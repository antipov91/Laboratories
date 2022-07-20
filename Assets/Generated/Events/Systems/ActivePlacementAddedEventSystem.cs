//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class ActivePlacementAddedEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{
	readonly System.Collections.Generic.List<IActivePlacementAddedListener> _listenerBuffer;

	public ActivePlacementAddedEventSystem(Contexts contexts) : base(contexts.Game)
	{
		_listenerBuffer = new System.Collections.Generic.List<IActivePlacementAddedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Added(GameMatcher.ActivePlacement)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.HasActivePlacement && entity.HasActivePlacementAddedListener;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.ActivePlacement;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(e.ActivePlacementAddedListener.value);
			foreach (var listener in _listenerBuffer)
			{
				listener.OnActivePlacementAdded(e, component.value);
			}
		}
	}
}
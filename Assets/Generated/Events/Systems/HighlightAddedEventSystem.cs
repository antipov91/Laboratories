//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class HighlightAddedEventSystem : JCMG.EntitasRedux.ReactiveSystem<GameEntity>
{
	readonly System.Collections.Generic.List<IHighlightAddedListener> _listenerBuffer;

	public HighlightAddedEventSystem(Contexts contexts) : base(contexts.Game)
	{
		_listenerBuffer = new System.Collections.Generic.List<IHighlightAddedListener>();
	}

	protected override JCMG.EntitasRedux.ICollector<GameEntity> GetTrigger(JCMG.EntitasRedux.IContext<GameEntity> context)
	{
		return JCMG.EntitasRedux.CollectorContextExtension.CreateCollector(
			context,
			JCMG.EntitasRedux.TriggerOnEventMatcherExtension.Added(GameMatcher.Highlight)
		);
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.HasHighlight && entity.HasHighlightAddedListener;
	}

	protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
	{
		foreach (var e in entities)
		{
			var component = e.Highlight;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(e.HighlightAddedListener.value);
			foreach (var listener in _listenerBuffer)
			{
				listener.OnHighlightAdded(e, component.value);
			}
		}
	}
}

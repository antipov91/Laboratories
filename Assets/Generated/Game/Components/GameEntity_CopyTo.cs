//------------------------------------------------------------------------------
// <auto-generated>
//		This code was generated by a tool (Genesis v2.4.7.0).
//
//
//		Changes to this file may cause incorrect behavior and will be lost if
//		the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JCMG.EntitasRedux;

public partial class GameEntity
{
	/// <summary>
	/// Copies <paramref name="component"/> to this entity as a new component instance.
	/// </summary>
	public void CopyComponentTo(IComponent component)
	{
		#if !ENTITAS_REDUX_NO_IMPL
		if (component is Laboratories.Components.Game.ActivePlacementComponent ActivePlacement)
		{
			CopyActivePlacementTo(ActivePlacement);
		}
		else if (component is Laboratories.Components.Game.IdComponent Id)
		{
			CopyIdTo(Id);
		}
		else if (component is Laboratories.Components.Game.DestroyedComponent Destroyed)
		{
			IsDestroyed = true;
		}
		else if (component is Laboratories.Components.Game.DraggableObjectComponent DraggableObject)
		{
			CopyDraggableObjectTo(DraggableObject);
		}
		else if (component is Laboratories.Components.Game.SocketComponent Socket)
		{
			CopySocketTo(Socket);
		}
		else if (component is Laboratories.Components.Game.NameComponent Name)
		{
			CopyNameTo(Name);
		}
		else if (component is Laboratories.Components.Game.SelectedWirePrefabComponent SelectedWirePrefab)
		{
			CopySelectedWirePrefabTo(SelectedWirePrefab);
		}
		else if (component is Laboratories.Components.Game.PlayerComponent Player)
		{
			IsPlayer = true;
		}
		else if (component is Laboratories.Components.Game.SpeedComponent Speed)
		{
			CopySpeedTo(Speed);
		}
		else if (component is Laboratories.Components.Game.TransformComponent Transform)
		{
			CopyTransformTo(Transform);
		}
		else if (component is Laboratories.Components.Game.DeviceActiveComponent DeviceActive)
		{
			CopyDeviceActiveTo(DeviceActive);
		}
		else if (component is Laboratories.Components.Game.DeviceComponent Device)
		{
			CopyDeviceTo(Device);
		}
		else if (component is Laboratories.Components.Game.HighlightComponent Highlight)
		{
			CopyHighlightTo(Highlight);
		}
		else if (component is Laboratories.Components.Game.PlacementsComponent Placements)
		{
			CopyPlacementsTo(Placements);
		}
		else if (component is Laboratories.Components.Game.ClickedComponent Clicked)
		{
			IsClicked = true;
		}
		else if (component is Laboratories.Components.Game.InitializeWireComponent InitializeWire)
		{
			CopyInitializeWireTo(InitializeWire);
		}
		else if (component is Laboratories.Components.Game.CameraMovementFXComponent CameraMovementFX)
		{
			CopyCameraMovementFXTo(CameraMovementFX);
		}
		else if (component is Laboratories.Components.Game.CameraComponent Camera)
		{
			CopyCameraTo(Camera);
		}
		else if (component is Laboratories.Components.Game.ViewComponent View)
		{
			CopyViewTo(View);
		}
		else if (component is Laboratories.Components.Game.ConnectedComponent Connected)
		{
			CopyConnectedTo(Connected);
		}
		else if (component is Laboratories.Components.Game.SelectedSocketComponent SelectedSocket)
		{
			CopySelectedSocketTo(SelectedSocket);
		}
		else if (component is Laboratories.Components.Game.ConnectedCountComponent ConnectedCount)
		{
			CopyConnectedCountTo(ConnectedCount);
		}
		else if (component is Laboratories.Game.PickupedComponent Pickuped)
		{
			IsPickuped = true;
		}
		else if (component is Laboratories.Game.InitializeGameObjectComponent InitializeGameObject)
		{
			CopyInitializeGameObjectTo(InitializeGameObject);
		}
		else if (component is Laboratories.Game.HandComponent Hand)
		{
			CopyHandTo(Hand);
		}
		else if (component is Laboratories.Game.CharacterControllerComponent CharacterController)
		{
			CopyCharacterControllerTo(CharacterController);
		}
		else if (component is Laboratories.Game.PossibleActionsComponent PossibleActions)
		{
			CopyPossibleActionsTo(PossibleActions);
		}
		else if (component is ActivePlacementAddedListenerComponent ActivePlacementAddedListener)
		{
			CopyActivePlacementAddedListenerTo(ActivePlacementAddedListener);
		}
		else if (component is DeviceActiveAddedListenerComponent DeviceActiveAddedListener)
		{
			CopyDeviceActiveAddedListenerTo(DeviceActiveAddedListener);
		}
		else if (component is HighlightAddedListenerComponent HighlightAddedListener)
		{
			CopyHighlightAddedListenerTo(HighlightAddedListener);
		}
		#endif
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (HasComponent(i))
			{
				if (copyToEntity.HasComponent(i))
				{
					throw new EntityAlreadyHasComponentException(
						i,
						"Cannot copy component '" +
						GameComponentsLookup.ComponentNames[i] +
						"' to " +
						this +
						"!",
						"If replacement is intended, please call CopyTo() with `replaceExisting` set to true.");
				}

				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies all components on this entity to <paramref name="copyToEntity"/>; if <paramref name="replaceExisting"/>
	/// is true any of the components that <paramref name="copyToEntity"/> has that this entity has will be replaced,
	/// otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting)
	{
		for (var i = 0; i < GameComponentsLookup.TotalComponents; ++i)
		{
			if (!HasComponent(i))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(i) || replaceExisting)
			{
				var component = GetComponent(i);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}

	/// <summary>
	/// Copies components on this entity at <paramref name="indices"/> in the <see cref="GameComponentsLookup"/> to
	/// <paramref name="copyToEntity"/>. If <paramref name="replaceExisting"/> is true any of the components that
	/// <paramref name="copyToEntity"/> has that this entity has will be replaced, otherwise they will be skipped.
	/// </summary>
	public void CopyTo(GameEntity copyToEntity, bool replaceExisting, params int[] indices)
	{
		for (var i = 0; i < indices.Length; ++i)
		{
			var index = indices[i];

			// Validate that the index is within range of the component lookup
			if (index < 0 && index >= GameComponentsLookup.TotalComponents)
			{
				const string OUT_OF_RANGE_WARNING =
					"Component Index [{0}] is out of range for [{1}].";

				const string HINT = "Please ensure any CopyTo indices are valid.";

				throw new IndexOutOfLookupRangeException(
					string.Format(OUT_OF_RANGE_WARNING, index, nameof(GameComponentsLookup)),
					HINT);
			}

			if (!HasComponent(index))
			{
				continue;
			}

			if (!copyToEntity.HasComponent(index) || replaceExisting)
			{
				var component = GetComponent(index);
				copyToEntity.CopyComponentTo(component);
			}
		}
	}
}

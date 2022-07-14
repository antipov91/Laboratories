using System;

namespace Laboratories.Game
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts, GameState initState)
        {
            switch (initState)
            {
                case GameState.Game:
                    AddGameSystems(contexts);
                    break;
                case GameState.Paused:
                    AddPausedSystems(contexts);
                    break;
                case GameState.Focused:
                    AddFocusedSystems(contexts);
                    break;
                case GameState.Edited:
                    AddEditedSystems(contexts);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddGameSystems(Contexts contexts)
        {
            Add(new GameEventSystems(contexts));
            Add(new InitializeEntitiesInSceneSystem(contexts));
            Add(new InitializeEntitySystem(contexts));

            Add(new MovementPlayerSystem(contexts));
            Add(new MovementEffectsSystem(contexts));
            Add(new RotationPlayerSystem(contexts));
            Add(new HighlightUpdateSystem(contexts));
            Add(new UpdatePauseSystem(contexts));
            Add(new InteractableSystem(contexts));
            Add(new PickupSystem(contexts));
            Add(new PlacementSystem(contexts));
            Add(new UpdateZoomSystem(contexts));

            Add(new InitializeDeviceSystem(contexts));
            Add(new UpdateDeviceSystem(contexts));
            Add(new ReleaseDeviceSystem(contexts));

            Add(new DestroySystem(contexts));
        }

        private void AddPausedSystems(Contexts contexts)
        {
            Add(new InitializeEntitySystem(contexts));
            Add(new UpdatePauseSystem(contexts));

            Add(new ReleaseDeviceSystem(contexts));

            Add(new DestroySystem(contexts));
        }

        private void AddFocusedSystems(Contexts contexts)
        {
            Add(new InitializeEntitySystem(contexts));
            Add(new UpdatePauseSystem(contexts));

            Add(new ReleaseDeviceSystem(contexts));

            Add(new DestroySystem(contexts));
        }

        private void AddEditedSystems(Contexts contexts)
        {
            
        }
    }
}
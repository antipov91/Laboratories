using System;

namespace Laboratories.Meta
{
    public class MetaSystems : Feature
    {
        public MetaSystems(Contexts contexts, GameState initState, GameConfig gameConfig)
        {
            switch (initState)
            {
                case GameState.Game:
                    AddGameSystems(contexts, gameConfig);
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

        private void AddGameSystems(Contexts contexts, GameConfig gameConfig)
        {
            Add(new InitializeMetaSystem(contexts, gameConfig));

            Add(new UpdateTimeSystem(contexts));
            Add(new UpdateGameStateSystem(contexts));
        }

        private void AddPausedSystems(Contexts contexts)
        {
            Add(new UpdateGameStateSystem(contexts));
        }

        private void AddFocusedSystems(Contexts  contexts)
        {
            Add(new UpdateGameStateSystem(contexts));
        }

        private void AddEditedSystems(Contexts contexts)
        {
            Add(new UpdateGameStateSystem(contexts));
        }
    }
}
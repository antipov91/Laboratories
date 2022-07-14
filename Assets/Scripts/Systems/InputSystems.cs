using System;

namespace Laboratories.Input
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts, GameState initState)
        {
            switch (initState)
            {
                case GameState.Game:
                    AddGameSystem(contexts);
                    break;
                case GameState.Paused:
                    AddPausedSystem(contexts);
                    break;
                case GameState.Focused:
                    AddFocusedSystem(contexts);
                    break;
                case GameState.Edited:
                    AddEditedSystem(contexts);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddGameSystem(Contexts contexts)
        {
            Add(new InitializeInputSystem(contexts));

            Add(new UpdateInputSystem(contexts));
        }

        private void AddPausedSystem(Contexts contexts)
        {
            Add(new UpdateInputSystem(contexts));
        }

        private void AddFocusedSystem(Contexts contexts)
        {
            Add(new UpdateInputSystem(contexts));
        }

        private void AddEditedSystem(Contexts contexts)
        {

        }
    }
}
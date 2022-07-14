using Laboratories.Ui;
using System;

namespace Laboratories
{
    public class UiSystems : Feature
    {
        public UiSystems(Contexts contexts, GameState initState)
        {
            switch (initState)
            {
                case GameState.Game:
                    AddGameSystems(contexts);
                    break;
                case GameState.Paused:
                    break;
                case GameState.Focused:
                    break;
                case GameState.Edited:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddGameSystems(Contexts contexts)
        {
            Add(new InitializeUiSystem(contexts));
            Add(new InvokeRadialMenuSystem(contexts));
        }
    }
}
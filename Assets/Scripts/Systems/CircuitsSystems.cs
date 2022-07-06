using Laboratories.Circuits;
using System;

namespace Laboratories
{
    public class CircuitsSystems : Feature
    {
        public CircuitsSystems(Contexts contexts, GameState initState)
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
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AddFocusedSystems(Contexts contexts)
        {
            Add(new CircuitsInitializeSystem(contexts));

            Add(new UpdateCircuitSystem(contexts));

            Add(new InitializeCurrentRSMSystem(contexts));
            Add(new InitializeVoltageRSMSystem(contexts));
            Add(new UpdateCurrentRSMSystem(contexts));
            Add(new UpdateVoltageRSMSystem(contexts));
        }

        private void AddPausedSystems(Contexts contexts)
        {
            
        }

        private void AddGameSystems(Contexts contexts)
        {
            
        }
    }
}
using JCMG.EntitasRedux;
using Laboratories.Game;
using Laboratories.Input;
using Laboratories.Meta;
using System;
using UnityEngine;

namespace Laboratories
{
    public class GameController : MonoBehaviour
    {
        public static GameState GameState { get; set; }

        private Systems gameSystems;
        private Systems pausedSystems;
        private Systems focusedSystems;
        private Systems editedSystems;

        [SerializeField] private GameConfig gameConfig;

        private void Start()
        {
            Contexts.SharedInstance.SubscribeId();

            gameSystems = CreateSystems(Contexts.SharedInstance, GameState.Game);
            pausedSystems = CreateSystems(Contexts.SharedInstance, GameState.Paused);
            focusedSystems = CreateSystems(Contexts.SharedInstance, GameState.Focused);
            editedSystems = CreateSystems(Contexts.SharedInstance, GameState.Edited);

            gameSystems.Initialize();
            pausedSystems.Initialize();
            focusedSystems.Initialize();
            editedSystems.Initialize();
        }

        private Systems CreateSystems(Contexts contexts, GameState initState)
        {
            return new Feature()
                .Add(new MetaSystems(contexts, initState, gameConfig))
                .Add(new InputSystems(contexts, initState))
                .Add(new CircuitsSystems(contexts, initState))
                .Add(new GameSystems(contexts, initState))
                .Add(new UiSystems(contexts, initState));
                
                //.Add(new CleanupSystems(contexts));*/
        }

        private void Update()
        {
            switch (GameState)
            {
                case GameState.Game:
                    gameSystems.Execute();
                    gameSystems.Update();
                    gameSystems.Cleanup();
                    break;
                case GameState.Paused:
                    pausedSystems.Execute();
                    pausedSystems.Update();
                    pausedSystems.Cleanup();
                    break;
                case GameState.Focused:
                    focusedSystems.Execute();
                    focusedSystems.Update();
                    focusedSystems.Cleanup();
                    break;
                case GameState.Edited:
                    editedSystems.Execute();
                    editedSystems.Update();
                    editedSystems.Cleanup();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            /*if (Contexts.SharedInstance.Meta.ManagerEntity.HasQuit)
            {
                var action = Contexts.SharedInstance.Meta.ManagerEntity.Quit.onQuit;
                systems.TearDown();
                action?.Invoke();
            }*/
        }

        private void FixedUpdate()
        {
            switch (GameState)
            {
                case GameState.Game:
                    gameSystems.FixedUpdate();
                    break;
                case GameState.Paused:
                    pausedSystems.FixedUpdate();
                    break;
                case GameState.Focused:
                    focusedSystems.FixedUpdate();
                    break;
                case GameState.Edited:
                    editedSystems.FixedUpdate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LateUpdate()
        {
            switch (GameState)
            {
                case GameState.Game:
                    gameSystems.LateUpdate();
                    break;
                case GameState.Paused:
                    pausedSystems.LateUpdate();
                    break;
                case GameState.Focused:
                    focusedSystems.LateUpdate();
                    break;
                case GameState.Edited:
                    editedSystems.LateUpdate();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
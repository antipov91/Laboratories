using JCMG.EntitasRedux;
using Laboratories.Game;
using Laboratories.Input;
using Laboratories.Meta;
using UnityEngine;

namespace Laboratories
{
    public class GameController : MonoBehaviour
    {
        private Systems systems;

        [SerializeField] private GameConfig gameConfig;

        private void Start()
        {
            Contexts.SharedInstance.SubscribeId();

            systems = CreateSystems(Contexts.SharedInstance);
            systems.Initialize();
        }

        private Systems CreateSystems(Contexts contexts)
        {
            return new Feature()
                .Add(new MetaSystems(contexts, gameConfig))
                .Add(new InputSystems(contexts))
                .Add(new GameSystems(contexts));
                /*.Add(new UiSystems(contexts))
                .Add(new CleanupSystems(contexts));*/
        }

        private void Update()
        {
            systems.Execute();
            systems.Update();
            systems.Cleanup();

            /*if (Contexts.SharedInstance.Meta.ManagerEntity.HasQuit)
            {
                var action = Contexts.SharedInstance.Meta.ManagerEntity.Quit.onQuit;
                systems.TearDown();
                action?.Invoke();
            }*/
        }

        private void FixedUpdate()
        {
            systems.FixedUpdate();
        }

        private void LateUpdate()
        {
            systems.LateUpdate();
        }
    }
}
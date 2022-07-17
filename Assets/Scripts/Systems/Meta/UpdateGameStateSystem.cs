using JCMG.EntitasRedux;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories.Meta
{
    public class UpdateGameStateSystem : ReactiveSystem<MetaEntity>
    {
        private readonly Contexts contexts;

        public UpdateGameStateSystem(Contexts contexts) : base(contexts.Meta)
        {
            this.contexts = contexts;
        }

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context)
        {
            return context.CreateCollector(MetaMatcher.GameState);
        }

        protected override bool Filter(MetaEntity entity)
        {
            return entity.HasGameState;
        }

        protected override void Execute(List<MetaEntity> entities)
        {
            var metaEntity = contexts.Meta.ManagerEntity;
            if (metaEntity.GameState.value == GameController.GameState)
                return;

            metaEntity.ReplacePreviouseGameState(GameController.GameState);
            GameController.GameState = metaEntity.GameState.value;

            switch (metaEntity.GameState.value)
            {
                case GameState.Game:
                    contexts.Ui.ManagerEntity.PauseMenu.instance.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
                case GameState.Paused:
                    contexts.Ui.ManagerEntity.PauseMenu.instance.gameObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case GameState.Focused:
                    contexts.Ui.ManagerEntity.PauseMenu.instance.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case GameState.Edited:
                    contexts.Ui.ManagerEntity.PauseMenu.instance.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
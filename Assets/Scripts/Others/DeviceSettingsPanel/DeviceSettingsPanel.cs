using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public abstract class DeviceSettingsPanel : MonoBehaviour
    {
        [SerializeField] private Button exitBtn;

        protected Contexts contexts;
        protected GameEntity gameEntity;

        private void OnEnable()
        {
            exitBtn.onClick.AddListener(ExitClick);
        }

        private void OnDisable()
        {
            exitBtn.onClick.RemoveListener(ExitClick);
        }

        private void ExitClick()
        {
            contexts.Meta.ManagerEntity.ReplaceGameState(GameState.Game);
            gameObject.SetActive(false);
        }

        public abstract bool CheckCondition(Contexts contexts, GameEntity senderEntity);

        public void Invoke(Contexts contexts, GameEntity senderEntity)
        {
            contexts.Meta.ManagerEntity.ReplaceGameState(GameState.Paused);
            this.contexts = contexts;
            this.gameEntity = senderEntity;
            gameObject.SetActive(true);
            OnInvoked();
        }

        protected abstract void OnInvoked();
        protected abstract void OnClosed();

        public void Close()
        {
            gameObject.SetActive(false);
            OnClosed();
        }
    }
}
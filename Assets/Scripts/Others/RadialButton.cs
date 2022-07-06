using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public abstract class RadialButton : MonoBehaviour
    {
        private Contexts contexts;
        private GameEntity senderEntity;

        private Button btn;

        private void Awake()
        {
            btn = GetComponent<Button>();
        }

        private void OnEnable()
        {
            btn.onClick.AddListener(ClickHandle);
        }

        private void OnDisable()
        {
            btn.onClick.RemoveListener(ClickHandle);
        }

        private void ClickHandle()
        {
            contexts.Meta.ManagerEntity.ReplaceGameState(GameState.Game);
            contexts.Ui.ManagerEntity.RadialMenu.instance.Hide();
            Click(contexts, senderEntity);
        }

        public void Invoke(Contexts contexts, GameEntity senderEntity)
        {
            this.contexts = contexts;
            this.senderEntity = senderEntity;
            gameObject.SetActive(true);
            StartCoroutine(Fade());
        }

        public abstract bool CheckPossibleAction(Contexts contexts, GameEntity senderEntity);

        protected abstract void Click(Contexts contexts, GameEntity senderEntity);

        private IEnumerator Fade()
        {
            transform.localScale = Vector2.zero;
            var time = 0f;
            while (transform.localScale != Vector3.one)
            {
                time += Time.deltaTime;
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, time / contexts.Meta.ManagerEntity.GameConfig.instance.radialMenuAppearDuration);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
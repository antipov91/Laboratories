using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories
{
    public class RadialMenu : MonoBehaviour
    {
        private RadialButton[] radialButtons;

        private void Awake()
        {
            radialButtons = GetComponentsInChildren<RadialButton>();
        }

        public void Invoke(Contexts contexts, GameEntity senderEntity)
        {
            gameObject.SetActive(true);
            var btns = new List<RadialButton>();

            foreach (var btn in radialButtons)
            {
                if (btn.CheckPossibleAction(contexts, senderEntity))
                {
                    btns.Add(btn);
                }
                btn.gameObject.SetActive(false);
            }

            var centerScreen = new Vector2(Screen.width / 2, Screen.height / 2);
            float deltaAngle = 2f * Mathf.PI / btns.Count;
            for (int i = 0; i < btns.Count; i++)
            {
                float theta = i * deltaAngle;
                Vector2 position = new Vector2(Mathf.Sin(theta), Mathf.Cos(theta));
                btns[i].transform.position = centerScreen + position * contexts.Meta.ManagerEntity.GameConfig.instance.radialMenuRadius;
            }
            StartCoroutine(InvokeButtons(contexts, senderEntity, btns));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator InvokeButtons(Contexts contexts, GameEntity senderEntity, List<RadialButton> buttons)
        {
            foreach (var btn in buttons)
            {
                btn.Invoke(contexts, senderEntity);
                yield return new WaitForSeconds(contexts.Meta.ManagerEntity.GameConfig.instance.radialMenuAppearDuration);
            }
        }
    }
}
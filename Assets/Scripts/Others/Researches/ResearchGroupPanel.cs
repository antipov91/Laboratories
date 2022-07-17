using UnityEngine;

namespace Laboratories
{
    public class ResearchGroupPanel : MonoBehaviour
    {
        [SerializeField] private ResearchPanel[] panels;

        private void Awake()
        {
            foreach (var panel in panels)
                panel.gameObject.SetActive(false);
        }

        public void Invoke(Contexts contexts, GameEntity senderEntity)
        {
            foreach (var panel in panels)
            {
                if (panel.CheckCondition(contexts, senderEntity))
                    panel.Invoke(contexts, senderEntity);
                else
                    panel.Hide();
            }
        }
    }
}
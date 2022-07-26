using UnityEngine;
using UnityEngine.UI;

namespace Laboratories
{
    public class NameInfoPanel : MonoBehaviour
    {
        [SerializeField] private Text label;

        public void Invoke(string name)
        {
            gameObject.SetActive(true);
            label.text = name;
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
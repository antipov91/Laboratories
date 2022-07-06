using UnityEngine;

namespace Laboratories
{
    public abstract class SubMenu : MonoBehaviour
    {
        protected Menu menu;

        public void Init(Menu menu)
        {
            this.menu = menu;
            OnInit();
        }

        private void OnDestroy()
        {
            OnDeinit();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            OnShowed();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide();
        }

        protected virtual void OnShowed() { }
        protected virtual void OnHide() { }
        protected virtual void OnInit() { }
        protected virtual void OnDeinit() { }
    }
}
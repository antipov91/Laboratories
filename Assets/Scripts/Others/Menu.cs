using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories
{
    public class Menu : MonoBehaviour
    {
        private SubMenu[] subMenus;

        private SubMenu currentSubMenu;
        public SubMenu CurrentSubMenu
        {
            get { return currentSubMenu; }
            set
            {
                currentSubMenu?.Hide();
                currentSubMenu = value;
                currentSubMenu?.Show();
            }
        }

        private void Awake()
        {
            subMenus = GetComponentsInChildren<SubMenu>();
            foreach (var subMenu in subMenus)
                subMenu.Init(this);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Laboratories
{
    public class LaboratoriesTools : MonoBehaviour
    {
        public static List<GameObject> GetChildrens(Transform transform)
        {
            var childrens = new List<GameObject>();
            for (int i = 0; i < transform.childCount; i++)
            {
                childrens.Add(transform.GetChild(i).gameObject);
                childrens.AddRange(GetChildrens(transform.GetChild(i).transform));
            }
            return childrens;
        }

        public static List<T> GetAllComponents<T>(GameObject gameObject)
        {
            var components = new List<T>();
            components.AddRange(gameObject.GetComponents<T>());

            foreach (var item in GetChildrens(gameObject.transform))
                components.AddRange(item.GetComponents<T>());

            return components;
        }
    }
}
using UnityEngine;

namespace Laboratories.Views
{
    public abstract class MonoView<T> : MonoBehaviour
    {
        public abstract void LinkEntity(Contexts contexts, T entity);
        public abstract void UnlinkEntity(Contexts contexts, T entity);
    }
}
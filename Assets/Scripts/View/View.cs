using JCMG.EntitasRedux;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Laboratories.Views
{
    public abstract class View<T> : MonoBehaviour, IView where T : class, IEntity
    {
        protected Contexts contexts;
        protected T entity;

        private EntityLink entityLink;
        private List<MonoView<T>> monoViews;

        [SerializeField] private bool destroyWhenEntityIsDestroed = true;

        public void OnEntityInitilaized(Contexts contexts, IEntity entity)
        {
            this.entity = entity as T;
            entityLink = gameObject.AddComponent<EntityLink>();
            entityLink.Link(entity);

            monoViews = GetComponents<MonoView<T>>().ToList();
            foreach (var monoView in monoViews)
                monoView.LinkEntity(contexts, this.entity);
        }

        public void OnEntityDestroyed()
        {
            if (gameObject.GetComponent<EntityLink>() != null)
                CleanLinks();
            if (destroyWhenEntityIsDestroed)
                Destroy(gameObject);
        }

        private void CleanLinks()
        {
            foreach (var monoView in monoViews)
                monoView.UnlinkEntity(contexts, entity);

            gameObject.Unlink();
            Destroy(entityLink);
        }
    }
}
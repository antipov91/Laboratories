using UnityEngine;

namespace Laboratories.Views
{
    public class HighlightView : MonoView<GameEntity>, IHighlightAddedListener
    {
        private Renderer renderer;
        private MaterialPropertyBlock block;

        private void Awake()
        {
            block = new MaterialPropertyBlock();

            renderer = GetComponent<Renderer>();
        }

        public override void LinkEntity(Contexts contexts, GameEntity entity)
        {
            entity.AddHighlightAddedListener(this);
            entity.ReplaceHighlight(false);
        }

        public override void UnlinkEntity(Contexts contexts, GameEntity entity)
        {
            entity.RemoveHighlightAddedListener(this);
        }

        public void OnHighlightAdded(GameEntity entity, bool value)
        {
            renderer.GetPropertyBlock(block);
            block.SetFloat("_IsActive", value ? 1f : 0f);
            renderer.SetPropertyBlock(block);
        }
    }
}
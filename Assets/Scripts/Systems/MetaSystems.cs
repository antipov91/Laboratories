namespace Laboratories.Meta
{
    public class MetaSystems : Feature
    {
        public MetaSystems(Contexts contexts, GameConfig gameConfig)
        {
            Add(new InitializeMetaSystem(contexts, gameConfig));
            Add(new UpdateTimeSystem(contexts));
        }
    }
}
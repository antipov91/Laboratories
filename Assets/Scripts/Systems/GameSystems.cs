namespace Laboratories.Game
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new GameEventSystems(contexts));

            Add(new InitializeEntitiesInSceneSystem(contexts));
            Add(new MovementPlayerSystem(contexts));
            Add(new MovementEffectsSystem(contexts));
            Add(new RotationPlayerSystem(contexts));
            Add(new HighlightUpdateSystem(contexts));
        }
    }
}
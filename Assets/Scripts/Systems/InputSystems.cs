namespace Laboratories.Input
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts)
        {
            Add(new InitializeInputSystem(contexts));
            Add(new UpdateInputSystem(contexts));
        }
    }
}
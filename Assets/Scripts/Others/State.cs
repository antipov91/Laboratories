public abstract class State<T> where T : class
{
    protected T context;

    public State(T context)
    {
        this.context = context;
    }
}

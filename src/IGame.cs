namespace Base.Engine;

public interface IGame
{
    abstract public void Ready();
    abstract public void ProcessInput();
    abstract public void Update();
    abstract public void Render();
}
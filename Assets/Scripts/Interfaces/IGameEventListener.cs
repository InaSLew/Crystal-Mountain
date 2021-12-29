/// <summary>
/// Defines OnEventRaised() method for all game event listener to implement
/// </summary>
/// <typeparam name="T">Game event listener type</typeparam>
public interface IGameEventListener<T>
{
    void OnEventRaised(T value);
}

using System;

public static class EventContainer 
{
    public static event Action onPassFloor;

    public static void CallOnPassFloor()
    {
        onPassFloor?.Invoke();
    }
}

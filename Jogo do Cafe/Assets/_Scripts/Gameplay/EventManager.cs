using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void Action();
    public static event Action OnCall;

    public static void CallAction()
    {
        if (OnCall != null)
        {
            OnCall();
        }
    }
}

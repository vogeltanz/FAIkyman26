using UnityEngine;
using UnityEngine.Events;

public class DragonEyes : MonoBehaviour
{
    public UnityEvent<bool> PlayerIsVisible;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerIsVisible?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerIsVisible?.Invoke(false);
        }
    }
}

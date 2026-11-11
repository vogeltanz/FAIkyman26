using UnityEngine;
using UnityEngine.Events;

public class DragonMouth : MonoBehaviour
{
    public UnityEvent<float> PlayerHit;

    [SerializeField]
    float hitDamage = 10f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHit?.Invoke(hitDamage);
        }
    }
}

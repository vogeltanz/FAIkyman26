using UnityEngine;
using UnityEngine.Events;

public class DragonMouth : MonoBehaviour
{
    public UnityEvent<GameObject, float> PlayerHit;

    [SerializeField]
    float hitDamage = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHit?.Invoke(collision.gameObject, hitDamage);
        }
    }
}

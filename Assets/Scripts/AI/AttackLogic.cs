using CodeMonkey.HealthSystemCM;
using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    public void Attack(GameObject character, float damage)
    {
        IGetHealthSystem getHealthSystem = 
            character.GetComponent<IGetHealthSystem>();

        if (getHealthSystem != null)
        {
            HealthSystem healthSystem = getHealthSystem.GetHealthSystem();
            if (healthSystem.IsDead() == false)
            { 
                healthSystem.Damage(damage);
            }
        }
    }
}

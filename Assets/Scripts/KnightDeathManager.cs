using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class KnightDeathManager : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Die()
    {
        animator.SetTrigger("Death");

        GameObject.Destroy(gameObject.GetComponent<KnightController>());
    }

    public void DestroyPlayer()
    {
        GameObject.Destroy(this.gameObject);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}

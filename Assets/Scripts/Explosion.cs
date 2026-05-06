using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float radius = 1.5f;

    void Start()
    {
        Explode();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }

    void Explode()
    {
        // Damage player
    }
}

using UnityEngine;

public class EnemySimpleShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 5f;
    public float shootInterval = 2f; // seconds
    private float timer;

    public Transform player; // assign in inspector

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        if (!player) return;

        GameObject proj = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        
        Vector2 direction = (player.position - shootPoint.position).normalized;
        rb.linearVelocity = direction * projectileSpeed;
    }
}

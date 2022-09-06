using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Monster monster = collision.collider.GetComponent<Monster>();
        if (monster != null)
        {
            return;
        }

        Vector3 collisionPoint = new Vector3(collision.contacts[0].point.x, collision.contacts[0].point.y);
        Vector3 collisionDir = collisionPoint - transform.position;
        float inlineSpeed = Vector3.Dot(collisionDir.normalized, GetComponent<Rigidbody2D>().velocity);

        // angle of collision (came from the top)
        if (collision.contacts[0].normal.y < -0.5 ||
            collision.contacts[0].normal.y > 0.5 && inlineSpeed > 0.8
            )
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Transform))]
public class Bullet : MonoBehaviour
{

    private Rigidbody r;
    private Transform t;

    void Awake()
    {
        r = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        r.useGravity = false;
        Destroy(gameObject, 6f);
    }

    /// <summary> The amount of damage dealt by the bullet. </summary>
    [SerializeField]
    [Tooltip("The amount of damage dealt by the bullet.")]
    private float damage;

    void FixedUpdate()
    {
        if (r.velocity.magnitude != 0)
            t.rotation = Quaternion.LookRotation(r.velocity);
    }

    /// <summary>
    /// Damages the player and destroys the bullet upon contact.
    /// </summary>
    /// <param name="collisionInfo">The collision that caused this event.</param>
    void OnCollisionEnter(Collision collisionInfo)
    {
        Health health = collisionInfo.collider.GetComponent<Health>();
        if (health != null) {
            health.Damage(damage);
        }
        Destroy(gameObject);
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }

    public void setVelocity(Vector3 vel)
    {
        r.velocity = vel;
    }
}

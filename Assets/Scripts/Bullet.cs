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

    private float damage = 0;

    void FixedUpdate()
    {
        if (r.velocity.magnitude != 0)
            t.rotation = Quaternion.LookRotation(r.velocity);
    }

    void OnCollisionStay(Collision collisionInfo)
    {

        Destroy(gameObject);

        //TODO: if hit guard or player, they take damage.
        //GameObject hitObject = collisionInfo.gameObject;
        //      if (hitObject.tag == "Player")
        //    {
        //      UserController u = hitObject.GetComponent<UserController>();
        //      u.takeDamage(damage);
        //    }
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

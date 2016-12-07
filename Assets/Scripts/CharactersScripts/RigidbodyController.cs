using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class RigidbodyController : MonoBehaviour
{
    public FootStepper stepper;
    public Footstep leftStep;
    public Footstep rightStep;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool usingFootStepper = true;
    public float maxWalkAngle = 30f;

    private Animator anim;
    private bool grounded = false;
    private Rigidbody rb;
    private CapsuleCollider coll;
    private BoxCollider groundingBox;
    private AudioSource aud;

    public float turnSpeed = 1f;

    private float speed = 0;
    private float turn = 0;
    private bool startRoll = false;

    /// <summary> The character's ragdoll colliders. </summary>
    private Collider[] ragdoll;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        coll = GetComponent<CapsuleCollider>();
        groundingBox = GetComponent<BoxCollider>();
        aud = GetComponent<AudioSource>();
        Transform hips = transform.FindChild("Hips");
        if (hips != null) {
            ragdoll = hips.GetComponentsInChildren<Collider>();
            SetRagdollActive(false);
        }

        if (stepper == null)
        {
            usingFootStepper = false;
        }

        rb.freezeRotation = true;
        rb.useGravity = false;

    }

    void FixedUpdate()
    {
        OnLand();
    }

    void OnLand()
    {



        anim.SetFloat("speed", speed, 0.2f, Time.deltaTime);

		if (speed >= 0) {
			anim.SetFloat("turn", turn, 0.2f, Time.deltaTime);
            
			gameObject.transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		} else {
			anim.SetFloat("turn", -turn, 0.2f, Time.deltaTime);
			gameObject.transform.Rotate(0, -turn * turnSpeed * Time.deltaTime, 0);
		}

        anim.SetBool("startRoll", startRoll);


        if (grounded)
        {
            anim.SetBool("grounded", true);
        }
        else
        {
            anim.SetBool("grounded", false);
        }


        ColliderAdjust();


        rb.AddForce(new Vector3(0, -1.2f * gravity * rb.mass, 0));

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("falling_idle"))
        {
            anim.applyRootMotion = false;
        }
        else
        {
            anim.applyRootMotion = true;
        }

        if (fallTimer < 0)
        {
            grounded = false;
        }
        fallTimer -= Time.deltaTime;
    }

    void ColliderAdjust()
    {
        AnimatorStateInfo currentAnim = anim.GetCurrentAnimatorStateInfo(0);
        if (currentAnim.IsName("falling_to_roll") || currentAnim.IsName("sprinting_forward_roll"))
        {
            coll.center = new Vector3(0, 0.5f, 0);
            coll.height = 1f;
        }
        else
        {
            coll.center = new Vector3(0, 1f, 0);
            coll.height = 2f;
        }


    }


    public float fallbufferTime;
    private float fallTimer;

    void OnCollisionStay(Collision collisionInfo)
    {
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            if (Vector3.Angle(Vector3.up, contact.normal) < maxWalkAngle)
            {
                groundingBox.enabled = true;
                if (groundingBox.bounds.Contains(contact.point))
                {
                    grounded = true;
                    fallTimer = fallbufferTime;
                }
            }
        }
    }

    public void LeftStep()
    {
        if (!usingFootStepper)
            return;

        stepper.PlayStep(leftStep);
    }

    public void RightStep()
    {
        if (!usingFootStepper)
            return;

        stepper.PlayStep(rightStep);
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public void setTurn(float turn)
    {
        if (turn > 2)
        {
            this.turn = 2;
        } else
        {
            this.turn = turn;
        }
        
    }

    public void roll(bool roll)
    {
        startRoll = roll;
    }

    /// <summary>
    /// Enables or disables ragdoll physics on the character.
    /// </summary>
    /// <param name="active">Whether to enable ragdoll physics on the character.</param>
    public void SetRagdollActive(bool active) {
        foreach (Collider collider in ragdoll) {
            collider.gameObject.SetActive(active);
        }
        anim.enabled = !active;
    }

}


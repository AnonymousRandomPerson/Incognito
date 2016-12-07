using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Transform))]
public class UserController : MonoBehaviour {
    public RigidbodyController character;
    /// <summary> The player's current movement velocity </summary>
    public Vector2 velocity;

    void FixedUpdate () {
        handleInputs();
    }

    void handleInputs()
    {
        //float turn = Input.GetAxis("Mouse X");
        float hor = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        float roll = Input.GetAxis("Jump");

        velocity.x = hor;
        velocity.y = vert;
        if (velocity.magnitude > 1)
        {
            velocity /= velocity.magnitude;
        }

        if (!Input.GetButton("Run") && Mathf.Abs(Input.GetAxisRaw("Analog")) < 0.01f)
        {
            velocity = velocity / 3.5f;
        }

        moveDirection(hor, vert);
        character.setSpeed(velocity.magnitude);
        character.roll(roll > 0.5);
    }

    void moveDirection(float horiz, float vertical)
    {

        Camera mainCamera = Camera.main;

        Vector3 right3d = mainCamera.GetComponent<Transform>().right;
        Vector3 up3d = mainCamera.GetComponent<Transform>().up;

        Vector2 right = new Vector2(right3d.x, right3d.z).normalized * horiz;
        Vector2 up = new Vector2(up3d.x, up3d.z).normalized * vertical;

        Vector2 desiredDirection = right + up;
        float ddAngle = Mathf.Tan(desiredDirection.x / desiredDirection.y);
        Vector2 ddRight = new Vector2(1, Mathf.Atan(ddAngle + (Mathf.PI / 2f)));
        

        if (desiredDirection.magnitude == 0)
        {
            character.setTurn(0);
            return;
        }

        Vector2 forward = new Vector2(GetComponent<Transform>().forward.x, GetComponent<Transform>().forward.z);

        float angle = Vector2.Angle(desiredDirection, forward);
        Vector3 cross = Vector3.Cross(desiredDirection, forward);

        if (cross.z < 0)
            angle = -angle;

        character.setTurn(angle / 20f);

    }
}

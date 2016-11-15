using UnityEngine;
using System.Collections;

public class UserController : MonoBehaviour {
    public RigidbodyController character;

	void FixedUpdate () {
        handleInputs();
    }

    void handleInputs()
    {
        //float turn = Input.GetAxis("Mouse X");
        float turn = Input.GetAxisRaw("Horizontal");
        float speed = Input.GetAxisRaw("Vertical");
        float roll = Input.GetAxis("Fire1");
        float jump = Input.GetAxis("Jump");

        character.setTurn(turn);
        character.setSpeed(3 * speed);
        character.roll(roll > 0.5);
        character.jump(jump > 0.5);
    }
}

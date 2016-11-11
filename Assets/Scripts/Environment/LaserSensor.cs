using UnityEngine;

/// <summary>
/// A laser that kills the player.
/// </summary>
class LaserSensor : MonoBehaviour {

    /// <summary> The sound played when the player touches a laser. </summary>
    [SerializeField]
    [Tooltip("The sound played when the player touches a laser.")]
    private AudioClip laserSound;

    /// <summary>
    /// Toggles the sensor from active/nonactive.
    /// </summary>
    public void Toggle() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    /// <summary>
    /// Kills the player when colliding with the laser.
    /// </summary>
    /// <param name="collider">Collider.</param>
    private void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            Health health = collider.GetComponent<Health>();
            if (health.health > 0) {
                collider.GetComponent<AudioSource>().PlayOneShot(laserSound);
                collider.GetComponent<Health>().OHKO();
            }
        }
    }
}
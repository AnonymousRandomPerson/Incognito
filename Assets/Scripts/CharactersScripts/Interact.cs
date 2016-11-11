using UnityEngine;

/// <summary>
/// Handles the player interacting with object.
/// </summary>
class Interact : MonoBehaviour {

    /// <summary> The collider used to check if the player is in range of an interactable. </summary>
    private CapsuleCollider capsuleCollider;
    /// <summary> The layer mask used to find interactables. </summary>
    private int layerMask;

    /// <summary> The exclamation mark that appears above the player's head when able to interact. </summary>
    private GameObject exclamation;

    /// <summary> The level exit. </summary>
    private Exit exit;

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        capsuleCollider = GetComponent<CapsuleCollider>();
        layerMask = 1 | 1 << LayerMask.NameToLayer("Interactable");

        exclamation = transform.FindChild("Exclamation").gameObject;

        exit = FindObjectOfType<Exit>();
    }

    /// <summary>
    /// Updates the object.
    /// </summary>
    private void Update() {
        RaycastHit hit;
        Interactable interactable = null;
        if (exit.GetComponent<Collider>().bounds.Contains(transform.position)) {
            interactable = exit;
        } else if (Physics.Raycast(transform.position + capsuleCollider.center, transform.forward, out hit, capsuleCollider.radius * 2, layerMask)) {
            interactable = hit.collider.GetComponent<Interactable>();
        }
        if (interactable != null) {
            exclamation.SetActive(true);
            if (Input.GetButtonDown("Fire2")) {
                interactable.Interact(gameObject);
            }
        } else {
            exclamation.SetActive(false);
        }
    }
}
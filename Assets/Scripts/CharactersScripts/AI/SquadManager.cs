using UnityEngine;
using RAIN.Core;

/// <summary>
/// Coordinates AI interactions with each other.
/// </summary>
class SquadManager : MonoBehaviour {

    /// <summary> All guards in the scene. </summary>
    private AI[] guards;

    /// <summary> The singleton instance of the object. </summary>
    public static SquadManager instance {
        get;
        private set;
    }

    /// <summary> The player seen by a guard. </summary>
    public const string PLAYER = "player";
    /// <summary> The last position that a guard saw the player at. </summary>
    public const string LAST_SEEN_PLAYER = "lastSeenPlayer";
    /// <summary> Whether the guard has seen the player. </summary>
    public const string ALARMED = "alarmed";

    /// <summary>
    /// Initializes the singleton instance of the object.
    /// </summary>
    private void Awake() {
        instance = this;
    }

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        AIRig[] guardRigs = FindObjectsOfType<AIRig>();
        guards = new AI[guardRigs.Length];
        for (int i = 0; i < guards.Length; i++) {
            guards[i] = guardRigs[i].AI;
        }
    }

    /// <summary>
    /// Alerts all guards about the player's location.
    /// </summary>
    /// <param name="player">The player who was spotted.</param>
    public void AlertAllGuards(GameObject player) {
        foreach (AI guard in guards) {
            if (!(bool)guard.WorkingMemory.GetItem(ALARMED)) {
                guard.WorkingMemory.SetItem(ALARMED, true);
                guard.WorkingMemory.SetItem(LAST_SEEN_PLAYER, player.transform.position);
            }
        }
    }
}
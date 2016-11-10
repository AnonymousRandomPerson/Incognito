using UnityEngine;
using RAIN.Action;
using RAIN.Core;
using RAIN.Navigation.Waypoints;
using System.Collections.Generic;

/// <summary>
/// Chooses a random room to head towards.
/// </summary>
[RAINAction]
public class ChooseRoom : RAINAction {

    /// <summary> Keeps track of which waypoints are rooms. </summary>
    private static Dictionary<int, RoomPoints> roomPoints;

    /// <summary> The index of the guard to use when matching room points. </summary>
    private const string GUARD_NUMBER = "guardNumber";

    /// <summary>
    /// Initializes the AI.
    /// </summary>
    /// <param name="ai">The AI to initialize.</param>
    public override void Start(AI ai) {
        base.Start(ai);
        if (roomPoints == null || roomPoints[0] == null) {
            RoomPoints[] roomPointObjects = GameObject.FindObjectsOfType<RoomPoints>();
            roomPoints = new Dictionary<int, RoomPoints>(roomPointObjects.Length);
            foreach (RoomPoints roomPointObject in roomPointObjects) {
                roomPoints.Add(roomPointObject.guardNumber, roomPointObject);
            }
        }
        ai.WorkingMemory.SetItem("waypointNetwork", GetGuardPoints(ai).GetComponent<WaypointRig>());
    }

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai) {
        ai.WorkingMemory.SetItem("roomTarget", GetGuardPoints(ai).GetRandomRoom());
        return ActionResult.SUCCESS;
    }

    /// <summary>
    /// Gets the room points of a guard.
    /// </summary>
    /// <returns>The room points of the specified guard.</returns>
    /// <param name="ai">The guard to get room points for.</param>
    private RoomPoints GetGuardPoints(AI ai) {
        int guardNumber = (int)ai.WorkingMemory.GetItem(GUARD_NUMBER);
        return roomPoints[guardNumber];
    }
}
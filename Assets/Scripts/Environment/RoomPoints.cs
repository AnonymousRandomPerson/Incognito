using UnityEngine;
using RAIN.Navigation.Waypoints;
using System.Collections.Generic;

/// <summary>
/// Registers which points in the waypoint network are rooms.
/// </summary>
[RequireComponent(typeof(WaypointRig))]
class RoomPoints : MonoBehaviour {
    
    /// <summary> The number of the guard who is using this set of points. </summary>
    [SerializeField]
    [Tooltip("The number of the guard who is using this set of points.")]
    private int GuardNumber;
    /// <summary> The number of the guard who is using this set of points. </summary>
    public int guardNumber {
        get { return GuardNumber; }
    }
    
    /// <summary> The indices of waypoints that are rooms. </summary>
    [SerializeField]
    [Tooltip("The indices of waypoints that are rooms.")]
    private int[] roomIndices;
    /// <summary> The positions of rooms in the scene. </summary>
    private Vector3[] roomPositions;

    /// <summary>
    /// Finds the positions of rooms.
    /// </summary>
    private void Start() {
        roomPositions = new Vector3[roomIndices.Length];
        IList<Waypoint> waypoints = GetComponent<WaypointRig>().WaypointSet.Waypoints;
        for (int i = 0; i < roomPositions.Length; i++) {
            roomPositions[i] = waypoints[roomIndices[i] - 1].Position;
        }
    }

    /// <summary>
    /// Gets a random room position.
    /// </summary>
    /// <returns>A random room position.</returns>
    public Vector3 GetRandomRoom() {
        return roomPositions[Random.Range(0, roomPositions.Length)];
    }
}
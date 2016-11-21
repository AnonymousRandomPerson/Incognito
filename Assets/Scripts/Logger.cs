using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Logs various actions during the game.
/// </summary>
class Logger : MonoBehaviour {

    /// <summary> The singleton logger instance. </summary>
    private static Logger _instance;
    /// <summary> The singleton logger instance. </summary>
    public static Logger instance {
        get {
            return _instance;
        }
    }

    /// <summary> Whether player logging is enabled. </summary>
    [SerializeField]
    [Tooltip("Whether player logging is enabled.")]
    private bool loggingEnabled;
    /// <summary> The name of the file to write to. </summary>
    [SerializeField]
    [Tooltip("The name of the file to write to.")]
    private string filePath;

    /// <summary> The log file. </summary>
    private StreamWriter file;

    /// <summary> The player character. </summary>
    private UserController player;

    /// <summary> The timer between logging data. </summary>
    private float logTimer;
    /// <summary> The time between logging data. </summary>
    [SerializeField]
    [Tooltip("The time between logging data.")]
    private float logTime;

    /// <summary> The history of player positions. </summary>
    private List<Vector3> playerPositions;
    /// <summary> The positions of terminals that were switched. </summary>
    private List<Vector3> terminalPositions;
    /// <summary> The positions where the player took damage. </summary>
    private List<Vector3> damagePositions;
    /// <summary> The positions where the player was spotted by guards. </summary>
    private List<Vector3> spottedPositions;
    /// <summary> The positions where the player collected loot. </summary>
    private List<Vector3> lootPositions;
    /// <summary> The positions where bullets were shot. </summary>
    private List<Vector3> shotPositions;

    /// <summary>
    /// Sets the logger instance.
    /// </summary>
    private void Awake() {
        _instance = this;
    }

    /// <summary>
    /// Initializes the object.
    /// </summary>
    private void Start() {
        player = FindObjectOfType<UserController>();
        playerPositions = new List<Vector3>();
        terminalPositions = new List<Vector3>();
        damagePositions = new List<Vector3>();
        spottedPositions = new List<Vector3>();
        lootPositions = new List<Vector3>();
        shotPositions = new List<Vector3>();
    }

    /// <summary>
    /// Updates the object.
    /// </summary>
    private void Update() {
        logTimer += Time.deltaTime;
        if (logTimer >= logTime) {
            logTimer = 0;

            playerPositions.Add(player.transform.position);
        }
    }

    /// <summary>
    /// Logs a terminal being switched.
    /// </summary>
    /// <param name="position">The position of the switched terminal.</param>
    public void LogTerminal(Vector3 position) {
        terminalPositions.Add(position);
    }

    /// <summary>
    /// Logs an action at a particular position.
    /// </summary>
    /// <param name="list">The list to record the position in.</param>
    private void LogPosition(List<Vector3> list) {
        list.Add(player.transform.position);
    }

    /// <summary>
    /// Logs the player taking damage.
    /// </summary>
    public void LogDamage() {
        LogPosition(damagePositions);
    }

    /// <summary>
    /// Logs the player being spotted by guards.
    /// </summary>
    public void LogSpotted() {
        LogPosition(spottedPositions);
    }

    /// <summary>
    /// Logs the player collecting loot.
    /// </summary>
    /// <param name="position">The position of the loot.</param>
    public void LogLoot(Vector3 position) {
        lootPositions.Add(position);
    }

    /// <summary>
    /// Logs a guard shooting a bullet.
    /// </summary>
    /// <param name="position">The position of the guard.</param>
    public void LogShot(Vector3 position) {
        shotPositions.Add(position);
    }

    /// <summary>
    /// Writes text to the current log file.
    /// </summary>
    /// <param name="text">The text to log.</param>
    public void WriteToFile() {
        if (loggingEnabled) {
            // Create the log file.
            System.IO.Directory.CreateDirectory(filePath);
            string date = DateTime.Now.ToString().Replace(":", "").Replace("/", "").Replace(" ", "_");
            file = File.CreateText(filePath + "log_" + date + ".txt");

            WriteValue(Time.time, "Play time");
            WriteValue(player.GetComponent<Health>().dead, "Dead?");
            WriteVectorListWithName(terminalPositions, "Terminals", true);
            WriteVectorListWithName(damagePositions, "Damaged", true);
            WriteVectorListWithName(spottedPositions, "Spotted", true);
            WriteVectorListWithName(lootPositions, "Loot collected", true);
            WriteVectorListWithName(shotPositions, "Shots fired", true);
            WriteVectorListWithName(playerPositions, "Player positions");

            file.Close();
        }
    }

    /// <summary>
    /// Writes a list of vectors to the log file.
    /// </summary>
    /// <param name="vectorList">The list of vectors to log.</param>
    /// <param name="name">The name of the list.</param>
    /// <param name="writeSize">Whether to write the list size directly to the file.</param>
    private void WriteVectorListWithName(List<Vector3> vectorList, string name, bool writeSize = false) {
        file.WriteLine(name);
        if (writeSize) {
            file.WriteLine(vectorList.Count);
        }
        WriteVectorList(vectorList);
        file.WriteLine("");
    }

    /// <summary>
    /// Writes a list of vectors to the log file.
    /// </summary>
    /// <param name="vectorList">The list of vectors to log.</param>
    private void WriteVectorList(List<Vector3> vectorList) {
        foreach (Vector3 vector in vectorList) {
            file.WriteLine(vector.ToString());
        }
    }

    /// <summary>
    /// Writes a value to the log file.
    /// </summary>
    /// <param name="value">The value to log.</param>
    /// <param name="name">The name of the vector.</param>
    private void WriteValue(object value, string name) {
        file.WriteLine(name);
        file.WriteLine(value.ToString());
        file.WriteLine("");
    }
}
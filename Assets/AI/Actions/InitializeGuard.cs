using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// Initializes fields for the guard.
/// </summary>
[RAINAction]
public class InitializeGuard : RAINAction {

    /// <summary> The normal walking speed of a guard. </summary>
    public const float WALK_SPEED = 1.5f;

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai) {
        ai.WorkingMemory.SetItem(SquadManager.ALARMED, false);
        ai.Motor.DefaultSpeed = WALK_SPEED;
        return ActionResult.SUCCESS;
    }
}
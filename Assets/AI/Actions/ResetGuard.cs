using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// Alerts all guards about the player's presence.
/// </summary>
[RAINAction]
public class ResetGuard : RAINAction
{

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai)
    {
        ai.WorkingMemory.SetItem(SquadManager.ALARMED, false);
        ai.WorkingMemory.SetItem(SquadManager.LAST_SEEN_PLAYER, Vector3.zero);
        return ActionResult.SUCCESS;
    }
}

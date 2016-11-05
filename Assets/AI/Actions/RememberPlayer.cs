using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// Records the last place that the guard saw the player at.
/// </summary>
[RAINAction]
public class RememberPlayer : RAINAction {

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai) {
        GameObject player = (GameObject)ai.WorkingMemory.GetItem(SquadManager.PLAYER);
        if (player != null) {
            ai.WorkingMemory.SetItem(SquadManager.LAST_SEEN_PLAYER, player.transform.position);
        }
        return ActionResult.SUCCESS;
    }
}
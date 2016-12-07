using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// Registers that a guard has noticed the player.
/// </summary>
[RAINAction]
public class NoticePlayer : RAINAction {

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai) {
        object player = null;
        object playerSee = ai.WorkingMemory.GetItem("playerSee");
        object playerHear = ai.WorkingMemory.GetItem("playerHear");
        if (playerSee != null) {
            player = playerSee;
        } else if (playerHear != null) {
            player = playerHear;
        }
        ai.WorkingMemory.SetItem("player", player);
        return ActionResult.SUCCESS;
    }
}
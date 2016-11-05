using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// Causes the AI to spin around looking for the player.
/// </summary>
[RAINAction]
public class LookAround : RAINAction {

    /// <summary> The speed at which the AI rotates. </summary>
    private const float ROTATE_SPEED = 1;
    /// <summary> The amount that the AI has rotated by so far. </summary>
    private const string ROTATE_AMOUNT = "rotateAmount";

    /// <summary>
    /// Starts the action for the AI.
    /// </summary>
    /// <param name="ai">The AI to start the action for.</param>
    public override void Start(AI ai) {
        base.Start(ai);
        ai.WorkingMemory.SetItem(ROTATE_AMOUNT, 0f);
    }

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai) {
        float prevRotate = (float)ai.WorkingMemory.GetItem(ROTATE_AMOUNT);
        ai.Body.GetComponent<RigidbodyController>().setTurn(ROTATE_SPEED);
        prevRotate += ROTATE_SPEED * 4;
        if (prevRotate >= 360) {
            ai.WorkingMemory.SetItem(SquadManager.ALARMED, false);
            ai.WorkingMemory.SetItem(SquadManager.LAST_SEEN_PLAYER, Vector3.zero);
            return ActionResult.SUCCESS;
        } else {
            ai.WorkingMemory.SetItem(ROTATE_AMOUNT, prevRotate);
            return ActionResult.RUNNING;
        }
    }

    /// <summary>
    /// Stops the action for the AI.
    /// </summary>
    /// <param name="ai">The AI to stop the action for.</param>
    public override void Stop(AI ai) {
        base.Stop(ai);
        ai.Body.GetComponent<RigidbodyController>().setTurn(0);
    }
}
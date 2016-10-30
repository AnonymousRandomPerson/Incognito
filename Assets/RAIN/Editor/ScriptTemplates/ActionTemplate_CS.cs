using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// 
/// </summary>
[RAINAction]
public class ActionTemplate_CS : RAINAction {

    /// <summary>
    /// Initializes the AI.
    /// </summary>
    /// <param name="ai">The AI to initialize.</param>
    public override void Start(AI ai) {
        base.Start(ai);
    }

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai) {
        return ActionResult.SUCCESS;
    }

    /// <summary>
    /// Stops the action for the AI.
    /// </summary>
    /// <param name="ai">The AI to stop the action for.</param>
    public override void Stop(AI ai) {
        base.Stop(ai);
    }
}
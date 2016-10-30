using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// 
/// </summary>
[RAINDecision]
public class DecisionTemplate_CS : RAINDecision {

    /// <summary> The child of the decision that is running. </summary>
    private int _lastRunning = 0;

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
        ActionResult tResult = ActionResult.SUCCESS;

        for (; _lastRunning < _children.Count; _lastRunning++) {
            tResult = _children[_lastRunning].Run(ai);
            if (tResult != ActionResult.SUCCESS) {
                break;
            }
        }

        return tResult;
    }

    /// <summary>
    /// Stops the action for the AI.
    /// </summary>
    /// <param name="ai">The AI to stop the action for.</param>
    public override void Stop(AI ai) {
        base.Stop(ai);
    }
}
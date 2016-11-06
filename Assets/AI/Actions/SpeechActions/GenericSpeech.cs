using UnityEngine;
using RAIN.Action;
using RAIN.Core;

/// <summary>
/// Alerts all guards about the player's presence.
/// </summary>
[RAINAction]
public abstract class GenericSpeech : RAINAction
{

    /// <summary>
    /// Updates the AI every frame.
    /// </summary>
    /// <param name="ai">The AI to update.</param>
    public override ActionResult Execute(AI ai)
    {
        AudioSource sound = ai.Body.GetComponent<AudioSource>();
        AudioClip speech = GetClip();

        if (sound != null && speech != null)
        {
            sound.clip = speech;
            sound.Play();
        }

        return ActionResult.SUCCESS;
    }

    protected abstract AudioClip GetClip();
}

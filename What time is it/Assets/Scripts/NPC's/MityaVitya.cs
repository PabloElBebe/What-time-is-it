using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MityaVitya : TalkableNPC
{
    [SerializeField] private Transform L_eye;
    [SerializeField] private Transform R_eye;

    [SerializeField] private Vector2 L_eyeClamp;
    [SerializeField] private Vector2 R_eyeClamp;

    public override void StartTalking()
    {
        base.StartTalking();

        HelpSystems.StartDialogue?.Invoke((List<string>)Phrases);

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null) return;

        StartCoroutine(FollowPlayerEyes(player));
        
        BasicSaveSystem.SaveBoolData(true, "mityaVityaTalked");
    }

    private IEnumerator FollowPlayerEyes(Transform player)
    {
        while (true)
        {
            L_eye.localPosition = new Vector2(
                Mathf.Clamp(player.position.x - L_eye.position.x, L_eyeClamp.x, L_eyeClamp.y),
                2.06f);

            R_eye.localPosition = new Vector2(
                Mathf.Clamp(player.position.x - R_eye.position.x, R_eyeClamp.x, R_eyeClamp.y),
                2.06f);

            yield return null;
        }
    }
}

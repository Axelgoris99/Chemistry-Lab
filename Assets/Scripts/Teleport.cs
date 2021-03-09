using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Valve.VR.InteractionSystem;

public class Teleport : MonoBehaviour
{
    public RiggedHand[] hands;

    enum FingerState
    {
        NONE,
        RELEASED,
        PRESSED,
        DOWN
    };
    private FingerState[] fingerState;

    private TeleportMarkerBase[] teleportMarkers;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        fingerState = new FingerState[hands.Length];
        for (int i = 0; i < hands.Length; i++) fingerState[i] = FingerState.NONE;

        teleportMarkers = GameObject.FindObjectsOfType<TeleportMarkerBase>();

        player = Valve.VR.InteractionSystem.Player.instance;
        if (player == null)
        {
            Debug.LogError("Teleport: No Player instance found in map.");
            Destroy(this.gameObject);
            return;
        }

        ShowMarkers(false);
    }

    // Update is called once per frame
    void Update()
    {
        // check finger state
        for (int i= 0; i < hands.Length; i++)
        {
            Leap.Hand leapHand = hands[i].GetLeapHand();
            if (leapHand == null) continue;
            Leap.Finger index = leapHand.GetIndex();
            Leap.Finger thumb = leapHand.GetThumb();
            if (index.TipPosition.DistanceTo(thumb.TipPosition) < 0.03)
            {
                if (fingerState[i] == FingerState.PRESSED) fingerState[i] = FingerState.DOWN;
                else if (fingerState[i] != FingerState.DOWN) fingerState[i] = FingerState.PRESSED;
            }
            else
            {
                if (fingerState[i] == FingerState.RELEASED) fingerState[i] = FingerState.NONE;
                else if (fingerState[i] != FingerState.NONE) fingerState[i] = FingerState.RELEASED;
            }

            //
            if (fingerState[i] == FingerState.RELEASED)
            {
                ShowMarkers(false);
            }
            if (fingerState[i] == FingerState.PRESSED)
            {
                ShowMarkers(true);
            }
        }
    }

    void ShowMarkers(bool visible)
    {
        foreach (TeleportMarkerBase teleportMarker in teleportMarkers)
        {
            if (teleportMarker != null && teleportMarker.markerActive && teleportMarker.gameObject != null)
            {
                if (!visible)
                    teleportMarker.gameObject.SetActive(false);
                else if (teleportMarker.ShouldActivate(player.feetPositionGuess))
                {
                    teleportMarker.gameObject.SetActive(true);
                    teleportMarker.Highlight(false);
                }
            }
        }
        
    }
}

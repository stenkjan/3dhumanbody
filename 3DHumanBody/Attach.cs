using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Attach : MonoBehaviour
{
    private Interactable interactable;

    //initialisierung
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

   private void OnHandOverBegin(Hand hand)
    {
        hand.ShowGrabHint();
    }
    private void OnHandOverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    private void HandHoverUpdate(Hand hand)
    {
        //Erkennung, ob ein Objekt in greifnähe ist
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);
        // Grab function 
        if (interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }
        else if (isGrabEnding)
        //Objekt wird losgelassen
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }
}
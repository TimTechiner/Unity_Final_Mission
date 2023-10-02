using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public abstract void InteractWithPlayer();

    public abstract void DisableInteraction();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HittableNPC : NPC
{
    private int currentHP;

    [SerializeField]
    private int HP = 5;

    [SerializeField]
    private Material idleMaterial;
    
    [SerializeField]
    private Material attackedMaterial;

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Slider healthBarSlider;

    private float attackedDuration = 0.1f;
     
    public override void InteractWithPlayer()
    {
        currentHP--;

        healthBarSlider.value = (float)currentHP / HP;

        StartCoroutine(GetAttacked());

        if (currentHP == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        meshRenderer.material.color = idleMaterial.color;
        currentHP = HP;
    }
     
    private IEnumerator GetAttacked()
    {
        meshRenderer.material.color = attackedMaterial.color;
        yield return new WaitForSeconds(attackedDuration);
        meshRenderer.material.color = idleMaterial.color;
    }

    public override void DisableInteraction() { }
}

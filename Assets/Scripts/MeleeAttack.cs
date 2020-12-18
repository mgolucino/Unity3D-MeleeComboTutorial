using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttack : MonoBehaviour
{
    private Animator animator;

    readonly int hashMeleeAttackA = Animator.StringToHash("MeleeAttackA");
    readonly int hashNextAction = Animator.StringToHash("NextAction");

    public Transform actionList;
    private List<Image> actionListImages = new List<Image>();
    
    public Animation cylinderHit;

    private void Start()
    {
        animator = GetComponent<Animator>();

        for (int i = 0; i < actionList.childCount; i ++)
        {
            Image newImage = actionList.GetChild(i).GetComponent<Image>();

            if (newImage != null)
                actionListImages.Add(newImage);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            animator.SetTrigger(hashMeleeAttackA);
    }

    public void NextAction() // called by animation event
    {
        animator.SetTrigger(hashNextAction);
    }

    public void UpdateCanvas(int actionState) // called by StateHandler.cs
    {
        int listCount = actionListImages.Count;

        for (int i = 0; i < listCount; i ++)
        {
            actionListImages[i].color = new Color(1.0f, 1.0f, 1.0f, 0.33f);
        }

        if (actionState != 0)
            actionListImages[actionState - 1].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}
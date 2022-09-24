using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : Interactable
{
    [Header("gameObjects")]
    [SerializeField] private GameObject keyRequired;

    [Header("Audio")]
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource lockedSound;

    private Animator boxAnim;
    private bool open = false;

    private void Awake()
    {
        boxAnim = gameObject.GetComponent<Animator>();
    }

    protected override void Interact()
    {
        if (keyRequired.activeInHierarchy && !open)
        {
            boxAnim.Play("boxOpen", 0, 0.0f);
            keyRequired.SetActive(false);
            openSound.Play();
            open = true;
        }
        else if (!keyRequired.activeInHierarchy)
        {
            lockedSound.Play();
        }
    }
}

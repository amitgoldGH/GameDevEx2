using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDoorMotion : MonoBehaviour
{

    private Animator animator;
    private AudioSource doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        doorOpen = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("Shop_Door_Open", true);
        doorOpen.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("Shop_Door_Open", false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}

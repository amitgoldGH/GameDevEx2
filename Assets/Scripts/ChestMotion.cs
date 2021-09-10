using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestMotion : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHairSquare;
    public GameObject crossHairNormal;
    public new GameObject camera;
    public Text chestInteractText;
    private AudioSource ChestSound;
    // Start is called before the first frame update
    void Start()
    {
        ChestSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit);
        if (hit.transform.gameObject != null && hit.distance < 5)
        {
            if (hit.transform.gameObject == this.gameObject)// we hve focused on THIS
            {
                chestInteractText.gameObject.SetActive(true);
                crossHairSquare.SetActive(true);
                crossHairNormal.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("Chest_Is_Open", !(animator.GetBool("Chest_Is_Open")));
                    ChestSound.Play();
                }

            }
            else
            {
                chestInteractText.gameObject.SetActive(false);
                crossHairSquare.SetActive(false);
                crossHairNormal.SetActive(true);
            }

        }
    }
}

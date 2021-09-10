using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawerTop1Motion : MonoBehaviour
{
    public Animator animator;
    public GameObject crossHairSquare;
    public GameObject crossHairNormal;
    public GameObject camera;
    public Text drawerText;
    private AudioSource drawerAudio;
    // Start is called before the first frame update
    void Start()
    {
        drawerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(camera.transform.position, camera.transform.forward, out hit);
        if (hit.transform.gameObject != null && hit.distance < 5)
        {
            if (hit.transform.gameObject == this.gameObject)// we hve focused on THIS
            {
                drawerText.gameObject.SetActive(true);
                crossHairSquare.SetActive(true);
                crossHairNormal.SetActive(false);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("Top1_Is_Open", !(animator.GetBool("Top1_Is_Open")));
                    drawerAudio.Play();
                }

            }
            else
            {
                drawerText.gameObject.SetActive(false);
                crossHairSquare.SetActive(false);
                crossHairNormal.SetActive(true);
            }
            
        }

    }
}

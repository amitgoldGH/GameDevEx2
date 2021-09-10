using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldBarPickup : MonoBehaviour
{

    public GameObject camera;
    public Text goldBarPickupText;
    public Text goldBarCounterText;
    public AudioSource pickupSound;
    public static int numBars;
    // Start is called before the first frame update
    void Start()
    {
        numBars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit);
        if (hit.transform.gameObject != null && hit.distance < 5)
        {
            if (hit.transform.gameObject == this.gameObject)
            {
                goldBarPickupText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.T))
                {
                    numBars++;
                    pickupSound.Play();
                    goldBarCounterText.text = "Gold Bars Collected: " + numBars + "/2";
                    this.gameObject.SetActive(false);
                    goldBarPickupText.gameObject.SetActive(false);
                }

            }
            else
            {
                goldBarPickupText.gameObject.SetActive(false);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JodyNPCBehaviour : MonoBehaviour
{

    private Animator NPCAnimator;
    private AudioSource FemaleGruntSound;
    public GameObject targetGarry;
    private int gruntCounter;
    // Start is called before the first frame update
    void Start()
    {
        NPCAnimator = GetComponent<Animator>();
        FemaleGruntSound = GetComponent<AudioSource>();
        gruntCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position - targetGarry.transform.position).magnitude > 15.0)
        {
            NPCAnimator.SetInteger("state", 2);
            if(!FemaleGruntSound.isPlaying &&  gruntCounter < 1)
            {
                FemaleGruntSound.Play();
                gruntCounter++;
            }
                
        }
        else
        {
            NPCAnimator.SetInteger("state", 1);
            gruntCounter = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeVFX : MonoBehaviour
{
    public Animator anim;

    private void Update()
    {
        anim.SetBool("Chomp", true);
    }

    public void End()
    {
        anim.SetBool("Chomp", false);
        Invoke("Off", 0.2f);
    }
    public void Off()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneAnimation : MonoBehaviour
{
    Animator anim;
    Home home;
    
    // Start is called before the first frame update
    void Start()
    {
        home = FindObjectOfType<Home>();
        anim = GetComponent<Animator>();
        home.inGame = true;
        StartAnim();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnim()
    {
        anim.SetBool("StartAnim", true);
    }

    public void Reload()
    {
        anim.SetBool("StartAnim", false);
        StartAnim();
    }


}

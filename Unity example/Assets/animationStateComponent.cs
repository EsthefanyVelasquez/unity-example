using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateComponent : MonoBehaviour

private Animator animator;
{
    // Start is called before the first frame update
    void Start()
    {
        // Obtenemos el componente Animator del personaje
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        riding=animator.GetBool ("isRiding")
        bool adelante = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow));
        if (!riding && adelante).
        {
           animator.Setbool("isRiding",true)
         }

         if (riding && !adelante).
        {
           animator.Setbool("isRiding",false)
         }
        
    }
}

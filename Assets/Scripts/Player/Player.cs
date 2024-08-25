using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animation anim;
    void TakeDamage()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Hit();
        }
    }
    void Hit()
    {
        anim.Play("hit");
    }
}

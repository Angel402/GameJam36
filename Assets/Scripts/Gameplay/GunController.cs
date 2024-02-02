using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    Animator m_animator;
    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_animator.enabled = true;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            m_animator.SetTrigger("Shoot");
        }
    }
}

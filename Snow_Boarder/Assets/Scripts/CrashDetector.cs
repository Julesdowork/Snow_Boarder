using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D playerHead;

    void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && playerHead.IsTouching(other.collider))
            Debug.Log("OUCH! You bonked your head!");
    }
}

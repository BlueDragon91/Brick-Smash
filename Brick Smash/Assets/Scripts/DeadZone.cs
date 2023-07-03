using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private AudioSource DeadZoneSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            DeadZoneSound.Play();
            FindAnyObjectByType<GameManager>().Miss();
        }
    }
}

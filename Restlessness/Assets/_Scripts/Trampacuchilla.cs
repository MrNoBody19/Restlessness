using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampacuchilla : MonoBehaviour
{
    [SerializeField]
    private AudioClip _healthsound;

    [SerializeField]
    private float healtQTY = 5.0f;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.RestHeatl(healtQTY);
            AudioSource.PlayClipAtPoint(_healthsound, transform.position, 1f);
        }
    }
}


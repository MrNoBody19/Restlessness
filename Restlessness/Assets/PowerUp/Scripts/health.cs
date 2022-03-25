using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]
    private AudioClip _healthsound;

    [SerializeField]
    private float healtQTY = 5.0f;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Player player = other.GetComponent <Player>();
            player.AddHeatl(healtQTY);
            AudioSource.PlayClipAtPoint(_healthsound, transform.position, 1f);
            Player.
            Destroy(this.gameObject);
        }
    }
}

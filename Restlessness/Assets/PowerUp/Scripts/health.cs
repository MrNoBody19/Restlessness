using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField]
    private AudioClip _healthsound;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(_healthsound, transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}

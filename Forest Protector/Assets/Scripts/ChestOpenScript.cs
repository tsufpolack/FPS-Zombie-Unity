using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpenScript : MonoBehaviour
{

    public AudioClip audioClip;
    public Transform treasorBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
            treasorBox.GetComponent<Animation>().Play();
            Destroy(gameObject);
        }
    }
}

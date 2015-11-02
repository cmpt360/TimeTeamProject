using UnityEngine;
using System.Collections;

public class sounds : MonoBehaviour {

    // Use this for initialization
    public AudioClip myshot;

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<AudioSource>().clip = myshot;
            GetComponent<AudioSource>().Play();

        }
    }
}

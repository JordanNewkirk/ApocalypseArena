using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource background;
    private void Start()
    {
        background.volume = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

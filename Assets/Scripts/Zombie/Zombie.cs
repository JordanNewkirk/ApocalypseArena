using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public AudioSource zombieWalking;
    private void Start()
    {
        zombieWalking.volume = 1f;
        //zombieWalking.loop = true;
        zombieWalking.Play();
    }
    public class OnDeathEventArgs
    {
        public Zombie Zombie;
        public bool IsAlive = false;

        public OnDeathEventArgs(bool isAlive, Zombie zombie)
        {
            IsAlive = isAlive;
            Zombie = zombie;
        }
    }

    public static event System.EventHandler<OnDeathEventArgs> OnDeath;

    private void OnDestroy()
    {
        OnDeath?.Invoke(this, new OnDeathEventArgs(false, this));
    }
}
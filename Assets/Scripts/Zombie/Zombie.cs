using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
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

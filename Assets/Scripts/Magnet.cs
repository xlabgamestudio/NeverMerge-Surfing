using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private void Awake()
    {
        //Destroy in 3 seconds after spawn
        Destroy(this.gameObject, 4f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroy : MonoBehaviour
{
    public float lifeTime = 1f;
    public bool isKilled = false;
    // Start is called before the first frame update
    void Start()
    {
        isKilled = true;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

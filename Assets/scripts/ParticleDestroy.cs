using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticleDestroy : MonoBehaviour
{
    public float destroyTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
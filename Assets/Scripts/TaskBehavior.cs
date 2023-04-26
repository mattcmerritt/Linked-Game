using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBehavior : MonoBehaviour
{
    [SerializeField] private float RemainingTime;

    protected void Start()
    {
        RemainingTime = 2f;
    }

    protected void Update()
    {
        if(RemainingTime < 0)
        {
            // do something like give score
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D()
    {
        RemainingTime -= Time.deltaTime;
    }
}

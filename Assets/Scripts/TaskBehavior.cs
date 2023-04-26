using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBehavior : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)] private float RemainingTime;
    [SerializeField, Range(0, 1000)] private int PointValue;
    [SerializeField] private ScoreManager ScoreManager;

    protected void Update()
    {
        if(RemainingTime < 0)
        {
            ScoreManager.AddScore(PointValue);
            ScoreManager.DestroyTaskObject(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            RemainingTime -= Time.deltaTime;
        }
    }

    public void LinkScoreManager(ScoreManager sm)
    {
        ScoreManager = sm;
    }
}

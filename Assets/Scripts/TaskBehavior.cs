using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBehavior : MonoBehaviour
{
    [SerializeField, Range(0f, 5f)] private float StartingTime, RemainingTime;
    [SerializeField, Range(0, 1000)] private int PointValue;
    [SerializeField] private ScoreManager ScoreManager;
    [SerializeField] private GameObject ProgressBar;

    protected void Start()
    {
        RemainingTime = StartingTime;
    }

    protected void Update()
    {
        // progress bar
        float barPercent = RemainingTime / StartingTime;
        ProgressBar.transform.localScale = new Vector3(barPercent, 1, 1);
        ProgressBar.transform.localPosition = new Vector3(-(1 - barPercent) / 2f, 0, 0);

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

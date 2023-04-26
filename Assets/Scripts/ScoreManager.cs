using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> ActiveTasks;
    [SerializeField] private GameObject TaskPrefab;
    [SerializeField] private int Score;
    [SerializeField] private float TimeSinceLastTask;
    [SerializeField, Range(-10f, 10f)] private float TaskSpawnMinX, TaskSpawnMaxX, TaskSpawnMinY, TaskSpawnMaxY;
    [SerializeField, Range(0f, 10f)] private float TimeIntervalForSurvivalScore;
    [SerializeField, Range(0, 1000)] private int SurvivalScoreAmount;

    protected void Start()
    {
        Score = 0;
        TimeSinceLastTask = 0;

        StartCoroutine(AwardScoreOverTime());
    }

    protected void FixedUpdate()
    {
        TimeSinceLastTask += Time.deltaTime;

        // new task spawns every 3 sec + an additional 2 sec for every task that still exists
        // example: if 2 tasks exist, the next will spawn 7 seconds later, assuming that none are cleared in that time
        float timeToWait = 3f + (ActiveTasks.Count * 2);
        
        
        if(TimeSinceLastTask >= timeToWait)
        {
            TimeSinceLastTask = 0;
            GameObject newTask = Instantiate(TaskPrefab);
            newTask.GetComponent<TaskBehavior>().LinkScoreManager(this);
            ActiveTasks.Add(newTask);

            // move task to random position
            Vector3 newTaskPos = new Vector3(Random.Range(TaskSpawnMinX, TaskSpawnMaxX), Random.Range(TaskSpawnMinY, TaskSpawnMaxY), 0f);
            newTask.transform.position = newTaskPos;
        }
    }

    public IEnumerator AwardScoreOverTime()
    {
        yield return new WaitForSeconds(TimeIntervalForSurvivalScore);

        AddScore(SurvivalScoreAmount);

        StartCoroutine(AwardScoreOverTime());
    }

    public void DestroyTaskObject(GameObject taskObj)
    {
        ActiveTasks.Remove(taskObj);
        Destroy(taskObj);
    }

    public void AddScore(int pointsToAdd)
    {
        Score += pointsToAdd;
    }
}

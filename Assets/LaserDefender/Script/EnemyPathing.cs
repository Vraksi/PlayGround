using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    [SerializeField] List<Transform> waypoints;
    float moveSpeed;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Vi laver ikke en ny fordi vi assigner den i Inspector
        //Vi skal ikke finde et objekt fordi vi ikke har et objekt med Scriptet i scenen.
        waypoints = waveConfig.GetWaypoints();
        //tager teknisk fat i et gameobject derfor skal vi have transform.position med
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void MoveEnemy()
    {
        //TODO maybe <= og - 1 til waypoints.count
        if (waypointIndex <= waypoints.Count -1)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPos, movementThisFrame);

            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
            //waypointIndex = 0;
        }
    }
}

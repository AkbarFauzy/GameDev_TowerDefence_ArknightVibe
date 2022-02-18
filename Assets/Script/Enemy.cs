using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private bool isBlocked;
    [SerializeField] private int speed;
    private PathFinder pathFinder;

    private new void Start()
    {
        base.Start();
        isBlocked = false;
        if (pathFinder == null) {
            pathFinder = transform.parent.GetComponent<PathFinder>();
        }
        var paths = pathFinder.GetPath();
        StartCoroutine(FollowPath(paths));
    }

    private bool IsDestinationReach(Vector3 destination) => Vector3.Distance(this.transform.position, destination) < 0.001f;

    private IEnumerator FollowPath(List<Waypoint> paths)
    {
        foreach (Waypoint path in paths) {
            yield return StartCoroutine(MoveToWaypoint(path));

        }
        yield return null;
    }
    public IEnumerator MoveToWaypoint(Waypoint path)
    {
        Vector3 gridPos = new Vector3(path.GetGridPos().x, transform.position.y , path.GetGridPos().y);
        while (Vector3.Distance(transform.position, gridPos) > 0.001f) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, gridPos, step);
            yield return new WaitUntil(()=> !isBlocked);
        }
        yield break;
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Operator") {
            Debug.Log("collide");
            isBlocked = true;
        } else if (collision.gameObject.tag == "PlayerBase") {
            Stages.StageInstance.TakeDamage(1);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isBlocked = false;
    }


}

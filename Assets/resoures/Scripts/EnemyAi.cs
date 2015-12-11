using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{

    public float rotationSpeed = 90;
    public float speed = 2.5f;
    Transform player;


    void Update()
    {
        if (player == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
            {
                player = obj.transform;
            }
        }
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotationSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}

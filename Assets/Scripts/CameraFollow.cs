using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 deadZone = new Vector2(2f, 2f);

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        float dx = target.position.x - pos.x;
        float dy = target.position.y - pos.y;

        if (Mathf.Abs(dx) > deadZone.x)
            pos.x = target.position.x - Mathf.Sign(dx) * deadZone.x;

        if (Mathf.Abs(dy) > deadZone.y)
            pos.y = target.position.y - Mathf.Sign(dy) * deadZone.y;

        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}

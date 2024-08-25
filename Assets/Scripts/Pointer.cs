using UnityEngine;

public class Pointer : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
            pos.z = 0;
            transform.position = pos;
        }
    }
}

using UnityEngine;

public sealed class Billboard : MonoBehaviour
{
    private void LateUpdate()
    {
        if (Camera.main == null) return;
        transform.forward = Camera.main.transform.forward;
    }
}

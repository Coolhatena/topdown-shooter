using UnityEngine;

public sealed class Door : MonoBehaviour
{
    [SerializeField] private Collider blockingCollider;
    [SerializeField] private GameObject visualsClosed;
    [SerializeField] private GameObject visualsOpen;

    private void Awake()
    {
        if (blockingCollider == null) blockingCollider = GetComponent<Collider>();
    }

    public void Close()
    {
        if (blockingCollider != null) blockingCollider.enabled = true;
        if (visualsClosed != null) visualsClosed.SetActive(true);
        if (visualsOpen != null) visualsOpen.SetActive(false);
    }

    public void Open()
    {
        if (blockingCollider != null) blockingCollider.enabled = false;
        if (visualsClosed != null) visualsClosed.SetActive(false);
        if (visualsOpen != null) visualsOpen.SetActive(true);
    }
}

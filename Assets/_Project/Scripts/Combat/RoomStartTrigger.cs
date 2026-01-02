using UnityEngine;

public class RoomStartTrigger : MonoBehaviour
{
    [SerializeField] private RoomController room;

    private void OnTriggerEnter(Collider other)
    {
        if (room == null) return;

        if (!other.CompareTag("Player")) return;

        room.StartRoom();
        gameObject.SetActive(false);
        Debug.Log("Room enter triggered");
    }
}

using UnityEngine;

public sealed class RoomController : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;

    private bool cleared;

    private void Start()
    {
        cleared = false;
        spawner.Spawn();
    }

    private void Update()
    {
        if (cleared) return;

        if (spawner.IsCleared)
        {
            cleared = true;
            OnRoomCleared();
        }
    }

    private void OnRoomCleared()
    {
        Debug.Log("Room cleared!");
        // Additional logic for when the room is cleared.
    }
}

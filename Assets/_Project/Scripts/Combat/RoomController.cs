using UnityEngine;

public sealed class RoomController : MonoBehaviour
{
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private Door[] doors;

    [SerializeField] private GameObject clearRewardPrefab;
    [SerializeField] private Transform rewardSpawnPoint;

    private bool started;
    private bool cleared;

    private void Awake()
    {
        started = false;
        cleared = false;

        setDoorsOpen(true);
    }

    public void StartRoom()
    {
        if (started) return;

        started = true;
        cleared = false;

        setDoorsOpen(false);
        spawner.Spawn();
    }

    private void Update()
    {
        if (!started || cleared) return;

        if (spawner.IsCleared)
        {
            cleared = true;
            setDoorsOpen(true);
            OnRoomCleared();
        }
    }

    private void setDoorsOpen(bool open)
    {
        if (doors == null) return;

        for(int i = 0; i < doors.Length; i++)
        {
            if (doors[i] == null) continue;

            if (open) doors[i].Open();
            else doors[i].Close();
        }
    }

    private void OnRoomCleared()
    {
        Debug.Log("Room cleared!");

        if (clearRewardPrefab != null)
        {
            Vector3 pos = rewardSpawnPoint != null ? rewardSpawnPoint.position : transform.position;
            Instantiate(clearRewardPrefab, pos, Quaternion.identity);
        }
    }
}

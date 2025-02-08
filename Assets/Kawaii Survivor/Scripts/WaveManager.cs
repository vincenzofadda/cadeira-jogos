using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class WaveManager : MonoBehaviour
{
  [Header(" Elements ")]
  [SerializeField]
  private Player player;
  [Header(" Settings ")]
  [SerializeField] private float waveDuration;
  private float timer;
  private bool isTimerOn;
  private int currentWaveIndex;

  [Header(" Waves ")]
  [SerializeField] private Wave[] waves;
  private List<float> localCounters = new List<float>();

  void Start()
  {
    StartWave(0);
  }

  void Update()
  {
    if (!isTimerOn)
      return;

    if (timer < waveDuration)
      ManageCurrentWave();
    else
      StartWaveTransition();
  }

  private void StartWave(int waveIndex)
  {
    localCounters.Clear();
    foreach (WaveSegment segment in waves[waveIndex].segments)
      localCounters.Add(1);

    timer = 0;
    isTimerOn = true;
  }

  private void ManageCurrentWave()
  {
    Wave currentWave = waves[0];
    for (int i = 0; i < currentWave.segments.Count; i++)
    {
      WaveSegment segment = currentWave.segments[i];

      float tStart = segment.tStartEnd.x / 100 * waveDuration;
      float tEnd = segment.tStartEnd.y / 100 * waveDuration;


      if (timer < tStart || timer > tEnd)
        continue;

      float timeSinceSegmentStart = timer - tStart;

      float spawnDelay = 1f / segment.spawnFrequency;



      if (timeSinceSegmentStart / spawnDelay > localCounters[i])
      {
        Instantiate(segment.prefab, GetSpawnPosition(), Quaternion.identity, transform);
        localCounters[i]++;
      }
    }

    timer += Time.deltaTime;
  }

  private void StartWaveTransition()
  {
    currentWaveIndex++;
    StartWave(currentWaveIndex);
  }

  private Vector2 GetSpawnPosition()
  {
    Vector2 direction = Random.onUnitSphere;
    Vector2 offset = direction.normalized * Random.Range(6, 10);
    Vector2 targetPosition = (Vector2)player.transform.position + offset;

    targetPosition.x = Mathf.Clamp(targetPosition.x, -18, 18);
    targetPosition.y = Mathf.Clamp(targetPosition.y, -8, 8);


    return targetPosition;
  }
}

[System.Serializable]
public struct Wave
{
  public string name;
  public List<WaveSegment> segments;
}

[System.Serializable]
public struct WaveSegment
{
  [MinMaxSlider(0, 100)] public Vector2 tStartEnd;
  public float spawnFrequency;
  public GameObject prefab;
}
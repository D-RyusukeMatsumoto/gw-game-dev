using System.Collections;
using UnityEngine;

namespace Spawner
{
    /// <summary>
    /// エネミーのスポナー.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {

        // TODO : とりあえずこの実装、最終的にはScriptableObjectなりで実装する.
        [SerializeField] GameObject enemyPrefab;


        void Start()
        {
            // TODO : 最終的には外部からの軌道にする.
            StartSpawnScedule();
        }

        
        private IEnumerator Spawn()
        {
            bool isComplete = false;
            float timeCount = 0f;
            int spawnCount = 0;
            while (!isComplete)
            {
                yield return new WaitUntil(
                    () =>
                    {
                        timeCount += Time.deltaTime;
                        return 1f <= timeCount;
                    });
                timeCount = 0f;
                Instantiate(enemyPrefab);
                ++spawnCount;
                isComplete = 10 <= spawnCount;
            }
        }

        
        public void StartSpawnScedule()
        {
            StartCoroutine(Spawn());
        }


        


    }
}
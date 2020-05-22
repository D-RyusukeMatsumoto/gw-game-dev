using System;
using System.Collections;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyBase : MonoBehaviour
    {

        // デフォルトのライフタイムは10秒.
        [field: SerializeField]
        public float LifeTime { get; private set; } = 10f;

        void Start()
        {
            StartCoroutine(CalculateLifeTime());
        }

        
        /// <summary>
        /// ライフタイムを計算し、一定時間経過した場合に削除する.
        /// </summary>
        /// <returns></returns>
        IEnumerator CalculateLifeTime()
        {
            float timeCount = 0f;
            yield return new WaitUntil(() =>
                {
                    timeCount += Time.deltaTime;
                    Debug.Log($"hoge {timeCount}");
                    return LifeTime <= timeCount;
                });
            Destroy(gameObject);
        }


    }
}
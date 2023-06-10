using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Spawer : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 referencePosition;
    [SerializeField] private int numberEnemies;
    [SerializeField] private Quaternion spawRotation;
    [SerializeField] private Transform enemies;
    [SerializeField] private float timeBetweenEnemies;
    [SerializeField] private float initialWaitTime;
    //Subir el nivel de las balas
    [SerializeField] private BalaEnemyBasic enemyBala;
    [SerializeField] private EnemyBasic enemicBasic;
    //List of enemies
    [SerializeField] private List<GameObject> enemiesList;

    private struct EnemyData
    {
        public string enemyName;
        public int levelDifficult;
        public string enemyType;
    
    }

    private Dictionary<string, EnemyData> enemyDictionary = new Dictionary<string, EnemyData>();

    private void Awake()
    {
        EnemyData enemyBasicData = new EnemyData()
        {
            enemyName = "EnemyNumber1",
            levelDifficult = 1,
            enemyType = "Ship"

        };
        enemyDictionary.Add("EnemyBasic", enemyBasicData);

        PrintInfoFromEnemyBasic();
    }

    private void PrintInfoFromEnemyBasic()
    {
        if (enemyDictionary.TryGetValue("EnemyBasic", out EnemyData enemyBasicData)) 
        {
            Debug.Log(enemyBasicData.enemyName);
            Debug.Log(enemyBasicData.levelDifficult);
            Debug.Log(enemyBasicData.enemyType);
        }  
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawerCoroutine(enemyPrefab));
    }

    private IEnumerator EnemySpawerCoroutine(GameObject enemyPrefab) 
    { 
        yield return new WaitForSeconds(initialWaitTime);

        for (int i = 0; i < numberEnemies; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-referencePosition.x, referencePosition.x), referencePosition.y, Random.Range(2.5f, 10.5f));
            SpawEnemy(randomPosition, spawRotation);

            GameObject newObject = Instantiate(enemyPrefab);
            enemiesList.Add(newObject);

            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }
    public void SpawEnemy(Vector3 enemyPosition, Quaternion rotation)
    {
        Instantiate(enemyPrefab,enemyPosition, rotation, enemies);
    }
    // Update is called once per frame
    void Update()
    {

        //aumentar de velocidad cada vez que hay 10 enemigos instanciados

        if (enemiesList.Count == 10) {

            enemiesList.Clear();

            enemyBala.speed += 0.2f;
            enemicBasic.frecuenciaDeDisparo -= 0.2f;

            Debug.Log("YA PASARON TODOS LOS ENEMIGOS");
            Debug.Log("LA VELOCIDAD DE LA BALA ES " + enemyBala.speed);
            Debug.Log("LA FRECUENCIA DE DISPARO ES " + enemicBasic.frecuenciaDeDisparo);

        }
    }
    void OnDisable()
    {
        enemyBala.speed = 2;
        enemicBasic.frecuenciaDeDisparo = 2;
    }
}

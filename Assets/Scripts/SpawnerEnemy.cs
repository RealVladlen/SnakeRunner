using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy_1;
    [SerializeField] private GameObject[] _enemy_2;
    [SerializeField] private GameObject _firstGroupEnemy;
    [SerializeField] private GameObject _twoGroupEnemy;
    [SerializeField] private GameObject _frame;

    [SerializeField] private Material _material;
    [SerializeField] private Material _enemyMaterial;

    [SerializeField] private float _minDistance;
    [SerializeField] private float _maxDistance;

    private void Start()
    {

        Transform firstEnemyGroup = _firstGroupEnemy.transform;
        Transform twoEnemyGroup = _twoGroupEnemy.transform;

        firstEnemyGroup.position += new Vector3(0, 0, Random.Range(_minDistance, _maxDistance));
        twoEnemyGroup.position += new Vector3(0, 0, Random.Range(_minDistance, _maxDistance));


        // Назначение материалов
        _material = _frame.GetComponent<MeshRenderer>().sharedMaterial;

        _enemyMaterial = _frame.GetComponent<Frame>()._enemyMaterial;



        int enemy_1 = Random.Range(0, 2);

        if (enemy_1 == 0)
        {
            for (int i = 0; i < _enemy_1.Length; i++)
            {
                _enemy_1[i].GetComponent<MeshRenderer>().sharedMaterial = _material;

            }
            for (int i = 0; i < _enemy_2.Length; i++)
            {
                _enemy_2[i].GetComponent<MeshRenderer>().sharedMaterial = _enemyMaterial;
            }
        }
        else
        {
            for (int i = 0; i < _enemy_1.Length; i++)
            {
                _enemy_1[i].GetComponent<MeshRenderer>().sharedMaterial = _enemyMaterial;

            }
            for (int i = 0; i < _enemy_2.Length; i++)
            {
                _enemy_2[i].GetComponent<MeshRenderer>().sharedMaterial = _material;
            }
        }
    }
}

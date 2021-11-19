using UnityEngine;
using UnityEngine.SceneManagement;

public class UpPoints : MonoBehaviour
{
    private Transform _gameObj;

    private void Start()
    {
        _gameObj = gameObject.transform;

        _gameObj.position += new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
    }


    private void OnTriggerEnter(Collider other)
    {
        // +1 очко если совпадает цвет игрока и врага
        if (other.gameObject.tag == ("Player"))
        {
            bool fever = other.GetComponent<PlayerScore>().fever;

            if(fever == false)
            {
                if (other.gameObject.GetComponent<PlayerScore>().nameMaterials == gameObject.GetComponent<MeshRenderer>().sharedMaterial.name.ToString())
                {
                    other.gameObject.GetComponent<PlayerScore>().Score();

                    Destroy(gameObject);
                }

                // Перезагрузка уровня при несоответствии цвета или если это мина
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            else
            {
                other.gameObject.GetComponent<PlayerScore>().Score();

                Destroy(gameObject);
            }
        }
    }
}

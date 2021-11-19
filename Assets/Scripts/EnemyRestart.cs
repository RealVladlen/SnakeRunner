using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRestart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // +1 очко если совпадает цвет игрока и врага
        if (other.gameObject.tag == ("Player"))
        {
            bool fever = other.GetComponent<PlayerScore>().fever;

            if(fever == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                other.gameObject.GetComponent<PlayerScore>().Score();
                Destroy(gameObject);
            }
        }
    }
}

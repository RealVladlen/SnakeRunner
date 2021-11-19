using UnityEngine;

public class UpDiamonds : MonoBehaviour
{

    
    private void Start()
    {
        int random = Random.Range(0, 2);

        if (random == 1)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // +1 очко если совпадает цвет игрока и врага
        if (other.gameObject.tag == ("Player"))
        {
            bool fever = other.GetComponent<PlayerScore>().fever;

            if(fever == false)
            {
                other.gameObject.GetComponent<PlayerScore>().ScoreDiamonds();
                other.gameObject.GetComponent<PlayerScore>().FeverControlls();
                Destroy(gameObject);
            }

            else
            {
                other.gameObject.GetComponent<PlayerScore>().Score();

                Destroy(gameObject);
            }
        }
    }
}

using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] private Material[] _materials;

    public Material _enemyMaterial;
    public Material _frameMaterials;

    private void Awake()
    {
        _frameMaterials = _materials[Random.Range(0, _materials.Length)];

        do
        {
            _enemyMaterial = _materials[Random.Range(0, _materials.Length)];
        } while (_enemyMaterial == _frameMaterials);

        GetComponent<MeshRenderer>().sharedMaterial = _frameMaterials;
    }

    public void ChangeColor()
    {
        _frameMaterials = _materials[Random.Range(0, _materials.Length)];

        do
        {
            _enemyMaterial = _materials[Random.Range(0, _materials.Length)];
        } while (_enemyMaterial == _frameMaterials);

        GetComponent<MeshRenderer>().sharedMaterial = _frameMaterials;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            other.gameObject.GetComponent<MeshRenderer>().sharedMaterial = _frameMaterials;
            other.gameObject.GetComponent<PlayerScore>().nameMaterials = other.gameObject.GetComponent<MeshRenderer>().sharedMaterial.name.ToString();
        }

        if (other.gameObject.tag == ("Tail"))
        {
            other.gameObject.GetComponent<MeshRenderer>().sharedMaterial = _frameMaterials;
        }
    }
}

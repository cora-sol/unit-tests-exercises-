using UnityEngine;

public class Vault : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckValue())
            Debug.Log("hello");
    }

    private bool CheckValue()
    {
        return false;
    }
}

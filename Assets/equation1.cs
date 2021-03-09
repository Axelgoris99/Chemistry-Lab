using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equation1 : MonoBehaviour
{
    /* Flask1 + Flask2 resoud l'équation et donc l'énigme 1 */

    public GameObject flask1;
    public GameObject flask2;
    public GameObject flask3;
    public GameObject contenant;

    // Start is called before the first frame update
    void Start()
    {
        GameObject table = gameObject;
        flask1 = Instantiate(flask1, table.transform);
        flask1.transform.Translate(new Vector3(0.0f, 1.297f, 0.0f));

        flask2 = Instantiate(flask2, table.transform);
        flask2.transform.Translate(new Vector3(-0.15f, 1.297f, 0.4f));

        flask3 = Instantiate(flask3, table.transform);
        flask3.transform.Translate(new Vector3(0.25f, 1.297f, 0.25f));

        contenant = Instantiate(contenant, table.transform);
        contenant.transform.Translate(new Vector3(0.25f, 1.297f, -0.5f));

    }

    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

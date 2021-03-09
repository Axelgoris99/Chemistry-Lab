using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verserLiquide : MonoBehaviour
{
    public GameObject goutte;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        goutte = Instantiate(goutte, gameObject.transform);
        goutte.transform.Translate(new Vector3(0.0f, 0.3f, 0.0f));  //A commenter
    }

    // Update is called once per frame
    void Update()
    {
        //permet de recuperer les donnees de rotation en degré
        Vector3 rot = gameObject.transform.eulerAngles;
        
        //si la rotation suivant x ou z est plus grande(plus petite) que 90(-90), alors on verse du liquide
        if ((rot.x % 360) > 90 || (rot.x % 360) < -90 || (rot.z % 360) > 90 || (rot.z % 360) < -90)
        {
            goutte = Instantiate(goutte, gameObject.transform);
            //permet de faire apparaitre la goutte à l'entrée de la verrerie
            goutte.transform.Translate(new Vector3(0.0f, 0.3f, 0.0f));
        }
    }
}

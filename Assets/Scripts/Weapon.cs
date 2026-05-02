using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs input;

    void Awake() 
    {
        input =  GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (input.shoot)
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                input.ShootInput(false);
            }
        }

    }
}

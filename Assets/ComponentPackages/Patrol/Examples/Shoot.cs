using UnityEngine;

public class Shoot : MonoBehaviour
{
    public void Spotted()
    {
        Debug.Log("Target Spotted!");
    }

    public void Attack()
    {
        Debug.Log("Shoot!");
    }
}

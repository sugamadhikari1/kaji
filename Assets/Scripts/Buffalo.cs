using UnityEngine;

public class Buffalo : MonoBehaviour
{
    public float hunger = 100f;

    public void Feed(float amount)
    {
        hunger -= amount;

        if (hunger < 0)
            hunger = 0;

        Debug.Log("Buffalo fed! Hunger: " + hunger);
    }
}
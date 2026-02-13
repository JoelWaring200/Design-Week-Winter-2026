using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    public static FactoryManager instance;

    public bool FactoryHeadLeft = false;
    public bool FactoryArmLeft = false;
    public bool FactoryLegLeft = false;
    public bool FactoryBodyRight = false;
    public bool FactoryArmRight = false;
    public bool FactoryLegRight = false;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (FactoryHeadLeft && FactoryArmLeft && FactoryLegLeft &&
            FactoryBodyRight && FactoryArmRight && FactoryLegRight)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
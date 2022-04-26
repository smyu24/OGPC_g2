using UnityEngine;

public class DeployBot : MonoBehaviour
{
    public static DeployBot instance;
    public static bool deployed;

    [Header("Components")]
    [SerializeField] private GameObject bot;
    [SerializeField] private GameObject backpack;
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody botRigidB;
    [Header("Launch Settings")]
    [SerializeField] private float launchDist = 200f;

    private void Start()
    {
        instance = this; // singleton

        Return();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Deploy();
        }
    }

    private void Deploy()
    {
        deployed = true;
        bot.transform.SetParent(null);
        botRigidB = bot.AddComponent<Rigidbody>();
        botRigidB.constraints = RigidbodyConstraints.FreezeRotation;

        bot.transform.position = cam.transform.position + cam.transform.forward;
        botRigidB.AddForce(cam.transform.forward * launchDist, ForceMode.Impulse);
        StartCoroutine(GameManage.manager.TransitionPlayer());
    }

    public void Return()
    {
        deployed = false;
        bot.transform.position = backpack.transform.position;
        bot.transform.SetParent(backpack.transform);
        Destroy(botRigidB);
    }
}

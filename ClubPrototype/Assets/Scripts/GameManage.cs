using UnityEngine;
using System.Collections;

public class GameManage : MonoBehaviour
{
    public static GameManage manager;
    
    [Header("Components")]
    [SerializeField] private Animator transition;
    [SerializeField] private GameObject human;
    [SerializeField] private GameObject bot;

    private Camera humanCam;
    private Camera botCam;
    private PlayerMovement humanMove;
    private BotMovement botMove;
    private CameraControl humanCon;
    private CameraControl botCon;

    private void Start()
    {
        manager = this; // singleton

        humanCam = human.GetComponentInChildren<Camera>();
        humanMove = human.GetComponent<PlayerMovement>();
        humanCon = human.GetComponentInChildren<CameraControl>();

        botCam = bot.GetComponentInChildren<Camera>();
        botMove = bot.GetComponentInChildren<BotMovement>();
        botCon = bot.GetComponentInChildren<CameraControl>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && DeployBot.instance.deployed)
        {
            StartCoroutine(TransitionPlayer());
        }
    }

    public IEnumerator TransitionPlayer()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SwapPlayer();
        transition.SetTrigger("End");
    }

    private void SwapPlayer()
    {
        // a good example of why you should use state machines
        humanCam.enabled = !humanCam.enabled;
        botCam.enabled = !botCam.enabled;
        humanMove.enabled = !humanMove.enabled;
        botMove.enabled = !botMove.enabled;
        humanCon.enabled = !humanCon.enabled;
        botCon.enabled = !botCon.enabled;
    }
}

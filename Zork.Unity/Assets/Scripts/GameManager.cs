using UnityEngine;
using ZorkGame;
using TMPro;

public class GameManager : MonoBehaviour
    //To Do:
    // - Create Unity Input & Output Services
    // - 44:55 (last point in vid)

{
    #region Awake
    void Awake()
    {
        //Breakpoint this in the future to ensure that Load is deserializing the fed in json file
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(GameFileName);



        Game.Load(gameJsonAsset.text, InputService, OutputService);



    }//End Awake

    #endregion Awake

    #region Start
    void Start()
    {

    }//End Start

    #endregion Start

    #region Update
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            InputService.ProcessInput();
        }
    }//End Update

    #endregion Update


    #region Variables

    //Default filename provided in the event an inspector override is not given
    [SerializeField] private string GameFileName = "Zork";

    [SerializeField] private UnityOutputService OutputService;

    [SerializeField] private UnityInputService InputService;


    #endregion Variables
}

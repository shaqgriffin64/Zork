using UnityEngine;
using ZorkGame;
using TMPro;
using Zork.Common;
using Newtonsoft.Json;

public class GameManager : MonoBehaviour
{

    #region Properties
    public Player Location { get; set; }
    public Game Moves { get; set; }
    public Game Score { get; set; }


    #endregion Properties

    #region Variables

    //Default filename provided in the event an inspector override is not given
    [SerializeField] private string GameFile = "Zork";

    [SerializeField] private UnityOutputService OutputService;

    [SerializeField] private UnityInputService InputService;

    [SerializeField] private TextMeshProUGUI LocationText;

    [SerializeField] private TextMeshProUGUI ScoreText;

    [SerializeField] private TextMeshProUGUI MovesText;

    private Game _game;

    #endregion Variables


    #region Awake
    void Awake()
    {
        //Breakpoint this in the future to ensure that Load is deserializing the fed in json file
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(GameFile);
        _game = JsonConvert.DeserializeObject<Game>(gameJsonAsset.text);

        _game.Start(gameJsonAsset.text, InputService, OutputService);


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

        //Prints the player's current location
        LocationText.text = Location.ToString();

        MovesText.text = Moves.ToString();

        ScoreText.text = Score.ToString();




    }//End Update

    #endregion Update


}

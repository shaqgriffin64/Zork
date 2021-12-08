using Zork;
using Zork.Common;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using ZorkGame;

public class GameManager : MonoBehaviour
{
    #region Variables
    //Classic green squigglies

    [Tooltip("The text that displays the current location of the player")]
    [SerializeField] private TextMeshProUGUI LocationText;

    [Tooltip("The text that dispalys the current move count of the player")]
    [SerializeField] private TextMeshProUGUI MovesText;

    [Tooltip("The text that displays the current score of the player")]
    [SerializeField] private TextMeshProUGUI ScoreText;

    [Tooltip("References the intended INPUT service for the game")]
    [SerializeField] private UnityInputService InputService;

    [Tooltip("References the intended OUTPUT service for the game")]
    [SerializeField] private UnityOutputService OutputService;

    //Game Declaration / Instance
    [HideInInspector] private Game game;
    #endregion Variables

    #region Start
    void Start()
    {
        #region Starting stuff / Initialization

        //Fix the hard code in this bit
        TextAsset gametextAsset = Resources.Load<TextAsset>("Zork");

        //Overall just deserialization of the json file that is fed in "In this case being Zork"
        game = JsonConvert.DeserializeObject<Game>(gametextAsset.text);

        //Prints the player's current location once it's been changed
        game.Player.LocationChanged += (sender, Location) => LocationText.text = Location.ToString();

        //Starts game
        game.Start(InputService, OutputService, game);

        #region Location Bits
        //Gets the player's starting location
        LocationText.text = game.StartingLocation.ToString();

        //Gets the player's previous location
        game.previousLocation = game.Player.Location;

        #endregion Location Bits

        #endregion

        #region Initial Outputs and such

        //Prints the welcome message
        game.Output.WriteLine(game.WelcomeMessage);

        game.Output.WriteLine(game.Player.Location);


        //Initial / Customary look just like in the good ol' days
        Game.Look(game);

        //game.Output.WriteLine(game.Player.Location);

        //Double check the use of this
        game.Output.WriteLine(" ");

        #region InputField Selection / Activation

        InputService.InputField.Select();

        InputService.InputField.ActivateInputField();

        #endregion InputField

        #region Moves & Score
        game.Player.MovesChanged += (sender, moves) => MovesText.text = $"Moves: {moves.ToString()}";

        game.Player.ScoreChanged += (sender, score) => ScoreText.text = $"Score: {score.ToString()}";

        #endregion Moves & Score

        #endregion Initial Outputs and such

    }

    #endregion Start

    #region Update
    private void Update()
    {
        #region Quit Check
        if (game.IsRunning == false)
        {
            //Prints Exit Message
            game.Output.WriteLine(game.ExitMessage);

            //Kills Unity App
            UnityEditor.EditorApplication.isPlaying = false;

            Application.Quit();
        }
        #endregion Quit Check
    }

    #endregion Update


}//END GameManager

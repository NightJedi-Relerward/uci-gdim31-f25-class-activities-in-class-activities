using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BatManager : MonoBehaviour
{
    [SerializeField] private float _overlapDistance;
    [SerializeField] private float _interactDistance;
    [SerializeField] private float _timeBetweenNewMessages = 0.5f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private TMP_Text _reactionUiPrefab;

    // STEP 1 -----------------------------------------------------------------
    // Add a member variable named "_bats" that's an array of BatW6 Components.
    // In the Inspector, add ALL of the bats in the Scene.
    [SerializeField] private BatW6[] _bats;
    // STEP 1 -----------------------------------------------------------------

    // STEP 3 -----------------------------------------------------------------
    // Add a member variable named "_messages" that's an array of strings.
    // In the Inspector, add at least a few different messages for the bats to
    //      say when they reach the player.
    [SerializeField] private string[] _messages;
    // STEP 3 -----------------------------------------------------------------

    [SerializeField] private float[] _newTextTimers;

    // ------------------------------------------------------------------------
    private void Start()
    {
        // STEP 6 -------------------------------------------------------------
        // Uncomment and FIX the below line to initialize _newTextTimers as a
        //      float array with the same length as _bats.
        _newTextTimers = new float[_bats.Length];
        // STEP 6 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void Update()
    {
        // STEP 7 -------------------------------------------------------------
        // Loop through all of the entries in _newTextTimers, and increase each
        //      timer's value by the amount of time that passed this frame.
        for (int i = 0; i < _newTextTimers.Length; i++)
        {
            _newTextTimers[i] += Time.deltaTime;
        }
        // STEP 7 -------------------------------------------------------------

        // STEP 2 -------------------------------------------------------------
        // Write a for loop that visits all of the entires in the _bats array,
        //      and for each entry,
        //      check the distance between the bat and the player:
        //      IF the distance is less than _interactDistance, 
        //          make the bat chase the player;
        //          otherwise, make the bat STOP chasing the player.
        for (int i = 0; i < _bats.Length; i++)
        {
            BatW6 bat = _bats[i];
            float distance = Vector3.Distance(bat.transform.position, _playerTransform.position);

            if (distance <= _interactDistance)
            {
                bat.StartChase();
                if (distance < _overlapDistance)
                {
                    CreateReactions(bat);
                    //bat.StartChase ();
                }
   
            }
            else
            {
                bat.StopChase ();
            }

            // STEP 4
            // Also inside this for loop, if the distance between the bat and the
            //      player is less than _overlapDistance, call CreateReactions()
            //      and pass the bat in as an argument.
            //if (distance < _overlapDistance)
            //{
            //    CreateReactions(bat);
            //}
        }
        // STEP 2 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    private void CreateReactions(BatW6 bat)
    {
        // STEP 5 -------------------------------------------------------------
        // Use Random.Range() to pick a RANDOM INDEX in the _messages array
        //      and call SpawnReactionUI() with the string at that index.
        int index = Random.Range(0, _messages.Length);
        SpawnReactionUI(bat, _messages[index]);
        // STEP 5 -------------------------------------------------------------
    }

    // ------------------------------------------------------------------------
    // This method creates the Text GameObject at the location & with the 
    //      message specified by the parameters.
    // It also resets the _newTextTimers entry for that bat to 0.
    private void SpawnReactionUI(BatW6 bat, string message)
    {
        // STEP 8 -------------------------------------------------------------
        // Simply uncomment the below lines by removing the /* and */ to finish.

        int index = System.Array.IndexOf(_bats, bat);

        GridLayoutGroup layout = bat.GetComponentInChildren<GridLayoutGroup>();
        if (layout != null && _newTextTimers[index] >= _timeBetweenNewMessages)
        {
            _newTextTimers[index] = 0.0f;
            TMP_Text textObj = Instantiate(_reactionUiPrefab, layout.transform);
            textObj.text = message;
        }

        // STEP 8 -------------------------------------------------------------
    }
}
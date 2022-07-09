using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

namespace DemoMVP
{
    /// <summary>@brief
    /// This demo is able to play a MIDI file only by script.\n
    /// In Unity Editor:\n
    ///    Create a GameObject or reuse an existing one\n
    ///    add this script to the GameObject\n
    ///    and run!
    /// </summary>
    public class TheSimplestMidiPlayer : MonoBehaviour
    {
        // MidiPlayerGlobal is a singleton: only one instance can be created. Making static to have only one reference.

        MidiFilePlayer midiFilePlayer;

        private void Awake()
        {
            Debug.Log("Awake: dynamically add MidiFilePlayer component");

            // MidiPlayerGlobal is a singleton: only one instance can be created. 
            if (MidiPlayerGlobal.Instance == null)
                gameObject.AddComponent<MidiPlayerGlobal>();

            // When running, this component will be added to this gameObject. Set essential parameters.
            midiFilePlayer = gameObject.AddComponent<MidiFilePlayer>();
            midiFilePlayer.MPTK_CorePlayer = true;
            midiFilePlayer.MPTK_DirectSendToPlayer = true;
        }

        public void Start()
        {
            Debug.Log("Start: select a MIDI file from the MPTK DB and play");

            // Select a MIDI from the MIDI DB (with exact name)
            midiFilePlayer.MPTK_MidiName = "Bach can1";
            // Play the MIDI file
            midiFilePlayer.MPTK_Play();

            // If you only want to load the MIDI and read informartion like duration,
            // just, comment MPTK_Play() and uncomment these two lines:
                // MidiLoad midiLoadeded = midiFilePlayer.MPTK_Load();
                // Debug.Log(midiLoadeded.MPTK_DurationMS);
            // The MIDI is read but not play.
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

namespace DemoMVP
{
    public class SimpleSpatialStream : MonoBehaviour
    {
        // To be set with the inspector
        public MidiStreamPlayer midiStreamPlayer;

        // Delay between two notes in seconds
        public float Delay;

        // Current time, reset to 0 when note is played
        public float Last;

        // Note to play
        [Range(0, 127)]
        public int Note;

        // Max position of the gameobject 
        public int MaxPositionX;

        // Preset 
        [Range(0, 127)]
        public int Preset;

        // The current note playing
        private MPTKEvent midiEvent;

        // Update is called once per frame
        void Update()
        {
            // Play a note after a delay of 'Delay' seconds
            Last += Time.deltaTime;
            if (Last > Delay)
            {
                Last = 0f;

                // Stop the note 
                if (midiEvent != null)
                    midiStreamPlayer.MPTK_StopEvent(midiEvent);

                // Build a note with infinite duration ...
                midiEvent = new MPTKEvent() { Command = MPTKCommand.NoteOn, Value = Note };
                // ... and play it
                midiStreamPlayer.MPTK_PlayEvent(midiEvent);
            }

            // Change preset if needed. We can use always the channel 0 because all MidiStreamPlayer are using
            // an independant synthesizer, like different keyboards connected with a MIDI cable.
            // So changing the preset on one will not change others MidiStreamPlayer settings.
            if (midiStreamPlayer.MPTK_ChannelPresetGetIndex(0) != Preset)
                midiStreamPlayer.MPTK_ChannelForcedPresetSet(0, Preset);

            // Move the gameobect (sphere) on X axis from -StartPos to StartPos. The sound must pan along the X axis.
            transform.position = new Vector3(
                Mathf.Sin(Time.realtimeSinceStartup) * MaxPositionX,
                transform.position.y,
                transform.position.z);
        }
    }
}
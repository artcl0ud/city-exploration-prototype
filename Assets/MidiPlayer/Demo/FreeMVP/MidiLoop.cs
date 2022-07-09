//#define MPTK_PRO
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

/// <summary>@brief
/// Load a MIDI and play in loop between two bar position. 
/// Icing on the cake: filtering notes played by channel. 
/// 
/// As usual wit a MVP demo, focus is on the essentials: no value check, no error catch, limited functions ...
/// 
/// Warning: this method explained here lacks of precision. Look at the Maestro MPTK for a better solution.
/// </summary>
public class MidiLoop : MonoBehaviour
{
    /// <summary>@brief
    /// MPTK component able to play a Midi file from your list of Midi file. This PreFab must be present in your scene.
    /// </summary>
    public MidiFilePlayer midiFilePlayer;

    /// <summary>@brief
    /// Bar to start playing. Change value in the Inspector.
    /// </summary>
    public int StartBar;

    /// <summary>@brief
    /// Bar where to loop playing. Change value in the Inspector.
    /// </summary>
    public int LoopBar;

    /// <summary>@brief
    /// Play only notes from this channel. -1 for playing all channels. Change value in the Inspector.
    /// </summary>
    public int ChannelSelected;

    // Start is called before the first frame update
    void Start()
    {
        // Find existing MidiFilePlayer in the scene hierarchy
        // ---------------------------------------------------

        midiFilePlayer = FindObjectOfType<MidiFilePlayer>();
        if (midiFilePlayer == null)
        {
            Debug.LogWarning("Can't find a MidiFilePlayer Prefab in the current Scene Hierarchy. Add it with the MPTK menu.");
            return;
        }

        // Set Listeners 
        // -------------

        // triggered when MIDI starts playing (Indeed, will be triggered at every beginning of loop)
        midiFilePlayer.OnEventStartPlayMidi.AddListener(StartPlay);

        // triggered every time a group of MIDI events are ready to be played by the MIDI synth.
        midiFilePlayer.OnEventNotesMidi.AddListener(MidiReadEvents);
    }

    /// <summary>@brief
    /// Start playing MIDI: MIDI File is loaded and Midi Synth is initialized, but so far any MIDI event has been read.
    /// This is the right time to defined some specific behaviors. 
    /// </summary>
    /// <param name="midiname"></param>
    public void StartPlay(string midiname)
    {
        // Enable or disable MIDI channel
        for (int channel = 0; channel < 16; channel++)
            midiFilePlayer.MPTK_ChannelEnableSet(channel, channel == ChannelSelected || ChannelSelected == -1 ? true : false);

        // Set start position
        midiFilePlayer.MPTK_TickCurrent = ConvertBarToTick(StartBar);

        Debug.Log($"Start at tick {midiFilePlayer.MPTK_TickCurrent}" +
            $" DTPQN:{midiFilePlayer.MPTK_MidiLoaded.MPTK_DeltaTicksPerQuarterNote}" +
            $" NBM:{midiFilePlayer.MPTK_MidiLoaded.MPTK_NumberBeatsMeasure}" +
            $" NQB:{midiFilePlayer.MPTK_MidiLoaded.MPTK_NumberQuarterBeat}");
    }

    /// <summary>@brief
    /// Triggered by the listener when midi notes are available from MidiFilePlayer. 
    /// warning: when the events are reveived it's too late to stop playing them, they are already in the pipeline of the synth.
    /// Maestro MPTK Pro is able to 
    /// </summary>
    public void MidiReadEvents(List<MPTKEvent> midiEvents)
    {
        Debug.Log($"{midiEvents.Count}");

        if (midiFilePlayer.MPTK_TickCurrent >= ConvertBarToTick(LoopBar) - 1)
        {
            Debug.Log($"Stop at tick {ConvertBarToTick(LoopBar)}");

#if MPTK_PRO
            // Uncomment if you have the Pro version for a delayed start
            // ---------------------------------------------------------
            midiFilePlayer.MPTK_Stop(); // avoid delayed stop because MPTK will continue to trigger this function and MPTK_Stop will be continously call.
            // Delayed start for 2 seconds with a volume rampup of 0.1 second.
            midiFilePlayer.MPTK_Play(0.1000f, 2000f);
#else
            // Replay the MIDI: StartPlay method (see above) will be triggered and MPTK_TickCurrent will be set from StartBar value (converted to tick).
            midiFilePlayer.MPTK_RePlay();
#endif
        }
    }

    /// <summary>@brief
    /// Convert a bar number (musical score concept) to a tick position (MIDI concept).
    /// <br><b>Tested only with 4/4 signature! 
    /// If a brave guy wants to test I will be very happy :-)</b></br>
    /// </summary>
    /// <param name="bar"></param>
    /// <returns></returns>
    long ConvertBarToTick(int bar)
    {
        return (long)(bar * midiFilePlayer.MPTK_MidiLoaded.MPTK_NumberQuarterBeat * midiFilePlayer.MPTK_MidiLoaded.MPTK_DeltaTicksPerQuarterNote);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

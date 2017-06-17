using ICities;
using UnityEngine;

using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using ColossalFramework;
using ColossalFramework.UI;
using ColossalFramework.Globalization;


namespace NoBuoysMod
{
    public class NoBuoysMod : MonoBehaviour
    {
        public const string settingsFileName = "NoBuoysMod";
        public static NoBuoysMod instance;

        public static SavedBool noBuoysEnabled = new SavedBool("noBuoysEnabled", settingsFileName, true, true);

        public void ShowBuoys( bool param )
        {

            NetInfo netPrefab = PrefabCollection<NetInfo>.FindLoaded( "Ferry Path" );

            // Check if prefab is loaded, cancel if not
            if ( netPrefab == null )
            {
                DebugUtils.Log( "NBM: The ferry path could not be found" );
                return;
            }

            // cancel if lanes array is null (networks without lanes)
            if ( netPrefab.m_lanes == null )
                return;

            foreach ( NetInfo.Lane lane in netPrefab.m_lanes )
            {
                // cancel if lane props array is null (networks without lanes)
                if ( lane?.m_laneProps?.m_props == null )
                    continue;

                foreach ( NetLaneProps.Prop laneProp in lane.m_laneProps.m_props )
                {
                    if ( laneProp == null )
                        continue;

                    if ( laneProp.m_finalProp.name == "Nautical Marker" )
                    {
                        if ( param )
                        {
                            laneProp.m_probability = 0;
                            DebugUtils.Log( "NBM: Bouys removed successfully!" );
                        }
                        else
                        {
                            laneProp.m_probability = 100;
                            DebugUtils.Log( "NBM: Bouys showed again successfully!" );
                        }
                    }
                }
            }
            
        }

        public void OnGUI()
        {
            Event e = Event.current;
            if ( OptionsKeymapping.toggleBuoys.IsPressed(e) )
            {
                noBuoysEnabled.value = !noBuoysEnabled.value;
                ShowBuoys( noBuoysEnabled.value );
            }
        }
    }
}

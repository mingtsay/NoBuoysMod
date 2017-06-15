using ICities;

using UnityEngine;


namespace NoBuoysMod
{
    public class NoBouysLoader : LoadingExtensionBase
    {
        public override void OnLevelLoaded( LoadMode mode )
        {
            NoBuoysModConfig config = Configuration<NoBuoysModConfig>.Load();

            if ( config.NoBuoysEnabled )
            {
                NetInfo netPrefab = PrefabCollection<NetInfo>.FindLoaded( "Ferry Path" );

                // Check if prefab is loaded, cancel if not
                if ( netPrefab == null )
                {
                    Debug.LogError( "NBM: The ferry path could not be found" );
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
                            laneProp.m_probability = 0;
                        }
                    }
                }
                Debug.Log( "NBM: Bouys removed successfully!" );
            }
        }
        
    }
}

using ICities;

using UnityEngine;

namespace NoBuoysMod
{
    public class NoBouysLoader : LoadingExtensionBase
    {
        public override void OnLevelLoaded( LoadMode mode )
        {
            if (NoBuoysMod.instance == null)
            {
                NoBuoysMod.instance = new GameObject( "NoBuoysMod" ).AddComponent<NoBuoysMod>();
            }

            NoBuoysMod.instance.ShowBuoys( NoBuoysMod.noBuoysEnabled );
        }

        
    }
}

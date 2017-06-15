using ICities;
using UnityEngine;
using NoBuoysMod.TranslationFramework;

namespace NoBuoysMod
{
    public class ModInfo : IUserMod
    {
        Translation translation = new Translation();

        public string Name => "Buoys Remover";

        public string Description => translation.GetTranslation( "NBM_DESCRIPTION" );


        public void OnSettingsUI( UIHelperBase helper )
        {
            NoBuoysModConfig config = Configuration<NoBuoysModConfig>.Load();

            bool isEnabled = config.NoBuoysEnabled;

            helper.AddCheckbox( "Remove buoys", isEnabled, sel => {
                config.NoBuoysEnabled = sel;
                Configuration<NoBuoysModConfig>.Save();
            } );
        }

    }
}

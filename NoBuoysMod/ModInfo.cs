using ICities;
using System;
using ColossalFramework;
using ColossalFramework.UI;
using NoBuoysMod.TranslationFramework;

namespace NoBuoysMod
{
    public class ModInfo : IUserMod
    {
        public static Translation translation = new Translation();

        public string Name => "Buoys Remover";

        public string Description => translation.GetTranslation( "NBM_DESCRIPTION" );

        public ModInfo()
        {
            try
            {
                // Creating setting file
                GameSettings.AddSettingsFile( new SettingsFile[] { new SettingsFile() { fileName = NoBuoysMod.settingsFileName } } );
            }
            catch ( Exception e )
            {
                DebugUtils.Log( "Could not load/create the setting file." );
                DebugUtils.LogException( e );
            }
        }

        public void OnSettingsUI( UIHelperBase helper )
        {
            /*
            NoBuoysModConfig config = Configuration<NoBuoysModConfig>.Load();

            bool isEnabled = config.NoBuoysEnabled;

            helper.AddCheckbox( "Remove buoys", isEnabled, sel => {
                config.NoBuoysEnabled = sel;
                Configuration<NoBuoysModConfig>.Save();
            } );
            */
            UIHelper group = helper.AddGroup( Name ) as UIHelper;
            UIPanel panel = group.self as UIPanel;

            UICheckBox checkBox = (UICheckBox)group.AddCheckbox( translation.GetTranslation( "NBM_REMOVE_BUOYS" ), NoBuoysMod.noBuoysEnabled.value, ( b ) =>
            {
                NoBuoysMod.noBuoysEnabled.value = b;
            } );
            checkBox.tooltip = translation.GetTranslation( "NBM_REMOVE_BUOYS_TOOLTIP" );

            panel.gameObject.AddComponent<OptionsKeymapping>();

            group.AddSpace( 10 );
        }

        public const string version = "1.0.0";

    }
}

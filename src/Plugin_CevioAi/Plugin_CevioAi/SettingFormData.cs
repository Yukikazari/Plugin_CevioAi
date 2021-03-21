using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FNF.XmlSerializerSetting;

namespace Plugin_CevioAi
{
    class SettingFormData : ISettingFormData
    {
        private PluginSettings _settings = null;
        public SettingPropertyGrid _settingPropertyGrid = null;

        public string Title {
            get { return "こはるりよみあげの設定"; }
        }


        public bool ExpandAll {
            get { return false; }
        }

        public SettingsBase Setting {
            get { return this._settings; }
        }

        public SettingFormData(PluginSettings settings)
        {
            this._settings = settings;
            this._settingPropertyGrid = new SettingPropertyGrid(this._settings);
        }
    }
}

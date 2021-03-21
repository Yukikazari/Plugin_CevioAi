using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.ComponentModel;
using FNF.XmlSerializerSetting;

namespace Plugin_CevioAi
{
    class SettingPropertyGrid : ISettingPropertyGrid
    {
        private PluginSettings _settings = null;

        public SettingPropertyGrid(PluginSettings setting)
        {
            _settings = setting;
        }

        public string GetName()
        {
            return "読み上げ設定";
        }

        [Category("01)基本設定")]
        [DisplayName("SaikaSay2.exeパス")]
        [Description("SeikaSay2.exeへのフルパスを設定してください。")]
        [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SeikaSay2Path
        {
            get { return this._settings.SeikaSay2Path; }
            set { this._settings.SeikaSay2Path = value; }
        }
        [Category("02)キャラ設定")]
        [DisplayName("読み上げ音声のcid")]
        [Description("読み上げに利用するcidを設定してください。")]
        public int Character
        {
            get { return this._settings.CharacterId; }
            set { this._settings.CharacterId = value; }
        }
    }
}

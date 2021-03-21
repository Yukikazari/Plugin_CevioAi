using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using FNF.BouyomiChanApp;
using FNF.Utility;
using FNF.XmlSerializerSetting;
using System.Timers;

namespace Plugin_CevioAi
{
    public class Plugin_CevioAi : IPlugin
    {
        private string _path = Base.CallAsmPath + Base.CallAsmName + ".setting";
        private PluginSettings _setting = null;
        private SettingFormData _settingFormData = null;

        private string speakText;

        public string Name {
            get { return "こはるりよみあげ"; }
        }

        public string Version {
            get { return "2021/03/13版"; }
        }

        public string Caption
        {
            get { return "AssistantSeikaを利用して読み上げを行います。"; }
        }

        public ISettingFormData SettingFormData
        {
            get { return this._settingFormData; }
        }

        public void Begin()
        {
            this._setting = new PluginSettings();
            this._setting.Load(this._path);
            this._settingFormData = new SettingFormData(_setting);


            Pub.FormMain.BC.TalkTaskStarted += BC_TalkStarted;
        }

        public void End()
        {
            _setting.Save(this._path);


            Pub.FormMain.BC.TalkTaskStarted -= BC_TalkStarted;
        }

        private void BC_TalkStarted(object sender, BouyomiChan.TalkTaskStartedEventArgs e)
        {
            try
            {
                speakText = e.ReplaceWord;
                byte[] bytes = Encoding.GetEncoding(932, new EncoderReplacementFallback(""), new DecoderReplacementFallback("")).GetBytes(speakText);
                speakText = Encoding.GetEncoding(932).GetString(bytes);

                ReadKoharuri(speakText);
            }
            catch
            {
            }
        }

        private void ReadKoharuri(string Text)
        {
            var command = $"/c {this._setting.SeikaSay2Path} -cid {this._setting.CharacterId} -async -t \"{Text}\"";
            ProcessStartInfo p = new ProcessStartInfo("cmd.exe", command);

            p.CreateNoWindow = true;
            p.UseShellExecute = false;

            Process.Start(p);
        }


        /*
                private void Hoge()
                {
                    MessageBox.Show("start");

                    timer.Elapsed += (sender, e) =>
                    {
                        if (Pub.NowPlaying && Pub.NowTaskId != lastid)
                        {
                            lastid = Pub.NowTaskId;

                            var command = seika + "\"" + Pub.FormMain.textBoxSource.Text + "\"";
                            ProcessStartInfo p = new ProcessStartInfo("cmd.exe", command);

                            p.CreateNoWindow = true;
                            p.UseShellExecute = false;

                            Process.Start(p);

                            MessageBox.Show();

                        //    MessageBox.Show(command);
                        }
                    };

                    timer.Start();
                }
        */
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerCommandsLib.Commands
{
    public class StartProcess : ICommands
    {
        public string[] _appsName = new string[2];
        private string[] _appsPath = new string[2];
        private string[] _str = new string[10];
        public string CommandInfo()
        {
            return "Запускает нужное приложение из списка";
        }
        Dictionary<string, string> _commands = new Dictionary<string, string>()
        {
            {"StartProcess","StartProcess" },
            {"startprocess","StartProcess" },
            {"SP","StartProcess" },
            {"sp","StartProcess" }
        };
        public Dictionary<string, string> CommandName()
        {
            return _commands;
        }
        private void ParseApplicationsString()
        {

            if (File.Exists("APPS.txt"))
            {
                StreamReader reader = new StreamReader("APPS.txt");
                _str = reader.ReadToEnd().Split('\t');
            }


            else
            {
                using (StreamWriter sw = File.CreateText("APPS.txt"))
                {
                    sw.Write("WordPad\twordpad\tPaint\tpaint");
                }
                StreamReader reader = new StreamReader("APPS.txt");
                _str = reader.ReadToEnd().Split('\t');
            }



            int j = 1;
            int g = 2;
            for (int i = 1; i <= _str.Length; i++)
            {
                if (i % 2 != 0)
                {
                    _appsName[i - j] = _str[i - 1];
                    j++;
                }

                else
                {
                    _appsPath[i - g] = _str[i - 1];
                    g++;
                }


            }
        }
        public string[] ReturnAppsNames()
        {
            ParseApplicationsString();
            return _appsName;
        }


        public string Execute(string[] args)
        {
            string successful = "";
            ParseApplicationsString();
            try
            {


                for (int i = 0; i < _appsName.Length; i++)
                {
                    if (_appsName[i] == args[1])
                    {
                        Process.Start(_appsPath[i]);
                        successful = "Приложение " + _appsName[i] + " запущено";
                        break;
                    }
                    else
                    {
                        successful = "Приложение " + args[1] + " не найдено, список доступных приложений: \n";
                        foreach (string name in _appsName)
                            successful += name + "\n";
                    }


                }
            }
            catch (Exception ex)
            {
                successful = ex.Message;
            }
            return successful;
        }
    }
}

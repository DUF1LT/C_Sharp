using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_5
{
    public class Logger
    {
        private List<string> logs;

        public Logger()
        {
            logs = new List<string>();
        }
        public int Length { get => logs.Count; }
        public string this[int i] { get => logs[i]; }
        
        public void AddLog(Exception ex)
        {
            logs.Add($"%$%{DateTime.Now.ToString("dd.MM.yyyy hh:mm")},  INFO: {ex.GetType()} | {ex.Message} | {ex.TargetSite} \n-----------------------------------------------------------------------------\n");
        }

        public override string ToString()
        {
            string s = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} Logs:\n";
            foreach(var el in logs)
            {
                s += el + "\n";
            }
            return s;
        }

        public void ToFile(string path)
        {

            using (StreamWriter strWriter = new StreamWriter(path))
            {
                strWriter.WriteLine(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " Logs:");
                foreach(var el in logs)
                {
                    strWriter.WriteLine(el);
                }
            }
        }
    }
}

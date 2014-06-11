using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using WCFServer.Models;

namespace WCFServer
{

    /**
     * Klasa odpowiedzialna za Timer do usuwania nieaktywnych serwisow
     * */
    class MyTimer
    {
        private int m_nStart = 0;
        Repository Repos;
        NonRepository NonRepos;
        Timer oTimer;
        bool Datab;
        
        public MyTimer(Repository Rep){
            Repos = Rep;
            Datab = true;
        }

        public MyTimer(NonRepository Rep)
        {
            NonRepos = Rep;
            Datab = false;
        }

        /**
         * Odpalenie Timera
         * */
        public void StartTimer()
        {
            m_nStart = Environment.TickCount;
            oTimer = new Timer();
            oTimer.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            oTimer.Interval = 1000;
            oTimer.Enabled = true;
        }
        
        /**
         * Metoda wywyolywana co pewien okres czasu
         * */
        private void OnTimeEvent(object oSource,ElapsedEventArgs oElapsedEventArgs)
        {
            if (Datab)
                Repos.KillZombieServices();
            else
                NonRepos.KillZombieServices();
        }

        ~MyTimer() {
            oTimer.Stop();
        }
    }
}

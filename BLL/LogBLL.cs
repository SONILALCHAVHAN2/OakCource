﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LogBLL
    {
        public static void AddLog(int Processtype,string tablName,int ProcessID)
        {
            LogDAO.AddLog(Processtype,tablName,ProcessID);
        }
    }
}

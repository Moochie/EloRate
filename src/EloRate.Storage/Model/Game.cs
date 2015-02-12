﻿using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace EloRate.Storage.Model
{
    public class Game : TableEntity
    {
        public DateTime WhenPlayed { get; set; }
        public string Winner { get; set; }
        public string Loser { get; set; }

        public override string ToString()
        {
            return string.Format("{0} beat {1}", Winner, Loser);
        }
    }
}
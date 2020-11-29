﻿using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime.Internal.Settings;

namespace MovieRank.Libs.Models
{
    [DynamoDBTable("MovieRank")]
    public class MovieDb
    {
        [DynamoDBHashKey]
        public int UserId {get; set;}
        public string  MovieName { get; set; }
        public string  Description { get; set; }
        public List<string> Actors { get; set; }
        public int Ranking { get; set; }
        public string RankedDateTime { get; set; }
    }


    public static class MovieDBExtendah
    {
        public static int GetAMagicNumberFromMe(this MovieDb mydb)
        {
            return  mydb.UserId + 10*mydb.Ranking;
        }
    }
}

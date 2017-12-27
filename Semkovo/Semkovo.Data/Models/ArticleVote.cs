﻿namespace Semkovo.Data.Models
{
    public class ArticleVote
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Count { get; set; }
    }
}
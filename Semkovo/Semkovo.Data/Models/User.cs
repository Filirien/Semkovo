using System;
using System.Collections.Generic;

namespace Semkovo.Data.Models
{    
    // This class will be deleted
    public class User
    {
        public User()
        {
        }

        public User(string username, string email, string password)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{this.FirstName} {this.LastName}";
        public string Email { get; set; }
        public Role Role { get; set; }
        public int? ProfilePictureId { get; set; }
        public Picture ProfilePicture { get; set; }
        public bool? IsDeleted { get; set; }
        //  public DateTime? RegisteredOn { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<ArticleVote> UserVotes { get; set; } = new List<ArticleVote>();

        //public override string ToString()
        //{
        //    return $"{this.Username} {this.Email} {this.FullName}";
        //}
    }
}
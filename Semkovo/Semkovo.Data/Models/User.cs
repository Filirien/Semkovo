using System;
using System.Collections.Generic;

namespace Semkovo.Data.Models
{
    
    public class User
    {
        public User() { }
        public User(string username, string email, string password)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }

        public int Id { get; set; }
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
        public ICollection<Article> Articles { get; set; } = new List<Article>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<ArticleVote> UserVotes { get; set; }

        //public override string ToString()
        //{
        //    return $"{this.Username} {this.Email} {this.FullName}";
        //}
    }
}
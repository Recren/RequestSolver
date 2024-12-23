using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestSolver.Entities
{
    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_type { get; set; }
    }
}
namespace RequestSolver.Entities
{
    public class Request
    {
        public int request_id { get; set; }
        public string title { get; set; }
        public string level_of_severity { get; set; }

        //Used to set foreign keys
        public int assigned_to_user_id { get; set; }
        public int assigned_by_user_id { get; set; }

        public DateTime date_assigned { get; set; }
        public DateTime date_due { get; set; }
        public string request_description { get; set; }
        public string request_status { get; set; }
    }
}
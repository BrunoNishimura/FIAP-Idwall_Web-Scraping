namespace Challenge.Idwall.Web.AspNet.Models
{
    public class FugitiveModel
    {
        public int FugitiveId { get; set; }

        public string? FullName { get; set; }

        //public DateTime? BirthDay { get; set; }
        public string? BirthDay { get; set; }

        public string? Gender { get; set; }

        public string? Reference { get; set; }

        public FugitiveModel()
        {

        }
        
        public FugitiveModel(int fugitiveId, string? fullName, string? birthDay, string? gender, string? reference)
        {
            FugitiveId = fugitiveId;
            FullName = fullName;
            BirthDay = birthDay;
            Gender = gender;
            Reference = reference;
        }
    }
}

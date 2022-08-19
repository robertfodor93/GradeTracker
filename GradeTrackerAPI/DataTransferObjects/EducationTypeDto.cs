namespace GradeTrackerAPI.DataTransferObjects
{
    public class EducationTypeDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public double Calculation { get; set; }
    }
}

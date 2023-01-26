using System.ComponentModel.DataAnnotations;

namespace TaskTracker.DAL.Models
{
    public class ProjectEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public int Status { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        public int Priority { get; set; }
        public virtual ICollection<TodoTaskEntity> Tasks { get; set; }
    }
}
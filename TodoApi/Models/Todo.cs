using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class Todo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Project { get; set; }
        [Required]
        public bool Completed { get; set; }
    }
}
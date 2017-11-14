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
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("title")]
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [JsonProperty("project")]
        [StringLength(200)]
        public string Project { get; set; }
        [Required]
        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
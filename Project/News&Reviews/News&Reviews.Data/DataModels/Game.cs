﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Constants.ReviewsConstants;

namespace News_Reviews.Data.DataModels
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Name { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        [ForeignKey(nameof(Publisher))]
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }

        public virtual IEnumerable<Platform> Platforms { get; set; } = new List<Platform>();

        public virtual IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static News_Reviews.Constants.ReviewsConstants;

namespace News_Reviews.Data.DataModels
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
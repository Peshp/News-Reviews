﻿using System.ComponentModel.DataAnnotations;
using static News_Reviews.Constants.ReviewsConstants;

namespace News_Reviews.Data.DataModels
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GenreMaxLength)]
        public string Name { get; set; }
        public virtual IEnumerable<City> Cities { get; set; } = new List<City>();
    }
}
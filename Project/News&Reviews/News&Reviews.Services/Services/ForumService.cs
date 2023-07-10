﻿using Microsoft.EntityFrameworkCore;
using News_Reviews.Data;
using News_Reviews.DataModels;
using News_Reviews.Models.Models.Comments;
using News_Reviews.Models.Models.Forum;
using News_Reviews.Services.Interfaces;

namespace News_Reviews.Services.Services
{
    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext context;

        public ForumService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddNewPostAsync(PostViewModel model, string userId, int themeId)
        {
            Post post = new Post()
            {
                Content = model.Content,
                ThemeId = model.ThemeId,
                ApplicationUserId = userId,
            };

            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task AddNewThemeAsync(ThemesFormModel model)
        {
            Theme theme = new Theme()
            {
                Id = model.Id,
                Title = model.Title,
            };

            await context.AddAsync(theme);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetPostsAsync(int themeId, string username)
        {
            var models = await context.Posts
                .Where(p => p.ThemeId == themeId)
                .ToArrayAsync();

            var posts = models
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Content = p.Content,
                    Username = username,
                    ThemeId = themeId,
                });

            return posts;
        }

        public async Task<IEnumerable<ThemesViewModel>> GetThemesAsync(IEnumerable<PostViewModel> posts)
        {
            var models = await context.Themes
                .ToListAsync();

            var themes = models
                .Select(x => new ThemesViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Posts = posts.ToList(),
                });

            return themes;
        }

        public async Task RemovePostAsync(int postId)
        {
            var post = await context.Posts
                .FirstOrDefaultAsync(x => x.Id == postId);

            if(post != null)
            {
                context.Remove(post);
            }

            await context.SaveChangesAsync();
        }

        public async Task RemoveThemeAsync(int themeId)
        {
            var theme = await context.Themes
                .FirstOrDefaultAsync(x => x.Id == themeId);

            context.Themes.Remove(theme);
            await context.SaveChangesAsync();
        }
    }
}
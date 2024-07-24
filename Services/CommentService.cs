﻿using BlogAPI.Dtos;
using BlogAPI.Models;
using BlogAPI.Repositories;

namespace BlogAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _repository;
        private readonly PostRepository _postRepository;

        public CommentService(CommentRepository repository, PostRepository PostRepository)
        {
            _repository = repository;
            _postRepository = PostRepository;
        }

        public async Task<CommentDto> AddCommentAsync(long postId, CreateCommentDto commentDto)
        {
            var post = await _postRepository.GetByIdAsync(postId);
            if (post is null)
                throw new KeyNotFoundException($"Post with id {postId}, not found!");

            var comment = new Comment
            {
                Text = commentDto.Text,
                PostId = post.Id,
                Post = post
            };

            await _repository.AddAsync(comment);

            return new CommentDto(comment.Id, comment.Text, comment.PostId);
        }
    }
}
namespace BlogAPI.Dtos
{
    public record PostDto(long Id, string Title, string Content, int CommentsCount);
    public record PostWithCommentsDto(long Id, string Title, string Content, IEnumerable<CommentDto> Comments);
    public record CreatePostDto(string Title, string Content);
}
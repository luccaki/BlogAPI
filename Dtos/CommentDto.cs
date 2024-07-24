namespace BlogAPI.Dtos
{
    public record CommentDto(long Id, string Text, long PostId);
    public record CreateCommentDto(string Text);
}
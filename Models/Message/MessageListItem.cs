namespace Models.Message
{
    public class MessageListItem
    {
        public int MessageId { get; set; }
        public string RecipientId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
    }
}

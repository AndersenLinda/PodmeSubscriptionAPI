using System.ComponentModel.DataAnnotations;

namespace PodmeSubscriptionAPI.Models
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string PodcastName { get; set; }
        public bool IsActive { get; set; } = false;
    }

    public class SubscriptionRequest
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string PodcastName { get; set; }
    }

}

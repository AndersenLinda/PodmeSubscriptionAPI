using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PodmeSubscriptionAPI.Models;

namespace PodmeSubscriptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionContext _context;

        public SubscriptionController(SubscriptionContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSubscriptions()
        {
            var subscriptions = await _context.Subscriptions.ToListAsync();
            return Ok(subscriptions);
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartSubscription([FromBody] SubscriptionRequest request)
        {
            var subscription = new Subscription
            {
                Id = Guid.NewGuid(),
                UserEmail = request.UserEmail,
                PodcastName = request.PodcastName,
                IsActive = true
            };

            var existingSubscription = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserEmail.Equals(request.UserEmail) && s.PodcastName.Equals(request.PodcastName));

            if (existingSubscription != null)
            {
                if (existingSubscription.IsActive)
                {
                    return BadRequest("Subscription is already active.");
                }
                else
                {
                    existingSubscription.IsActive = true;
                }
            }
            else
            {
                _context.Subscriptions.Add(subscription);
            }

            await _context.SaveChangesAsync();
            return Ok(subscription);
        }

        [HttpPost("stop")]
        public async Task<IActionResult> StopSubscription([FromBody] SubscriptionRequest request)
        {
            var subscription = await _context.Subscriptions.FirstOrDefaultAsync(s => s.UserEmail.Equals(request.UserEmail) && s.PodcastName.Equals(request.PodcastName) && s.IsActive);

            if (subscription == null)
            {
                return NotFound("Subscription not found or already inactive.");
            }
            subscription.IsActive = false;
            await _context.SaveChangesAsync();
            return Ok(subscription);
        }
    }
}

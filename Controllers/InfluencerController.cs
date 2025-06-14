using Influencer_Outreach_AI.Models;
using Influencer_Outreach_AI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Influencer_Outreach_AI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InfluencerController : ControllerBase
{
    private readonly IInfluencerService _influencerService;
    private readonly ILogger<InfluencerController> _logger;

    public InfluencerController(
        IInfluencerService influencerService,
        ILogger<InfluencerController> logger)
    {
        _influencerService = influencerService;
        _logger = logger;
    }

    [HttpGet("discover")]
    public async Task<ActionResult<IEnumerable<Influencer>>> DiscoverInfluencers()
    {
        try
        {
            var influencers = await _influencerService.DiscoverInfluencersAsync();
            return Ok(influencers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error discovering influencers");
            return StatusCode(500, "An error occurred while discovering influencers");
        }
    }

    [HttpPost("{influencerId}/outreach")]
    public async Task<ActionResult> InitiateOutreach(int influencerId)
    {
        try
        {
            var result = await _influencerService.InitiateOutreachAsync(influencerId);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error initiating outreach");
            return StatusCode(500, "An error occurred while initiating outreach");
        }
    }

    [HttpPost("messages/{messageId}/response")]
    public async Task<ActionResult> ProcessResponse(int messageId, [FromBody] string response)
    {
        try
        {
            var result = await _influencerService.ProcessResponseAsync(messageId, response);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing response");
            return StatusCode(500, "An error occurred while processing the response");
        }
    }

    [HttpGet("pending-outreach")]
    public async Task<ActionResult<IEnumerable<Influencer>>> GetInfluencersForOutreach()
    {
        try
        {
            var influencers = await _influencerService.GetInfluencersForOutreachAsync();
            return Ok(influencers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting influencers for outreach");
            return StatusCode(500, "An error occurred while getting influencers for outreach");
        }
    }

    [HttpGet("pending-messages")]
    public async Task<ActionResult<IEnumerable<OutreachMessage>>> GetPendingMessages()
    {
        try
        {
            var messages = await _influencerService.GetPendingMessagesAsync();
            return Ok(messages);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting pending messages");
            return StatusCode(500, "An error occurred while getting pending messages");
        }
    }
}
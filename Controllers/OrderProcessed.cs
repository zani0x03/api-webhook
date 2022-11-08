using api_webhooke.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_webhook.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderProcessedController : ControllerBase
{
 
    private readonly ILogger<OrderProcessedController> _logger;

    public OrderProcessedController(ILogger<OrderProcessedController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("processed")]
    public async Task<ActionResult> Processed([FromBody]Order order){
        try{
            _logger.LogInformation($"{DateTimeOffset.Now} - Info recebida: {order.OrderId.ToString()}");
            return Ok();   
        }catch(Exception ex){
            _logger.LogError(ex, "General error");
            return StatusCode(500);     
        }
    }  
}
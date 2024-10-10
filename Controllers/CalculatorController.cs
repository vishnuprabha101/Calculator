using Calculator.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService<int> _calculatorService;

        public CalculatorController(ICalculatorService<int> calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b) => Ok(_calculatorService.Add(a, b));

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b) => Ok(_calculatorService.Subtract(a, b));

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b) => Ok(_calculatorService.Multiply(a, b));

        [HttpGet("divide")]
        public IActionResult Divide(int a, int b) => Ok(_calculatorService.Divide(a, b));
    }
}

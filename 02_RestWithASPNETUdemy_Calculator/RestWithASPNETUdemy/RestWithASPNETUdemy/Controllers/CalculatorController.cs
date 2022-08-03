using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetAdicao(string firstNumber, string secondNumber)
        {
            if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);                                
                return Ok(sum.ToString());       
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]  
        public IActionResult Getsubtracaoo(string firstNumber,string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var subtracao = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(subtracao.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplication(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var divisao = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(divisao.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Getdivision(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var divisao = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(divisao.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult GetMean(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var divisao = (ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber)) / 2;
                return Ok(divisao.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        [HttpGet("SquareRoot/{firstNumber}")]
        public IActionResult GetSquareRoot(string firstNumber)
        {
            if (isNumeric(firstNumber))
            {
                var divisao = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(divisao.ToString());
            }
            return BadRequest("Invalid Imput");
        }

        private bool isNumeric(string strNUmber)
        {
            double number;

            bool isNumber = double.TryParse(
                strNUmber, System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        private decimal  ConvertToDecimal(string strNUmber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNUmber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

 
    }
}

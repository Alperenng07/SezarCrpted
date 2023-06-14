using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace SezarCrpted.Controllers
{
    





    [ApiController]
    [Route("[controller]")]
    public class CryptedController:ControllerBase
    {

        List<char> Charts = new List<char>() {
                      'A', 'B', 'C', 'D', 'E', 'F',
                        'G', 'H', 'I', 'J', 'K', 'L',
                        'M', 'N', 'O', 'P', 'Q','R',
                        'S', 'T', 'U', 'V', 'W','X',
                        'Y', 'Z'
                    };


        private IConfiguration configuration;
        public CryptedController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

       


        // [Microsoft.AspNetCore.Mvc.HttpPost]
        [HttpPost("{text}/encrypt")]
     
        public async Task<IActionResult> Encrypt(string text)
        {

            int count = configuration.GetValue<int>("itter:count");


            text = text.ToUpper();
            List<char> key = text.ToCharArray().ToList();
            List<char> code = new List<char>();
           
            // kod…..
             
           
            for (int i = 0; i < key.Count; i++)
            {
                if (Charts.Contains(key[i]))
                {
                    var pop = Charts.IndexOf(key[i]) + count;

                    code.Add(Charts[pop]);
                }
                else
                {
                    code.Add(key[i]);
                }

            };

            string encryptedText = new string(code.ToArray());



            return Ok(encryptedText);
        
        }

      //  [Microsoft.AspNetCore.Mvc.HttpPost]
      [HttpPost("{encryptedText}/decrypt")]
       
        public async Task<IActionResult> Decrypt(string encryptedText)
        {
            // kod…..

            int count = configuration.GetValue<int>("itter:count");

            encryptedText = encryptedText.ToUpper();
            List<char> key = encryptedText.ToCharArray().ToList();
            List<char> code = new List<char>();

            // kod…..


            for (int i = 0; i < key.Count; i++)
            {
                if (Charts.Contains(key[i]))
                {
                    var pop = Charts.IndexOf(key[i]) - count;

                    code.Add(Charts[pop]);
                }
                else
                {
                    code.Add(key[i]);
                }

            };
            string text = new string(code.ToArray());


            return Ok(text);
        }


    }
}

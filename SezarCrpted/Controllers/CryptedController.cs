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

      


        private IConfiguration configuration;
        public CryptedController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

       


        [HttpPost("{text}/encrypt")]
     
        public async Task<IActionResult> Encrypt(string text)
        {
         

            int count = configuration.GetValue<int>("itter:count");
            string satir = configuration.GetValue<string>("itter:harfs");

         

            
             List<char> Charts = satir.ToCharArray().ToList();



            text = text.ToUpper();
            List<char> key = text.ToCharArray().ToList();
            List<char> code = new List<char>();
           
            // kod…..
             
           
            for (int i = 0; i < key.Count; i++)
            {
                if (Charts.Contains(key[i]))
                {
                    var pop = (Charts.IndexOf(key[i]) + count) % 31;

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

      
      [HttpPost("{encryptedText}/decrypt")]
       
        public async Task<IActionResult> Decrypt(string encryptedText)
        {
            // kod…..

            string satir = configuration.GetValue<string>("itter:harfs");
            int count = configuration.GetValue<int>("itter:count");
            

            List<char> Charts = satir.ToCharArray().ToList();

            encryptedText = encryptedText.ToUpper();
            List<char> key = encryptedText.ToCharArray().ToList();
            List<char> code = new List<char>();





            // kod…..


            for (int i = 0; i < key.Count; i++)
            {
                if (Charts.Contains(key[i]))
                {
                    var pop = (Charts.IndexOf(key[i]) - count);

                    if (pop >= 0)
                    {
                        pop = (Charts.IndexOf(key[i]) - count) % 31;
                    }
                    else
                    {
                        pop = pop + 31;
                    }

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

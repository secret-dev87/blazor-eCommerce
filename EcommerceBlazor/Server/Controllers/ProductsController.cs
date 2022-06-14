using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Products> Products = new List<Products>
        {
		    //mock products
		    new Products
            {
                Id = 1,
                Title = "Breaking Bad",
                Description = "Breaking Bad is an American neo-Western crime drama television series created and produced by Vince Gilligan. Set and filmed in Albuquerque, New Mexico, it tells the story of Walter White (Bryan Cranston), an underpaid, overqualified, and dispirited high-school chemistry teacher who is struggling with a recent diagnosis of stage-three lung cancer. Walter turns to a life of crime, partnering with his former student Jesse Pinkman (Aaron Paul), by producing and distributing crystal meth to secure his family's financial future before he dies, while navigating the dangers of the criminal underworld.",
                ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/23632594.jpg",
                Price = 11.99m
            },
            new Products
            {
                Id = 2,
                Title = "Raised by Wolves",
                Description = "Raised by Wolves is an American science fiction drama television series created by Aaron Guzikowski that premiered on HBO Max on September 3, 2020. The first two episodes were directed by Ridley Scott, who also serves as an executive producer for the show. The series was renewed for a second season shortly after its debut, and the second season premiered on February 3, 2022. The first season was met with generally positive reviews from critics, while the second season has received critical acclaim. In June 2022, the series was cancelled after two seasons.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/6/64/Raised_by_Wolves_%28TV%29.jpg",
                Price = 7.99m
            },
            new Products
            {
                Id = 3,
                Title = "True Detective",
                Description = "Constructed as a nonlinear narrative, season one focuses on Louisiana State Police homicide detectives Rustin Rust Cohle (McConaughey) and Martin Marty Hart (Harrelson), who investigated the murder of prostitute Dora Lange in 1995. Seventeen years later, they must revisit the investigation, along with several other unsolved crimes. During this time, Hart's infidelity threatens his marriage to Maggie (Monaghan), and Cohle struggles to cope with his troubled past.",
                ImageUrl = "http://ic.pics.livejournal.com/iskander_zombie/17864134/1500378/1500378_original.jpg",
                Price = 10.99m
            }
        };

        [HttpGet]
        //detects a call and pass the data by using Ok method
        public async Task<IActionResult> GetProducts()
        {
            return Ok(Products);
        }
    }
}

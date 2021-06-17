using BilliardShop.Application.Hash;
using BilliardShop.Domain;
using BilliardShop.EfDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BilliardShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulateController : ControllerBase
    {
        // POST api/<PopulateController>
        [HttpPost]
        public IActionResult Post([FromServices] BilliardShopContext context, [FromServices] IHashPassword hashPassword)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Tables"
                },
                new Category
                {
                    Name = "Cues"
                },
                new Category
                {
                    Name = "Cue Cases"
                },
                new Category
                {
                    Name = "Balls"
                },
                new Category
                {
                    Name = "Chalks"
                },
                new Category
                {
                    Name = "Cloth"
                }
            };

            var brands = new List<Brand>
            {
                new Brand
                {
                    Name = "Diamond"
                },
                new Brand
                {
                    Name = "Rasson"
                },
                new Brand
                {
                    Name = "Predator"
                },
                new Brand
                {
                    Name = "Mezz"
                },
                new Brand
                {
                    Name = "Aramith"
                },
                new Brand
                {
                    Name = "Master"
                },
                new Brand
                {
                    Name = "Simonis"
                }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Pro-Am",
                    Description = "DIAMOND BILLIARD PRODUCTS INC. is excited to introduce the new DIAMOND PRO-AM for the finest billiard halls and homes around the world. The PRO-AM is our highest grade commercial model table. It is an extremely quiet ball return table that includes all the same features and playability of our DIAMOND PROFESSIONAL. The PRO-AM is superior in terms of construction, quality, and materials, but most importantly, it's playability is second to none. The main difference is the one-piece slate design featured in 7', 8', and 9' models. The PRO-AM has rapidly gained the respect of the professional, amateur, and casual players everywhere.",
                    Price = 7995,
                    Quantity = 50,
                    Category = categories.First(),
                    Brand = brands.First()
                },
                new Product
                {
                    Name = "Victory II Plus",
                    Description ="The Victory features the unique pedestal and legs that look like a “V” from each side of the table. Victory is equipped with our own designed and patented SLS(Slate Leveling System) and LLS(Leg Leveling System) as well TPR material pockets. 30mm thick premium Rasson slate, Adamath-Wood Rail, KLEMATCH P59(K55) rubber cushion and aluminum alloy beam guarantee the most consistent response and longevity of table use. The luxurious look Adamath-Wood rail is resistant to water, fire, warping, scratches and dents. Victory table meets and exceeds the specifications as set by EPBF and WPA.",
                    Price = 6950,
                    Quantity = 30,
                    Category = categories.First(),
                    Brand = brands.ElementAt(1)
                },
                new Product
                {
                    Name = "P3 REVO",
                    Description ="The world’s most advanced shaft paired with our most advanced cue construction technology. Introducing the Predator P3 REVO Limited pool cues. Featuring Leopard Wood and a Curly Maple, 30-piece construction, the Uni-Loc® Weight Cartridge system, and comes paired with your choice of REVO® carbon fiber composite shaft. Each of these cues has the beauty and technology to take your game to new heights.",
                    Price = 1349,
                    Quantity = 30,
                    Category = categories.ElementAt(1),
                    Brand = brands.ElementAt(2)
                },
                new Product
                {
                    Name = "ACE-187",
                    Description ="The ACE Series reinvented with the new WX Alpha shaft for amplified power and precision. With the combination of Miki's masterful artistry and unprecedented technology. The ACE Series delivers ultimate cue responsiveness and incredible accuracy. Get the competitive edge with an ACE in your hands.",
                    Price = 1750,
                    Quantity = 25,
                    Category = categories.ElementAt(1),
                    Brand = brands.ElementAt(3)
                },
                new Product
                {
                    Name = "Urbain Pool Cue Case",
                    Description ="Functional and fashionable – who says a case can’t be both? Inspired from the backpack designs of Europe, Urbain cue cases were designed to stand out. With a combination of premium protection and unparalleled comfort, who knew having this much storage could look so good?",
                    Price = 219,
                    Quantity = 50,
                    Category = categories.ElementAt(2),
                    Brand = brands.ElementAt(2)
                },
                new Product
                {
                    Name = "MZ-35",
                    Description ="The multifunctional MZ-35 soft case features specialized compartments and a double zipper top cover structure. This top cover design enables you to take cues out from the top and carry assembled cues in the case. The newly improved MZ-35 is a perfect blend of function and style. An ideal choice for the competitive amateurs and professional players.",
                    Price = 330,
                    Quantity = 40,
                    Category = categories.ElementAt(2),
                    Brand = brands.ElementAt(3)
                },
                new Product
                {
                    Name = "Tournament BLACK",
                    Description ="Aramith has created the new Tournament BLACK set to combine the very best of pool ball quality with an innovative, trendy and groundbreaking 'black' design (patent pending). Anticipating the need to better discern the balls on TV but also on small screen devices, we have teamed up with Matchroom Multisport to develop new colours. The Aramith Tournament set exists also in TV and regular colours.",
                    Price = 401.27m,
                    Quantity = 100,
                    Category = categories.ElementAt(3),
                    Brand = brands.ElementAt(4)
                },
                new Product
                {
                    Name = "Aramith Tournament",
                    Description ="The Aramith Tournament set features the Duramith™ technology with its hi-tech engineered molecular structure enhancing drastically the longevity of the balls while minimizing significantly table cloth wear. With a life-time that exceeds up to 8 times that of the average polyester and phenol-like resins, reaching easily up to 40 years in residential use, Aramith ball sets are the logical choice for both the trade and the player.",
                    Price = 356.26m,
                    Quantity = 200,
                    Category = categories.ElementAt(3),
                    Brand = brands.ElementAt(4)
                },
                new Product
                {
                    Name = "Arcos II",
                    Description ="Predator teamed up with legendary billiard ball maker Aramith to unleash an all-new, highly accurate and durable pool ball set. Our goal, as always, is to help you elevate your play and enjoyment of the game by providing the best billiard ball set available today. By applying the signature Predator style to Aramith’s flawless technology and production we’ve created a set of pool balls like no other.",
                    Price = 399,
                    Quantity = 55,
                    Category = categories.ElementAt(3),
                    Brand = brands.ElementAt(2)
                },
                new Product
                {
                    Name = "1080 Pure",
                    Description ="After more than five years of research and development, and three years of testing by the game’s top pros, Predator design the best billiard chalk. Comprised of a special formula utilizing Pure silica and an exacting development process, the Predator 1080 Pure billiard chalk was created with one thing in mind — winning.",
                    Price = 9.5m,
                    Quantity = 300,
                    Category = categories.ElementAt(4),
                    Brand = brands.ElementAt(2)
                },
                new Product
                {
                    Name = "Master Billiard Chalk",
                    Description ="Professional grade billiard chalk delivers a smooth and even coating that will not cake or flake.",
                    Price = 5.69m,
                    Quantity = 500,
                    Category = categories.ElementAt(4),
                    Brand = brands.ElementAt(5)
                },
                new Product
                {
                    Name = "Simonis 860",
                    Description ="Initially developed for 9-Ball. Slightly slower than the #760 Blend. Combed worsted wool, high thread count and higher wool content assure long lasting wear and reduced ball burning. Nap-free... will not pill, fluff or shed. Available in 66 inches and 78 inches widths.",
                    Price = 390,
                    Quantity = 50,
                    Category = categories.Last(),
                    Brand = brands.Last()
                },
                new Product
                {
                    Name = "Simonis 760",
                    Description ="Combed worsted wool and high thread count assure long lasting wear. Nap-free...will not pill, fluff or shed. Available in 66 inches and 78 inches widths. Higher-Speed play for Bank Pool, Straight Pool and One - Pocket.",
                    Price = 390,
                    Quantity = 400,
                    Category = categories.Last(),
                    Brand = brands.Last()
                },
                new Product
                {
                    Name = "Arcadia",
                    Description ="Introducing the Predator Arcadia Reserve and Select high-performance worsted pool table felt designed for high-performance and for the ultimate playing experience. If you are looking to refelt your pool table and want the best billiard cloth, you can choose between the competition RESERVE tournament blue cloth and the SELECT's large color choices. Both types of replacement felt are available in 7FT, 8FT and 9FT precut sizes. The ARCADIA RESERVE pool table felt is the official cloth of many WPA professional events, including the World 10-Ball Championship Men and Women, the Juniors World 9-Ball Championship and the new US Pro Billiard Series.",
                    Price = 360,
                    Quantity = 70,
                    Category = categories.Last(),
                    Brand = brands.ElementAt(2)
                }
            };


            var users = new List<User>
            {
                new User
                {
                    FirstName = "Admin",
                    LastName = "Adminovic",
                    Email = "admin@gmail.com",
                    Password = hashPassword.ComputeSha256Hash("admin123")
                },
                new User
                {
                    FirstName = "Stefan",
                    LastName = "Dimitrijevic",
                    Email = "stefan@gmail.com",
                    Password = hashPassword.ComputeSha256Hash("stefan123")
                }
            };

            var adminUseCases = Enumerable.Range(1, 31);

            var adminInsert = new List<UserUseCase>();

            foreach (var adminUseCase in adminUseCases)
            {
                var userUseCase = new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = adminUseCase
                };

                adminInsert.Add(userUseCase);
            }


            var registeredUserUseCases = new List<int> { 2, 3, 7, 8, 12, 13, 17, 18, 21, 23, 24, 25 };

            var registeredInsert = new List<UserUseCase>();

            foreach (var registeredUserUseCase in registeredUserUseCases)
            {
                var userUseCase = new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = registeredUserUseCase
                };

                registeredInsert.Add(userUseCase);
            }

            context.Categories.AddRange(categories);
            context.Brands.AddRange(brands);
            context.Products.AddRange(products);
            context.Users.AddRange(users);
            context.UserUseCases.AddRange(adminInsert);
            context.UserUseCases.AddRange(registeredInsert);

            context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}

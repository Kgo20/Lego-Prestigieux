using Lego_Prestigieux.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Policy;

namespace Lego_Prestigieux.Data
{
    public static class SeedExtension
    {
        private static readonly PasswordHasher<ApplicationUser> PASSWORD_HASHER = new();

        private static ProductModel ProductSeed(string name, string detail, float price, int reduction, int quantity, Status status, Category category, string url)
        {
            var product = new ProductModel
            {
                Name = name,
                Detail = detail,
                Price = price,
                Reduction = reduction,
                Quantity = quantity,
                Status = status,
                Category = category,
                URL = url
            };

            return product;
        }

        public static void Seed(this ModelBuilder builder)
        {
            var admins = new List<ApplicationUser>() {
                CreateUser("Francois", "Qwerty123!")
            };

            var products = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name= "The Razor Crest™",
                    Category= Category.StarWars,
                    Detail= "The LEGO® Star Wars™ design team, headed by Jens Kronvold Fredericksen" +
                    " and César Carvalhosa Soares, have created a model with authentic detail and hidden references to iconic scenes.",
                    Quantity= 1,
                    Price= 5000,
                    Reduction= 0,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/bltdbe9230cce3804cf/75331.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 2,
                    Name= "AT-AT™",
                    Category= Category.StarWars,
                    Detail= "This stunning new AT-AT™ features movable, posable legs to recreate the famous scene from Star Wars: The Empire Strikes Back.",
                    Quantity= 1,
                    Price= 1049.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blta7b7b825b6d4fc0a/75313_Prod.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id =3,
                    Name= "Millennium Falcon™",
                    Category= Category.StarWars,
                    Detail= "Welcome to the largest, most detailed LEGO® Star Wars Millennium Falcon model we’ve ever created—in fact, with 7,500 pieces " +
                    "it’s one of our biggest LEGO models, period! This amazing LEGO interpretation of Han Solo’s unforgettable Corellian freighter has all the details that" +
                    " Star Wars fans of any age could wish for, including intricate exterior detailing, upper and lower quad laser cannons, landing legs, lowering boarding ramp" +
                    " and a 4-minifigure cockpit with detachable canopy. Remove individual hull plates to reveal the highly detailed main hold, rear compartment and gunnery" +
                    " station. This amazing model also features interchangeable sensor dishes and crew, so you decide whether to " +
                    "play out classic LEGO Star Wars adventures with Han, Leia, Chewbacca and C-3PO, or enter the world of Episode VII and VIII with older Han, Rey," +
                    " Finn and BB-8!",
                    Quantity= 1,
                    Price= 1049.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt95c35d4ed5665a49/75192.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 4,
                    Name= "Imperial Star Destroyer™",
                    Category= Category.StarWars,
                    Detail= "Build and display an icon of the Galactic Empire – the Devastator. With over 4,700 LEGO® pieces," +
                    " this Ultimate Collector Series 75252 Imperial Star Destroyer model captures all the authentic details of the" +
                    " starship as it appeared in the opening scene of Star Wars: A New Hope, including swiveling guns, a tilting radar" +
                    " dish, huge engine exhausts, intricate surface detailing and of course a buildable scale version of the Rebels'" +
                    " Tantive IV starship to chase down. This galactic civil war UCS set also includes a display stand with informational" +
                    " fact plaque and 2 Imperial minifigures, making it the perfect LEGO Star Wars collectible for discerning fans.",
                    Quantity= 1,
                    Price= 849.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt934044fa508776e2/75252.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 5,
                    Name= "Republic Gunship™",
                    Category= Category.StarWars,
                    Detail= "Spark memories of the epic Battle of Geonosis in Star Wars: The Clone Wars with this Ultimate Collector Series" +
                    " build-and-display model of a Republic Gunship (75309). Authentic features of a Low Altitude Assault Transport (LAAT) " +
                    "vehicle are beautifully reproduced in LEGO® bricks, including the pilot cockpits, swing-out spherical gun turrets, 2 " +
                    "cannons on top, super-long wings, opening sides and rear hatch and interior details.",
                    Quantity= 1,
                    Price= 499.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt91c46d94ca062573/75309.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 6,
                    Name= "Mos Eisley Cantina™",
                    Category= Category.StarWars,
                    Detail= "Enjoy quality me-time and relive iconic Star Wars: A New Hope moments with the awesome" +
                    " LEGO® Star Wars™ Mos Eisley Cantina (75290) construction model for display. This 3,187-piece " +
                    "Master Builder Series set features the Cantina with lots of authentic details to delight fans, plus " +
                    "attachable buildings to recreate a Mos Eisley city scene.",
                    Quantity= 1,
                    Price= 499.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/bltb4d7806b805a25ef/75290.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 7,
                    Name= "Luke Skywalker’s Landspeeder™",
                    Category= Category.StarWars,
                    Detail= "Be transported to the desert planet of Tatooine as you build the first-ever LEGO® Star Wars™" +
                    " Ultimate Collector Series version of Luke Skywalker’s Landspeeder (75341). Use new building techniques" +
                    " and custom-made LEGO elements to recreate this iconic vehicle in intricate detail. From the cockpit windshield" +
                    " to the turbine engine missing its cover, it has everything you remember from Star Wars: A New Hope.",
                    Quantity= 1,
                    Price= 299.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt524ab29e9aac7e7e/75341.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 8,
                    Name= "R2-D2™",
                    Category= Category.StarWars,
                    Detail= "Relive classic Star Wars™ moments as you build this exceptionally detailed R2-D2 LEGO® droid figure." +
                    " The brilliant new-for-May-2021 design is packed with authentic details, including a retractable mid-leg," +
                    " rotating head, opening and extendable front hatches, a periscope that can be pulled up and turned, and Luke" +
                    " Skywalker’s lightsaber hidden in a compartment in the head.",
                    Quantity= 1,
                    Price= 299.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt38e8915698af2d5f/75308.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 9,
                    Name= "The Justifier™",
                    Category= Category.StarWars,
                    Detail= "Children aged 9 and up can recreate epic Star Wars: The Bad Batch stories with this superb LEGO®" +
                    " brick-built model of bounty hunter Cad Bane’s starship, The Justifier (75323). Fans will love the realistic" +
                    " features, such as the rear engine that folds up and down for flight and landing, a detailed cockpit, spring-loaded" +
                    " shooters on the wingtips and a ‘laser’ jail cell to imprison Omega. There are 4 LEGO Star Wars™ minifigures of Cad" +
                    " Bane, Omega, Fennec Shand and Hunter with cool weapons and accessories, plus a Todo 360 LEGO droid figure to inspire " +
                    "imaginative play.",
                    Quantity= 1,
                    Price= 209.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/bltf829afe15b940424/75323.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 10,
                    Name= "AT-AT™",
                    Category= Category.StarWars,
                    Detail= "Relive the Battle of Hoth and other classic Star Wars™ trilogy scenes with this AT-AT (75288) LEGO® building kit" +
                    " for kids! Different sections of the All Terrain Armored Transport vehicle open up for easy play, and it has spring-loaded " +
                    "shooters, plus a speeder bike inside. Fans will also love authentic details such as a winch to pull up Luke and his thermal" +
                    " detonator element.",
                    Quantity= 1,
                    Price= 209.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt7dc15f12b7f8c85f/75288.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 11,
                    Name= "Millennium Falcon™",
                    Category= Category.StarWars,
                    Detail= "Inspire youngsters and grownups with this 75257 LEGO® Star Wars™ Millennium Falcon model. This brick-built version of " +
                    "the iconic Corellian freighter features an array of details, like rotating top and bottom gun turrets, 2 spring-loaded shooters," +
                    " a lowering ramp and an opening cockpit with space for 2 minifigures. The top panels also open out to reveal a detailed interior" +
                    " in which kids will love to play out scenes from the Star Wars: The Rise of Skywalker movie featuring Star Wars characters Finn," +
                    " Chewbacca, Lando Calrissian, Boolio, C-3PO, R2-D2 and D-O. This iconic LEGO Star Wars set also makes a great collectible for any fan.",
                    Quantity= 1,
                    Price= 209.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt892f38a4fd55edeb/75257.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 12,
                    Name= "Imperial Light Cruiser™",
                    Category= Category.StarWars,
                    Detail= "Open up a galaxy of Star Wars: The Mandalorian Season 2 adventures for fans with this LEGO® brick-built model of the Imperial Light" +
                    " Cruiser (75315). It features a bridge that doubles as a handle for flying, 2 rotating turrets with spring-loaded shooters, plus 2 mini TIE" +
                    " Fighters and a launcher. A hatch gives easy access to the cabin which has a hologram table and storage for the electrobinoculars and other" +
                    " accessory elements.",
                    Quantity= 1,
                    Price= 199.99f,
                    Reduction= 3,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt847a7b38581ded36/75315.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 13,
                    Name= "AT-TE™ Walker",
                    Category= Category.StarWars,
                    Detail= "Recreate the Battle of Utapau with this fantastic LEGO® Star Wars™ AT-TE Walker (75337)." +
                    " A great gift idea for Star Wars: Revenge of the Sith fans aged 9 and up, this building toy features posable legs," +
                    " a 360-degree-rotating elevating heavy blaster cannon with 2 stud shooters, a detachable minifigure cockpit and 2 detailed" +
                    " cabins with space for up to 7 LEGO minifigures in total. Each of the cabins opens for easy play and an extendable handle makes" +
                    " it simple to lift and move the AT-TE.",
                    Quantity= 1,
                    Price= 179.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt05cf4b74ee94dd14/75337.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 14,
                    Name= "The Razor Crest™",
                    Category= Category.StarWars,
                    Detail= "Relive bounty hunter The Mandalorian™ and the Child’s battles against Scout Trooper and other enemies with The Razor Crest™ " +
                    "(75292) LEGO® Star Wars™ building toy for kids. This brick-built armored transport shuttle features a cargo hold with opening sides that" +
                    " double as access ramps and carbonite bounty elements inside, a dual LEGO minifigure cockpit, spring-loaded shooters, escape pod and more" +
                    " authentic details to inspire creative play.",
                    Quantity= 1,
                    Price= 179.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt3ad5b3c87e4b33ab/75292_alt13.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 15,
                    Name= "Yoda™",
                    Category= Category.StarWars,
                    Detail= "Add to any fan’s collection with two Yoda LEGO® Star Wars™ characters in one set! This intricately detailed 75255 display model" +
                    " of powerful Jedi Master Yoda is based on the character from Star Wars: Attack of the Clones, and includes a posable head and eyebrows," +
                    " moving fingers and toes, and Yoda's signature green Lightsaber. This characterful LEGO Star Wars figure also includes a fact plaque with" +
                    " details about Yoda and a stand to mount the included Yoda minifigure with Lightsaber, making for an ideal Star Wars collectible for any fan.",
                    Quantity= 1,
                    Price= 139.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/bltcbf69ce35da7ccc7/75255.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 16,
                    Name= "The Bad Batch™ Attack Shuttle",
                    Category= Category.StarWars,
                    Detail= "Kids will love role-playing Clone Force 99 missions with this LEGO® brick-built version of The Bad Batch Attack Shuttle (75314)" +
                    " from Star Wars: The Bad Batch. It features large wings that move up and down for landing and flight modes, 2 spring-loaded shooters and" +
                    " an opening dual LEGO minifigure cockpit and rear cabin with space for 2 LEGO minifigures and weapons storage. Pull up the central dorsal" +
                    " fin to access the interior for easy play.",
                    Quantity= 1,
                    Price= 139.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/bltfaad030bea9058dd/75314.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 17,
                    Name= "Inquisitor Transport Scythe™",
                    Category= Category.StarWars,
                    Detail= "Kids can play out Jedi-hunting missions from Star Wars: Obi-Wan Kenobi with LEGO® Star Wars™ Inquisitor Transport Scythe (75336)." +
                    " This buildable toy starship has adjustable wings for flight and landing modes, 2 spring-loaded shooters and an access ramp. The cockpit" +
                    " opens for easy viewing of the detailed interior, which has 3 minifigure seats and storage clips for lightsabers. There are also LEGO minifigures" +
                    " of Ben Kenobi, the Grand Inquisitor, Reva (Third Sister) and the Fifth Brother with lightsaber weapons for creative role play.",
                    Quantity= 1,
                    Price= 129.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt4d307a3c7a83a584/75336.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 18,
                    Name= "LEGO® Titanic",
                    Category= Category.Collections,
                    Detail= "This 1:200 scale model is designed in 3 sections, faithfully recreating the features of the Titanic. The cross section reveals" +
                    " interior details like the first-class dining room, the grand staircase, one of the boiler rooms and many cabins from the different passenger" +
                    " classes. Bring the story of the Titanic to life by recreating details such as the ship’s bridge, promenade deck, reading lounge, swimming" +
                    " pool and many more.",
                    Quantity= 1,
                    Price= 849.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/bltb94632aeb971eb91/10294.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 19,
                    Name= "Colosseum",
                    Category= Category.Collections,
                    Detail= "Nowhere on Earth compares to the majesty of the Colosseum of Rome. So, get ready to escape your everyday life as you take on the biggest" +
                    " ever LEGO® build (as at November 2020) yet. This epic 9,036-piece Colosseum model depicts each part of the famous structure in great detail." +
                    " Authentic detailing shows the northern part of the outer wall’s facade and its iconic arches. The model features 3 stories, adorned with columns " +
                    "of the Doric, Ionic and Corinthian orders while the attic is decorated with Corinthian pilasters.",
                    Quantity= 1,
                    Price= 649.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt86423e4ec25d4312/10276.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 20,
                    Name= "Hogwarts Express™ – Collectors' Edition",
                    Category= Category.Collections,
                    Detail= "Capture the magic of the Harry Potter™ stories with a buildable, 1:32 scale replica of the most iconic vehicle in the Wizarding World." +
                    " LEGO® Harry Potter Hogwarts Express™ – Collectors' Edition (76405) is a spectacular build-and-display project for adult Harry Potter enthusiasts," +
                    " which will enchant all who see it.",
                    Quantity= 1,
                    Price= 619.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt83f6220f6516afa9/76405.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 21,
                    Name= "App-Controlled Cat® D11 Bulldozer",
                    Category= Category.Nouveautés,
                    Detail= "Celebrate a hero of the construction world as you build a replica version of the biggest Cat® dozer with this LEGO® Technic™ App-Controlled Cat®" +
                    " D11 Bulldozer (42131) kit. This large set lets adults enjoy quality ‘me time’ focusing on their passion. Just like the real Cat® bulldozer, this model" +
                    " is built in modular sections. LEGO fans will love the new-for-October-2021 LEGO element – a large track that can be tightened and loosened. And the build" +
                    " is just the start! With many authentic features and functions packed into this model, there’s lots to discover.",
                    Quantity= 1,
                    Price= 619.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blte405fddce1d7d127/42131.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 22,
                    Name= "Hogwarts™ Castle",
                    Category= Category.Prestigieux,
                    Detail= "Make the magic come alive at the LEGO® Harry Potter™ 71043 Hogwarts™ Castle! This highly detailed LEGO Harry Potter collectible has over" +
                    " 6,000 pieces and offers a rewarding build experience. It comes packed with highlights from the Harry Potter series, where you will discover towers," +
                    " turrets, chambers, classrooms, creatures, the Whomping Willow™ and Hagrid´s hut, plus many more iconic features. And with 4 minifigures, 27 microfigures" +
                    " featuring students, professors and statues, plus 5 Dementors, this advanced building set makes the perfect Harry Potter gift.",
                    Quantity= 1,
                    Price= 589.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt2c408dc4fb192074/71043.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 23,
                    Name= "Loop Coaster",
                    Category= Category.MeilleursVendeurs,
                    Detail= "Take your seat. It’s time to relive the thrills of your favorite roller-coaster rides. But wait – there’s no rush. This LEGO® Loop Coaster " +
                    "(10303) is a building project for adults. So take your time crafting all the details of this functional roller-coaster model.",
                    Quantity= 1,
                    Price= 499.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt0e81d1708c094553/10303.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 24,
                    Name= "Lion Knights' Castle",
                    Category= Category.Enfants,
                    Detail= "A long time ago there was a child who loved to build with LEGO® bricks. Now that child is grown up and there’s a new quest to enjoy." +
                    " Celebrating 90 years of LEGO history, the Lion Knights’ Castle (10305) building set is a new interpretation inspired by the original LEGO Castle" +
                    " System and a build requested by fans for years.",
                    Quantity= 1,
                    Price= 499.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt0254ea3dce736ea0/10305.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 25,
                    Name= "Grand Piano",
                    Category= Category.Adultes,
                    Detail= "Do you have a passion for music? Do you like to relax by focusing on a fun," +
                    " hands-on project in your free time? If so, this incredible LEGO® Ideas Grand Piano model kit (21323) is just the creative activity for you.",
                    Quantity= 1,
                    Price= 499.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt20c84b1ff55e3256/21323.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 26,
                    Name= "Real Madrid – Santiago Bernabéu Stadium",
                    Category= Category.Collections,
                    Detail= "A build to capture the heart of any Real Madrid fan. This LEGO® Real Madrid – Santiago Bernabéu Stadium (10299) building" +
                    " kit for adults lets you build an accurate scale model version of one of the most celebrated soccer stadiums of all time. So kick" +
                    " back and take your time discovering all the details packed into this collectible model.",
                    Quantity= 1,
                    Price= 499.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blte226ac95a59d6b48/10299.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 27,
                    Name= "Daily Bugle",
                    Category= Category.MeilleursVendeurs,
                    Detail= "LEGO® Marvel Spider-Man Daily Bugle (76178) brings together a cast of 25 classic characters from the Spiderverse in" +
                    " a stunning build-and-display construction project for adults.",
                    Quantity= 0,
                    Price= 449.99f,
                    Reduction= 1,
                    Status = Status.Indisponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt149a36e6328fd9a8/76178.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 28,
                    Name= "Bugatti Chiron",
                    Category= Category.Adultes,
                    Detail= "Explore engineering excellence with the LEGO® Technic™ 42083 Bugatti Chiron advanced building set. This exclusive model" +
                    " has been developed in partnership with Bugatti Automobiles S.A.S to capture the essence of the quintessential super sports car," +
                    " and comes with gleaming aerodynamic bodywork, logoed spoked rims with low-profile tires, and detailed brake discs. The accessible" +
                    " cockpit features a Technic 8-speed gearbox with movable paddle gearshift and a steering wheel bearing the Bugatti emblem. Insert the" +
                    " top speed key and you can switch the active rear wing from handling to top speed position. The rear lid affords a glimpse of the detailed" +
                    " W16 engine with moving pistons, while beneath the hood you’ll discover a unique serial number and a compact storage compartment" +
                    " containing a stylish Bugatti overnight bag. This 1:8 scale model comes with a classic Bugatti duo-tone blue color scheme that reflects" +
                    " the brand's signature color, and a set of stickers for additional detailing. The set is delivered in luxurious box packaging and includes" +
                    " a color collector’s booklet with comprehensive building instructions.",
                    Quantity= 1,
                    Price= 349.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/bltd13aa93d1b640045/42083.jpg?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                },
                new ProductModel()
                {
                    Id= 30,
                    Name= "Sanctum Sanctorum",
                    Category= Category.MeilleursVendeurs,
                    Detail= "Capture the magic of Doctor Strange with the stunning LEGO® Marvel Sanctum Sanctorum (76218), a celebration of the Master of " +
                    "the Mystic Arts – designed with adult enthusiasts in mind.",
                    Quantity= 1,
                    Price= 309.99f,
                    Reduction= 1,
                    Status = Status.Disponible,
                    URL = "https://www.lego.com/cdn/cs/set/assets/blt5157080434f0c032/76218.png?fit=bounds&format=webply&quality=80&width=170&height=170&dpr=1"
                }
            };


            builder.SeedUsers(admins);
            builder.SeedUsersToRole(admins, new IdentityRole("Admin"));

            builder.SeedProducts(products);
        }

        private static void SeedProducts(this ModelBuilder builder, IEnumerable<ProductModel> products)
        {
            foreach (var product in products)
            {
                builder.Entity<ProductModel>().HasData(product);
            }
        }

        private static ApplicationUser CreateUser(string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
            };
            user.PasswordHash = PASSWORD_HASHER.HashPassword(user, password);

            return user;
        }

        private static void SeedUsers(this ModelBuilder builder, IEnumerable<ApplicationUser> users)
        {
            foreach (var user in users)
            {
                builder.Entity<ApplicationUser>().HasData(user);
            }
        }

        private static void SeedUsersToRole(this ModelBuilder builder, IEnumerable<ApplicationUser> users, IdentityRole role)
        {
            builder.Entity<IdentityRole>().HasData(role);

            foreach (var user in users)
            {
                builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = role.Id
                });
            }
        }
    }
}

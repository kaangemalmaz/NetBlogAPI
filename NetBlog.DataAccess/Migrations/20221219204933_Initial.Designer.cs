﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetBlog.DataAccess.Context.EntityFramework;

#nullable disable

namespace NetBlog.DataAccess.Migrations
{
    [DbContext(typeof(NetBlogContext))]
    [Migration("20221219204933_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NetBlog.Entities.Concrete.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("Date");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9096),
                            LastModifiedBy = "",
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9098),
                            LastModifiedBy = "",
                            Name = "Java"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9100),
                            LastModifiedBy = "",
                            Name = "NodeJs"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9102),
                            LastModifiedBy = "",
                            Name = "React"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9103),
                            LastModifiedBy = "",
                            Name = "PHP Symfony"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9104),
                            LastModifiedBy = "",
                            Name = "MongoDb"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9106),
                            LastModifiedBy = "",
                            Name = "MSSQL"
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9107),
                            LastModifiedBy = "",
                            Name = "PostreSQL"
                        },
                        new
                        {
                            Id = 9,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 232, DateTimeKind.Utc).AddTicks(9109),
                            LastModifiedBy = "",
                            Name = "Firebase"
                        });
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("Date");

                    b.Property<int?>("ParentCommentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("ParentCommentId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1977),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 1,
                            Text = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır."
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1980),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 2,
                            Text = "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1982),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 3,
                            Text = "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem /Ipsum."
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1983),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 4,
                            Text = "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst."
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1985),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 5,
                            Text = "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum."
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1987),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 6,
                            Text = "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a."
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1988),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 7,
                            Text = "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts."
                        },
                        new
                        {
                            Id = 8,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1990),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 8,
                            Text = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)."
                        },
                        new
                        {
                            Id = 9,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1991),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 9,
                            Text = "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت."
                        },
                        new
                        {
                            Id = 10,
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(1993),
                            Email = "admin@gmail.com",
                            IsActive = false,
                            PostId = 10,
                            Text = "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。"
                        });
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(2920),
                            Email = "aaaa@gmail.com",
                            Title = "AAAAAAAAAAAAAAAAA"
                        });
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("Date");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("Date");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5838),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "C# 9.0 ve .NET 5 Yenilikleri"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5842),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "C++ 11 ve 19 Yenilikleri"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5843),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "JavaScript ES2019 ve ES2020 Yenilikleri"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Content = "É um facto estabelecido de que um leitor é distraído pelo conteúdo legível de uma página quando analisa a sua mancha gráfica. Logo, o uso de Lorem Ipsum leva a uma distribuição mais ou menos normal de letras, ao contrário do uso de 'Conteúdo aqui,conteúdo aqui'', tornando-o texto legível. Muitas ferramentas de publicação electrónica e editores de páginas web usam actualmente o Lorem Ipsum como o modelo de texto usado por omissão, e uma pesquisa por 'lorem ipsum' irá encontrar muitos websites ainda na sua infância. Várias versões têm evoluído ao longo dos anos, por vezes por acidente, por vezes propositadamente (como no caso do humor).",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5845),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "Typescript 4.1"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan \"de Finibus Bonorum et Malorum\" (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan \"Lorem ipsum dolor sit amet\" 1.10.32 sayılı bölümdeki bir satırdan gelmektedir. 1500'lerden beri kullanılmakta olan standard Lorem Ipsum metinleri ilgilenenler için yeniden üretilmiştir. Çiçero tarafından yazılan 1.10.32 ve 1.10.33 bölümleri de 1914 H. Rackham çevirisinden alınan İngilizce sürümleri eşliğinde özgün biçiminden yeniden üretilmiştir.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5847),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "Java ve Android'in Geleceği | 2021"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 6,
                            Content = "Le Lorem Ipsum est simplement du faux texte employé dans la composition et la mise en page avant impression. Le Lorem Ipsum est le faux texte standard de l'imprimerie depuis les années 1500, quand un imprimeur anonyme assembla ensemble des morceaux de texte pour réaliser un livre spécimen de polices de texte. Il n'a pas fait que survivre cinq siècles, mais s'est aussi adapté à la bureautique informatique, sans que son contenu n'en soit modifié. Il a été popularisé dans les années 1960 grâce à la vente de feuilles Letraset contenant des passages du Lorem Ipsum, et, plus récemment, par son inclusion dans des applications de mise en page de texte, comme Aldus PageMaker.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5849),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "Python ile Veri Madenciliği | 2021"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 7,
                            Content = "Contrairement à une opinion répandue, le Lorem Ipsum n'est pas simplement du texte aléatoire. Il trouve ses racines dans une oeuvre de la littérature latine classique datant de 45 av. J.-C., le rendant vieux de 2000 ans. Un professeur du Hampden-Sydney College, en Virginie, s'est intéressé à un des mots latins les plus obscurs, consectetur, extrait d'un passage du Lorem Ipsum, et en étudiant tous les usages de ce mot dans la littérature classique, découvrit la source incontestable du Lorem Ipsum. Il provient en fait des sections 1.10.32 et 1.10.33 du 0De Finibus Bonorum et Malorum' (Des Suprêmes Biens et des Suprêmes Maux) de Cicéron. Cet ouvrage, très populaire pendant la Renaissance, est un traité sur la théorie de l'éthique. Les premières lignes du Lorem Ipsum, 'Lorem ipsum dolor sit amet...'', proviennent de la section 1.10.32",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5850),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "Php Laravel Başlangıç Rehberi | API"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 8,
                            Content = "Plusieurs variations de Lorem Ipsum peuvent être trouvées ici ou là, mais la majeure partie d'entre elles a été altérée par l'addition d'humour ou de mots aléatoires qui ne ressemblent pas une seconde à du texte standard. Si vous voulez utiliser un passage du Lorem Ipsum, vous devez être sûr qu'il n'y a rien d'embarrassant caché dans le texte. Tous les générateurs de Lorem Ipsum sur Internet tendent à reproduire le même extrait sans fin, ce qui fait de lipsum.com le seul vrai générateur de Lorem Ipsum. Iil utilise un dictionnaire de plus de 200 mots latins, en combinaison de plusieurs structures de phrases, pour générer un Lorem Ipsum irréprochable. Le Lorem Ipsum ainsi obtenu ne contient aucune répétition, ni ne contient des mots farfelus, ou des touches d'humour.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5852),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "Kotlin ile Mobil Programlama"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 9,
                            Content = "Al contrario di quanto si pensi, Lorem Ipsum non è semplicemente una sequenza casuale di caratteri. Risale ad un classico della letteratura latina del 45 AC, cosa che lo rende vecchio di 2000 anni. Richard McClintock, professore di latino al Hampden-Sydney College in Virginia, ha ricercato una delle più oscure parole latine, consectetur, da un passaggio del Lorem Ipsum e ha scoperto tra i vari testi in cui è citata, la fonte da cui è tratto il testo, le sezioni 1.10.32 and 1.10.33 del 'de Finibus Bonorum et Malorum' di Cicerone. Questo testo è un trattato su teorie di etica, molto popolare nel Rinascimento. La prima riga del Lorem Ipsum, 'Lorem ipsum dolor sit amet..'', è tratta da un passaggio della sezione 1.10.32.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5854),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "Swift ile IOS Programlama"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 1,
                            Content = "Esistono innumerevoli variazioni dei passaggi del Lorem Ipsum, ma la maggior parte hanno subito delle variazioni del tempo, a causa dell’inserimento di passaggi ironici, o di sequenze casuali di caratteri palesemente poco verosimili. Se si decide di utilizzare un passaggio del Lorem Ipsum, è bene essere certi che non contenga nulla di imbarazzante. In genere, i generatori di testo segnaposto disponibili su internet tendono a ripetere paragrafi predefiniti, rendendo questo il primo vero generatore automatico su intenet. Infatti utilizza un dizionario di oltre 200 vocaboli latini, combinati con un insieme di modelli di strutture di periodi, per generare passaggi di testo verosimili. Il testo così generato è sempre privo di ripetizioni, parole imbarazzanti o fuori luogo ecc.",
                            CreatedBy = "InitialCreate",
                            CreatedDate = new DateTime(2022, 12, 19, 20, 49, 33, 233, DateTimeKind.Utc).AddTicks(5856),
                            Thumbnail = "articleImages/defaultArticle.png",
                            Title = "Ruby on Rails ile AirBnb Klon Kodlayalım"
                        });
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Comment", b =>
                {
                    b.HasOne("NetBlog.Entities.Concrete.Comment", "ParentComment")
                        .WithMany("SubComment")
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("NetBlog.Entities.Concrete.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentComment");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Post", b =>
                {
                    b.HasOne("NetBlog.Entities.Concrete.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Comment", b =>
                {
                    b.Navigation("SubComment");
                });

            modelBuilder.Entity("NetBlog.Entities.Concrete.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}

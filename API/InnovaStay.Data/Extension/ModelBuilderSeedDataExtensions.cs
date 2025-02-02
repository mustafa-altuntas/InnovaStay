using InnovaStay.Data.Concrete;
using InnovaStay.Entity.Concrete;

namespace InnovaStay.Data.Extension
{
    internal static class ModelBuilderSeedDataExtensions
    {

        public static void InitialData(AppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (!dbContext.Rooms.Any())
            {
                SeedRoom(dbContext);
                SeedService(dbContext);
                SeedStaff(dbContext);
                SeedSubscribe(dbContext);
                SeedTestimonial(dbContext);
                dbContext.SaveChanges();
            }
        }

        static void SeedStaff(AppDbContext dbContext)
        {
            dbContext.Staffs.AddRange(new[] {
                new Staff { Name = "Ahmet Yılmaz", Title = "Genel Müdür", SocialMedia1 = "facebook.com/ahmet", SocialMedia2 = "twitter.com/ahmet", SocialMedia3 = "linkedin.com/ahmet" },
                new Staff { Name = "Mehmet Demir", Title = "Resepsiyonist", SocialMedia1 = "facebook.com/mehmet", SocialMedia2 = "twitter.com/mehmet", SocialMedia3 = "linkedin.com/mehmet" },
                new Staff { Name = "Ayşe Çelik", Title = "Kat Görevlisi", SocialMedia1 = "facebook.com/ayse", SocialMedia2 = "twitter.com/ayse", SocialMedia3 = "linkedin.com/ayse" },
                new Staff { Name = "Fatma Kaya", Title = "Aşçı", SocialMedia1 = "facebook.com/fatma", SocialMedia2 = "twitter.com/fatma", SocialMedia3 = "linkedin.com/fatma" },
                new Staff { Name = "Ali Şahin", Title = "Teknisyen", SocialMedia1 = "facebook.com/ali", SocialMedia2 = "twitter.com/ali", SocialMedia3 = "linkedin.com/ali" },
                new Staff { Name = "Emre Ak", Title = "Garson", SocialMedia1 = "facebook.com/emre", SocialMedia2 = "twitter.com/emre", SocialMedia3 = "linkedin.com/emre" },
                new Staff { Name = "Hülya Güneş", Title = "Misafir İlişkileri Sorumlusu", SocialMedia1 = "facebook.com/hulya", SocialMedia2 = "twitter.com/hulya", SocialMedia3 = "linkedin.com/hulya" },
                new Staff { Name = "Zeynep Bulut", Title = "Spa Yöneticisi", SocialMedia1 = "facebook.com/zeynep", SocialMedia2 = "twitter.com/zeynep", SocialMedia3 = "linkedin.com/zeynep" },
                new Staff { Name = "Halil İbrahim", Title = "Güvenlik Görevlisi", SocialMedia1 = "facebook.com/halil", SocialMedia2 = "twitter.com/halil", SocialMedia3 = "linkedin.com/halil" },
                new Staff {  Name = "Sevgi Deniz", Title = "Animasyon Sorumlusu", SocialMedia1 = "facebook.com/sevgi", SocialMedia2 = "twitter.com/sevgi", SocialMedia3 = "linkedin.com/sevgi" },
                new Staff {  Name = "Veli Kara", Title = "Şoför", SocialMedia1 = "facebook.com/veli", SocialMedia2 = "twitter.com/veli", SocialMedia3 = "linkedin.com/veli" },
                new Staff {  Name = "Burcu Öz", Title = "Satın Alma Müdürü", SocialMedia1 = "facebook.com/burcu", SocialMedia2 = "twitter.com/burcu", SocialMedia3 = "linkedin.com/burcu" },
                new Staff {  Name = "Hakan Tunç", Title = "Muhasebe Müdürü", SocialMedia1 = "facebook.com/hakan", SocialMedia2 = "twitter.com/hakan", SocialMedia3 = "linkedin.com/hakan" },
                new Staff {  Name = "Nazan Koç", Title = "Müşteri Hizmetleri", SocialMedia1 = "facebook.com/nazan", SocialMedia2 = "twitter.com/nazan", SocialMedia3 = "linkedin.com/nazan" },
                new Staff {  Name = "Can Yıldız", Title = "Bakım Onarım Uzmanı", SocialMedia1 = "facebook.com/can", SocialMedia2 = "twitter.com/can", SocialMedia3 = "linkedin.com/can" },
                new Staff {  Name = "Derya Çetin", Title = "Barmen", SocialMedia1 = "facebook.com/derya", SocialMedia2 = "twitter.com/derya", SocialMedia3 = "linkedin.com/derya" },
                new Staff {  Name = "Kerem Uysal", Title = "Vale", SocialMedia1 = "facebook.com/kerem", SocialMedia2 = "twitter.com/kerem", SocialMedia3 = "linkedin.com/kerem" },
                new Staff {  Name = "Sibel Er", Title = "Kat Şefi", SocialMedia1 = "facebook.com/sibel", SocialMedia2 = "twitter.com/sibel", SocialMedia3 = "linkedin.com/sibel" },
                new Staff {  Name = "Tolga Gök", Title = "Elektrikçi", SocialMedia1 = "facebook.com/tolga", SocialMedia2 = "twitter.com/tolga", SocialMedia3 = "linkedin.com/tolga" },
                new Staff {  Name = "Ece Arslan", Title = "Pazarlama Müdürü", SocialMedia1 = "facebook.com/ece", SocialMedia2 = "twitter.com/ece", SocialMedia3 = "linkedin.com/ece" },
                new Staff {  Name = "Furkan Çelik", Title = "Oda Servisi", SocialMedia1 = "facebook.com/furkan", SocialMedia2 = "twitter.com/furkan", SocialMedia3 = "linkedin.com/furkan" },
                new Staff {  Name = "Buse Şen", Title = "Fitness Eğitmeni", SocialMedia1 = "facebook.com/buse", SocialMedia2 = "twitter.com/buse", SocialMedia3 = "linkedin.com/buse" },
                new Staff {  Name = "Kadir Öztürk", Title = "Bahçıvan", SocialMedia1 = "facebook.com/kadir", SocialMedia2 = "twitter.com/kadir", SocialMedia3 = "linkedin.com/kadir" },
                new Staff {  Name = "Selin Aydın", Title = "Kuaför", SocialMedia1 = "facebook.com/selin", SocialMedia2 = "twitter.com/selin", SocialMedia3 = "linkedin.com/selin" },
                new Staff {  Name = "Serkan Yavuz", Title = "Depo Sorumlusu", SocialMedia1 = "facebook.com/serkan", SocialMedia2 = "twitter.com/serkan", SocialMedia3 = "linkedin.com/serkan" },
                new Staff {  Name = "Hande Çakır", Title = "Eğitim Uzmanı", SocialMedia1 = "facebook.com/hande", SocialMedia2 = "twitter.com/hande", SocialMedia3 = "linkedin.com/hande" }
            }

                );
        }

        static void SeedRoom(AppDbContext dbContext)
        {
            dbContext.Rooms.AddRange(new[] {

                new Room {RoomNumber = "101", RoomCoverImage = "room101.jpg", Price = 500, Title = "Standart Oda", BedCount = 1, BathCount = 1, Wifi = "Var", Description = "Konforlu ve ekonomik bir oda." },
                new Room {RoomNumber = "102", RoomCoverImage = "room102.jpg", Price = 600, Title = "Standart Oda", BedCount = 1, BathCount = 1, Wifi = "Var", Description = "Geniş yataklı standart oda." },
                new Room {RoomNumber = "103", RoomCoverImage = "room103.jpg", Price = 700, Title = "Deluxe Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Manzaralı deluxe oda." },
                new Room {RoomNumber = "104", RoomCoverImage = "room104.jpg", Price = 800, Title = "Aile Odası", BedCount = 3, BathCount = 1, Wifi = "Var", Description = "Aileler için ideal oda." },
                new Room {RoomNumber = "105", RoomCoverImage = "room105.jpg", Price = 900, Title = "Suit Oda", BedCount = 2, BathCount = 2, Wifi = "Var", Description = "Lüks suit oda." },
                new Room {RoomNumber = "106", RoomCoverImage = "room106.jpg", Price = 750, Title = "Deluxe Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Şehir manzaralı deluxe oda." },
                new Room {RoomNumber = "107", RoomCoverImage = "room107.jpg", Price = 550, Title = "Standart Oda", BedCount = 1, BathCount = 1, Wifi = "Var", Description = "Ekonomik standart oda." },
                new Room {RoomNumber = "108", RoomCoverImage = "room108.jpg", Price = 650, Title = "Standart Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "İki kişilik standart oda." },
                new Room {RoomNumber = "109", RoomCoverImage = "room109.jpg", Price = 1000, Title = "King Suit", BedCount = 3, BathCount = 2, Wifi = "Var", Description = "Lüks King Suit oda." },
                new Room { RoomNumber = "110", RoomCoverImage = "room110.jpg", Price = 850, Title = "Aile Odası", BedCount = 3, BathCount = 1, Wifi = "Var", Description = "Çocuklar için özel alanlı oda." },
                new Room { RoomNumber = "111", RoomCoverImage = "room111.jpg", Price = 720, Title = "Deluxe Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Geniş banyolu deluxe oda." },
                new Room { RoomNumber = "112", RoomCoverImage = "room112.jpg", Price = 580, Title = "Standart Oda", BedCount = 1, BathCount = 1, Wifi = "Var", Description = "Tek kişilik ekonomik oda." },
                new Room { RoomNumber = "113", RoomCoverImage = "room113.jpg", Price = 690, Title = "Standart Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Modern standart oda." },
                new Room { RoomNumber = "114", RoomCoverImage = "room114.jpg", Price = 870, Title = "Suit Oda", BedCount = 2, BathCount = 2, Wifi = "Var", Description = "Lüks suit, geniş alanlı." },
                new Room { RoomNumber = "115", RoomCoverImage = "room115.jpg", Price = 900, Title = "King Suit", BedCount = 3, BathCount = 2, Wifi = "Var", Description = "Havuz manzaralı King Suit." },
                new Room { RoomNumber = "116", RoomCoverImage = "room116.jpg", Price = 600, Title = "Deluxe Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Ekstra konforlu deluxe oda." },
                new Room { RoomNumber = "117", RoomCoverImage = "room117.jpg", Price = 530, Title = "Standart Oda", BedCount = 1, BathCount = 1, Wifi = "Var", Description = "Uygun fiyatlı standart oda." },
                new Room { RoomNumber = "118", RoomCoverImage = "room118.jpg", Price = 720, Title = "Aile Odası", BedCount = 3, BathCount = 1, Wifi = "Var", Description = "Aile için tasarlanmış oda." },
                new Room { RoomNumber = "119", RoomCoverImage = "room119.jpg", Price = 780, Title = "Suit Oda", BedCount = 2, BathCount = 2, Wifi = "Var", Description = "Deniz manzaralı suit oda." },
                new Room { RoomNumber = "120", RoomCoverImage = "room120.jpg", Price = 850, Title = "King Suit", BedCount = 3, BathCount = 2, Wifi = "Var", Description = "Büyük aileler için ideal." },
                new Room { RoomNumber = "121", RoomCoverImage = "room121.jpg", Price = 750, Title = "Deluxe Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Şık ve modern deluxe oda." },
                new Room { RoomNumber = "122", RoomCoverImage = "room122.jpg", Price = 540, Title = "Standart Oda", BedCount = 1, BathCount = 1, Wifi = "Var", Description = "Konforlu ve sessiz oda." },
                new Room { RoomNumber = "123", RoomCoverImage = "room123.jpg", Price = 680, Title = "Standart Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Manzaralı standart oda." },
                new Room { RoomNumber = "124", RoomCoverImage = "room124.jpg", Price = 960, Title = "Suit Oda", BedCount = 2, BathCount = 2, Wifi = "Var", Description = "Ekstra geniş suit oda." },
                new Room { RoomNumber = "125", RoomCoverImage = "room125.jpg", Price = 870, Title = "King Suit", BedCount = 3, BathCount = 2, Wifi = "Var", Description = "Lüks King Suit, özel balkonlu." },
                new Room { RoomNumber = "126", RoomCoverImage = "room126.jpg", Price = 620, Title = "Deluxe Oda", BedCount = 2, BathCount = 1, Wifi = "Var", Description = "Minimal tasarımlı deluxe oda." },
                new Room { RoomNumber = "127", RoomCoverImage = "room127.jpg", Price = 510, Title = "Standart Oda", BedCount = 1, BathCount = 1, Wifi = "Var", Description = "Ekonomik ve sade oda." }
            }
                );
        }

        static void SeedService(AppDbContext dbContext)
        {
            dbContext.Services.AddRange(new[] {

                new Service { ServiceIcon = "icon1.png", Title = "Ücretsiz Wi-Fi", Description = "Tüm alanlarda kesintisiz ve hızlı internet." },
                new Service { ServiceIcon = "icon2.png", Title = "Oda Servisi", Description = "24 saat oda servisi hizmeti." },
                new Service { ServiceIcon = "icon3.png", Title = "Havuz", Description = "Açık ve kapalı yüzme havuzu olanakları." },
                new Service { ServiceIcon = "icon4.png", Title = "Spa ve Masaj", Description = "Rahatlatıcı spa ve masaj hizmetleri." },
                new Service { ServiceIcon = "icon5.png", Title = "Restoran", Description = "Dünya mutfağından lezzetler sunan restoran." },
                new Service { ServiceIcon = "icon6.png", Title = "Fitness Merkezi", Description = "Modern ekipmanlarla donatılmış spor salonu." },
                new Service { ServiceIcon = "icon7.png", Title = "Havalimanı Transferi", Description = "Ücretsiz havalimanı transfer hizmeti." },
                new Service { ServiceIcon = "icon8.png", Title = "Ütü ve Çamaşırhane", Description = "Hızlı ve güvenilir çamaşır hizmeti." },
                new Service { ServiceIcon = "icon9.png", Title = "Otopark", Description = "Ücretsiz ve güvenli otopark imkanı." },
                new Service {  ServiceIcon = "icon10.png", Title = "Toplantı Salonu", Description = "Modern donanımlı toplantı ve konferans salonu." },
                new Service {  ServiceIcon = "icon11.png", Title = "Çocuk Kulübü", Description = "Çocuklar için güvenli oyun alanı." },
                new Service {  ServiceIcon = "icon12.png", Title = "Kütüphane", Description = "Zengin içerikli kütüphane." },
                new Service {  ServiceIcon = "icon13.png", Title = "Vale Hizmeti", Description = "Profesyonel vale hizmeti." },
                new Service {  ServiceIcon = "icon14.png", Title = "Bisiklet Kiralama", Description = "Şehir turu için bisiklet kiralama hizmeti." },
                new Service {  ServiceIcon = "icon15.png", Title = "Kahvaltı", Description = "Açık büfe kahvaltı hizmeti." },
                new Service {  ServiceIcon = "icon16.png", Title = "Bar", Description = "Zengin içecek menüsüyle bar hizmeti." },
                new Service {  ServiceIcon = "icon17.png", Title = "Dalış Eğitimi", Description = "Profesyonel dalış eğitimi hizmeti." },
                new Service {  ServiceIcon = "icon18.png", Title = "Güzellik Salonu", Description = "Bakım ve güzellik hizmetleri." },
                new Service {  ServiceIcon = "icon19.png", Title = "Gezi Rehberi", Description = "Şehir turları için rehberlik hizmeti." },
                new Service {  ServiceIcon = "icon20.png", Title = "Şoförlü Araç", Description = "Özel şoförlü araç hizmeti." },
                new Service {  ServiceIcon = "icon21.png", Title = "Bebek Bakımı", Description = "Eğitimli personel ile bebek bakımı hizmeti." },
                new Service {  ServiceIcon = "icon22.png", Title = "Parti Organizasyonu", Description = "Kişiye özel parti organizasyonu hizmeti." },
                new Service {  ServiceIcon = "icon23.png", Title = "Oyun Salonu", Description = "Bilardo, masa tenisi ve oyun makineleri." },
                new Service {  ServiceIcon = "icon24.png", Title = "Açık Büfe Öğle Yemeği", Description = "Zengin içerikli açık büfe öğle yemeği." },
                new Service {  ServiceIcon = "icon25.png", Title = "Canlı Müzik", Description = "Her akşam canlı müzik etkinlikleri." },
                new Service {  ServiceIcon = "icon26.png", Title = "Yoga Dersleri", Description = "Profesyonel yoga eğitmenleri eşliğinde dersler." },
                new Service {  ServiceIcon = "icon27.png", Title = "Fotoğraf Hizmeti", Description = "Profesyonel fotoğraf çekimi hizmeti." },
                new Service {  ServiceIcon = "icon28.png", Title = "Evlilik Teklifi Organizasyonu", Description = "Romantik evlilik teklifi düzenlemeleri." },
                new Service {  ServiceIcon = "icon29.png", Title = "Deniz Turu", Description = "Tekneyle günlük deniz turları." },
                new Service {  ServiceIcon = "icon30.png", Title = "Doğa Yürüyüşleri", Description = "Rehber eşliğinde doğa yürüyüşü etkinlikleri." },
                new Service {  ServiceIcon = "icon31.png", Title = "Kuaför", Description = "Kadın ve erkek kuaför hizmeti." },
                new Service {  ServiceIcon = "icon32.png", Title = "Mini Bar", Description = "Odada mini bar hizmeti." },
                new Service {  ServiceIcon = "icon33.png", Title = "Sinema", Description = "Kapalı alanda film gösterimi." },
                new Service {  ServiceIcon = "icon34.png", Title = "Tatil Paketi", Description = "Kapsamlı tatil paketi fırsatları." },
                new Service {  ServiceIcon = "icon35.png", Title = "Kano", Description = "Gölde kano kiralama hizmeti." },
                new Service {  ServiceIcon = "icon36.png", Title = "Balık Tutma", Description = "Rehber eşliğinde balık tutma etkinlikleri." },
                new Service {  ServiceIcon = "icon37.png", Title = "Ekipman Kiralama", Description = "Doğa sporları için ekipman kiralama." },
                new Service {  ServiceIcon = "icon38.png", Title = "Tekerlekli Sandalye", Description = "Engelli misafirler için tekerlekli sandalye temini." },
                new Service {  ServiceIcon = "icon39.png", Title = "Açık Hava Sineması", Description = "Yıldızların altında film keyfi." },
                new Service {  ServiceIcon = "icon40.png", Title = "Özel Plaj", Description = "Sadece misafirlere özel plaj alanı." },
                new Service {  ServiceIcon = "icon41.png", Title = "Cankurtaran Hizmeti", Description = "Profesyonel cankurtaran hizmeti." },
                new Service {  ServiceIcon = "icon42.png", Title = "Şarap Tadımı", Description = "Şarap severler için özel tadım etkinlikleri." },
                new Service {  ServiceIcon = "icon43.png", Title = "Sanat Atölyesi", Description = "Resim ve heykel dersleri." },
                new Service {  ServiceIcon = "icon44.png", Title = "Hediye Dükkanı", Description = "Otelde hediyelik eşya alışverişi." }
            }
                );
        }

        static void SeedSubscribe(AppDbContext dbContext)
        {
            dbContext.Subscribes.AddRange(new[] {

                new Subscribe { Mail = "ali.veli@example.com" },
                new Subscribe { Mail = "ayse.fatma@example.com" },
                new Subscribe { Mail = "mehmet.kaya@example.com" },
                new Subscribe { Mail = "elif.deniz@example.com" },
                new Subscribe { Mail = "emre.bey@example.com" },
                new Subscribe { Mail = "seda.gul@example.com" },
                new Subscribe { Mail = "burak.kaan@example.com" },
                new Subscribe { Mail = "zeynep.nur@example.com" },
                new Subscribe { Mail = "ahmet.turk@example.com" },
                new Subscribe {  Mail = "merve.cicek@example.com" },
                new Subscribe {  Mail = "kaan.deniz@example.com" },
                new Subscribe {  Mail = "cemre.gunes@example.com" },
                new Subscribe {  Mail = "yasin.toprak@example.com" },
                new Subscribe {  Mail = "sema.hayat@example.com" },
                new Subscribe {  Mail = "berk.umut@example.com" },
                new Subscribe {  Mail = "didem.gozde@example.com" },
                new Subscribe {  Mail = "gokhan.ay@example.com" },
                new Subscribe {  Mail = "neslihan.kurt@example.com" },
                new Subscribe {  Mail = "orhan.tan@example.com" },
                new Subscribe {  Mail = "cansu.aksoy@example.com" }
                }
            );
        }

        static void SeedTestimonial(AppDbContext dbContext)
        {
            dbContext.Testimonials.AddRange(new[] {
                 new Testimonial { Name = "Ali Veli", Title = "Harika Tatil", Description = "Her şey mükemmeldi, tekrar geleceğim.", Image = "testimonial1.jpg" },
                 new Testimonial { Name = "Ayşe Yılmaz", Title = "Mükemmel Hizmet", Description = "Personel çok ilgiliydi, teşekkürler.", Image = "testimonial2.jpg" },
                 new Testimonial { Name = "Mehmet Kaya", Title = "Eşsiz Deneyim", Description = "Otel çok temiz ve huzurluydu.", Image = "testimonial3.jpg" },
                 new Testimonial { Name = "Elif Demir", Title = "Unutulmaz Tatil", Description = "Manzarası harikaydı, memnun kaldım.", Image = "testimonial4.jpg" },
                 new Testimonial { Name = "Emre Çelik", Title = "Hizmet Kalitesi", Description = "Yemekler çok lezzetliydi, tekrar geleceğim.", Image = "testimonial5.jpg" },
                 new Testimonial { Name = "Seda Gül", Title = "Aile Tatili", Description = "Çocuklar için çok uygun bir oteldi.", Image = "testimonial6.jpg" },
                 new Testimonial { Name = "Burak Kaan", Title = "Romantik Kaçamak", Description = "Eşimle harika bir tatil geçirdik.", Image = "testimonial7.jpg" },
                 new Testimonial { Name = "Zeynep Nur", Title = "Konforlu Konaklama", Description = "Odalar çok rahat ve ferahtı.", Image = "testimonial8.jpg" },
                 new Testimonial { Name = "Ahmet Türk", Title = "İlgili Personel", Description = "Her şey düşünülmüş, çok memnun kaldık.", Image = "testimonial9.jpg" },
                 new Testimonial {  Name = "Merve Çiçek", Title = "Muhteşem Manzara", Description = "Manzara nefes kesiciydi.", Image = "testimonial10.jpg" },
                 new Testimonial {  Name = "Kaan Deniz", Title = "Spa Keyfi", Description = "Spa hizmetleri çok rahatlatıcıydı.", Image = "testimonial11.jpg" },
                 new Testimonial {  Name = "Cemre Güneş", Title = "Lezzetli Yemekler", Description = "Restorandaki yemekler inanılmazdı.", Image = "testimonial12.jpg" },
                 new Testimonial {  Name = "Yasin Toprak", Title = "Eşsiz Deneyim", Description = "Doğayla iç içe bir tatil yaptık.", Image = "testimonial13.jpg" },
                 new Testimonial {  Name = "Sema Hayat", Title = "Keyifli Bir Tatil", Description = "Tüm çalışanlara teşekkür ederim.", Image = "testimonial14.jpg" },
                 new Testimonial {  Name = "Berk Umut", Title = "Huzur Verici", Description = "Sessiz ve huzurlu bir otel.", Image = "testimonial15.jpg" },
                 new Testimonial {  Name = "Didem Gözde", Title = "Hızlı Hizmet", Description = "Her şey hızlı ve pratikti.", Image = "testimonial16.jpg" },
                 new Testimonial {  Name = "Gökhan Ay", Title = "Memnuniyet Garantili", Description = "Herkese tavsiye ederim.", Image = "testimonial17.jpg" },
                 new Testimonial {  Name = "Neslihan Kurt", Title = "Güler Yüzlü Personel", Description = "Personel çok güleryüzlü ve ilgiliydi.", Image = "testimonial18.jpg" },
                 new Testimonial {  Name = "Orhan Tan", Title = "Eşsiz Güzellik", Description = "Bölge çok güzeldi, tekrar geleceğiz.", Image = "testimonial19.jpg" },
                 new Testimonial {  Name = "Cansu Aksoy", Title = "Rahatlık ve Konfor", Description = "Yataklar çok rahattı, uyku kalitem arttı.", Image = "testimonial20.jpg" },
                 new Testimonial {  Name = "Halil İbrahim", Title = "Harika Deneyim", Description = "Unutulmaz bir tatil oldu.", Image = "testimonial21.jpg" },
                 new Testimonial {  Name = "Buse Yıldız", Title = "Eşsiz Tatil", Description = "Her şey eksiksizdi, çok memnun kaldık.", Image = "testimonial22.jpg" },
                 new Testimonial {  Name = "Okan Çelik", Title = "Hizmet Kalitesi", Description = "Hizmet mükemmeldi, çalışanlara teşekkürler.", Image = "testimonial23.jpg" },
                 new Testimonial {  Name = "Dilan Karadağ", Title = "Aile Tatili", Description = "Ailemle huzurlu bir tatil geçirdim.", Image = "testimonial24.jpg" },
                 new Testimonial {  Name = "Bora Deniz", Title = "Harika Yemekler", Description = "Yemekler çok lezzetliydi, tekrar geleceğim.", Image = "testimonial25.jpg" },
                 new Testimonial {  Name = "Ceyda Güngör", Title = "Konforlu Odalar", Description = "Odalar çok temiz ve konforluydu.", Image = "testimonial26.jpg" },
                 new Testimonial {  Name = "Tamer Uzun", Title = "Eğlenceli Aktiviteler", Description = "Otel aktiviteleri çok eğlenceliydi.", Image = "testimonial27.jpg" },
                 new Testimonial {  Name = "Simge Akarsu", Title = "Güler Yüz", Description = "Tüm personel çok güleryüzlüydü.", Image = "testimonial28.jpg" },
                 new Testimonial {  Name = "Cenk Dağ", Title = "Sessiz ve Huzurlu", Description = "Dinlenmek için harika bir yer.", Image = "testimonial29.jpg" },
                 new Testimonial {  Name = "Mina Kaya", Title = "Temizlik ve Düzen", Description = "Her yer çok temiz ve düzenliydi.", Image = "testimonial30.jpg" },
                 new Testimonial {  Name = "Baran Efe", Title = "Manzara", Description = "Manzaraya bayıldık, unutulmazdı.", Image = "testimonial31.jpg" },
                 new Testimonial {  Name = "Ebru Şahin", Title = "Harika Kahvaltı", Description = "Kahvaltılar çok güzeldi.", Image = "testimonial32.jpg" },
                 new Testimonial {  Name = "Mert Yıldırım", Title = "Keyifli Tatil", Description = "Her şey için teşekkür ederiz.", Image = "testimonial33.jpg" },
                 new Testimonial {  Name = "Ceren Karaca", Title = "Çok Memnun Kaldım", Description = "Bu tatili unutamayacağım.", Image = "testimonial34.jpg" },
                 new Testimonial {  Name = "Efe Korkmaz", Title = "Doğa İle İç İçe", Description = "Doğayla iç içe bir tatildi.", Image = "testimonial35.jpg" },
                 new Testimonial {  Name = "Pelin Gümüş", Title = "İdeal Tatil", Description = "Herkese tavsiye ederim.", Image = "testimonial36.jpg" }
             }
             );
        }





    }
}

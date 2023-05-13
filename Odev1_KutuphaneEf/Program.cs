// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

public class Yazar
{
    public int Id { get; set; }
    public string YazarAdi { get; set; }
    public ICollection<Kitap> Kitaplar { get; set; }
}

public class YayinEvi
{ 
    public int Id { get; set; }
    public string YayinEviAdi { get; set; }
    public string Telefon { get; set; }
    public ICollection<Kitap> Kitaplar { get; set; }
}

public class Tur
{
    public int Id { get; set; }
    public string TurAdi { get; set; }
    public ICollection<Kitap> Kitaplar { get; set; }
}

public class Ogrenci
{
    public int Id { get; set; }
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public char Cinsiyet { get; set; }
    public string Sinif { get; set; }
    public DateTime DogumTarihi { get; set; }
    public string AktifMi { get; set; }
    public DateTime KayitTarihi { get; set; }
    public ICollection<Islem> Islemler { get; set; }
}

public class Kitap
{
    public int Id { get; set; }
    public string KitapAdi { get; set; }
    public int SayfaSayisi { get; set; }
    public bool SilindiMi { get; set; }
    public DateTime KayitTarihi { get; set; }
    public int YazarId { get; set; }
    public DateTime BasimTarihi { get; set; }
    public int YayınEviId { get; set; }
    public int TurId { get; set; }
    public string Dil { get; set; }
    public int KitapSayisi { get; set; }
    public string Cevirmen { get; set; }
    public ICollection<Yazar> Yazarlar { get; set; }
    public ICollection<YayinEvi> YayinEvleri { get; set; }
    public ICollection<Tur> Turler { get; set; }
    public ICollection<Islem> Islemler { get; set; }
}

public class Islem
{
    public int Id { get; set; }
    public int OgrenciId { get; set; }
    public int KitapId { get; set; }
    public DateTime OduncAldigiTarihi { get; set; }
    public bool IadeEdildiMi { get; set; }
    public ICollection<Ogrenci> Ogrenciler { get; set; }
    public ICollection<Kitap> Kitaplar { get; set; }
}


public class Context : DbContext
{
    public DbSet<Ogrenci> Ogrenciler { get; set; }
    public DbSet<Islem> Islemler { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Tur> Turler { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<YayinEvi> YayinEvleri { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=ASUS;Database=EfOdevKutuphane;Integrated Security=true");
    }
}
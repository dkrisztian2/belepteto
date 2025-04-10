using belepteto;

var esemenyKezelo = new EsemenyKezelo();
esemenyKezelo.LoadFromData("bedat.txt");

Console.WriteLine("2. feladat");
Console.WriteLine($"Az első tanuló {esemenyKezelo.Elso.IdpontTime}-kor lépett be a főkapun.");
Console.WriteLine($"Az utolsó tanuló {esemenyKezelo.Utolso.IdpontTime}-kor lépett ki a főkapun.");

esemenyKezelo.KesokListaja("kesok.txt");

Console.WriteLine("4. feladat");
Console.WriteLine($"A menzán aznap {esemenyKezelo.EbedelokSzama} tanúló ebédelt.");

Console.WriteLine("5. feladat");
Console.WriteLine($"Aznap {esemenyKezelo.KolcsonzokSzama} tanuló kölcsönzött a könyvtárban.");
Console.WriteLine(esemenyKezelo.KolcsonzokSzama > esemenyKezelo.EbedelokSzama ? "Többen voltak, mint a menzán." : "Nem voltak többen, mint a menzán.");

Console.WriteLine("6. feladat");
Console.WriteLine("Az érintett tanulók:");
esemenyKezelo.Logok().ForEach(x => Console.Write($"{x} "));

Console.WriteLine("7. feladat");
Console.Write("Egy tanuló azonosítója=");
var input = Console.ReadLine();
if (esemenyKezelo.TartozkodasiIdo(input)[0] == 'I')
{
    Console.WriteLine(esemenyKezelo.TartozkodasiIdo(input));
}
else
{
    Console.WriteLine($"A tanuló érkezése és távozása között {esemenyKezelo.TartozkodasiIdo(input)} telt el");
}
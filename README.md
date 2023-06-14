# SezarCrpted

Sezar şifreleme algoritması, alfabetik düzenin basitçe kaydırılmasından ibaret. Alfabetik düzenin ne kadar kaydırılacağı en baştan belirleniyor. Yani, baştan bir anahtar sayı belirlemek gerekiyor. 

Anahtar sayımız 3 olsun diyelim. Yazılan harften 3 sonraki harf bizim şifrelenmiş harfimiz oluyor. Örneğin B harfinden 3 sonraki harf E harfi (B–C–D–E). Şifreli metinde B yerine E yazacağız. Alfabe bittiğinde ne yapacağım diye sorabilirsiniz. Cevabı basit. Alfabenin başına döneceksiniz. Z harfine 3 eklediğimde (Z–A–B–C), C harfine ulaşıyorum.

1. 1 adet şifreleme, 1 adet şifre çözme olmak üzere aynı controller içerisinde 2 adet Post methodlu API oluşturulmalıdır.
2. Şifreleme => parametre olarak bir string almalı ve bunu şifreleyerek response döndürmelidir. (Anahtar sayı alınmamalıdır)
3. Şifre çözme => parametre olarak şifrelenmiş bir string almalı ve bu şifreyi çözerek response döndürmelidir. (Anahtar sayı alınmamalıdır)
4. Anahtar sayı “appsettings.Development.json” içerisinde tanımlanmalıdır ve controller’dan erişilmelidir.

[HttpPost]
public async Task<IActionResult> Encrypt(string text)
{
    // kod…..

    return Ok(encryptedText);
}

[HttpPost]
public async Task<IActionResult> Decrypt(string encryptedText)
{
    // kod…..

    return Ok(text);
}

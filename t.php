<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>RC2 Şifreleme/Çözme</title>
</head>
<body>
    <h2>RC2 Şifreleme/Çözme</h2>
    <form method="post">
        <label for="inputMetin">Metin Girin:</label><br>
        <input type="text" id="inputMetin" name="inputMetin" value=""><br><br>
        <input type="submit" value="Şifrele/Çöz">
    </form>

    <?php
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        if (!empty($_POST["inputMetin"])) {
            $inputMetin = $_POST["inputMetin"];

            // RC2 Şifreleme Fonksiyonu
            function rc2_sifrele($strGiris) {
                $key = "12341234"; // Key 8 bayt olmalı
                $iv = "12341234";   // IV de 8 bayt olmalı
                $strGiris = pkcs5_pad($strGiris); // PKCS5 padding

                $encrypted = openssl_encrypt($strGiris, 'rc2-cbc', $key, OPENSSL_RAW_DATA, $iv);
                return base64_encode($encrypted);
            }

            // RC2 Çözme Fonksiyonu
            function rc2_coz($strGiris) {
                $key = "12341234"; // Key 8 bayt olmalı
                $iv = "12341234";   // IV de 8 bayt olmalı

                $decrypted = openssl_decrypt(base64_decode($strGiris), 'rc2-cbc', $key, OPENSSL_RAW_DATA, $iv);
                return pkcs5_unpad($decrypted);
            }

            // PKCS5 padding fonksiyonları
            function pkcs5_pad($text) {
                $blocksize = 8;
                $pad = $blocksize - (strlen($text) % $blocksize);
                return $text . str_repeat(chr($pad), $pad);
            }

            function pkcs5_unpad($text) {
                $pad = ord($text[strlen($text)-1]);
                return substr($text, 0, -$pad);
            }

            // Şifreleme veya Çözme işlemi
            $sifreliMetin = rc2_sifrele($inputMetin);
            echo "<p>Şifrelenmiş metin: $sifreliMetin</p>";

            $cozulmusMetin = rc2_coz($sifreliMetin);
            echo "<p>Çözülmüş metin: $cozulmusMetin</p>";
        } else {
            echo "<p>Lütfen bir metin girin.</p>";
        }
    }
    ?>
</body>
</html>

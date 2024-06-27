<?php

function rc2_sifrele($str_giris) {
    $key = "12341234";  // Key 8 bytes
    $iv = "12341234";   // IV 8 bytes
    $str_giris = pkcs5_pad($str_giris);  // PKCS5 padding
    $encrypted = openssl_encrypt($str_giris, 'rc2-cbc', $key, OPENSSL_RAW_DATA | OPENSSL_ZERO_PADDING, $iv);
    return base64_encode($encrypted);
}

function rc2_coz($str_giris) {
    $key = "12341234";
    $iv = "12341234";
    $str_giris = base64_decode($str_giris);
    $decrypted = openssl_decrypt($str_giris, 'rc2-cbc', $key, OPENSSL_RAW_DATA | OPENSSL_ZERO_PADDING, $iv);
    return pkcs5_unpad($decrypted);  // Remove padding
}

function pkcs5_pad($data) {
    $block_size = 8;
    $pad = $block_size - (strlen($data) % $block_size);
    return $data . str_repeat(chr($pad), $pad);
}

function pkcs5_unpad($data) {
    $pad = ord($data[strlen($data) - 1]);
    return substr($data, 0, -1 * $pad);
}

// Handle form submission
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    if (isset($_POST["encrypt"])) {
        $input_text = $_POST["input_text"];
        $encrypted_text = rc2_sifrele($input_text);
    } elseif (isset($_POST["decrypt"])) {
        $input_text = $_POST["input_text"];
        $decrypted_text = rc2_coz($input_text);
    }
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>RC2 Encryption Demo</title>
</head>
<body>
    <h2>RC2 Encryption and Decryption</h2>
    <form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
        <label for="input_text">Input Text:</label><br>
        <input type="text" id="input_text" name="input_text" value="<?php echo isset($input_text) ? htmlspecialchars($input_text) : ''; ?>"><br><br>
        <input type="submit" name="encrypt" value="Encrypt">
        <input type="submit" name="decrypt" value="Decrypt"><br><br>

        <?php if (isset($encrypted_text)): ?>
            <label for="encrypted_text">Encrypted Text:</label><br>
            <textarea id="encrypted_text" name="encrypted_text" rows="5" cols="40"><?php echo htmlspecialchars($encrypted_text); ?></textarea><br><br>
        <?php endif; ?>

        <?php if (isset($decrypted_text)): ?>
            <label for="decrypted_text">Decrypted Text:</label><br>
            <textarea id="decrypted_text" name="decrypted_text" rows="5" cols="40"><?php echo htmlspecialchars($decrypted_text); ?></textarea><br><br>
        <?php endif; ?>
    </form>
</body>
</html>

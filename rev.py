from Crypto.Cipher import RC2
import base64

def byte8(veri):
    return bytearray(veri, 'utf-8')

def rc2_sifrele(str_giris):
    ary_key = byte8("12341234")  # Key 8 bayt olmalı
    ary_iv = byte8("12341234")   # IV de 8 bayt olmalı
    cipher = RC2.new(ary_key, RC2.MODE_CBC, ary_iv)
    pad_len = 8 - len(str_giris) % 8
    str_giris += chr(pad_len) * pad_len  # PKCS5 padding
    encrypted = cipher.encrypt(byte8(str_giris))
    return base64.b64encode(encrypted).decode('utf-8')

def rc2_coz(str_giris):
    ary_key = byte8("12341234")
    ary_iv = byte8("12341234")
    cipher = RC2.new(ary_key, RC2.MODE_CBC, ary_iv)
    encrypted = base64.b64decode(str_giris)
    decrypted = cipher.decrypt(encrypted)
    pad_len = decrypted[-1]
    return decrypted[:-pad_len].decode('utf-8')

def main():
    orijinal_metin = "1"
    sifreli_metin = rc2_sifrele(orijinal_metin)
    print("Şifrelenmiş metin: " + sifreli_metin)

    cozulmus_metin = rc2_coz(sifreli_metin)
    print("Çözülmüş metin: " + cozulmus_metin)

if __name__ == "__main__":
    main()

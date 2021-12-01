Imports System.IO
Imports System.Security.Cryptography


'Aes암호화 클래스
Public Class AesEncrypt
	Public Shared Function EncryptStringToBytes_Aes(ByVal plainText As String, ByVal Key As Byte(), ByVal IV As Byte()) As Byte()

		If plainText Is Nothing OrElse plainText.Length <= 0 Then
			Throw New ArgumentException("Wrong plainText")
		End If

		Dim Encrypted As Byte()

		Using aesTemp As Aes = Aes.Create()
			aesTemp.Key = Key
			aesTemp.IV = IV

			'암호화 변형 스트림
			Dim encryptor As ICryptoTransform = aesTemp.CreateEncryptor(aesTemp.Key, aesTemp.IV)
			' Create the streams used for encryption. 암호화를 위한 스트림
			Using msEncrypt As New MemoryStream()
				Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
					Using swEncrypt As New StreamWriter(csEncrypt)
						'스트림라이터로 CryptoStream에 쓴다
						swEncrypt.Write(plainText)
					End Using
					Encrypted = msEncrypt.ToArray()
				End Using
			End Using
		End Using

		Return Encrypted

	End Function
	Public Shared Function DecryptStringFromBytes_Aes(ByVal cipherText As Byte(), ByVal Key() As Byte, ByVal IV() As Byte) As String

		If cipherText Is Nothing OrElse cipherText.Length <= 0 Then
			Throw New ArgumentException("Wrong cipherText")
		End If

		'암호화 해제한 스트링 저장
		Dim plaintext As String = Nothing

		' Create an Aes object
		' with the specified key and IV.
		Using aesAlg As Aes = Aes.Create()
			aesAlg.Key = Key
			aesAlg.IV = IV

			'복호화 변형 스트림
			Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

			' Create the streams used for decryption.
			Using msDecrypt As New MemoryStream(cipherText)

				Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)

					Using srDecrypt As New StreamReader(csDecrypt)
						'스트림에서 모두 읽어서 String에 넣음
						plaintext = srDecrypt.ReadToEnd()
					End Using
				End Using
			End Using
		End Using

		Return plaintext
	End Function
End Class

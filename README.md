# PDF Encryption and Decryption Using DES Algorithm

## Project Overview

This project implements a **Data Encryption Standard (DES)** algorithm to encrypt and decrypt PDF files. The encrypted PDF is then represented as a **Base64 encoded string** to ensure that the binary data is safely displayed or transmitted as text. The user can select a PDF file, enter a secret key, and choose whether to encrypt or decrypt the file.

## Features

- **Encrypt PDF Files**: Encrypts a PDF file using the DES algorithm and represents the encrypted data as a Base64 string.
- **Decrypt PDF Files**: Decrypts a Base64 encoded PDF file using the DES algorithm to restore it to its original form.
- **Base64 Encoding**: The encrypted data is represented in Base64 encoding, ensuring that all characters are valid for display and storage.
- **GUI Interface**: A simple Windows Forms interface to allow users to interact with the application easily.

## Requirements

- **.NET Framework**: Version 4.7 or higher
- **C# Development Environment**: Visual Studio or any compatible IDE
- **Operating System**: Windows (any version that supports .NET Framework)

## How to Run the Project

1. **Clone/Download** the project to your local machine.
2. Open the project in **Visual Studio** or your preferred C# IDE.
3. Build the project by pressing `F7` or selecting **Build Solution** from the **Build** menu.
4. Run the project by pressing `Ctrl + F5` or selecting **Start Without Debugging** from the **Debug** menu.
5. The application will launch with a user interface where you can:
   - Select a PDF file to encrypt or decrypt.
   - Enter a **64-bit secret key** for the encryption/decryption process.
   - Choose whether to **encrypt** or **decrypt** the file.
6. The **encrypted** file will be saved in Base64 encoded format, and the **decrypted** file will be restored to its original format.

## How It Works

1. **Encryption**:
   - The application reads the selected PDF file.
   - The DES algorithm is applied to the file's content using the provided secret key.
   - The encrypted data is then Base64 encoded.
   - The Base64 encoded string can be displayed or saved as a new file.
   
2. **Decryption**:
   - The Base64 encoded string (encrypted data) is decoded back to its original binary form.
   - The DES algorithm is applied to the decoded data using the provided secret key to decrypt it.
   - The decrypted file is saved as a new PDF.

## Example

### Encryption

- **PDF File**: `document.pdf`
- **Key**: `1234567890ABCDEF`
- **Encrypted Data** (Base64 string): `...Base64String...`
- **Saved Encrypted File**: `encrypted.pdf`

### Decryption

- **Encrypted File**: `encrypted.pdf`
- **Key**: `1234567890ABCDEF`
- **Decrypted File**: `document.pdf`

## Project Structure

- `Form1.cs`: Main form containing the user interface and logic for encryption and decryption.
- `DES.cs`: Contains the core implementation of the DES encryption and decryption logic.
- `Program.cs`: Entry point for the application.

## Acknowledgments

- This project was developed for the **Information Security** course as part of the semester assignment.
- The DES algorithm and Base64 encoding were referenced from various cryptography and programming resources.

---

Feel free to modify it based on your project specifics!

# DES Algorithm Implementation in C#

This project provides a C# implementation of the Data Encryption Standard (DES) algorithm. It includes functionalities for encrypting and decrypting text, particularly within PDF files, offering a practical application of this classic symmetric-key block cipher.

## Features

*   **DES Encryption:** Implements the core DES algorithm for encrypting data.
*   **DES Decryption:** Implements the core DES algorithm for decrypting data.
*   **PDF Integration:** Reads text from PDF files using the iText7 library.
*   **User Interface:** Provides a Windows Forms application for easy interaction.
*   **Key Generation:** Generates 16 subkeys from the provided key using the DES key schedule.
*   **Base64 Encoding/Decoding:** Encodes the ciphertext to Base64 for easier storage and transmission.
*   **Input Validation:** Validates the key input to ensure it meets the DES requirements.
*   **Error Handling:** Provides user feedback through message boxes for various scenarios.

## Technologies Used

*   **Programming Language:** C#
*   **Framework:** .NET Framework (Windows Forms)
*   **Libraries:**
    *   iText7: For PDF manipulation (text extraction and creation).
    *   System.Configuration: For application settings.
    *   System.Windows.Forms: For creating the graphical user interface.

## Installation

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/zohaibsaeed117/DES_Algorithm_Implementation.git
    ```

2.  **Open the project in Visual Studio:**

    Navigate to the cloned directory and open the `DES.sln` solution file in Visual Studio.

3.  **Restore NuGet Packages:**

    Visual Studio should automatically restore the required NuGet packages (iText7). If not, manually restore them by right-clicking on the solution in the Solution Explorer and selecting "Restore NuGet Packages."

4.  **Build the project:**

    Build the project by selecting "Build" -> "Build Solution" from the Visual Studio menu.

## Usage

1.  **Run the application:**

    After building the project, run the executable file located in the `bin/Debug` or `bin/Release` directory.

2.  **Upload a PDF file:**

    Click the "Upload File" button to select a PDF file from which to extract text.

3.  **Enter a key:**

    Enter a valid 8-character (64-bit) key in the "Key" textbox.

4.  **Select encryption or decryption:**

    Choose either the "Encrypt" or "Decrypt" radio button.

5.  **Perform the action:**

    Click the "Action" button to encrypt or decrypt the text extracted from the PDF file.

6.  **Output PDF:**

    A new PDF file containing the encrypted or decrypted text will be created in the same directory as the original PDF file.

Example C# code snippet for using the DES class:

```csharp
// Example usage within Form1.cs (simplified)
string key = key_input.Text; // Get key from textbox
string extractedText = ExtractTextFromPdf(filePath); // Extract text from PDF

DES des = new DES();
string encryptedText = des.Encrypt(extractedText, key); // Encrypt the text
string decryptedText = des.Decrypt(encryptedText, key); // Decrypt the text

CreatePdf(encryptedText, "encrypted_output.pdf"); // Create a PDF with encrypted text
CreatePdf(decryptedText, "decrypted_output.pdf"); // Create a PDF with decrypted text
```

## Project Structure

The project directory structure is as follows:

```
DES_Algorithm_Implementation/
├── DES/
│   ├── DES.csproj
│   ├── Program.cs
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── DES.cs
│   ├── Properties/
│   │   ├── AssemblyInfo.cs
│   │   ├── Resources.resx
│   │   ├── Resources.Designer.cs
│   │   ├── Settings.settings
│   │   ├── Settings.Designer.cs
├── DES.sln
├── README.md
```

*   **DES.csproj:** The C# project file.
*   **Program.cs:** The entry point of the application.
*   **Form1.cs:** The main form of the application, handling user interaction and PDF processing.
*   **Form1.Designer.cs:** The designer file for `Form1.cs`, defining the UI layout.
*   **DES.cs:** Contains the implementation of the DES algorithm, including key generation, encryption, and decryption functions.
*   **Properties/:** Contains application settings, resources, and assembly information.
    *   **AssemblyInfo.cs:** Contains assembly metadata.
    *   **Resources.resx/Resources.Designer.cs:** Manages embedded resources.
    *   **Settings.settings/Settings.Designer.cs:** Manages application settings.
*   **DES.sln:** The solution file for Visual Studio.
*   **README.md:** This file, providing information about the project.

## Contributing

Contributions are welcome! Please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and commit them with clear, concise messages.
4.  Submit a pull request to the main branch.

Please ensure your code adheres to the existing coding style and includes appropriate unit tests.

## License

This project is licensed under the [MIT License](LICENSE). See the `LICENSE` file for details.

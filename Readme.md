================================================================================
                           SECURE FILE VAULT - USER MANUAL
================================================================================

[1] PREREQUISITES & INSTALLATION
--------------------------------------------------------------------------------
* Need .NET Framework 4.7.2 Runtime Installer
  Link: https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-offline-installer
* Install the runtime, then RESTART your computer.


[2] SYSTEM REQUIREMENTS
--------------------------------------------------------------------------------
* Operating System : Windows 10 / 11 (64-bit recommended)
* .NET Framework   : Version 4.7.2 or higher
* Storage          : At least 50 MB free space
* RAM              : Minimum 512 MB


[3] GETTING STARTED
--------------------------------------------------------------------------------
Step 1: Launch the Application
        * Double-click 'SecureFileVault.exe'
        * Main Menu will appear with two options: UPLOADER and VIEWER
        * Click 'UPLOADER'


[4] FIRST TIME SETUP
--------------------------------------------------------------------------------
Step 2: Login to Uploader (First Time Only)
        * A login screen will appear with the following fields:
          - Password: [text box]
          - [CREATE & LOGIN] button
          - [CANCEL] button
        
        * Instructions:
          1. Enter a password (at least 6 characters)
          2. Click [CREATE & LOGIN]
          
        !!! IMPORTANT !!!
        Save this password immediately. THERE IS NO RECOVERY AVAILABLE.


[5] CREATE OR OPEN A VAULT
--------------------------------------------------------------------------------
After successful login, the Uploader Form will display:
* Section 1: VAULT LOCATION
  - [OPEN VAULT] button
  - [CREATE NEW] button
  - Vault path display: "No vault selected"

--- OPTION A: Create New Vault (Recommended) ---
Step 1: Click [CREATE NEW] button.
Step 2: A 'Save File' dialog window will appear.
Step 3: Choose a destination folder (Desktop, Documents, USB Drive, etc.).
Step 4: Enter a file name (Example: my_vault.dat).
Step 5: Click [Save].
Step 6: Click [OK] on the confirmation message.

--- OPTION B: Open Existing Vault ---
Step 1: Click [OPEN VAULT] button.
Step 2: Navigate to your existing '.dat' file.
Step 3: Select the file and click [Open].


[6] UNLOCK THE VAULT
--------------------------------------------------------------------------------
* Section 2: VAULT ACCESS
  - Fields: Master Password [text box] | [UNLOCK] button

* Instructions:
  1. Enter a strong master password.
     (This password encrypts ALL files inside this specific vault)
  2. Click [UNLOCK].

!!! CRITICAL WARNINGS !!!
* All files in this vault use the SAME password.
* No password recovery - lost password = lost data permanently.
* During preview, 3 wrong password attempts will Automatically DELETE the file.


[7] UPLOAD FILES
--------------------------------------------------------------------------------
After successfully unlocking the vault:
Step 1: Click [UPLOAD] button.
Step 2: A file dialog window will appear.
Step 3: Navigate to the file you want to secure.
Step 4: Select the file (Supported formats: JPG, JPEG, PNG, PDF).
Step 5: Click [Open].

* Success Message will display:
  - Upload successful
  - Source file location
  - Destination vault location
  - Encryption method: AES-256

* The uploaded file will appear in the list showing:
  - File name (original name preserved)
  - File size (B, KB, MB, GB)


[8] DELETE FILES (Optional)
--------------------------------------------------------------------------------
Step 1: Select the file you want to remove from the list.
Step 2: Click [DELETE] button.
Step 3: A confirmation dialog will appear.
Step 4: Click [Yes] to confirm.

Note: Deleted files cannot be recovered under any circumstances.


[9] LOCK THE VAULT
--------------------------------------------------------------------------------
Step 1: Click [LOCK] button.
Step 2: A confirmation dialog will appear.
Step 3: Click [Yes].

Result: You will return to the login screen. The vault remains securely 
        encrypted on your disk.
================================================================================
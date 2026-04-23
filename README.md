# VREM - Variable Rotor Encryption Machine
VREM is an encryption algorithm based on [rotor machines](https://en.wikipedia.org/wiki/Rotor_machine) that dynamically changes the number of rotors based on the length of the key.

IMPORTANT: Read the [security considerations](#security-considerations) at the bottom of this document before using this software.
## Description
VREM works on a byte-by-byte basis, independent of the file's own encoding. As such, VREM's substitution map has a period of 256^L, where L is the length of the key.

VREM uses a reflector layer (dynamically generated based on the key) after the virtual rotors, which makes the machine self-reciprocal, thus allowing for encryption and decryption via the same algorithm, without any need to change mode.
By itself, this mechanism introduces a weakness to cryptanalysis as no character can ever be encrypted into itself. To address this issue, VREM uses an additional mechanism called selfcrypt. In every block of 256 bytes processed by the algorythm, one byte is guaranteed to be encrypted into itself. The exact position of this byte however is calculated based on the key, and since the key has arbitrary length there are infinite keys which produce the same selfcrypt index, thus making it impossible to extract the key in the event that the index was found. Additionally, the selfcrypt index is updated once every time the machine completes a full rotation of its substitution map, but the updated value is not necessarily different from the previous one.
## Usage
`vrem <path>`

Prompts the user for a key, then the contents of the file specified by path — if valid — will be truncated and overwritten with the file's bytes processed via the algorithm using said key.

`vrem <key> <path>`

The contents of the file specified by path — if valid — will be truncated and overwritten with the file's bytes processed via the algorithm using the given key.
## Installation
### Windows
- Download the executable from the latest release and save it to any directory.
- Use the program by opening a terminal/powershell window in that directory and calling `.\vrem.exe` or by specifying the full path to the executable from any other directory.
- To add `vrem` as a recognized command, add an entry to the Path environment variable pointing to the directory where the executable is.

## Security Considerations
I am not a cybersecurity expert. This program was created mostly as a personal project for fun and personal use, based on the knowledge I had from some introductory cybersec classes taken in university, as well as some independent research.
The code has not been reviewed (for now) by any expert in the field and is provided with no guarantees. If you see any issues with it and want to let me know you are more than welcome to, I will likely try to address them, but this is ultimately still just a personal project.
